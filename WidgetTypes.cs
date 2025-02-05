using System.Runtime.Serialization;

public enum WidgetTypes
{
    [EnumMember(Value = "component")]
    Component,

    [EnumMember(Value = "node")]
    Node,

    [EnumMember(Value = "unformatted-text")]
    UnformattedText,

    [EnumMember(Value = "di-button")]
    Button
}
