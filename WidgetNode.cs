using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text.Json;
using System.Text.Json.Serialization;

public abstract class BaseComponent
{
    public BehaviorSubject<Dictionary<string, object>> Props { get; }

    protected BaseComponent(Dictionary<string, object> props)
    {
        Props = new BehaviorSubject<Dictionary<string, object>>(props);
    }

    public abstract object Render();
}

public class WidgetNode
{
    public WidgetTypes Type { get; }
    public BehaviorSubject<Dictionary<string, object>> Props { get; }
    public BehaviorSubject<List<object>> Children { get; } // "Renderable" approximation

    public WidgetNode(WidgetTypes type, Dictionary<string, object> props, List<object> children)
    {
        Type = type;
        Props = new BehaviorSubject<Dictionary<string, object>>(props);
        Children = new BehaviorSubject<List<object>>(children);
    }
}

public class RawChildlessWidgetNodeWithId
{
    public int Id { get; }
    public WidgetTypes Type { get; }
    public Dictionary<string, object> Props { get; }

    public RawChildlessWidgetNodeWithId(int id, WidgetTypes type, Dictionary<string, object> props)
    {
        Id = id;
        Type = type;
        Props = props;
    }

    public Dictionary<string, object> ToSerializableDict()
    {
        var output = new Dictionary<string, object>
        {
            { "id", Id },
            { "type", Type }
        };

        foreach (var kvp in Props)
        {
            if (kvp.Value is not Delegate)
                output[kvp.Key] = kvp.Value;
        }

        return output;
    }

}

public static class WidgetFactory
{
    public static WidgetNode CreateWidgetNode(WidgetTypes widgetType, Dictionary<string, object> props, List<object> children)
    {
        return new WidgetNode(widgetType, props, children);
    }

    public static RawChildlessWidgetNodeWithId CreateRawChildlessWidgetNodeWithId(int id, WidgetNode node)
    {
        return new RawChildlessWidgetNodeWithId(id, node.Type, node.Props.Value);
    }

    private static Dictionary<string, object> InitPropsWithStyle(object? style)
    {
        var props = new Dictionary<string, object>();

        if (style != null)
        {
            var type = style.GetType();
            if (type.GetProperty("Style")?.GetValue(style) is object styleDef)
                props["style"] = styleDef;
            if (type.GetProperty("ActiveStyle")?.GetValue(style) is object activeStyle)
                props["activeStyle"] = activeStyle;
            if (type.GetProperty("HoverStyle")?.GetValue(style) is object hoverStyle)
                props["hoverStyle"] = hoverStyle;
            if (type.GetProperty("DisabledStyle")?.GetValue(style) is object disabledStyle)
                props["disabledStyle"] = disabledStyle;
        }

        return props;
    }

    public static WidgetNode RootNode(List<object> children, object? style = null)
    {
        var props = InitPropsWithStyle(style);
        props["root"] = true;
        return CreateWidgetNode(WidgetTypes.Node, props, children);
    }

    public static WidgetNode Node(List<object> children, object? style = null)
    {
        var props = InitPropsWithStyle(style);
        props["root"] = false;
        return CreateWidgetNode(WidgetTypes.Node, props, children);
    }

    public static WidgetNode UnformattedText(string text, object? style = null)
    {
        var props = InitPropsWithStyle(style);
        props["text"] = text;
        return CreateWidgetNode(WidgetTypes.UnformattedText, props, new List<object>());
    }

    public static WidgetNode Button(string label, Action? onClick = null, object? style = null)
    {
        var props = InitPropsWithStyle(style);
        props["label"] = label;
        if (onClick != null)
            props["on_click"] = onClick; // Not serializable, just stored

        return CreateWidgetNode(WidgetTypes.Button, props, new List<object>());
    }
}

public class RawChildlessWidgetNodeWithIdEncoder : JsonConverter<RawChildlessWidgetNodeWithId>
{
    public override RawChildlessWidgetNodeWithId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization not needed.");
    }

    public override void Write(Utf8JsonWriter writer, RawChildlessWidgetNodeWithId value, JsonSerializerOptions options)
    {
        var dict = value.ToSerializableDict();
        JsonSerializer.Serialize(writer, dict, options);
    }
}
