class Q414_ThirdMaximum
{
    // TC: O(n long n), SC: O(n)
    public int ThirdMax_Trival(int[] nums)
    {
        Array.Sort(nums);
        var list = nums.Distinct().Reverse().ToArray();
        return list.Length < 3 ? list[0] : list[2];
    }

    private int? Largest = null;
    private int? SecondLargest = null;
    private int? ThirdLargest = null;

    // TC: O(n), SC: O(1)
    public int ThirdMax_ThreeVars(int[] nums)
    {
        for (var i=0; i<nums.Length; i++)
        {
            UpdateLargest(nums[i]);
        }
        return (int)(ThirdLargest??Largest!);
    }

    public void UpdateLargest(int input)
    {
        if (input == Largest || input == SecondLargest || input == ThirdLargest) 
            return;

        if (Largest == null || input > Largest) 
        {
            ThirdLargest = SecondLargest;
            SecondLargest = Largest;
            Largest = input;
        }
        else if (SecondLargest == null || input > SecondLargest)
        {
            ThirdLargest = SecondLargest;
            SecondLargest = input;
        }
        else if (ThirdLargest == null || input > ThirdLargest)
        {
            ThirdLargest = input;
        }
    }
}

class Q414_ThirdMaximumTestData: TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {3, 2, 1}, 1],
        [new int[] {1, 2}, 2],
        [new int[] {2, 2, 3, 1}, 1],
        [new int[] {1, 1, 2}, 2],
        [new int[] {1, 2, int.MinValue}, int.MinValue],
        [new int[] {int.MinValue, int.MinValue, int.MinValue}, int.MinValue],
    ];
}

public class Q414_ThirdMaximumTests
{
    [Theory]
    [ClassData(typeof(Q414_ThirdMaximumTestData))]
    public void OfficerTestCase(int[] input, int expected)
    {
        var sut = new Q414_ThirdMaximum();
        var actual = sut.ThirdMax_ThreeVars(input);
        Assert.Equal(expected, actual);
    }
}