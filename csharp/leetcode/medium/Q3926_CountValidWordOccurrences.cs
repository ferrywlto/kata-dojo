public class Q3926_CountValidWordOccurrences
{
    public int[] CountWordOccurrences(string[] chunks, string[] queries)
    {
        return [];
    }

    public static TheoryData<string[], string[], int[]> TestData => new TheoryData<string[], string[], int[]>
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
