
class Q1089_DuplicateZeros
{
    // TC: O(n), used queue to limit operations complete in 2 pass, one for duplicate the zeros, one for copying them back
    // SC: O(n), length of arr
    public void DuplicateZeros(int[] arr) 
    {
        // it will use more memory but can avoid O(n!) time, down to O(2n)
        var queue = new Queue<int>();
        var idx = 0;
        while(queue.Count < arr.Length)
        {
            if (arr[idx] != 0) queue.Enqueue(arr[idx]);
            else {
                if(queue.Count < arr.Length) queue.Enqueue(0);
                if(queue.Count < arr.Length) queue.Enqueue(0);
            }
            idx++;
        }
        idx = 0;
        while(queue.Count > 0)
        {
            arr[idx++] = queue.Dequeue();
        }
    }    
}
class Q1089_DuplicateZerosTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,0,2,3,0,4,5,0}, new int[]{1,0,0,2,3,0,0,4}],
        [new int[]{1,2,3}, new int[]{1,2,3}],
    ];
}
public class Q1089_DuplicateZerosTests
{
    [Theory]
    [ClassData(typeof(Q1089_DuplicateZerosTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1089_DuplicateZeros();
        sut.DuplicateZeros(input);
        Assert.Equal(input, expected);
    }
}