using System.Reactive.Subjects;
using DynamicData;


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

// Assuming WidgetStyle, Button, and Text exist
public class App : BaseComponent
{
    private IDisposable _appStateSubscription;

    public App()
    {
        _appStateSubscription = AppStateManager.SampleAppState.Subscribe(latestAppState =>
        {
            Props.OnNext(new
            {
                todo_text = latestAppState.TodoText,
                todo_items = latestAppState.TodoItems
            });
        });
    }

    public override Node Render()
    {
        var children = new List<Node>
        {
            Button("Add todo", AppStateManager.OnClick, buttonStyle)
        };

        foreach (var todoItem in Props.Value.todo_items)
        {
            string text = $"{todoItem.Text} ({(todoItem.Done ? "done" : "to do")}).";
            children.Add(UnformattedText(text, textStyle));
        }

        return Node(children);
    }

    public override void Dispose()
    {
        _appStateSubscription.Dispose();
    }
}

public class Root : BaseComponent
{
    public override Node Render() => RootNode(new List<Node> { new App() });
}