public class Q2404_MostFrequentEvenElement
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique even numbers in nums
    public int MostFrequentEven(int[] nums)
    {
        var evens = new Dictionary<int, int>();
        var smallest = int.MaxValue;
        var highestFrequency = int.MinValue;
        foreach (var n in nums)
        {
            if (n % 2 != 0) continue;

            if (evens.TryGetValue(n, out var val)) evens[n] = ++val;
            else evens.Add(n, 1);

            if (evens[n] > highestFrequency)
            {
                highestFrequency = evens[n];
                smallest = n;
            }
            else if (evens[n] == highestFrequency && n < smallest)
            {
                smallest = n;
            }
        }
        return smallest != int.MaxValue ? smallest : -1;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {0,1,2,2,4,4,1}, 2],
        [new int[] {4,4,4,9,2,4}, 4],
        [new int[] {29,47,21,41,13,37,25,7}, -1],
        [new int[] {10000}, 10000],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MostFrequentEven(input);
        Assert.Equal(expected, actual);
    }
}
