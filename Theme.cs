

using System.Runtime.Serialization;
using Newtonsoft.Json;

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

public record FontDef(string name, int size);

public record ImVec2(float x, float y);


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

public record StyleRules(
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] Align? align = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] FontDef? font = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] Dictionary<ImGuiCol, object>? colors = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] Dictionary<ImGuiStyleVar, object>? vars = null
);

public record BorderStyle(
    object color, 
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] float? thickness = null
);


public record YogaStyle(
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] Direction? direction = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] FlexDirection? flexDirection = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] JustifyContent? justifyContent = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] AlignContent? alignContent = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] AlignItems? alignItems = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] AlignSelf? alignSelf = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] PositionType? positionType = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] FlexWrap? flexWrap = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] Overflow? overflow = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] Display? display = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] float? flex = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] float? flexGrow = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] float? flexShrink = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] float? flexBasis = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] float? flexBasisPercent = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] Dictionary<Edge, float>? position = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] Dictionary<Edge, float>? margin = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] Dictionary<Edge, float>? padding = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] Dictionary<Gutter, float>? gap = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] float? aspectRatio = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] object? width = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] object? minWidth = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] object? maxWidth = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] object? height = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] object? minHeight = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] object? maxHeight = null
);

public record BaseDrawStyle(
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] StyleColValue? backgroundColor = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] BorderStyle? border = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] BorderStyle? borderTop = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] BorderStyle? borderRight = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] BorderStyle? borderBottom = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] BorderStyle? borderLeft = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] float? rounding = null,
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] List<RoundCorners>? roundCorners = null
);



public record NodeStyleDef(
    YogaStyle? layout = null,
    BaseDrawStyle? baseDraw = null
)
{
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


public record WidgetStyleDef(
    StyleRules? styleRules = null,
    YogaStyle? layout = null,
    BaseDrawStyle? baseDraw = null
)
{
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


public record NodeStyle(
    NodeStyleDef? style = null,
    NodeStyleDef? hoverStyle = null,
    NodeStyleDef? activeStyle = null,
    NodeStyleDef? disabledStyle = null
);

public record WidgetStyle(
    WidgetStyleDef? style = null,
    WidgetStyleDef? hoverStyle = null,
    WidgetStyleDef? activeStyle = null,
    WidgetStyleDef? disabledStyle = null
);
