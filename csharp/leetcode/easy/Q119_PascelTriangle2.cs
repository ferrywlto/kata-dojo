
public class Q119_PascelTriangle2TestData : IEnumerable<object[]>
{
    private readonly List<object[]> _data =
    [
        [0, new List<IList<int>>{new List<int>() {1}}],
        [1, new List<IList<int>>{new List<int>() {1, 1}}],
        [2, new List<IList<int>>{new List<int>() {1, 2, 1}}],
        [3, new List<IList<int>>{new List<int>() {1, 3, 3, 1}}],
        [4, new List<IList<int>>{new List<int>() {1, 4, 6, 4, 1}}],
    ];

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}
public class Q119_PascelTriangle2Tests
{
    [Theory]
    [ClassData(typeof(Q119_PascelTriangle2TestData))]
    public void OfficialTestCases(int nthRow, IList<int> expected) {
        var sut = new Q119_PascelTriangle2();
        var actual = sut.GetRow(nthRow);
        Assert.True(Enumerable.SequenceEqual(expected, actual));
     }
}

/*
Constraints:
0 <= rowIndex <= 33
*/
public class Q119_PascelTriangle2
{
    public IList<int> GetRow(int rowIndex)
    {
        return new List<int>();
    }
}