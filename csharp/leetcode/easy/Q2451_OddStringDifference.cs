public class Q2451_OddStringDifference
{
    // TC: O(n*m), n scale with length of words and m scale with characters in each word
    // SC: O(n*m), same as time.
    public string OddString(string[] words)
    {
        var set = new Dictionary<string, List<string>>();

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            var diffArr = new int[word.Length - 1];
            for (var j = 1; j < word.Length; j++)
            {
                diffArr[j - 1] = word[j] - word[j - 1];
            }
            var key = string.Join(',', diffArr);

            if (set.TryGetValue(key, out var value)) value.Add(word);
            else set.Add(key, [word]);
        }

        foreach (var p in set)
        {
            if (p.Value.Count == 1) return p.Value[0];
        }
        return string.Empty;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"adc","wzy","abc"}, "abc"],
        [new string[] {"ddd","poo","baa","onn"}, "ddd"],
        [new string[] {"aaa","bob","ccc","ddd"}, "bob"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string expected)
    {
        var actual = OddString(input);
        Assert.Equal(expected, actual);
    }
}
