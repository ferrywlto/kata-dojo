public class Q2515_ShortestDistanceToTargetStringInCircularArray
{
    public int ClosetTarget(string[] words, string target, int startIndex)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"hello","i","am","leetcode","hello"}, "hello", 1, 1],
        [new string[] {"a","b","leetcode"}, "leetcode", 0, 1],
        [new string[] {"i","eat","leetcode"}, "ate", 0, -1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string target, int idx, int expected)
    {
        var actual = ClosetTarget(input, target, idx);
        Assert.Equal(expected, actual);
    }

}