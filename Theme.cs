

using System.Runtime.Serialization;
using DynamicData;

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


public enum ImPlotScale
{
    Linear = 0,
    Time = 1,
    Log10 = 2,
    SymLog = 3
}


public enum ImPlotMarker
{
    None_ = -1,
    Circle = 0,
    Square = 1,
    Diamond = 2,
    Up = 3,
    Down = 4,
    Left = 5,
    Right = 6,
    Cross = 7,
    Plus = 8,
    Asterisk = 9
}


public enum ImGuiStyleVar
{
    Alpha = 0,
    DisabledAlpha = 1,
    WindowPadding = 2,
    WindowRounding = 3,
    WindowBorderSize = 4,
    WindowMinSize = 5,
    WindowTitleAlign = 6,
    ChildRounding = 7,
    ChildBorderSize = 8,
    PopupRounding = 9,
    PopupBorderSize = 10,
    FramePadding = 11,
    FrameRounding = 12,
    FrameBorderSize = 13,
    ItemSpacing = 14,
    ItemInnerSpacing = 15,
    IndentSpacing = 16,
    CellPadding = 17,
    ScrollbarSize = 18,
    ScrollbarRounding = 19,
    GrabMinSize = 20,
    GrabRounding = 21,
    TabRounding = 22,
    TabBorderSize = 23,
    TabBarBorderSize = 24,
    TableAngledHeadersAngle = 25,
    TableAngledHeadersTextAlign = 26,
    ButtonTextAlign = 27,
    SelectableTextAlign = 28,
    SeparatorTextBorderSize = 29,
    SeparatorTextAlign = 30,
    SeparatorTextPadding = 31
}


public enum ImGuiDir
{
    None_ = -1,
    Left = 0,
    Right = 1,
    Up = 2,
    Down = 3
}


[Flags]
public enum ImGuiHoveredFlags
{
    None_ = 0,
    ChildWindows = 1 << 0,
    RootWindow = 1 << 1,
    AnyWindow = 1 << 2,
    NoPopupHierarchy = 1 << 3,
    AllowWhenBlockedByPopup = 1 << 5,
    AllowWhenBlockedByActiveItem = 1 << 7,
    AllowWhenOverlappedByItem = 1 << 8,
    AllowWhenOverlappedByWindow = 1 << 9,
    AllowWhenDisabled = 1 << 10,
    NoNavOverride = 1 << 11,
    ForTooltip = 1 << 12,
    Stationary = 1 << 13,
    DelayNone = 1 << 14,
    DelayShort = 1 << 15,
    DelayNormal = 1 << 16,
    NoSharedDelay = 1 << 17
}

class Types
{
    public static List<object> HEXA(string color, float alpha)
    {
        return new List<object> { color, alpha };
    }
}

public class FontDef
{
    public string name { get; set; }
    public int size { get; set; }

    public FontDef(string name, int size)
    {
        this.name = name;
        this.size = size;
    }
}

public class ImVec2
{
    public float x { get; set; }
    public float y { get; set; }
}

public class StyleColValue
{
    public object value { get; set; }

    public StyleColValue(string color)
    {
        value = color;
    }

    public StyleColValue(List<object> hexa)
    {
        value = hexa;
    }
}

public enum Align
{
    [EnumMember(Value = "left")]
    Left,

    [EnumMember(Value = "right")]
    Right
}

public enum Direction
{
    [EnumMember(Value = "inherit")]
    Inherit,

    [EnumMember(Value = "ltr")]
    Ltr,

    [EnumMember(Value = "rtl")]
    Rtl
}

public enum FlexDirection
{
    [EnumMember(Value = "column")]
    Column,

    [EnumMember(Value = "column-reverse")]
    ColumnReverse,

    [EnumMember(Value = "row")]
    Row,

    [EnumMember(Value = "row-reverse")]
    RowReverse
}

public enum JustifyContent
{
    [EnumMember(Value = "flex-start")]
    FlexStart,

    [EnumMember(Value = "center")]
    Center,

    [EnumMember(Value = "flex-end")]
    FlexEnd,

    [EnumMember(Value = "space-between")]
    SpaceBetween,

    [EnumMember(Value = "space-around")]
    SpaceAround,

    [EnumMember(Value = "space-evenly")]
    SpaceEvenly
}

public enum AlignContent
{
    [EnumMember(Value = "auto")]
    Auto,

    [EnumMember(Value = "flex-start")]
    FlexStart,

    [EnumMember(Value = "center")]
    Center,

    [EnumMember(Value = "flex-end")]
    FlexEnd,

    [EnumMember(Value = "stretch")]
    Stretch,

    [EnumMember(Value = "space-between")]
    SpaceBetween,

    [EnumMember(Value = "space-around")]
    SpaceAround,

    [EnumMember(Value = "space-evenly")]
    SpaceEvenly
}

public enum AlignItems
{
    [EnumMember(Value = "auto")]
    Auto,

    [EnumMember(Value = "flex-start")]
    FlexStart,

    [EnumMember(Value = "center")]
    Center,

    [EnumMember(Value = "flex-end")]
    FlexEnd,

    [EnumMember(Value = "stretch")]
    Stretch,

    [EnumMember(Value = "baseline")]
    Baseline
}

public enum AlignSelf
{
    [EnumMember(Value = "auto")]
    Auto,

    [EnumMember(Value = "flex-start")]
    FlexStart,

    [EnumMember(Value = "center")]
    Center,

    [EnumMember(Value = "flex-end")]
    FlexEnd,

    [EnumMember(Value = "stretch")]
    Stretch,

    [EnumMember(Value = "baseline")]
    Baseline
}

public enum PositionType
{
    [EnumMember(Value = "static")]
    Static,

    [EnumMember(Value = "relative")]
    Relative,

    [EnumMember(Value = "absolute")]
    Absolute
}

public enum FlexWrap
{
    [EnumMember(Value = "no-wrap")]
    NoWrap,

    [EnumMember(Value = "wrap")]
    Wrap,

    [EnumMember(Value = "wrap-reverse")]
    WrapReverse
}

public enum Overflow
{
    [EnumMember(Value = "visible")]
    Visible,

    [EnumMember(Value = "hidden")]
    Hidden,

    [EnumMember(Value = "scroll")]
    Scroll
}

public enum Display
{
    [EnumMember(Value = "flex")]
    Flex,

    [EnumMember(Value = "none")]
    DisplayNone
}

public enum Edge
{
    [EnumMember(Value = "left")]
    Left,

    [EnumMember(Value = "top")]
    Top,

    [EnumMember(Value = "right")]
    Right,

    [EnumMember(Value = "bottom")]
    Bottom,

    [EnumMember(Value = "start")]
    Start,

    [EnumMember(Value = "end")]
    End,

    [EnumMember(Value = "horizontal")]
    Horizontal,

    [EnumMember(Value = "vertical")]
    Vertical,

    [EnumMember(Value = "all")]
    All
}

public enum Gutter
{
    [EnumMember(Value = "column")]
    Column,

    [EnumMember(Value = "row")]
    Row,

    [EnumMember(Value = "all")]
    All
}

public enum RoundCorners
{
    [EnumMember(Value = "all")]
    All,

    [EnumMember(Value = "topLeft")]
    TopLeft,

    [EnumMember(Value = "topRight")]
    TopRight,

    [EnumMember(Value = "bottomLeft")]
    BottomLeft,

    [EnumMember(Value = "bottomRight")]
    BottomRight
}

public class StyleRules
{
    public Align? align { get; set; }
    public FontDef? font { get; set; }
    public Dictionary<ImGuiCol, object>? colors { get; set; }
    public Dictionary<ImGuiStyleVar, object>? vars { get; set; }
}

public class BorderStyle
{
    public object color { get; set; }
    public float? thickness { get; set; }
}

public class YogaStyle
{
    public Direction? direction { get; set; }
    public FlexDirection? flexDirection { get; set; }
    public JustifyContent? justifyContent { get; set; }
    public AlignContent? alignContent { get; set; }
    public AlignItems? alignItems { get; set; }
    public AlignSelf? alignSelf { get; set; }
    public PositionType? positionType { get; set; }
    public FlexWrap? flexWrap { get; set; }
    public Overflow? overflow { get; set; }
    public Display? display { get; set; }
    public float? flex { get; set; }
    public float? flexGrow { get; set; }
    public float? flexShrink { get; set; }
    public float? flexBasis { get; set; }
    public float? flexBasisPercent { get; set; }
    public Dictionary<Edge, float>? position { get; set; }
    public Dictionary<Edge, float>? margin { get; set; }
    public Dictionary<Edge, float>? padding { get; set; }
    public Dictionary<Gutter, float>? gap { get; set; }
    public float? aspectRatio { get; set; }
    public object? width { get; set; }
    public object? minWidth { get; set; }
    public object? maxWidth { get; set; }
    public object? height { get; set; }
    public object? minHeight { get; set; }
    public object? maxHeight { get; set; }
}

public class BaseDrawStyle
{
    public StyleColValue? backgroundColor { get; set; }
    public BorderStyle? border { get; set; }
    public BorderStyle? borderTop { get; set; }
    public BorderStyle? borderRight { get; set; }
    public BorderStyle? borderBottom { get; set; }
    public BorderStyle? borderLeft { get; set; }
    public float? rounding { get; set; }
    public List<RoundCorners>? roundCorners { get; set; }
}


public class NodeStyleDef
{
    public YogaStyle? layout { get; set; }
    public BaseDrawStyle? baseDraw { get; set; }

    public NodeStyleDef(YogaStyle? layout = null,
                       BaseDrawStyle? baseDraw = null)
    {
        this.layout = layout;
        this.baseDraw = baseDraw;
    }

    public Dictionary<string, object> ToDictionary()
    {
        var outDict = new Dictionary<string, object>();

        if (layout != null)
        {
            foreach (var prop in layout.GetType().GetProperties())
            {
                var value = prop.GetValue(layout);
                if (value != null)
                {
                    outDict[prop.Name] = value;
                }
            }
        }

        if (baseDraw != null)
        {
            foreach (var prop in baseDraw.GetType().GetProperties())
            {
                var value = prop.GetValue(baseDraw);
                if (value != null)
                {
                    outDict[prop.Name] = value;
                }
            }
        }

        return outDict;
    }
}


public class WidgetStyleDef
{
    public StyleRules? styleRules{ get; set; }
    public YogaStyle? layout { get; set; }
    public BaseDrawStyle? baseDraw { get; set; }

    public WidgetStyleDef(StyleRules? styleRules = null,
                       YogaStyle? layout = null,
                       BaseDrawStyle? baseDraw = null)
    {
        this.styleRules = styleRules;
        this.layout = layout;
        this.baseDraw = baseDraw;
    }

    public Dictionary<string, object> ToDictionary()
    {
        var outDict = new Dictionary<string, object>();

        if (styleRules != null)
        {
            foreach (var prop in styleRules.GetType().GetProperties())
            {
                var value = prop.GetValue(styleRules);
                if (value != null)
                {
                    outDict[prop.Name] = value;
                }
            }
        }

        if (layout != null)
        {
            foreach (var prop in layout.GetType().GetProperties())
            {
                var value = prop.GetValue(layout);
                if (value != null)
                {
                    outDict[prop.Name] = value;
                }
            }
        }

        if (baseDraw != null)
        {
            foreach (var prop in baseDraw.GetType().GetProperties())
            {
                var value = prop.GetValue(baseDraw);
                if (value != null)
                {
                    outDict[prop.Name] = value;
                }
            }
        }

        return outDict;
    }
}

public class NodeStyle
{
    public NodeStyleDef? style { get; set; }

    public NodeStyleDef? hoverStyle { get; set; }

    public NodeStyleDef? activeStyle { get; set; }

    public NodeStyleDef? disabledStyle { get; set; }
}


public class WidgetStyle
{
    public WidgetStyleDef? style { get; set; }
    public WidgetStyleDef? hoverStyle { get; set; }
    public WidgetStyleDef? activeStyle { get; set; }
    public WidgetStyleDef? disabledStyle { get; set; }
}