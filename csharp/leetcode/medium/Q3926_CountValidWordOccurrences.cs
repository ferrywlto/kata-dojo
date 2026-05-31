using System.Text;

public class Q3926_CountValidWordOccurrences
{
    // TC: O(n), n is the total length of chunks
    // SC: O(n + q), where n is the total length in chunks and q is the number of query
    public int[] CountWordOccurrences(string[] chunks, string[] queries)
    {
        var qDict = new Dictionary<string, int>(queries.Length);

        for (var i = 0; i < queries.Length; i++)
        {
            qDict.TryAdd(queries[i], 0);
        }

        var sb = new StringBuilder(string.Concat(chunks));

        for (var i = 0; i < sb.Length; i++)
        {
            if (sb[i] != '-') continue;
            if (i == 0 || i == sb.Length - 1 || !char.IsAsciiLetterLower(sb[i - 1]) || !char.IsAsciiLetterLower(sb[i + 1]))
            {
                sb[i] = ' ';
            }
        }
        // Faster version can be achieved by instead of building the full word array with Split, process each word as soon as you find its boundary in the loop above.
        var words = sb.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            if (qDict.TryGetValue(word, out int value)) qDict[word] = ++value;
        }

        var result = new int[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            result[i] = qDict[queries[i]];
        }

        return result;
    }

    public static TheoryData<string[], string[], int[]> TestData => new()
    {
        { ["hello wor", "ld hello"], ["hello", "world", "wor"], [2, 1, 0] },
        { ["a-b a--b ", "a-", "b"], ["a-b", "a", "b"], [2, 1, 1] },
        { ["-cat dog- mouse"], ["cat", "dog", "mouse", "cat-dog"], [1, 1, 1, 0] }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] chunk, string[] query, int[] expected)
    {
        var actual = CountWordOccurrences(chunk, query);
        Assert.Equal(expected, actual);
    }
}
