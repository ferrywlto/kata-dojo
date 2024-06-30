class Q1337_TheWeakestRowsInMatrix
{
    // TC: O(n), scale on number of 1s in matrix + k
    // SC: O(n), scale on number of distinct soliders, worse case each row have distinct number of soliders thus n entries in dictionary + k space for result holding list  
    public int[] KWeakestRows(int[][] mat, int k)
    {
        var dict = new SortedDictionary<int, List<int>>();
        for(var i=0; i<mat.Length; i++)
        {
            var row = mat[i];
            var soliders = 0;
            for(var j=0; j<row.Length; j++)
            {
                if (row[j] == 0) break;
                soliders++;
            }
            if(dict.TryGetValue(soliders, out var list)) list.Add(i);
            else dict.Add(soliders, [i]);
        }
        
        var result = new List<int>();
        foreach(var pair in dict)
        {
            var list = pair.Value;
            foreach(var l in list)
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