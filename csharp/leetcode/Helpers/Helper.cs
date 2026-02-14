public static class EnumerableExtension
{
    public static Dictionary<T, int> Analyze<T>(this IEnumerable<T> input) where T : notnull
    {
        var dict = new Dictionary<T, int>();
        foreach (var item in input)
        {
            if (dict.TryGetValue(item, out var value))
            {
                dict[item]++;
            }
            else
            {
                dict[item] = 1;
            }
        }
        return dict;
    }
}
