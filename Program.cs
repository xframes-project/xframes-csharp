using Newtonsoft.Json;


public struct Theme2
{
    public Dictionary<int, List<object>> colors { get; set; }

    public Theme2(Dictionary<int, List<object>> colorsDict)
    {
        colors = colorsDict;
    }
}


class Program
{
    static async Task Main(string[] args)
    {
        var fontDefs = new
        {
            defs = new[]
            {
                new { name = "roboto-regular", sizes = new[] { 16, 18, 20, 24, 28, 32, 36, 48 } }
            }
            .SelectMany(font => font.sizes.Select(size => new FontDef(font.name, size)))
            .ToList()
        };

        string fontDefsJson = JsonConvert.SerializeObject(fontDefs);

        // Assuming theme2Colors is defined like this:
        var theme2Colors = new Dictionary<string, string>
        {
            { "white", "#FFFFFF" },
            { "lighterGrey", "#B0B0B0" },
            { "black", "#000000" },
            { "lightGrey", "#A0A0A0" },
            { "darkestGrey", "#1A1A1A" },
            { "darkerGrey", "#505050" },
            { "darkGrey", "#2E2E2E" }
        };

        // Define the theme with a tuple (string color, int alpha)
        var theme2 = new Theme2(new Dictionary<int, List<object>>
        {
            { ((int)ImGuiCol.Text), new List<object> { theme2Colors["white"], 1 } },
            { ((int) ImGuiCol.TextDisabled), new List<object> { theme2Colors["lighterGrey"], 1 } },
            { ((int) ImGuiCol.WindowBg), new List<object> { theme2Colors["black"], 1 } },
            { ((int) ImGuiCol.ChildBg), new List<object> { theme2Colors["black"], 1 } },
            { ((int) ImGuiCol.PopupBg), new List<object> { theme2Colors["white"], 1 } },
            { ((int) ImGuiCol.Border), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.BorderShadow), new List<object> { theme2Colors["darkestGrey"], 1 } },
            { ((int) ImGuiCol.FrameBg), new List<object> { theme2Colors["black"], 1 } },
            { ((int) ImGuiCol.FrameBgHovered), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.FrameBgActive), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.TitleBg), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.TitleBgActive), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.TitleBgCollapsed), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.MenuBarBg), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.ScrollbarBg), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.ScrollbarGrab), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.ScrollbarGrabHovered), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.ScrollbarGrabActive), new List<object> { theme2Colors["darkestGrey"], 1 } },
            { ((int) ImGuiCol.CheckMark), new List<object> { theme2Colors["darkestGrey"], 1 } },
            { ((int) ImGuiCol.SliderGrab), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.SliderGrabActive), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.Button), new List<object> { theme2Colors["black"], 1 } },
            { ((int) ImGuiCol.ButtonHovered), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.ButtonActive), new List<object> { theme2Colors["black"], 1 } },
            { ((int) ImGuiCol.Header), new List<object> { theme2Colors["black"], 1 } },
            { ((int) ImGuiCol.HeaderHovered), new List<object> { theme2Colors["black"], 1 } },
            { ((int) ImGuiCol.HeaderActive), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.Separator), new List<object> { theme2Colors["darkestGrey"], 1 } },
            { ((int) ImGuiCol.SeparatorHovered), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.SeparatorActive), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.ResizeGrip), new List<object> { theme2Colors["black"], 1 } },
            { ((int) ImGuiCol.ResizeGripHovered), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.ResizeGripActive), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.Tab), new List<object> { theme2Colors["black"], 1 } },
            { ((int) ImGuiCol.TabHovered), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.TabActive), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.TabUnfocused), new List<object> { theme2Colors["black"], 1 } },
            { ((int) ImGuiCol.TabUnfocusedActive), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.PlotLines), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.PlotLinesHovered), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.PlotHistogram), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.PlotHistogramHovered), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.TableHeaderBg), new List<object> { theme2Colors["black"], 1 } },
            { ((int) ImGuiCol.TableBorderStrong), new List<object> { theme2Colors["lightGrey"], 1 } },
            { ((int) ImGuiCol.TableBorderLight), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.TableRowBg), new List<object> { theme2Colors["darkGrey"], 1 } },
            { ((int) ImGuiCol.TableRowBgAlt), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.TextSelectedBg), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.DragDropTarget), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.NavHighlight), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.NavWindowingHighlight), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.NavWindowingDimBg), new List<object> { theme2Colors["darkerGrey"], 1 } },
            { ((int) ImGuiCol.ModalWindowDimBg), new List<object> { theme2Colors["darkerGrey"], 1 } }
        });

        string theme2Json = JsonConvert.SerializeObject(theme2);

        Console.WriteLine("Program started.");

        var service = new WidgetRegistrationService();
        var treeTraversal = new ShadowNodeTraversalHelper(service);

        XFrames.OnInitCb onInit = () => {
            Console.WriteLine("Initialization callback called!");

            var root = new Root();
            treeTraversal.TraverseTree(root);
        };

        XFrames.OnTextChangedCb onTextChanged = (int id, string value) => { };
        XFrames.OnComboChangedCb onComboChanged = (int id, int index) => { };
        XFrames.OnNumericValueChangedCb onNumericValueChanged = (int id, float value) => { };
        XFrames.OnBooleanValueChangedCb onBooleanValueChanged = (int id, bool value) => { };
        XFrames.OnMultipleNumericValuesChangedCb onMultipleNumericValuesChanged = (int id, IntPtr rawValues, int numValues) => {
            float[] values = XFrames.MarshalFloatArray(rawValues, numValues);
        };
        XFrames.OnClickCb onClick = (int id) => {
            service.DispatchOnClickEvent(id);
        };

        XFrames.init("./assets", fontDefsJson, theme2Json, onInit, onTextChanged, onComboChanged, onNumericValueChanged, onBooleanValueChanged, onMultipleNumericValuesChanged, onClick);

        // Start the background task that will keep the process running
        await KeepProcessRunning();

        Console.WriteLine("Program finished.");
    }

    // Asynchronous method to keep the process running
    static async Task KeepProcessRunning()
    {
        bool flag = true;

        while (flag)
        {
            // Simulate some periodic work
            //Console.WriteLine("Process is running...");

            // Wait for 1 second without blocking the thread
            await Task.Delay(1000);  // Delay for 1000ms (1 second)
        }
    }
}
