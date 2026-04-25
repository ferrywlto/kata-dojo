
public class Q3896_MinOperationsToTransformArrayIntoAlternatingPrime
{

    // TC: O(n * g * sqrt(M + g)), n scales with length of nums, g scale with max distance from even-index value to next prime, which sqrt(M + g) is from IsPrime()
    // SC: O(p), p scales with number of prime found in the process
    private static HashSet<int> primes = [2, 3];
    public int MinOperations(int[] nums)
    {
        var result = 0;

        // for primes
        for (var i = 0; i < nums.Length; i += 2)
        {
            var n = nums[i];
            if (n == 1)
            {
                result++;
                continue;
            }

            // Not sure if it is prime
            while (n > 1 && !primes.Contains(n))
            {
                if (IsPrime(n))
                {
                    primes.Add(n);
                    break;
                }

                result++;
                n++;
            }
        }

        // for non-primes
        for (var i = 1; i < nums.Length; i += 2)
        {
            var item = nums[i];
            if (item == 2) { result += 2; continue; }
            if (item % 2 == 0) continue;

            if (primes.Contains(item))
            {
                // Prime must be odd, except 2. So any prime plus one is non-prime.
                result++;
                continue;
            }

            // is odd and not sure if is prime    
            if (IsPrime(item))
            {
                primes.Add(item);
                // any prime plus 1 except 2 must be non-prime
                result++;
            }
        }
        return result;
    }
    private static bool IsPrime(int input)
    {
        if (input <= 1) return false;
        if (input == 2) return true;
        if (input % 2 == 0) return false;
        for (int i = 3; i * i <= input; i += 2)
        {
            if (input % i == 0) return false;
        }
        return true;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 2, 3, 4], 3 },
        { [5, 6, 7, 8], 0 },
        { [4, 4], 1 },
        { [8, 12], 3 },
        { [24, 5, 19, 5], 7 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}
