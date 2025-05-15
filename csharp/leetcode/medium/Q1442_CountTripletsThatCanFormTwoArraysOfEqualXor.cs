public class Q1442_CountTripletsThatCanFormTwoArraysOfEqualXor(ITestOutputHelper output)
{
    public int CountTriplets(int[] arr)
    {
        if(arr.Length < 3) return 0;

        var len = arr.Length;
        

        // get Xor from i to i+n
        for(var i=1; i<len-1; i++)
        {
            Xor2(arr, i);
        }
        var result = 0;
        foreach(var p in Cache)
        {
            output.WriteLine("result: {0}, count: {1}, idxes: {2}", p.Key, p.Value.count, string.Join(',', p.Value.indexes.Select(p => $"[{p[0]},{p[1]}]")));
            if(p.Value.count > 1) result += p.Value.count;
        }
        return result;
    }
    Dictionary<int, (int count, List<int[]> indexes)> Cache = new(); 
    private void Xor(int[] arr, int startIdx) 
    {
        var temp = arr[startIdx];
        for(var i=startIdx+1; i<arr.Length; i++) {
            temp ^= arr[i];
            if(startIdx == 0 && i == arr.Length - 1) continue;

            if(!Cache.TryGetValue(temp, out var val)) {
                Cache.Add(temp, (1, [[startIdx,i]]));
            }
            else {
                var (count, indexes) = val;
                indexes.Add([startIdx, i]);
                Cache[temp] = (++count, indexes);
                output.WriteLine("Xor: {0}, start: {1}, end: {2}", temp, startIdx, i);
            }
        }
    }
    private void Xor2(int[] arr, int j)
    {
        var left = arr[0];
        for(var i=1; i<j; i++)
        {
            left ^= arr[i];
            if(!Cache.TryGetValue(left, out var val_left)) {
                Cache.Add(left, (1, [[0, i]]));
            }
            else {
                var (count, indexes) = val_left;
                indexes.Add([0, i]);
                Cache[left] = (++count, indexes);
                output.WriteLine("left Xor: {0}, start: {1}, end: {2}", left, 0, i);
            }
        }
        var right = arr[j];

        for(var k=j; k<arr.Length; k++)
        {
            right ^= arr[k];
            if(!Cache.TryGetValue(right, out var val_right2))
            {
                Cache.Add(right, (1, [[j, k]]));
            }
            else 
            {
                var (count, indexes) = val_right2;
                indexes.Add([j, k]);
                Cache[right] = (++count, indexes);
                output.WriteLine("right Xor: {0}, start: {1}, end: {2}", left, j, k);            
            }
        }
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,3,1,6,7], 4},
        {[1,1,1,1,1], 10},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountTriplets(input);
        Assert.Equal(expected, actual);
    }
}