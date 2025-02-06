using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class WidgetRegistrationService
{
    private readonly object idGeneratorLock = new object();
    private readonly object idWidgetRegistrationLock = new object();
    private readonly object idEventRegistrationLock = new object();

    private readonly ReplaySubject<Action> eventsSubject = new ReplaySubject<Action>(10);
    private readonly BehaviorSubject<Dictionary<int, Action>> onClickRegistry = new BehaviorSubject<Dictionary<int, Action>>(new Dictionary<int, Action>());

    private readonly Dictionary<int, object> widgetRegistry = new Dictionary<int, object>();

    private int lastWidgetId = 0;
    private int lastComponentId = 0;

    public WidgetRegistrationService()
    {
        eventsSubject
            .Throttle(TimeSpan.FromMilliseconds(1))
            .Subscribe(fn => fn());
    }

    public object GetWidgetById(int widgetId)
    {
        lock (idWidgetRegistrationLock)
        {
            widgetRegistry.TryGetValue(widgetId, out var widget);
            return widget;
        }
    }

    public void RegisterWidget(int widgetId, object widget)
    {
        lock (idWidgetRegistrationLock)
        {
            widgetRegistry[widgetId] = widget;
        }
    }

    public int GetNextWidgetId()
    {
        lock (idGeneratorLock)
        {
            var widgetId = lastWidgetId;
            lastWidgetId++;
            return widgetId;
        }
    }

    public int GetNextComponentId()
    {
        lock (idGeneratorLock)
        {
            var componentId = lastComponentId;
            lastComponentId++;
            return componentId;
        }
    }

    public void RegisterOnClick(int widgetId, Action onClick)
    {
        lock (idEventRegistrationLock)
        {
            var newRegistry = new Dictionary<int, Action>(onClickRegistry.Value)
            {
                { widgetId, onClick }
            };
            onClickRegistry.OnNext(newRegistry);
        }
    }

    public void DispatchOnClickEvent(int widgetId)
    {
        if (onClickRegistry.Value.TryGetValue(widgetId, out var onClick))
        {
            eventsSubject.OnNext(onClick);
        }
        else
        {
            Console.WriteLine($"Widget with id {widgetId} has no on_click handler");
        }
    }

    public void CreateWidget(RawChildlessWidgetNodeWithId widget)
    {
        // Filter out functions/delegates from props
        var filteredProps = widget.props
            .Where(kv => kv.Value == null || !typeof(Delegate).IsAssignableFrom(kv.Value.GetType()))
            .ToDictionary(kv => kv.Key, kv => kv.Value);

        // Create a new dictionary to hold the flattened object
        var widgetData = new Dictionary<string, object>
        {
            { "id", widget.id },
            { "type", widget.type }
        };

        // Add the filtered props to the widgetData dictionary
        foreach (var kv in filteredProps)
        {
            widgetData[kv.Key] = kv.Value;
        }

        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Converters = new List<JsonConverter> { new StringEnumConverter() }
        };
        var widgetJson = JsonConvert.SerializeObject(widgetData, settings);
        SetElement(widgetJson);
    }

    public void PatchWidget(int widgetId, object widget)
    {
        var widgetJson = JsonConvert.SerializeObject(widget);
        PatchElement(widgetId, widgetJson);
    }

    public void LinkChildren(int widgetId, List<int> childIds)
    {
        var childrenJson = JsonConvert.SerializeObject(childIds);
        SetChildren(widgetId, childrenJson);
    }

    // These methods need work
    public void SetData(int widgetId, object data)
    {
        var dataJson = JsonConvert.SerializeObject(data);
        ElementInternalOp(widgetId, dataJson);
    }

    public void AppendData(int widgetId, object data)
    {
        var dataJson = JsonConvert.SerializeObject(data);
        ElementInternalOp(widgetId, dataJson);
    }

    public void ResetData(int widgetId)
    {
        var dataJson = JsonConvert.SerializeObject("");
        ElementInternalOp(widgetId, dataJson);
    }

    public void ResetData(int widgetId, object data)
    {
        var dataJson = JsonConvert.SerializeObject(data);
        ElementInternalOp(widgetId, dataJson);
    }

    public void AppendDataToPlotLine(int widgetId, double x, double y)
    {
        var plotData = new { x, y };
        ElementInternalOp(widgetId, JsonConvert.SerializeObject(plotData));
    }

    public void SetPlotLineAxesDecimalDigits(int widgetId, double x, double y)
    {
        var axesData = new { x, y };
        ElementInternalOp(widgetId, JsonConvert.SerializeObject(axesData));
    }

    public void AppendTextToClippedMultiLineTextRenderer(int widgetId, string text)
    {
        ExternAppendText(widgetId, text);
    }

    public void SetInputTextValue(int widgetId, string value)
    {
        var inputTextData = new { value };
        ElementInternalOp(widgetId, JsonConvert.SerializeObject(inputTextData));
    }

    public void SetComboSelectedIndex(int widgetId, int index)
    {
        var selectedIndexData = new { index };
        ElementInternalOp(widgetId, JsonConvert.SerializeObject(selectedIndexData));
    }

    private void SetElement(string jsonData)
    {
        XFrames.setElement(jsonData);
    }

    private void PatchElement(int widgetId, string jsonData)
    {
        // Implement patch logic
    }

    private void SetChildren(int widgetId, string jsonData)
    {
        XFrames.setChildren(widgetId, jsonData);
    }

    private void ElementInternalOp(int widgetId, string jsonData)
    {
        // Implement internal operation logic
    }

    private void ExternAppendText(int widgetId, string text)
    {
        // Implement text appending logic
    }
}

