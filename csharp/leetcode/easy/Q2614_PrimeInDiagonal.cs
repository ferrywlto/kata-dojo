public class Q2614_PrimeInDiagonal
{
    // TC: O(n), n scale with elements in diagonal
    // SC: O(m), m scale with unique numbers in diagonal for cache
    public int DiagonalPrime(int[][] nums)
    {
        var n = nums.Length;
        var largest = 0;
        for (var i = 0; i < n; i++)
        {
            var item = nums[i][i];
            if (IsPrime(item))
            {
                if (item > largest)
                    largest = item;
            }
            var lastIdx = n - i - 1;
            item = nums[i][lastIdx];
            if (IsPrime(item))
            {
                if (item > largest)
                    largest = item;
            }
        }
        return largest;
    }
    Dictionary<int, bool> PrimeTable = [];
    public bool IsPrime(int input)
    {
        if (PrimeTable.TryGetValue(input, out var val)) return val;
        if (input <= 1) return false;
        if (input == 2) return true;
        if (input % 2 == 0) return false;
        for (var i = 3; i * i <= input; i += 2)
        {
            if (input % i == 0)
            {
                PrimeTable.Add(input, false);
                return false;
            }
        }
        PrimeTable.Add(input, true);
        return true;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {
            new int[][]
            {
                [1,2,3],
                [5,6,7],
                [9,10,11],
            }, 11
        },
        {
            new int[][]
            {
                [1,2,3],
                [5,17,7],
                [9,11,10],
            }, 17
        },
        {
            new int[][]
            {
                [788,645,309,559],
                [624,160,435,724],
                [770,483,95,695],
                [510,779,984,238],
            }, 0
        },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = DiagonalPrime(input);
        Assert.Equal(expected, actual);
    }
}
