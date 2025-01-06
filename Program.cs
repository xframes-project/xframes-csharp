using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;



public enum ImGuiCol
{
    Text = 0,
    TextDisabled = 1,
    WindowBg = 2,
    ChildBg = 3,
    PopupBg = 4,
    Border = 5,
    BorderShadow = 6,
    FrameBg = 7,
    FrameBgHovered = 8,
    FrameBgActive = 9,
    TitleBg = 10,
    TitleBgActive = 11,
    TitleBgCollapsed = 12,
    MenuBarBg = 13,
    ScrollbarBg = 14,
    ScrollbarGrab = 15,
    ScrollbarGrabHovered = 16,
    ScrollbarGrabActive = 17,
    CheckMark = 18,
    SliderGrab = 19,
    SliderGrabActive = 20,
    Button = 21,
    ButtonHovered = 22,
    ButtonActive = 23,
    Header = 24,
    HeaderHovered = 25,
    HeaderActive = 26,
    Separator = 27,
    SeparatorHovered = 28,
    SeparatorActive = 29,
    ResizeGrip = 30,
    ResizeGripHovered = 31,
    ResizeGripActive = 32,
    Tab = 33,
    TabHovered = 34,
    TabActive = 35,
    TabUnfocused = 36,
    TabUnfocusedActive = 37,
    PlotLines = 38,
    PlotLinesHovered = 39,
    PlotHistogram = 40,
    PlotHistogramHovered = 41,
    TableHeaderBg = 42,
    TableBorderStrong = 43,
    TableBorderLight = 44,
    TableRowBg = 45,
    TableRowBgAlt = 46,
    TextSelectedBg = 47,
    DragDropTarget = 48,
    NavHighlight = 49,
    NavWindowingHighlight = 50,
    NavWindowingDimBg = 51,
    ModalWindowDimBg = 52,
    COUNT = 53
}

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
    public static float[] MarshalFloatArray(IntPtr ptr, int length)
    {
        float[] array = new float[length];
        Marshal.Copy(ptr, array, 0, length);
        return array;
    }

    // Importing the functions from the C DLL
    [DllImport("xframesshared.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void resizeWindow(int width, int height);

    [DllImport("xframesshared.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void setElement(string elementJson);

    [DllImport("xframesshared.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void patchElement(int id, string elementJson);

    [DllImport("xframesshared.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void elementInternalOp(int id, string elementJson);

    [DllImport("xframesshared.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void setChildren(int id, string childrenIds);

    [DllImport("xframesshared.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void appendChild(int parentId, int childId);

    [DllImport("xframesshared.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr getChildren(int id);

    [DllImport("xframesshared.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void appendTextToClippedMultiLineTextRenderer(int id, string data);

    [DllImport("xframesshared.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr getStyle();

    [DllImport("xframesshared.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void patchStyle(string styleDef);

    [DllImport("xframesshared.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void setDebug(bool debug);

    [DllImport("xframesshared.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void showDebugWindow();

    [DllImport("xframesshared.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void init(
        string assetsBasePath,
        string rawFontDefinitions,
        string rawStyleOverrideDefinitions,
        OnInitCb onInit,
        OnTextChangedCb onTextChanged,
        OnComboChangedCb onComboChanged,
        OnNumericValueChangedCb onNumericValueChanged,
        OnBooleanValueChangedCb onBooleanValueChanged,
        OnMultipleNumericValuesChangedCb onMultipleNumericValuesChanged,
        OnClickCb onClick
    );

    // Define the delegates for the callback functions
    public delegate void OnInitCb();
    public delegate void OnTextChangedCb(int id, string value);
    public delegate void OnComboChangedCb(int id, int index);
    public delegate void OnNumericValueChangedCb(int id, float value);
    public delegate void OnBooleanValueChangedCb(int id, bool value);
    public delegate void OnMultipleNumericValuesChangedCb(int id, IntPtr values, int numValues);
    public delegate void OnClickCb(int id);

    public class FontDef
    {
        public string name { get; set; }
        public int size { get; set; }
    }

    // Example usage
    static async Task Main(string[] args)
    {
        var fontDefs = new
        {
            defs = new[]
            {
                new { name = "roboto-regular", sizes = new[] { 16, 18, 20, 24, 28, 32, 36, 48 } }
            }
            .SelectMany(font => font.sizes.Select(size => new FontDef { name = font.name, size = size }))
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

        OnInitCb onInit = () => {
            Console.WriteLine("Initialization callback called!");

            var rootNode = new Dictionary<string, object>
            {
                { "id", 0 },
                { "type", "node" },
                { "root", true }
            };

            var textNode = new Dictionary<string, object>
            {
                { "id", 1 },
                { "type", "unformatted-text" },
                { "text", "Hello, world!" }
            };

            setElement(JsonConvert.SerializeObject(rootNode));
            setElement(JsonConvert.SerializeObject(textNode));
            setChildren(0, JsonConvert.SerializeObject(new List<int> { 1 }));
        };

        OnTextChangedCb onTextChanged = (int id, string value) => { };
        OnComboChangedCb onComboChanged = (int id, int index) => { };
        OnNumericValueChangedCb onNumericValueChanged = (int id, float value) => { };
        OnBooleanValueChangedCb onBooleanValueChanged = (int id, bool value) => { };
        OnMultipleNumericValuesChangedCb onMultipleNumericValuesChanged = (int id, IntPtr rawValues, int numValues) => {
            float[] values = MarshalFloatArray(rawValues, numValues);
        };
        OnClickCb onClick = (int id) => { };

        init("./assets", fontDefsJson, theme2Json, onInit, onTextChanged, onComboChanged, onNumericValueChanged, onBooleanValueChanged, onMultipleNumericValuesChanged, onClick);

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
