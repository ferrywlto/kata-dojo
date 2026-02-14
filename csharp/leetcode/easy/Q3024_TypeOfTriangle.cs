public class Q3024_TypeOfTriangle
{
    // TC: O(1), constant complexity
    // SC: O(1), same as time 
    public string TriangleType(int[] nums)
    {
        if (IsTriangle(nums))
        {
            if (
                nums[0] == nums[1] &&
                nums[0] == nums[2]
            ) return "equilateral";
            else if (
                nums[0] == nums[1] ||
                nums[1] == nums[2] ||
                nums[2] == nums[0]
            ) return "isosceles";
            else return "scalene";
        }
        return "none";
    }
    public bool IsTriangle(int[] input) =>
    input[0] + input[1] > input[2] &&
    input[1] + input[2] > input[0] &&
    input[0] + input[2] > input[1];

    public static TheoryData<int[], string> TestData => new()
    {
        {[3,3,3], "equilateral"},
        {[3,4,5], "scalene"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, string expected)
    {
        var actual = TriangleType(input);
        Assert.Equal(expected, actual);
    }
}
