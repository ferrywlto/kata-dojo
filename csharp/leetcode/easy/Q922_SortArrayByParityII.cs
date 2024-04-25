class Q922_SortArrayByParityII
{
    // TC: O(n), n is length of nums, 2n for worst case that all positions are wrong
    // SC: O(n), n is the number of wrong positions
    public int[] SortArrayByParityII(int[] nums)
    {
        var oddQueue = new Queue<int>();
        var evenQueue = new Queue<int>();
        var idxQueue = new Queue<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (i % 2 == 0 && nums[i] % 2 == 1)
            {
                oddQueue.Enqueue(nums[i]);
                // Swap with available correct values to shrink the queues
                if (evenQueue.Count > 0)
                {
                    nums[i] = evenQueue.Dequeue();
                }
                else
                {
                    idxQueue.Enqueue(i);
                }
            }
            else if (i % 2 == 1 && nums[i] % 2 == 0)
            {
                evenQueue.Enqueue(nums[i]);
                if (oddQueue.Count > 0)
                {
                    nums[i] = oddQueue.Dequeue();
                }
                else
                {
                    idxQueue.Enqueue(i);
                }
            }
        }
        while (idxQueue.Count > 0)
        {
            var idx = idxQueue.Dequeue();
            if (idx % 2 == 0)
            {
                nums[idx] = evenQueue.Dequeue();
            }
            else
            {
                nums[idx] = oddQueue.Dequeue();
            }
        }
        return nums;
    }
}

class Q922_SortArrayByParityIITestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{4,2,5,7}, new int[]{4,5,2,7}],
        [new int[]{2,3}, new int[]{2,3}],
        [new int[]{2,3,1,1,4,0,0,4,3,3}, new int[]{2,3,4,1,4,1,0,3,0,3}],
    ];
}

public class Q922_SortArrayByParityIITests
{
    [Theory]
    [ClassData(typeof(Q922_SortArrayByParityIITestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q922_SortArrayByParityII();
        var actual = sut.SortArrayByParityII(input);
        Assert.Equal(expected, actual);
    }
}