public class Q4049_CountValuesWithEquallySpacedOccurrencesII
{
    // TC: O(n)
    // SC: O(n), worst case if all elements are unique.
    public int CountSpecialIntegers(int[] nums)
    {
        var posDict = new Dictionary<int, List<int>>();
        var countDict = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var n = nums[i];
            if (!posDict.ContainsKey(n))
                posDict.Add(n, []);

            if (countDict.TryGetValue(n, out var count))
                countDict[n] = count + 1;
            else
                countDict.TryAdd(n, 1);

            posDict[n].Add(i);
        }

        var result = 0;
        foreach (var countPair in countDict)
        {
            if (countPair.Value <= 2) continue;

            var positions = posDict[countPair.Key];
            var diff = positions[1] - positions[0];
            var same = true;
            for (var i = 2; i < positions.Count; i++)
            {
                if (positions[i] - positions[i - 1] == diff) continue;
                same = false;
                break;
            }

            if (!same) continue;
            result++;
        }

        return result;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 8, 1, 5, 1, 5, 8, 5], 2 },
        { [8, 8, 8, 8], 1 },
        { [8, 8, 6, 6, 8], 0 },
        {
            [
                24, 36, 36, 58, 20, 5, 79, 80, 79, 32, 83, 38, 64, 53, 71, 62, 8, 12, 36, 50, 18, 54, 26, 83, 68, 32,
                81,
                70, 3, 49, 92, 46, 62, 70, 63, 45, 73, 65, 42, 50, 35, 24, 4, 41, 77, 29, 4, 100, 36, 8, 61, 68, 46, 99,
                75,
                30, 21, 13, 32, 85, 31, 35, 69, 95, 8, 98, 29, 74, 50, 46, 23, 23, 31, 76, 41, 95, 90, 46, 76, 4, 91,
                90,
                46, 73, 73, 19, 73, 25, 64, 70, 40, 23, 63, 5, 12, 8, 30, 78, 29, 3, 68, 62, 1, 43, 79, 26, 17, 44, 92,
                23,
                42, 8, 3, 19, 76, 91, 19, 100, 15, 68, 47, 10, 48, 91, 85, 51, 76, 13, 44, 39, 42, 18, 21, 94, 56, 82,
                63,
                84, 41, 23, 91, 72, 89, 79, 46, 29, 86, 76, 23, 49, 40, 94, 89, 38, 17, 23, 94, 1, 90, 74, 51, 99, 73,
                5,
                24, 78, 41, 79, 29, 82, 73, 14, 64, 19, 43, 96, 10, 31, 45, 41, 22, 82, 12, 91, 86, 82, 94, 43, 58, 2,
                34,
                27, 32, 89, 9, 45, 33, 14, 93, 1, 7, 50, 57, 94, 54, 22, 53, 64, 49, 45, 70, 49, 13, 62, 74, 84, 98, 88,
                29,
                21, 58, 10, 5, 38, 3, 41, 34, 14, 10, 44, 22, 49, 21, 94, 10, 71, 12, 44, 77, 79, 62, 91, 4, 56, 84, 22,
                78,
                56, 21, 7, 13, 43, 27, 25, 53, 90, 71, 93, 94, 70, 34, 85, 37, 39, 31, 13, 7, 51, 74, 71, 63, 20, 7, 47,
                1,
                55, 12, 38, 85, 81, 77, 62, 26, 13, 4, 27, 22, 82, 38, 11, 61, 15, 40, 51, 61, 63, 85, 34, 12, 83, 70,
                50,
                24, 48, 49, 48, 24, 58, 6, 34, 57, 60, 34, 29, 35, 73, 8, 20, 97, 90
            ],
            0
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountSpecialIntegers(input);
        Assert.Equal(expected, actual);
    }
}
