namespace Core.Tools.Casts.Interfaces
{
    public interface ICastTools<T>
    {
        IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs(T model);
    }
}