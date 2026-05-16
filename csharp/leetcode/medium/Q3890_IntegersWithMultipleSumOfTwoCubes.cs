public class Q3890_IntegersWithMultipleSumOfTwoCubes
{
    // TC: O(n^2), dominated by nested loop
    // SC: O(n), n scaled by the size of n
    public IList<int> FindGoodIntegers(int n)
    {
        var cube = 0;
        var curr = 1;
        var cubes = new List<int>();
        while (cube < n)
        {
            cube = Cube(curr++);
            cubes.Add(cube);
        }

        var sums = new HashSet<int>();
        var good = new HashSet<int>();
        for (var b = 0; b < cubes.Count; b++)
        {
            for (var a = 0; a <= b; a++)
            {
                var sum = cubes[a] + cubes[b];
                if (sum > n) continue;

                if (!sums.Add(sum)) good.Add(sum);
            }
        }

        var result = good.ToList();
        result.Sort();
        return result;
    }
    private int Cube(int input) => input * input * input;

    public static TheoryData<int, List<int>> TestData => new()
    {
        { 4104, [1729, 4104] },
        { 578, [] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, List<int> expected)
    {
        var actual = FindGoodIntegers(input);
        Assert.Equal(expected, actual);
    }
}
