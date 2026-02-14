using Row = (int key, string value);
class Q1656_DesignOrderedStream
{
    public readonly string[] stream;
    private int pointer = 0;
    public Q1656_DesignOrderedStream(int n)
    {
        stream = new string[n];
    }

    // TC: O(n), worst case the whole stream have to read through
    // SC: O(n), worst case the whole stream have to add to result list
    public IList<string> Insert(int idKey, string value)
    {
        var idx = idKey - 1;
        stream[idx] = value;

        if (idx != pointer) return [];

        var result = new List<string>();
        while (pointer < stream.Length && !string.IsNullOrEmpty(stream[pointer]))
        {
            result.Add(stream[pointer]);
            pointer++;
        }
        return result;
    }
}

class Q1656_DesignOrderedStreamTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new Row[]
            {
                (3, "ccccc"),
                (1, "aaaaa"),
                (2, "bbbbb"),
                (5, "eeeee"),
                (4, "ddddd"),
            },
            new string[][]
            {
                [],
                ["aaaaa"],
                ["bbbbb", "ccccc"],
                [],
                ["ddddd", "eeeee"],
            },
        ]
    ];
}

public class Q1656_DesignOrderedStreamTests
{
    [Theory]
    [ClassData(typeof(Q1656_DesignOrderedStreamTestData))]
    public void OfficialTestCases(Row[] input, string[][] expected)
    {
        var sut = new Q1656_DesignOrderedStream(input.Length);
        for (var i = 0; i < input.Length; i++)
        {
            (var key, var value) = input[i];
            var actual = sut.Insert(key, value);

            Assert.Equal(expected[i], actual);
        }
    }
}
