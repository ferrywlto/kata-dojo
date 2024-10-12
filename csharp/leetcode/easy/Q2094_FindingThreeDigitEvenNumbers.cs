public class Q2094_FindingThreeDigitEvenNumbers(ITestOutputHelper output)
{
    // Correct implmentation
    // Digits to find always within 100-998, just need to check if all digits can be find in array...
    // TC: O(n), the n scale with length of digits for the globalDict, the main calculation is 888/2 * m where m is number of unique digit in digits
    // SC: O(m), m scale with the number of unique digit in digits, plus as most (998 - 100) / 2 = 444 entries for result 
    public int[] FindEvenNumbers(int[] digits)
    {
        var globalDict = digits.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var result = new List<int>();
        for (var i = 100; i <= 998; i += 2)
        {
            var temp = i;
            var localDict = new Dictionary<int, int>();
            while (temp > 0)
            {
                var digit = temp % 10;
                if (localDict.TryGetValue(digit, out var val))
                {
                    localDict[digit] = ++val;
                }
                else localDict.Add(digit, 1);
                temp /= 10;
            }
            var match = true;
            foreach (var p in localDict)
            {
                if (!globalDict.ContainsKey(p.Key) || globalDict[p.Key] < p.Value)
                {
                    match = false;
                    break;
                }
            }

            if (match) result.Add(i);
        }
        return result.ToArray();
    }


    // Below is brute force approach that find all possible combinations
    int[]? _d = null;
    readonly HashSet<int> result = [];
    public int[] FindEvenNumbers_BruteForceCombinations(int[] digits)
    {
        _d = digits;
        RecursiveInnerProduct(digits, 0, 3, []);
        var l = result.Select(x => string.Join(',', x));
        output.WriteLine(string.Join(Environment.NewLine, l));

        var sorted = result
            .Order()
            .ToArray();
        return sorted;
    }
    private int ConstructThreeDigitNumberFromDigits(List<int> input)
    {
        return _d![input[0]] * 100 +
        _d[input[1]] * 10 +
        _d[input[2]];
    }

    private void RecursiveInnerProduct(int[] input, int depth, int depthMax, List<int> list)
    {
        if (depth == depthMax)
        {
            result.Add(ConstructThreeDigitNumberFromDigits(list));
            return;
        }

        for (var i = 0; i < input.Length; i++)
        {
            var n = input[i];
            if (depth == 0 && n == 0) continue;
            else if (depth == depthMax - 1 && n % 2 != 0) continue;
            else if (list.Contains(i)) continue;

            list.Add(i);
            RecursiveInnerProduct(input, depth + 1, depthMax, list);
            list.RemoveAt(list.Count - 1);
        }
    }
    public static List<object[]> TestData =>
    [
        [new int[] {2,1,3,0}, new int[] {102,120,130,132,210,230,302,310,312,320}],
        [new int[] {2,2,8,8,2}, new int[] {222,228,282,288,822,828,882}],
        [new int[] {3,7,5}, Array.Empty<int>()],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = FindEvenNumbers(input);
        Assert.Equal(expected, actual);
    }
}