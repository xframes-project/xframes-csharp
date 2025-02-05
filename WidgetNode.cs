﻿using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text.Json;
using System.Text.Json.Serialization;

public interface IRenderable
{}

public abstract class BaseComponent : IRenderable
{
    public BehaviorSubject<Dictionary<string, object>> props { get; }

    protected BaseComponent()
    {
        this.props = new BehaviorSubject<Dictionary<string, object>>(new Dictionary<string, object>{});
    }

    protected BaseComponent(Dictionary<string, object> props)
    {
        this.props = new BehaviorSubject<Dictionary<string, object>>(props);
    }

    public abstract IRenderable Render();
}

public class WidgetNode : IRenderable
{
    public WidgetTypes type { get; }
    public BehaviorSubject<Dictionary<string, object>> props { get; }
    public BehaviorSubject<List<IRenderable>> children { get; } // "Renderable" approximation

    public WidgetNode(WidgetTypes widgetType, Dictionary<string, object> props, List<IRenderable> children)
    {
        this.type = widgetType;
        this.props = new BehaviorSubject<Dictionary<string, object>>(props);
        this.children = new BehaviorSubject<List<IRenderable>>(children);
    }
}

public class RawChildlessWidgetNodeWithId
{
    public RawChildlessWidgetNodeWithId(int id, WidgetTypes type, Dictionary<string, object> props)
    {
        this.id = id;
        this.type = type;
        this.props = props;
    }

    public int id { get; set; }
    public WidgetTypes type { get; set; }
    public Dictionary<string, object> props { get; set; }
}

public static class WidgetNodeFactory
{
    public static WidgetNode WidgetNode(WidgetTypes widgetType, Dictionary<string, object> props, List<IRenderable> children)
    {
        return new WidgetNode(widgetType, props, children);
    }

    public static RawChildlessWidgetNodeWithId RawChildlessWidgetNodeWithId(int id, WidgetNode node)
    {
        return new RawChildlessWidgetNodeWithId(id, node.type, node.props.Value);
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

    public static WidgetNode RootNode(List<IRenderable> children, object? style = null)
    {
        var props = InitPropsWithStyle(style);
        props["root"] = true;
        return WidgetNode(WidgetTypes.Node, props, children);
    }

    public static WidgetNode Node(List<IRenderable> children, object? style = null)
    {
        var props = InitPropsWithStyle(style);
        props["root"] = false;
        return WidgetNode(WidgetTypes.Node, props, children);
    }

    public static WidgetNode UnformattedText(string text, object? style = null)
    {
        var props = InitPropsWithStyle(style);
        props["text"] = text;
        return WidgetNode(WidgetTypes.UnformattedText, props, new List<IRenderable>());
    }

    public static WidgetNode Button(string label, Action? onClick = null, object? style = null)
    {
        var props = InitPropsWithStyle(style);
        props["label"] = label;
        if (onClick != null)
            props["on_click"] = onClick; // Not serializable, just stored

        return WidgetNode(WidgetTypes.Button, props, new List<IRenderable>());
    }
}


