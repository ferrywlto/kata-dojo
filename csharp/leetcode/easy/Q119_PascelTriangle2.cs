
public class Q119_PascelTriangle2TestData : IEnumerable<object[]>
{
    private readonly List<object[]> _data =
    [
        [0, new List<int>() {1}],
        [1, new List<int>() {1, 1}],
        [2, new List<int>() {1, 2, 1}],
        [3, new List<int>() {1, 3, 3, 1}],
        [4, new List<int>() {1, 4, 6, 4, 1}],
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
    // input must start and end with 1
    public IList<int> GetRow(int rowIndex)
    {
        // because the tests are zero based
        rowIndex++;
        var input = new List<int>() { 1 };
        if (rowIndex == 1) return input;
        else if(rowIndex == 2) {
            input.Insert(0, 1);
            return input;
        }

        for (var j = 1; j < rowIndex; j++)
        {
            // add generated from input 
            for (var i = 0; i < input.Count - 1; i++)
            {
                input[i] = input[i] + input[i + 1];
            }
            // set the last to 1;
            input[input.Count - 1] = 1;
            // append 1 at the beginning
            input.Insert(0, 1);
        }
        return input;
    }
}