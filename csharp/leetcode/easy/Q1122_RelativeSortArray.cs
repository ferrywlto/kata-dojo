
class Q1122_RelativeSortArray
{
    // TC: O(n log n) due to notInArr2.Sort(), worst case almost all numbers in arr1 is not in arr2
    // SC: O(n), the buckets and dictionary size equals to the size of arr1 + arr2
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        var notInArr2 = new List<int>();
        var arr2Dict = new Dictionary<int, int>();
        var buckets = new List<int>[arr2.Length];
        // initialize buckets
        for(var i=0; i<buckets.Length; i++)
            buckets[i] = [];

        for(var i=0; i<arr2.Length; i++)
            arr2Dict.Add(arr2[i], i);

        for(var i=0; i<arr1.Length; i++)
        {
            if(!arr2Dict.TryGetValue(arr1[i], out var bucketIdx))
                notInArr2.Add(arr1[i]);
            else
                buckets[bucketIdx].Add(arr1[i]);
        }
        var result = new List<int>();
        for(var i=0; i<buckets.Length; i++)
            result.AddRange(buckets[i]);

        notInArr2.Sort();
        result.AddRange(notInArr2);        
        return result.ToArray();
    }
}
class Q1122_RelativeSortArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[] {2,3,1,3,2,4,6,7,9,2,19},
            new int[] {2,1,4,3,9,6},
            new int[] {2,2,2,1,4,3,3,9,6,7,19},
        ],
        [
            new int[] {28,6,22,8,44,17},
            new int[] {22,28,8,6},
            new int[] {22,28,8,6,17,44},
        ]
    ];
}
public class Q1122_RelativeSortArrayTests
{
    [Theory]
    [ClassData(typeof(Q1122_RelativeSortArrayTestData))]
    public void OfficialTestCases(int[] arr1, int[] arr2, int[] expected)
    {
        var sut = new Q1122_RelativeSortArray();
        var actual = sut.RelativeSortArray(arr1, arr2);
        Assert.Equal(expected, actual);
    }
}
