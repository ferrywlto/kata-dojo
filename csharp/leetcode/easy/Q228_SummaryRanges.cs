class Q228_SummaryRanges
{
    public IList<string> SummaryRanges(int[] nums)
    {
        if (nums.Length == 1) return [nums[0].ToString()];

        // use 2 int pointers
        int start = 0;
        int end = 0;
        var dict = new Dictionary<int, int>();

        for(var i=0; i<nums.Length-1; i++)
        {
            if(nums[i]+1 != nums[i+1])
            {
                dict.Add(start, end);
                start = i+1;
                end = i+1;

                if (i==nums.Length-2) 
                {
                    dict.Add(start, end);
                }
                continue;
            }

            end++;
            if (i==nums.Length-2) 
            {
                dict.Add(start, end);
            }
        }

        var result = dict
            .Select(x => x.Key == x.Value 
                ? nums[x.Key].ToString() 
                : $"{nums[x.Key]}->{nums[x.Value]}")
            .ToList();

        return result;
    }
}

class Q228_SummaryRangesTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{0, 1, 2, 4, 5, 7}, new string[]{"0->2", "4->5", "7"}],
        [new int[]{0, 2, 3, 4, 6, 8, 9}, new string[]{"0", "2->4", "6", "8->9"}],
        [new int[]{-1}, new string[]{"-1"}],
    ];
}

public class Q228_SummaryRangesTests
{
    [Theory]
    [ClassData(typeof(Q228_SummaryRangesTestData))]
    public void OfficialTestCases(int[] input, string[] expected)
    {
        var sut = new Q228_SummaryRanges();
        var actual = sut.SummaryRanges(input);

        Assert.Equal(expected, actual);
    }
}