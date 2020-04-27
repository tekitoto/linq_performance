public class DataClass
{
    public int Id { get; private set; } = 0;
    public string Value { get; private set; } = null;

    public DataClass(int _id, string _value)
    {
        Id = _id;
        Value = _value;
    }
}
