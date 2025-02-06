using System.Reactive.Linq;
using System.Reactive.Subjects;

public class TodoItem
{
    public string Text { get; }
    public bool Done { get; }

    public TodoItem(string text, bool done)
    {
        Text = text;
        Done = done;
    }
}

public class AppState
{
    public string TodoText { get; }
    public List<TodoItem> TodoItems { get; }

    public AppState(string todoText, List<TodoItem> todoItems)
    {
        TodoText = todoText;
        TodoItems = new List<TodoItem>(todoItems);
    }
}

public static class AppStateManager
{
    public static BehaviorSubject<AppState> SampleAppState { get; } =
        new BehaviorSubject<AppState>(new AppState("", new List<TodoItem>()));

    public static void OnClick()
    {
        var newTodo = new TodoItem("New Todo", false);
        var currentState = SampleAppState.Value;

        var newState = new AppState(
            currentState.TodoText,
            new List<TodoItem>(currentState.TodoItems) { newTodo }
        );

        SampleAppState.OnNext(newState);
    }
}

public class App : BaseComponent, IDisposable
{
    private IDisposable _appStateSubscription;
    private bool _disposed;

    public WidgetStyle TextStyle { get; }
    public WidgetStyle ButtonStyle { get; }

    public App()
    {
        TextStyle = new WidgetStyle(
            style: new WidgetStyleDef(
                styleRules: new StyleRules(
                    font: new FontDef("roboto-regular", 32)
                )
            )
        );

        ButtonStyle = new WidgetStyle(
            style: new WidgetStyleDef(
                styleRules: new StyleRules(
                    font: new FontDef("roboto-regular", 32)
                ),
                layout: new YogaStyle(
                    width: "50%",
                    padding: new Dictionary<Edge, float> { { Edge.Vertical, 10 } },
                    margin: new Dictionary<Edge, float> { { Edge.Left, 140 } }
                )
            )
        );


        _appStateSubscription = AppStateManager.SampleAppState.Subscribe(latestAppState =>
        {
            // Ensure that we are updating the Props value with the correct dictionary
            props.OnNext(new Dictionary<string, object>
            {
                { "todoText", latestAppState.TodoText },
                { "todoItems", latestAppState.TodoItems }
            });
        });
    }

    public override IRenderable Render()
    {
        var children = new List<IRenderable>
        {
            WidgetNodeFactory.Button("Add todo", AppStateManager.OnClick, ButtonStyle)
        };

        // Safe access to "todoItems" from Props.Value
        if (props.Value.TryGetValue("todoItems", out var todoItemsObj) && todoItemsObj is List<TodoItem> todoItems)
        {
            foreach (var todoItem in todoItems)
            {
                string text = $"{todoItem.Text} ({(todoItem.Done ? "done" : "to do")}).";
                children.Add(WidgetNodeFactory.UnformattedText(text, TextStyle));
            }
        }

        return WidgetNodeFactory.Node(children);
    }

    public override void Dispose()
    {
        _appStateSubscription?.Dispose();
        GC.SuppressFinalize(this);

        base.Dispose();
    }
}

public class Root : BaseComponent
{
    public override IRenderable Render() => WidgetNodeFactory.RootNode(new List<IRenderable> { new App() });
}