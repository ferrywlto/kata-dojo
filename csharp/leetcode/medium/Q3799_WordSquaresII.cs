public class Q3799_WordSquaresII(ITestOutputHelper output)
{
    List<List<string>> result = [];
    public IList<IList<string>> WordSquares(string[] words)
    {
        Array.Sort(words);
        var list = new List<string>();

        for(var i=0; i<words.Length - 3; i++)
        {
            for(var j=i+1; j<words.Length - 2; j++)
            {
                for(var k=j+1; k<words.Length - 1; k++)
                {
                    for(var m=k+1; m<words.Length; m++)
                    {
                        output.WriteLine($"{words[i]}, {words[j]}, {words[k]}, {words[m]}");
                    }
                }
            }
        }


        // BT(words, list, 0);
        return [];
    }

    private void BT(string[] words, List<string> picks, int idx)
    {
        // if(IsSquare(words[topIdx], words[leftIdx], words[rightIdx], words[bottomIdx]))
        // {
        //     result.Add([words[topIdx], words[leftIdx], words[rightIdx], words[bottomIdx]]);
        //     return;
        // }
        if(picks.Count == 4)
        {
            output.WriteLine(string.Join(',', picks));
            return;
        }

        if(idx < words.Length)
        {
            output.WriteLine($"i:{idx}, picksCount: {picks.Count}");
            // pick top
            picks.Add(words[idx]);
            BT(words, picks, idx + 1);
            picks.RemoveAt(picks.Count - 1);
        }
    }

    private bool IsSquare(string top, string left, string right, string bottom)
    {
        return 
            top[0] == left[0] &&
            top[3] == right[0] &&
            bottom[0] == left[3] &&
            bottom[3] == right[3];
    }

    public static TheoryData<string[], string[][]> TestData => new()
    {
        // {
        //     ["able","area","echo","also"],
        //     [["able","area","echo","also"],["area","able","also","echo"]]
        // },
        // {
        //     ["code","cafe","eden","edge"],
        //     []
        // },
        {
            ["a","b","c","d","e"],
            [["a"]]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string[][] expected)
    {
        var actual = WordSquares(input);
        Assert.Equal(expected, actual);
    }
}
