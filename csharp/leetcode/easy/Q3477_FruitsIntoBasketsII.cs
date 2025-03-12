public class Q3477_FruitsIntoBasketsII
{
    // TC: O(n*m), n scale with length of fruits and m scale with length of baskets
    // SC: O(1), space used does not scale with input
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        var result = 0;
        for (var i = 0; i < fruits.Length; i++)
        {
            var found = false;
            for (var j = 0; j < baskets.Length; j++)
            {
                if (baskets[j] >= fruits[i])
                {
                    baskets[j] = -1;
                    found = true;
                    break;
                }
            }
            if (!found) result++;
        }

        return result;
    }
    public static TheoryData<int[], int[], int> TestData => new()
    {
        {[4,2,5], [3,5,4], 1},
        {[3,6,1], [6,4,7], 0},
        {[8,5], [1,8], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int expected)
    {
        var actual = NumOfUnplacedFruits(input1, input2);
        Assert.Equal(expected, actual);
    }
}