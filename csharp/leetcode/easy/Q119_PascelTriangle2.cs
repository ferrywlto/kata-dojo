namespace dojo.leetcode;

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
    // TC: still O(n^2), SC: Improved from O(n^2) to O(n)
    public IList<int> GetRow(int rowIndex)
    {
        // because the tests are zero based
        rowIndex++;
        var input = new List<int>() { 1 };
        if (rowIndex == 1) return input;
        else if(rowIndex == 2) {
            input.Add(1);
            return input;
        }

        // The main idea is, the next row is always having one more element than the previous row.
        // therefore we can either doing right to left by updating each element by adding the next element and then insert 1 at the beginning
        // or we can do it in reverse, update each elemeng by adding the previous element and then append 1 at the end
        // doing the reverse way is more efficient because .Add() is O(1) while .Insert() is O(n)
        for (var j = 1; j < rowIndex; j++)
        {
            // add generated from input 
            for (var i = input.Count - 1; i >= 1; i--)
            {
                input[i] = input[i] + input[i- 1];
            }
            // append 1 at the end
            input.Add(1);
        }
        return input;
    }
}