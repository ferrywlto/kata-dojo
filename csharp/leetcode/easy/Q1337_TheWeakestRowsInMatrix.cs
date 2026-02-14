class Q1337_TheWeakestRowsInMatrix
{
    // TC: O(log n), scale on number of 1s in matrix
    // SC: O(m+k), m is number of row, worse case each row have distinct number of soliders + k space for result holding list
    public int[] KWeakestRows(int[][] mat, int k)
    {
        var dict = new SortedDictionary<int, List<int>>();
        for (var i = 0; i < mat.Length; i++)
        {
            var row = mat[i];
            // use binary search
            var start = 0;
            var end = row.Length - 1;
            while (start < end)
            {
                var middle = start + (end - start) / 2;
                if (row[middle] == 1) start = middle + 1;
                else end = middle;
            }
            // After the loop, 'start' should point to the first '0' or be equal to row.Length if all are '1's.
            // To find the number of soldiers (1's), we check if the element at 'start' is a '1' to handle the case where all elements are '1's.
            int soliders = (start == row.Length || row[start] == 0) ? start : start + 1;

            if (dict.TryGetValue(soliders, out var list)) list.Add(i);
            else dict.Add(soliders, [i]);
        }

        var result = new List<int>();
        foreach (var pair in dict)
        {
            var list = pair.Value;
            foreach (var l in list)
            {
                result.Add(l);
                if (result.Count == k) return result.ToArray();
            }
        }
        return result.ToArray();
    }
}
class Q1337_TheWeakestRowsInMatrixTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [1,1,0,0,0],
                [1,1,1,1,0],
                [1,0,0,0,0],
                [1,1,0,0,0],
                [1,1,1,1,1],
            }, 3,
            new int[] {2,0,3}
        ],
        [
            new int[][]
            {
                [1,0,0,0],
                [1,1,1,1],
                [1,0,0,0],
                [1,0,0,0],
            }, 2,
            new int[] {0,2}
        ],
        [
            new int[][]
            {
                [1,0],[0,0],[1,0]
            }, 2,
            new int[] {1,0}
        ]
    ];
}
public class Q1337_TheWeakestRowsInMatrixTests
{
    [Theory]
    [ClassData(typeof(Q1337_TheWeakestRowsInMatrixTestData))]
    public void OfficialTestCases(int[][] input, int k, int[] expected)
    {
        var sut = new Q1337_TheWeakestRowsInMatrix();
        var actual = sut.KWeakestRows(input, k);
        Assert.Equal(expected, actual);
    }
}
