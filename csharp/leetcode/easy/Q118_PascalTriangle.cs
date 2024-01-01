
public class Q118_PascalTriangleTestsData : IEnumerable<object[]>
{
    private readonly List<object[]> _data =
    [
        [1, new List<List<int>>{new() {1}}],
        [5, new List<List<int>>{
            new() {1},
            new() {1, 1},
            new() {1, 2, 1},
            new() {1, 3, 3, 1},
            new() {1, 4, 6, 4, 1},
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
    public void OfficialTestCases(int numRows, List<List<int>> expected) 
    {
        var sut = new Q118_PascalTriangle();
        var actual = sut.Generate(numRows);
        var expectedList = expected.Select(x => x.ToList()).ToList();
        
        for(var i = 0; i < expectedList.Count; i++)
        {
            Assert.True(Enumerable.SequenceEqual(expectedList[i], actual[i]));
        }
    }
}
public class Q118_PascalTriangle 
{
    public IList<IList<int>> Generate(int numRows) {
        return new List<IList<int>>(){new List<int>(){1}};
    }
}