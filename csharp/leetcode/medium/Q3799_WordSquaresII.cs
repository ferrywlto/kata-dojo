public class Q3799_WordSquaresII
{
    public IList<IList<string>> WordSquares(string[] words)
    {
        var heads = new Dictionary<char, HashSet<string>>();
        var tails = new Dictionary<char, HashSet<string>>();

        for (var i = 0; i < words.Length; i++)
        {
            if (heads.TryGetValue(words[i][0], out var headSet))
            {
                headSet.Add(words[i]);
            }
            else
            {
                headSet = [words[i]];
                heads.Add(words[i][0], headSet);
            }

            if (tails.TryGetValue(words[i][3], out var tailSet))
            {
                tailSet.Add(words[i]);
            }
            else
            {
                tailSet = [words[i]];
                tails.Add(words[i][3], tailSet);
            }
        }

        var result = new List<IList<string>>();
        foreach (var top in tails)
        {
            var topTail = top.Key;
            foreach (var topCandidate in top.Value)
            {
                var topHead = topCandidate[0];

                if (heads.TryGetValue(topTail, out HashSet<string>? wordsStartWithTopTail))
                {
                    foreach (var rightCandidate in wordsStartWithTopTail)
                    {
                        if(rightCandidate != topCandidate)
                        {
                            var rightTail = rightCandidate[3];
                            if (tails.TryGetValue(rightTail, out HashSet<string>? wordsEndWithRightTail))
                            {
                                foreach (var bottomCandidate in wordsEndWithRightTail)
                                {
                                    if (bottomCandidate != rightCandidate && bottomCandidate != topCandidate)
                                    {
                                        var bottomHead = bottomCandidate[0];
                                        if (tails.TryGetValue(bottomHead, out HashSet<string>? wordsEndWithBottomHead))
                                        {
                                            foreach (var leftCandidate in wordsEndWithBottomHead)
                                            {
                                                if (leftCandidate != bottomCandidate && leftCandidate != rightCandidate && leftCandidate != topCandidate)
                                                {
                                                    var leftHead = leftCandidate[0];
                                                    if (leftHead == topHead)
                                                    {
                                                        List<string> square =
                                                        [
                                                            topCandidate, leftCandidate, rightCandidate, bottomCandidate
                                                        ];

                                                        result.Add(square);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // ascending lexicographic sort
        result.Sort((a, b) =>
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (a[i][j] < b[i][j]) return -1;
                    if (a[i][j] > b[i][j]) return 1;
                }
            }
            return 0;
        });
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
