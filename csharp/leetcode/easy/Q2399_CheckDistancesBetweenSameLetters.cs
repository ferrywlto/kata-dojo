public class Q2399_CheckDistancesBetweenSameLetters
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input, it is always size 26 array 
    public bool CheckDistances(string s, int[] distance)
    {
        var pos = new int[26];

        for (var i = 0; i < s.Length; i++)
        {
            var idx = s[i] - 'a';
            if (pos[idx] == 0) pos[idx] = i + 1;
            else if (i - pos[idx] != distance[idx]) return false;
        }
        return true;
    }
    public static List<object[]> TestData =>
    [
        ["abaccb", new int[] {1,3,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, true],
        ["aa", new int[] {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int[] d, bool expected)
    {
        var actual = CheckDistances(input, d);
        Assert.Equal(expected, actual);
    }
}