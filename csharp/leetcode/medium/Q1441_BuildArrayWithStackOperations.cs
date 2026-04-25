public class Q1441_BuildArrayWithStackOperations
{
    // TC: O(n), n scale with length of target
    // SC: O(n), for storing the result, otherwise O(1)
    public IList<string> BuildArray(int[] target, int n)
    {
        var list = new List<string>();
        for (var i = 0; i < target.Length; i++)
        {
            var diff = i == 0 ? target[i] : target[i] - target[i - 1];
            if (diff > 1)
            {
                var repeat = diff - 1;
                var pushOps = Enumerable.Repeat("Push", repeat);
                var popOps = Enumerable.Repeat("Pop", repeat);
                list.AddRange(pushOps);
                list.AddRange(popOps);
            }
            list.Add("Push");
        }
        return list;
    }
    public static TheoryData<int[], int, string[]> TestData => new()
    {
        {[1,3], 3, ["Push","Push","Pop","Push"]},
        {[1,3,5,8], 3, ["Push","Push","Pop","Push","Push","Pop","Push","Push","Push","Pop","Pop","Push"]},
        {[1,2,3], 3, ["Push","Push","Push"]},
        {[1,2], 4, ["Push","Push"]},
        {[2,3,4], 4, ["Push","Pop","Push","Push","Push"]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int n, string[] expected)
    {
        var actual = BuildArray(input, n);
        Assert.Equal(expected, actual);
    }
}
