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

// TC: O(n log n) version
public int LastStoneWeight_Faster(int[] stones)
{
    // Use binary search tree to make max finding time to O(log n)
    var bst = new SortedSet<(int weight, int index)>();
    for (int i = 0; i < stones.Length; i++)
    {
        bst.Add((stones[i], i));
    }

    while (bst.Count > 1)
    {
        var stone1 = bst.Max;
        bst.Remove(stone1);
        var stone2 = bst.Max;
        bst.Remove(stone2);

        if (stone1.weight != stone2.weight)
        {
            bst.Add((stone1.weight - stone2.weight, stone1.index));
        }
    }

    return bst.Count > 0 ? bst.Max.weight : 0;
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
        var actual = sut.LastStoneWeight_Faster(input);
        Assert.Equal(expected, actual);
    }
}