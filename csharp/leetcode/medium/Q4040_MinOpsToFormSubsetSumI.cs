public class Q4040_MinOpsToFormSubsetSumI(ITestOutputHelper output)
{
    // TC: O(n * sum/2 * sum)
    // SC: O(sum + 1)
    public int MinOperations(int[] nums, int sum)
    {
        // sum is maximum to 5000
        var oldBoxes = Enumerable.Repeat(int.MaxValue, sum + 1).ToArray();

        // A subset can have 0 elements, to achieve a sum of zero, choose nothing and the cost thus zero.
        oldBoxes[0] = 0;

        // try use buckets sum?
        // nums[n] <= 500, nums.length <= 100 which is relatively small
        // each number can become a list where all elements <= sum. e.g. sum = 4, nums[i] = 10 => 2,1,0
        // how to stack the sum?
        foreach (var num in nums)
        {
            var newBoxes = (int[])oldBoxes.Clone();
            var reachableFromNum = GetReachableValues(num, sum);

            foreach (var (boxesToMoveRight, cost) in reachableFromNum)
            {
                for (var sourceBox = 0; sourceBox + boxesToMoveRight <= sum; sourceBox++)
                {
                    if (oldBoxes[sourceBox] == int.MaxValue) continue;

                    var destinationBox = sourceBox + boxesToMoveRight;
                    var costAfterMoving = oldBoxes[sourceBox] + cost;

                    newBoxes[destinationBox] = Math.Min(newBoxes[destinationBox], costAfterMoving);
                }
            }

            oldBoxes = newBoxes;
        }

        output.WriteLine($"{string.Join(',', oldBoxes)}");
        return oldBoxes[sum] == int.MaxValue ? -1 : oldBoxes[sum];
    }

    private IEnumerable<(int value, int cost)> GetReachableValues(int input, int sum)
    {
        var tmp = input;
        var ops = 0;
        var result = new List<(int value, int cost)>();

        if (tmp <= sum)
        {
            result.Add((tmp, ops));
        }

        while (tmp * 2 <= sum)
        {
            tmp *= 2;
            if (tmp <= sum)
            {
                ops++;
                result.Add((tmp, ops));
            }
        }

        ops = 0;
        tmp = input;
        output.WriteLine($"before divide: {tmp}");
        // value 0 is a useless for counting minimal cost, so doesn't need to add it.
        while (tmp > 1)
        {
            tmp /= 2;
            ops++;
            result.Add((tmp, ops));
        }

        output.WriteLine(string.Join(',', result.Select(r => $"[{r.value}, {r.cost}]")));
        return result;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        // sum 0 cost always 0

        { [5, 6, 10], 4, 3 },

        // clone cost
        // for number 5
        // 5 > 4 => 5, 2, 1
        // sum 5, cost 0
        // sum 2, cost 1
        // sum 1, cost 2

        // for sum 5, cost 0
        // at loop idx = 0, 0 + 5 = 5 > sum, skip loop

        // for sum 2, cost 1
        // at loop idx = 0, 0 + 2 = 2 < sum
        // the loop is to overlay the current (sum, cost) pair over all seen cost
        // cost[0] is seen
        // so clone[0 + 2] => clone[2] = Min(clone[2], cost[0] + 1) => Min(int.Max, 1) = 1
        // at loop idx = 1, 1 + 2 = 3 < sum
        // since clone[1] is not seen, skip this
        // at loop idx = 2, 2 + 2 = 4 = sum
        // since clone[2] already seen at idx = 0,
        // if we work on the same cost array we will use the mixed result
        // that's why a cost clone is needed
        // at loop idx = 3, 3 + 2 = 5 > sum, exit loop
        // clone become [0, ?, 1, ?, ?]

        // for sum 1, cost 2
        // at loop idx = 0, 0 + sum = 1 <= sum
        // cost[0] is seen
        // so clone[0 + 1] => clone[1] = Min(clone[1], cost[0] + 2) => Min(int.Max, 2) = 2
        // at loop idx = 1, 1 + 1 = 2 <= sum
        // cost[1] is not seen (its in clone but not int cost[] yet), skip
        // at loop idx = 2, 2 + 1 = 3 <= sum
        // cost[2] is not seen, skip
        // at loop idx = 3, 3 + 1 = 4 <= sum
        // cost[3] is not seen skip
        // at loop idx = 4, 4 + 1 > sum, skip loop
        // clone become [0, 2, 1, ?, ?]

        // replace cost with clone
        // cost become [0, 2, 1, ?, ?]

        // clone cost
        // for number 6
        // 6 > 4 => 6, 3, 1
        // sum 6, cost 0
        // sum 3, cost 1
        // sum 1, cost 2

        // for sum 6 > sum skip loop
        // at loop idx = 0, 0 + 6 = 6 > sum, skip loop

        // for sum 3, cost 1
        // at loop idx 0, 0 + 3 = 3 < sum
        // cost[0] is seen
        // so clone[0 + 3] => clone[3] = Min(clone[3], cost[0] + 1) => Min(int.Max, 1) => 1
        // at loop idx 1, 1 + 3 = 4 <= sum
        // cost[1] is seen
        // so clone[1 + 3] => clone [4] = Min(clone[4], cost[1] + 1) => Min(int.Max, 3) => 3
        // at loop idx 2, 2 + 3 = 5 > sum, skip
        // clone become [0, 2, 1, 1, 3]

        // for sum 1, cost 2
        // at loop idx 0, 0 + 1 = 1 <= sum
        // cost[0] is seen
        // so clone[0 + 1] => clone[1] = Min(clone[1], cost[0] + 2) => Min(2, 0 + 2) => 2
        // at loop idx 1, 1 + 1 = 2 <= sum
        // cost[1] is seen
        // so clone[1 + 1] => clone[2] = Min(clone[2], cost[1] + 2) => Min(1, 2 + 2) => 1
        // at loop idx 2, 2 + 1 = 3 <= sum
        // cost[2] is seen
        // so clone[2 + 1] => clone[3] = Min(clone[3], cost[2] + 2) => Min(1, 1 + 2) => 1
        // at loop idx 3, 3 + 1 = 4 <= sum
        // cost[3] is unseen, skip loop
        // clone become [0, 2, 1, 1, 3]

        // replace cost with clone
        // cost become [0, 2, 1, 1, 3]

        // for number 10
        // 5 > 4 => 10, 5, 2, 1
        // sum 10, cost 0
        // sum 5, cost 1
        // sum 2, cost 2
        // sum 1, cost 3

        // for sum 10, cost 0
        // at loop idx = 0, 0 + 10 = 5 > sum, skip loop

        // for sum 5, cost 1
        // at loop idx = 0, 0 + 5 = 5 > sum, skip loop

        // for sum 2, cost 2
        // at loop idx = 0, 0 + 2 = 2 < sum
        // cost[0] is seen
        // so clone[0 + 2] => clone[2] = Min(clone[2], cost[0] + 2) => Min(1, 2) => 1
        // at loop idx = 1, 1 + 2 = 3 < sum
        // cost[1] is seen
        // so clone[1 + 2] => clone[3] = Min(clone[3], cost[1] + 2) => Min(1, 1 + 2) => 1
        // at loop idx = 2, 2 + 2 = 4 = sum
        // clone[2] is seen
        // so clone[2 + 2] => clone[4] = Min(clone[4], cost[2] + 2) => Min(3, 1 + 2) => 3
        // at loop idx = 3, 3 + 2 = 5 > sum, exit loop
        // clone become [0, 2, 1, 1, 3]

        // for sum 1, cost 3
        // at loop idx = 0, 0 + sum = 1 <= sum
        // cost[0] is seen
        // so clone[0 + 1] => clone[1] = Min(clone[1], cost[0] + 3) => Min(2, 0 + 3) => 2
        // at loop idx = 1, 1 + 1 = 2 <= sum
        // cost[1] is seen
        // so clone[1 + 1] => clone[2] = Min(clone[2], cost[1] + 3) => Min(1, 2 + 3) => 1
        // at loop idx = 2, 2 + 1 = 2 <= sum
        // cost[2] is seen
        // so clone[2 + 1] => clone[3] = Min(clone[3], cost[2] + 3) => Min(1, 1 + 3) => 1
        // at loop idx = 3, 3 + 1 = 4 <= sum
        // cost[3] is seen
        // so clone[3 + 1] => clone[4] = Min(clone[4], cost[3] + 3) => Min(3, 1 + 3) => 3
        // at loop idx = 4, 4 + 1 > sum, skip loop
        // clone become [0, 2, 1, 1, 3]

        // replace cost with clone
        // cost become [0, 2, 1, 1, 3]

        // return cost[sum] => cost[4] = 3

        { [10, 2], 13, 3 },
        // 10 < 13 => 10, 5, 2, 1, 0
        // 2 < 13 => 2, 4, 8, 1, 0 <= multiplication must do first before division

        { [6, 3], 8, -1 },
        // 6 < 8 => 6, 3, 1, 0
        // 3 < 8 => 3, 6, 1, 0
        // no sum can reach 8, so is -1

        { [1, 4], 6, 1 },
        { [1, 4], 4, 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int sum, int expected)
    {
        var actual = MinOperations(nums, sum);
        Assert.Equal(expected, actual);
    }
}
