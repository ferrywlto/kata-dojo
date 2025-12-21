using System.Text;

public class Q3781_MaxScoreAfterBinarySwaps(ITestOutputHelper output)
{
    public long MaximumScore(int[] nums, string s)
    {
        var maxScore = 0L;
        var lastOneIdx = s.LastIndexOf('1');
        var firstZeroIdx = int.MaxValue;
        var sb = new StringBuilder(s);
        for(var i=0; i<=lastOneIdx; i++)
        {
            if(sb[i] == '1')
            {
                var currentMaxIdx = i;
                for(var j=i-1; j>=firstZeroIdx; j--)
                {
                    output.WriteLine($"back nums[{j}]: {nums[j]}, nums[{currentMaxIdx}]: {nums[currentMaxIdx]}");
                    if(sb[j] == '0' && nums[j] > nums[currentMaxIdx])
                    {
                        output.WriteLine($"hit");
                        currentMaxIdx = j;
                        if(j < firstZeroIdx) firstZeroIdx = j;
                    }
                }
                if(i != currentMaxIdx)
                {                    
                    sb[currentMaxIdx] = '1';
                    sb[i] = '0';
                }
                maxScore += nums[currentMaxIdx];
                output.WriteLine($"i: {i}, currentMaxIdx: {currentMaxIdx}, {sb.ToString()}");
            }
            else
            {
                if(i < firstZeroIdx) firstZeroIdx = i;
            }
        }

        return maxScore;
    }
    // public long MaximumScore2(int[] nums, string s)
    // {
    //     var lastOneIdx = s.LastIndexOf('1');
    //     if(lastOneIdx == -1) return 0;

    //     var numOnes = 0;
    //     for(var i = 0; i<=lastOneIdx; i++)
    //     {
    //         if(s[i] == '1') numOnes++;
    //     }
    //     output.WriteLine($"lastOneIdx: {lastOneIdx}, numOnes: {numOnes}");

    //     var toSort = new int[lastOneIdx + 1];
    //     Array.Copy(nums, toSort, toSort.Length);
    //     Array.Sort(toSort);

    //     var result = 0;
    //     for(var i = 0; i < numOnes; i++)
    //     {
    //         var idx = toSort.Length - i - 1;
    //         var picked = toSort[idx];
    //         output.WriteLine($"picked: toSort[{idx}]: {picked}");
    //         result += picked;
    //     }        
    //     return result;
    // }
    // private void CascadeMax(long[] arr, long input)
    // {
    //     for(var i = 0; i< arr.Length; i++)
    //     {
    //         if(input > arr[i])
    //         {
    //             for(var j = arr.Length - 1; j>i; j--)
    //             {
    //                 arr[j] = arr[j-1];
    //             }
    //             arr[i] = input;
    //             return;
    //         }
    //     }
    // }

    public static TheoryData<int[], string, long> TestData => new()
    {
        {[2,1,5,2,3], "01010", 7},
        {[4,7,2,9], "0000", 0},
        {[8,1,7,1,3,7,5,6,10,10], "0010111000", 27},
        {[1,8,8,4,6,2], "110100", 17}, 
        {[5,6,4,6,10,3,2,2,6], "010010111", 33}, // 6 + 10 + 6 + 5
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, string score, long expected)
    {
        var actual = MaximumScore(input, score);
        Assert.Equal(expected, actual);
    }
}
