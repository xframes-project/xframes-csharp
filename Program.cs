using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

class Program
{
    // Importing the functions from the C DLL
    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void resizeWindow(int width, int height);

    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void setElement(string elementJson);

    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void patchElement(int id, string elementJson);

    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void elementInternalOp(int id, string elementJson);

    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void setChildren(int id, string childrenIds);

    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void appendChild(int parentId, int childId);

    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr getChildren(int id);

    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void appendTextToClippedMultiLineTextRenderer(int id, string data);

    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr getStyle();

    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void patchStyle(string styleDef);

    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void setDebug(bool debug);

    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void showDebugWindow();

    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int run();

    [DllImport("xframes.dll", CallingConvention = CallingConvention.Cdecl)]
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
    public delegate void OnTextChangedCb(string text);
    public delegate void OnComboChangedCb(int index);
    public delegate void OnNumericValueChangedCb(float value);
    public delegate void OnBooleanValueChangedCb(bool value);
    public delegate void OnMultipleNumericValuesChangedCb(float[] values);
    public delegate void OnClickCb(int x, int y);

    public class FontDef
    {
        public string Name { get; set; }
        public int Size { get; set; }
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
            .SelectMany(font => font.sizes.Select(size => new FontDef { Name = font.name, Size = size }))
            .ToList()
        };

        Console.WriteLine("Program started.");

        // Example for the callback delegate setup
        OnInitCb onInit = () => { Console.WriteLine("Initialization callback called!"); };
        init("./assets", "{\"font\": \"Arial\"}", "{\"style\": \"default\"}", onInit, null, null, null, null, null, null);

        // Call other functions as needed
        run();

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
            Console.WriteLine("Process is running...");

            // Wait for 1 second without blocking the thread
            await Task.Delay(1000);  // Delay for 1000ms (1 second)
        }
    }
}
