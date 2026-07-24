public class Q1442_CountTripletsThatCanFormTwoArraysOfEqualXor
{
    // TC: O(n^2)
    // SC: O(n)
    /* facts
    L = XOR of left part
    R = XOR of right part
    if L == R that means L ^ R == 0
    so if xor(arr[i..k]) == 0, if arr[i..k] length is x, then it can has x - 1 splits
    */
    public int CountTriplets(int[] arr)
    {
        var len = arr.Length;
        Span<int> xor = stackalloc int[len];
        xor[0] = arr[0];

        // do triangular prefix xor
        var result = 0;
        for (var i = 1; i < len; i++)
        {
            xor[i] = xor[i - 1] ^ arr[i];
            // consider prefix [2,1,0,6,1], the 0 is from 2,3,1, which has length 3, add len - 1 to result means 2, which is i
            // has the following possible splits
            // [2] | [3, 1] => 0
            // [2, 3] | [1] => 0
            if (xor[i] == 0)
                result += i;
        }

        for (var i = 1; i < len; i++)
        {
            for (var j = i; j < len; j++)
            {
                xor[j] ^= arr[i - 1];
                if (xor[j] == 0)
                    // consider the following:
                    /*
                        [2,1,0,6,1]
                        [0,3,2,4,3]
                        [0,0,1,7,0]
                        [0,0,0,6,1]
                        [0,0,0,0,7]
                    */
                    // [0,0,1,7,0], means xor from[idx 2 to 4], which has length of 3. Add length - 1 to result, (j - i) => 4 - 2 => which is 2.
                    // 1,6,7 can be spilt into:
                    // [1] | [6, 7] => [1] | [1] => 0
                    // [1, 6] | [7] => [7] | [7] => 0
                    result += j - i;
            }
        }

        return result;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {[2,3,1,6,7], 4},
        {[1,1,1,1,1], 10},
        {[218,218], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountTriplets(input);
        Assert.Equal(expected, actual);
    }
}
