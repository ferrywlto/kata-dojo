public class Q2900_LongestUnequalAdjacentGroupsSubsequenceI(ITestOutputHelper output)
{
    public IList<string> GetLongestSubsequence(string[] words, int[] groups)
    {
        var longestLen = -1;
        List<int> longestIdxList = new();
        for (var i=0; i<groups.Length; i++)
        {
            var currentList = new List<int> {i};
            var last = groups[i];
            for(var j=i+1; j<groups.Length; j++)
            {
                if(groups[j] != last) {
                    currentList.Add(j);
                    last = groups[j];
                }
            }
            output.WriteLine("list: [{0}], count: {1}", string.Join(',', currentList), currentList.Count);
            if (currentList.Count > longestLen)
            {
                longestLen = currentList.Count;
                longestIdxList = currentList;
            }
            if (groups.Length < longestLen) 
            {
                break;
            }
        }
        return [.. longestIdxList.Select(x => words[x])];
    }
    public static TheoryData<string[], int[], List<string>> TestData => new()
    {
        {["e","a","b"], [0,0,1], ["e","b"]},
        {["a","b","c","d"], [1,0,1,1], ["a","b","c"]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int[] groups, List<string> expected)
    {
        var actual = GetLongestSubsequence(input, groups);
        Assert.Equal(expected, actual);
    }
}