public class Q2610_ConvertArrayInto2DArrayWithConditions
{
    public IList<IList<int>> FindMatrix(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        for(var i=0; i<nums.Length; i++)
        {
            var n = nums[i];
            if(dict.TryGetValue(n, out var val))
            {
                dict[n] = ++val;
            }
            else 
            {
                dict.Add(n, 1);
            }
        }

        var result = new List<IList<int>>();
        while(dict.Count > 0)
        {
            var listAdd = new List<int>();
            var listRemove = new List<int>();
            foreach(var p in dict) 
            {
                var k = p.Key;
                listAdd.Add(k);
                dict[k]--;
                if(dict[k] == 0) 
                {
                    listRemove.Add(k);
                }
            }
            for(var i=0; i<listRemove.Count; i++)
            {
                dict.Remove(listRemove[i]);
            }
            result.Add(listAdd);
        }
        return result;
    }
    public static TheoryData<int[], List<List<int>>> TestData => new()
    {
        {
            [1,3,4,1,2,3,1],
            [[1,3,4,2],[1,3],[1]]
        },
        {
            [1,2,3,4],
            [[1,2,3,4]]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, List<List<int>> expected)
    {
        var actual = FindMatrix(input);
        Assert.Equal(expected, actual);
    }
}