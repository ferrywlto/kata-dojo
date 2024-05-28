class Q1013_PartitionArrayIntoThreePartsWithEqualSum
{
    // TC: O(n^2) n is length of arr, the ^2 comes from Array.IndexOf in order to find the complement part, 
    // otherwise if the array is skewed with large numbers at the beginning or end even the array can be partitioned into 3 equal sum groups, 
    // algorithms will used up most numbers before formed the first groups, making the final group not able to formed
    // SC: O(n), n is the length of arr to record which item has been processed
    public bool CanThreePartsEqualSum(int[] arr)
    {
        if (arr.All(c => c == 0)) return true;
        var sum = arr.Sum();
        if (sum % 3 != 0) return false;
        
        var target = sum / 3;
        var processed = new HashSet<int>();
        var groupFormed = 0;
        var currentSum = 0;
        for(var i=0; i<arr.Length; i++)
        {
            // Console.WriteLine($"current: arr({i}): {arr[i]}");
            if(processed.Contains(i))
            {
                // Console.WriteLine($"skipping arr({i}): {arr[i]} as processed");
                continue;
            }
            if(arr[i] == target) {
                processed.Add(i);
                groupFormed++;
                // Console.WriteLine($"group formed as arr({i}): {arr[i]} == target: {target}, groups: {groupFormed}");
                continue;
            }

            currentSum += arr[i];
            processed.Add(i);
            // Console.WriteLine($"processed arr({i}): {arr[i]}, currentSum: {currentSum}");
            if(currentSum == target)
            {
                // Console.WriteLine($"group formed as arr({i}): {arr[i]} currentSum {currentSum} == target {target}");
                groupFormed++;
                currentSum = 0;
                continue;
            }

            var lookfor = target - currentSum;
            var lookResult = Array.IndexOf(arr, lookfor, i + 1);
            // Console.WriteLine($"currentSum {currentSum} not reaching target {target} after adding arr({i}): {arr[i]}, lookingFor {lookfor}, result: arr[{lookResult}]: {(lookResult != -1 ? arr[lookResult] : string.Empty)}");
            if(lookResult != -1 && !processed.Contains(lookResult))
            {
                groupFormed++;
                // Console.WriteLine($"complement of {currentSum}, {lookfor} found at arr[{lookResult}]: {arr[lookResult]}, groupFormed now: {groupFormed}");
                currentSum = 0;
                processed.Add(lookResult);
            }
        }
        // Console.WriteLine($"processed: {processed.Count}, arrLength: {arr.Length}, groupFormed: {groupFormed}, finalSum: {currentSum}");
        return groupFormed == 3 && currentSum == 0;
    }
}

class Q1013_PartitionArrayIntoThreePartsWithEqualSumTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {0,2,1,-6,6,-7,9,1,2,0,1}, true],
        [new int[] {0,2,1,-6,6,7,9,-1,2,0,1}, false],
        [new int[] {3,3,6,5,-2,2,5,1,-9,4}, true],
        [new int[] {0,0,0,0}, true],
        // Leetcode is wrong, it can be paritioned into 3 equal parts
        [new int[] {24,-4,-5,-12,5,16,-12,22,2}, true],
    ];
}

public class Q1013_PartitionArrayIntoThreePartsWithEqualSumTests
{
    [Theory]
    [ClassData(typeof(Q1013_PartitionArrayIntoThreePartsWithEqualSumTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q1013_PartitionArrayIntoThreePartsWithEqualSum();
        var actual = sut.CanThreePartsEqualSum(input);
        Assert.Equal(expected, actual);
    }
}
