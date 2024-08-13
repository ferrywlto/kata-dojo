using Row = (int key, string value);
class Q1656_DesignOrderedStream
{
    public IList<string> Insert(int idKey, string value)
    {
        return [];
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
        var sut = new Q1656_DesignOrderedStream();
        for (var i = 0; i < input.Length; i++)
        {
            (var key, var value) = input[i];
            var actual = sut.Insert(key, value);
            Assert.Equal(expected[i], actual);
        }
    }
}