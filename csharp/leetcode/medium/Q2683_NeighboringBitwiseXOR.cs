public class Q2683_NeighboringBitwiseXOR
{
    public bool DoesValidArrayExist(int[] derived)
    {
        var len = derived.Length;
        if (len == 1) return false;

        var original = new int[len];
        // get the first guess
        if (derived[0] == 0)
        {
            original[0] = 0;
            original[1] = 0;

            for (var i = 1; i < len; i++)
            {
                if (derived[i] == 0)
                {
                    if (original[i] == 0)
                    {
                        original[i + 1] = 0;
                    }
                }
                 
                if (i == len - 1)
                    {

                    }
            }
        }
        return false;
    }

    // need to use recursion
    private bool Recur(int[] derived, int[] original)
    {
        return false;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[1,1,0], true},
        {[1,1], true},
        {[1,0], false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = DoesValidArrayExist(input);
        Assert.Equal(expected, actual);
    }
}
