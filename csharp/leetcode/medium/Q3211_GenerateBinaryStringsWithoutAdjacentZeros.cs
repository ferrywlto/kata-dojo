using System.Text;

public class Q3211_GenerateBinaryStringsWithoutAdjacentZeros
{
    // TC: O(n^2), n scale with size of n
    // SC: O(2^n)
    public IList<string> ValidStrings(int n)
    {
        var set = new HashSet<string> { "0", "1" };
        var len = 1;
        while (len < n)
        {
            var newSet = new HashSet<string>();
            foreach (var str in set)
            {
                if (str[^1] == '0')
                {
                    newSet.Add(str + '1');
                }
                else
                {
                    newSet.Add(str + '0');
                    newSet.Add(str + '1');
                }
            }
            set = newSet;
            len++;
        }

        return set.ToList();
    }
    public static TheoryData<int, string[]> TestData => new()
    {
        {3, ["010","011","101","110","111"]},
        {1, ["0","1"]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, string[] expected)
    {
        var actual = ValidStrings(input);
        Assert.Equal(expected, actual);
    }
}