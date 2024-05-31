class Q1046_LastStoneWeight
{
    // TC: O(n^2), n is length of stones, it needs to run n-1 times in while loop
    // and  
    // SC: O(n), n is the length of list
    public int LastStoneWeight(int[] stones)
    {
        if (stones.Length == 1) return stones[0];

        var list = stones.ToList();
        
        while(list.Count > 1)
        {
            list.Sort();
            var diff = Math.Max(list[^1], list[^2]) - Math.Min(list[^1], list[^2]);
            list.RemoveAt(list.Count - 1);    
            list.RemoveAt(list.Count - 1);
            list.Add(diff);    
        }

        return list[0];
    }
}

class Q1046_LastStoneWeightTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{2,7,4,1,8,1}, 1],
        [new int[]{1}, 1],
    ];
}

public class Q1046_LastStoneWeightTests
{
    [Theory]
    [ClassData(typeof(Q1046_LastStoneWeightTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1046_LastStoneWeight();
        var actual = sut.LastStoneWeight(input);
        Assert.Equal(expected, actual);
    }
}