
public class Q118_PascalTriangleTestsData : IEnumerable<object[]>
{
    private readonly List<object[]> _data =
    [
        [1, new List<IList<int>>{new List<int>() {1}}],
        [5, new List<IList<int>>{
            new List<int>() {1},
            new List<int>() {1, 1},
            new List<int>() {1, 2, 1},
            new List<int>() {1, 3, 3, 1},
            new List<int>() {1, 4, 6, 4, 1},
            }
        ],
    ];

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Q118_PascalTriangleTests
{
    [Theory]
    [ClassData(typeof(Q118_PascalTriangleTestsData))]
    public void OfficialTestCases(int numRows, IList<IList<int>> expected)
    {
        var sut = new Q118_PascalTriangle();
        var actual = sut.Generate(numRows);
        var expectedList = expected.Select(x => x.ToList()).ToList();

        for (var i = 0; i < expectedList.Count; i++)
        {
            Assert.True(Enumerable.SequenceEqual(expectedList[i], actual[i]));
        }
    }
}
public class Q118_PascalTriangle
{
    // TC: O(n^2), SC: O(n^2) - Cannot be improved as we need to return the entire triangle
    public IList<IList<int>> Generate(int numRows)
    {
        var output = new List<IList<int>>() { new List<int> { 1 } };
        for (var i = 0; i < numRows - 1; i++)
        {
            output.Add(GenerateNext(output[i]));
        }
        return output;
    }

    // TC: O(n), SC: O(n)
    // The charactristics of Pascal's triangle the number of elements N in last row will produce N-1 elements in the next row between the starting and ending 1 
    public static IList<int> GenerateNext(IList<int> input)
    {
        // set the starting 1
        var output = new List<int>{1};

        // add generated from input 
        for (var i = 0; i < input.Count - 1; i++)
        {
            output.Add(input[i] + input[i + 1]);
        }

        // set the ending 1
        output.Add(1);

        return output;
    }
}