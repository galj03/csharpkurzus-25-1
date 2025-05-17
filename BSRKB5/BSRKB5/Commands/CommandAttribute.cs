namespace BSRKB5.Commands;
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
internal class CommandAttribute(string name) : Attribute
{
    public string Name { get; } = name;
    public required string Text { get; init; }
}
