using System.Reactive.Linq;

public class ShadowNode
{
    public int id { get; set; }
    public IRenderable renderable { get; set; }
    public Dictionary<string, object> currentProps { get; set; }
    public List<ShadowNode> children { get; set; }
    public IDisposable propsChangeSubscription { get; set; }
    public IDisposable childrenChangeSubscription { get; set; }

    public List<ShadowNode> GetLinkableChildren()
    {
        var outList = new List<ShadowNode>();

        foreach (var child in children)
        {
            if (child != null && child.renderable != null)
            {
                if (child.renderable is WidgetNode)
                {
                    outList.Add(child);
                }
                else if (child.children.Count > 0)
                {
                    outList.AddRange(child.GetLinkableChildren());
                }
            }
        }

        return outList;
    }
}

public class ShadowNodeTraversalHelper
{
    private readonly WidgetRegistrationService _widgetRegistrationService;

    public ShadowNodeTraversalHelper(WidgetRegistrationService widgetRegistrationService)
    {
        _widgetRegistrationService = widgetRegistrationService;
    }

    public bool ArePropsEqual(Dictionary<string, object> props1, Dictionary<string, object> props2)
    {
        if (props1.Count != props2.Count)
        {
            return false;
        }

        foreach (var kvp in props1)
        {
            if (!props2.TryGetValue(kvp.Key, out var value) || !Equals(kvp.Value, value))
                return false;
        }
        return true;
    }

    public void SubscribeToPropsHelper(ShadowNode shadowNode)
    {
        shadowNode.propsChangeSubscription?.Dispose();

        if (shadowNode.renderable is BaseComponent component)
        {
            shadowNode.propsChangeSubscription = component.props.Skip(1).Subscribe(newProps => HandleComponentPropsChange(shadowNode, component, newProps));
        }
        else if (shadowNode.renderable is WidgetNode widgetNode)
        {
            shadowNode.propsChangeSubscription = widgetNode.props.Skip(1).Subscribe(newProps => HandleWidgetNodePropsChange(shadowNode, widgetNode, newProps));
        }
    }

    public void HandleWidgetNode(RawChildlessWidgetNodeWithId widget)
    {
        if (widget.type == WidgetTypes.Button)
        {
            if (widget.props.TryGetValue("on_click", out var onClick) && onClick is Action action)
            {
                _widgetRegistrationService.RegisterOnClick(widget.id, action);
            }
        }
    }

    public void HandleComponentPropsChange(ShadowNode shadowNode, BaseComponent component, Dictionary<string, object> newProps)
    {
        if (ArePropsEqual(shadowNode.currentProps, newProps))
        {
            return;
        }

        var shadowChild = TraverseTree(component.Render());
        shadowNode.children = new List<ShadowNode> { shadowChild };
        shadowNode.currentProps = newProps;

        var linkableChildren = shadowNode.GetLinkableChildren();
        _widgetRegistrationService.LinkChildren(shadowNode.id, linkableChildren.Select(child => child.id).ToList());
    }

    public void HandleWidgetNodePropsChange(ShadowNode shadowNode, WidgetNode widgetNode, Dictionary<string, object> newProps)
    {
        _widgetRegistrationService.CreateWidget(WidgetNodeFactory.RawChildlessWidgetNodeWithId(shadowNode.id, widgetNode));

        var shadowChildren = widgetNode.children.Value.Select(child => TraverseTree(child)).ToList();
        shadowNode.children = shadowChildren;
        shadowNode.currentProps = newProps;

        _widgetRegistrationService.LinkChildren(shadowNode.id, shadowNode.children.Select(child => child.id).ToList());
    }

    public ShadowNode TraverseTree(IRenderable renderable)
    {
        if (renderable is BaseComponent component)
        {
            var shadowChild = TraverseTree(component.Render());

            var id = _widgetRegistrationService.GetNextComponentId();
            var shadowNode = new ShadowNode
            {
                id = id,
                renderable = renderable,
                children = new List<ShadowNode> { shadowChild },
                currentProps = component.props.Value // Fix: Changed 'Props' to 'props'
            };

            SubscribeToPropsHelper(shadowNode);
            return shadowNode;
        }
        else if (renderable is WidgetNode widgetNode)
        {
            var id = _widgetRegistrationService.GetNextWidgetId();
            var rawNode = WidgetNodeFactory.RawChildlessWidgetNodeWithId(id, widgetNode);

            HandleWidgetNode(rawNode);
            _widgetRegistrationService.CreateWidget(rawNode);

            var shadowNode = new ShadowNode
            {
                id = id,
                renderable = renderable,
                children = widgetNode.children.Value.Select(TraverseTree).ToList(),
                currentProps = widgetNode.props.Value
            };

            var linkableChildren = shadowNode.GetLinkableChildren();
            if (linkableChildren.Count > 0)
            {
                _widgetRegistrationService.LinkChildren(id, linkableChildren.Select(child => child.id).ToList());
            }

            SubscribeToPropsHelper(shadowNode);
            return shadowNode;
        }
        else
        {
            throw new Exception("Unrecognized renderable");
        }
    }
}