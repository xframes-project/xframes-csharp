using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

class XFrames
{
    public delegate void OnInitCb();
    public delegate void OnTextChangedCb(int id, string value);
    public delegate void OnComboChangedCb(int id, int index);
    public delegate void OnNumericValueChangedCb(int id, float value);
    public delegate void OnBooleanValueChangedCb(int id, bool value);
    public delegate void OnMultipleNumericValuesChangedCb(int id, IntPtr values, int numValues);
    public delegate void OnClickCb(int id);

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
}
