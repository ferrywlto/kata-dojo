public class Q1963_MinNumberOfSwapsToMakeStringBalanced
{
    // Poor description and name, the question didn't need the answer to be symmetric.
    // TC: O(n)
    // SC: O(1)
    public int MinSwaps(string s)
    {
        var swapCount = 0;
        var imbalance = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '[')
            {
                imbalance++;
            }
            else
            {
                if (imbalance == 0)
                {
                    // It means ] > [, that means must need a swap from the right of current position. 
                    swapCount++;
                    // Open bracket swapped to the front therefore imbalance need to increment. 
                    imbalance++;
                }
                else
                {
                    imbalance--;
                }
            }
        }
        return swapCount;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"][][", 1},
        {"]]][[[", 2},
        {"[]", 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinSwaps(input);
        Assert.Equal(expected, actual);
    }
}
