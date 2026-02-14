public class Q2515_ShortestDistanceToTargetStringInCircularArray
{
    // TC: O(n), n sacle with length of words
    // SC: O(1), space used does not scale with input
    public int ClosetTarget(string[] words, string target, int startIndex)
    {
        var distance = -1;
        var step = 0;
        var initIdx = startIndex;
        var n = words.Length;
        //clockwise
        while (step < n)
        {
            if (words[initIdx] == target)
            {
                distance = step;
                break;
            }
            step++;
            initIdx = initIdx == n - 1 ? 0 : (initIdx + 1);
        }
        //anti-clockwise
        step = 0;
        initIdx = startIndex;
        while (step < n)
        {
            if (words[initIdx] == target && step < distance)
            {
                distance = step;
                break;
            }
            step++;
            initIdx = initIdx == 0 ? n - 1 : (initIdx - 1);
        }
        return distance;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"hello","i","am","leetcode","hello"}, "hello", 1, 1],
        [new string[] {"a","b","leetcode"}, "leetcode", 0, 1],
        [new string[] {"i","eat","leetcode"}, "ate", 0, -1],
        [new string[] {"i","eat","leetcode"}, "i", 0, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string target, int idx, int expected)
    {
        var actual = ClosetTarget(input, target, idx);
        Assert.Equal(expected, actual);
    }

}
