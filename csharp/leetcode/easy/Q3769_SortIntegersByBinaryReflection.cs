// Licensed to the .NET Foundation under one or more agreements.

namespace Leetcode.Easy;

public class Q3769_SortIntegersByBinaryReflection
{
    public int[] SortByReflection(int[] nums)
    {
        return [];
    }

    public static TheoryData<int[], int[]> TestData = new TheoryData<int[], int[]>
    {
        { [4, 5, 4], [4, 4, 5] },
        { [3,6,5,8], [8,3,6,5] },
    };
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int[] expected)
    {
        var actual = SortByReflection(nums);
        Assert.Equal(expected, actual);
    }
}
