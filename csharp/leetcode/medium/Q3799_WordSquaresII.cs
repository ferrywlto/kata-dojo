public class Q3799_WordSquaresII
{
    public IList<IList<string>> WordSquares(string[] words)
    {
        Array.Sort(words, StringComparer.Ordinal);

        var byFirst = new List<string>[26];
        var byPair = new List<string>[26 * 26];

        for (var i = 0; i < 26; i++) byFirst[i] = [];
        for (var i = 0; i < 26 * 26; i++) byPair[i] = [];

        static int C(char c) => c - 'a';
        static int Key(char first, char last) => C(first) * 26 + C(last);

        foreach (var word in words)
        {
            byFirst[C(word[0])].Add(word);
            byPair[Key(word[0], word[3])].Add(word);
        }

        var result = new List<IList<string>>();

        foreach (var top in words)
        {
            foreach (var left in byFirst[C(top[0])])
            {
                if (left == top) continue;

                foreach (var right in byFirst[C(top[3])])
                {
                    if (right == top || right == left) continue;

                    foreach (var bottom in byPair[Key(left[3], right[3])])
                    {
                        if (bottom == top || bottom == left || bottom == right) continue;

                        result.Add([top, left, right, bottom]);
                    }
                }
            }
        }

        return result;
    }

    public static TheoryData<string[], IList<IList<string>>> TestData => new()
    {
        {
            ["able","area","echo","also"],
            [["able","area","echo","also"],["area","able","also","echo"]]
        },
        {
            ["code","cafe","eden","edge"],
            []
        },
        {
            ["avvj","dooe","exxj","diia"],
            [["diia","dooe","avvj","exxj"],["dooe","diia","exxj","avvj"]]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, IList<IList<string>> expected)
    {
        var actual = WordSquares(input);
        Assert.Equal(expected, actual);
    }
}
