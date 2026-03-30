public class Q3881_DirectionAssignmentsWithExactlyKVisiblePeople
{
    // Question provided mod, it is a prime.
    const long MOD = 1_000_000_007;

    
    public int CountVisiblePeople(int n, int pos, int k)
    {
        // The trick here is we doesn't need to separate the question into left and right part.
        // For total k people visible:
        // There must be N 'R' on the left side and M 'L' on the right side.
        // Essentially total N 'R'/'L' in both sides, which is a bit combination. 
        var combinations = NcR(n - 1, k);

        // * 2 because the pos always have 2 variations 'L'/'R'
        var result = (combinations * 2) % MOD;
        return (int)result;
    }

    long NcR(int n, int k)
    {
        if (k < 0 || k > n) return 0;
        if (k == 0 || k == n) return 1;

        k = Math.Min(k, n - k);
        long result = 1;

        for (var i = 1; i <= k; i++)
        {
            result = result * (n - k + i) % MOD;
            result = result * ModPow(i, MOD - 2) % MOD;
        }

        return result;
    }

    // a^e mod MOD, without ever building the huge number a^e directly.
    // This is binary exponentiation.
    // Instead of doing a * a * a * ... e times, it uses the binary form of e.
    // a^13 = a^8 + a^4 + a^1
    // TC: O(log e)
    long ModPow(long a, long e)
    {
        long result = 1;
        a %= MOD;

        while (e > 0)
        {
            if ((e & 1) == 1) result = result * a % MOD;
            a = a * a % MOD;
            e >>= 1;
        }

        return result;
    }

    public static TheoryData<int, int, int, int> TestData => new()
    {
        { 3, 1, 0, 2 }, { 3, 2, 1, 4 }, { 1, 0, 0, 2 },
        {63, 33, 30, 119696362}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int pos, int k, int expected)
    {
        var actual = CountVisiblePeople(n, pos, k);
        Assert.Equal(expected, actual);
    }
}
