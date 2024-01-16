
namespace dojo.leetcode;

public class Q217_ContainsDuplicate
{
    // Inefficient way first
    // TC:O(n), SC:O(n)
    public bool ContainsDuplicate(int[] nums)
    {
        var dict = new Dictionary<int, int>();

        for (var i=0; i<nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i])) 
            {
                dict[nums[i]]++;
            }
            else
            {
                dict.Add(nums[i], 1);
            }
        }

        return dict.Any(x => x.Value > 1);
    }
}

public class Q217_ContainsDuplicateTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [
            new int[]{1,2,3,1},
            true
        ],
        [
            new int[]{1,2,3,4},
            false,
        ],
        [
            new int[]{1,1,1,3,3,4,3,2,4,2},
            true
        ]
    ];
}

public class Q217_ContainsDuplicateTests(ITestOutputHelper output) : BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q217_ContainsDuplicateTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q217_ContainsDuplicate();
        var actual = sut.ContainsDuplicate(input);
        Assert.Equal(expected, actual);
    }
}