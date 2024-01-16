public class StatModifier
{
    public readonly float Value;
    public readonly StatModType Type;
    public readonly int Order;
    public readonly object Source;

    public StatModifier(float value, StatModType type, int order, object source)
    {
        Value = value;
        Type = type;
        Order = order;
        Source = source;
    }

    // Requires Value and Type. Calls the "Main" constructor and sets Order and Source to their default values: (int)type and null, respectively.
    public StatModifier(float value, StatModType type) : this(value, type, (int)type, null) { }

    // Requires Value, Type and Order. Sets Source to its default value: null
    public StatModifier(float value, StatModType type, int order) : this(value, type, order, null) { }

    // Requires Value, Type and Source. Sets Order to its default value: (int)Type
    public StatModifier(float value, StatModType type, object source) : this(value, type, (int)type, source) { }
}

public enum StatModType
{
    // The numbers correspond to the order priority of each StatModType, if we want to add another type of modifier with a an order priority between
    // 2 of the already existing modifier, we can by putting a number between the 2 modifier.

    Flat = 100,
    PercentAdd = 200,
    PercentMult = 300,
}