public class Q4002_CountValidSequences
{
    /*
    Tried:
    - built the sequence generator.
    - recognized that one even number makes the entire product even.
    - noticed that enumerating every completion prevents the shortcut.
    - attempt to count all possible even sequence is impossible.
    - independently reached the important idea: count everything, then subtract the all-odd cases.
    */
    private const long Mod = 1_000_000_007;
    private long[] factorial = [];
    private long[] inverseFactorial = [];
    public int CountValidSequences(int n, int k)
    {
        // cache for avoid recalculating factorial in multiple nCr calculations
        factorial = new long[n + 1];
        inverseFactorial = new long[n + 1];

        factorial[0] = 1;

        for (var i = 1; i <= n; i++)
        {
            factorial[i] = factorial[i - 1] * i % Mod;
        }

        inverseFactorial[n] = Power(factorial[n], Mod - 2);

        for (var i = n; i > 0; i--)
        {
            inverseFactorial[i - 1] =
                inverseFactorial[i] * i % Mod;
        }

        // code above are just for caching, not related to solving this
        // n numbers has n - 1 gaps between each number
        var gaps = n - 1;
        // group the numbers into k groups means place k - 1 dividers
        var dividers = k - 1;
        var total = Combination(gaps, dividers);

        long allOdd = 0;

        var unitsAfterInitialOnes = n - k;

        if (unitsAfterInitialOnes % 2 == 0)
        {
            // To keep every value odd, units must be added in groups of two: (each time add 2)
            var pairs = unitsAfterInitialOnes / 2;
            // Distribute x identical pair of unit among k positions,
            // allowing zero items per position:

            // Combination(x + k - 1, k - 1)
            // it is about encoding the pair and divider symbols like PP | | and P | P |
            // forget it for now if cannot understand them
            var pairsAndDividers = pairs + dividers;

            allOdd = Combination(
                pairsAndDividers,
                dividers);
        }
        // if remaining after placing 1 into each sequence element is odd, that means not possible to achieve all odd.
        return (int)((total - allOdd + Mod) % Mod);
    }
    // For calculating nCr, forget about the inverseFactorial,
    // it use inverse modulo to prevent overflow as question asked to keep only reminder % 1_000_000_007
    // So modular arithmetic replaces division with an “undo number.”
    // Don't try to understand it right now.
    private long Combination(int count, int choose)
    {
        if (choose < 0 || choose > count)
            return 0;

        return factorial[count]
                * inverseFactorial[choose] % Mod
                * inverseFactorial[count - choose] % Mod;
    }
    // Same that don't try to understand it right now.
    private static long Power(long value, long exponent)
    {
        long result = 1;

        while (exponent > 0)
        {
            if ((exponent & 1) == 1)
            {
                result = result * value % Mod;
            }

            value = value * value % Mod;
            exponent >>= 1;
        }

        return result;
    }

    public static TheoryData<int, int, int> TestData => new()
    {
        {5, 3, 3},
        {3, 2, 2},
        {5, 5, 0},
        {35, 19, 202399141},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int k, int expected)
    {
        var actual = CountValidSequences(n, k);
        Assert.Equal(expected, actual);
    }
}
