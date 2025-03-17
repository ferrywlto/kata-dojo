public class Q1175_PrimeArrangements
{
    // Since constraint of n is 1<=n<=100, we can cache number of primes in n to speed up 
    // nPn = n!
    // num primes in n == num prime idx in n
    // Total is all permutations from prime indexes * all permutations from non-prime indexes 
    // num of prime ! * num of non-prime !
    static Q1175_PrimeArrangements()
    {
        var temp = new int[101];
        for (var i = 0; i < s_primeList.Count; i++)
        {
            temp[s_primeList[i]] = 1;
        }
        var current = 0;
        for (var j = 0; j < s_numberOfPrimesAt.Length; j++)
        {
            if (temp[j] == 1) current++;
            s_numberOfPrimesAt[j] = current;
        }
        long permutations = 1;
        s_permutations[1] = 1;
        for (var k=2; k<=100; k++) {
            // Modulus the result prevent overflow as instructed in constraints
            permutations = permutations * k % s_reminder;
            s_permutations[k] = permutations;
        }
    }
    static readonly int[] s_numberOfPrimesAt = new int[101];
    static readonly List<int> s_primeList =
    [
        2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
        31, 37, 41, 43, 47, 53, 59, 61, 67,
        71, 73, 79, 83, 89, 97
    ];
    static readonly long s_reminder = (long)Math.Pow(10, 9) + 7;
    static readonly long[] s_permutations = new long[101];

    // TC: O(n), n scale with size of n, worst case 100, thus it can be treat as O(1)
    // SC: O(1), space used does not scale with input
    public int NumPrimeArrangements(int n)
    {
        if(n==1) return 1;
        var countPrimes = s_numberOfPrimesAt[n];
        var countNonPrimes = n - countPrimes;
        var pPrime = s_permutations[countPrimes];
        var pNonPrime = s_permutations[countNonPrimes];

        var total = pPrime * pNonPrime % s_reminder;
        return (int)total;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {5, 12},
        {100, 682289015},
        {1, 1},
        {2, 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = NumPrimeArrangements(input);
        Assert.Equal(expected, actual);
    }
}