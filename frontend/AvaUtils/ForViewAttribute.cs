namespace AvaUtils;

[AttributeUsage(AttributeTargets.Class)]
public class ForViewAttribute(Type viewType) : Attribute {
    private Type viewType = viewType;
    public Type GetViewType() => viewType;
}