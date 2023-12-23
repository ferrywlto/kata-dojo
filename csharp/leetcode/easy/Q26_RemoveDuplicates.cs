public class Q26_RemoveDuplicatesTests
{
    [Theory]
    [InlineData(new int[] { 1, 1, 2 }, 2)] // 1, 2, 1
    [InlineData(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)] // 0, 1, 2, 3, 4, 0, 1, 1, 2, 3
    [InlineData(new int[] { -50,-50,-49,-48,-47,-47,-47,-46,-45,-43,-42,-41,-40,-40,-40,-40,-40,-40,-39,-38,-38,-38,-38,-37,-36,-35,-34,-34,-34,-33,-32,-31,-30,-28,-27,-26,-26,-26,-25,-25,-24,-24,-24,-22,-22,-21,-21,-21,-21,-21,-20,-19,-18,-18,-18,-17,-17,-17,-17,-17,-16,-16,-15,-14,-14,-14,-13,-13,-12,-12,-10,-10,-9,-8,-8,-7,-7,-6,-5,-4,-4,-4,-3,-1,1,2,2,3,4,5,6,6,7,8,8,9,9,10,10,10,11,11,12,12,13,13,13,14,14,14,15,16,17,17,18,20,21,22,22,22,23,23,25,26,28,29,29,29,30,31,31,32,33,34,34,34,36,36,37,37,38,38,38,39,40,40,40,41,42,42,43,43,44,44,45,45,45,46,47,47,47,47,48,49,49,49,50 }, 91)] // 0, 1, 2, 3, 4, 0, 1, 1, 2, 3
    public void OfficialTestCases(int[] nums, sbyte expected)
    {
        var sut = new Q26_RemoveDuplicates();
        var actual = sut.RemoveDuplicates(nums);
        Assert.Equal(expected, actual);
    } 
}
public class Q26_RemoveDuplicates
{
    // From the problem description and others discussion, the answer needed to switch the value in place because the auto judge will check the array element by element for the first K elements.
    // Where K is the distinct number of elements in the array.
    // The input array is sorted.
    // Speed: 105ms (99.98%), Memory: 49.3MB (5.2%)
    // Even faster edition. The idea is since the array is sorted, whenever we encounter a bigger number, swap it to the front, after the loop, the first K(i.e swapped) elements will be the distinct elements. 
    // Such that the array will be sorted inplace, no need to call .Distainct().Count() and then copy the values back to fulfill the hidden auto judge requirements.
    // The complexity is O(n-1) where n is the length of the array.
    public int RemoveDuplicates(int[] nums) 
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return 1;
        if (nums.Length == 2) return (nums[0] == nums[1]) ? 1 : 2;

        var smallest = nums[0];
        // used to keep track the index of the next element to swap.
        var idxToSwap = 1;
        int temp;
        Console.WriteLine($"nums={string.Join(",", nums)}, i={0}, idxToSwap={idxToSwap}, smallest={smallest}");
        for(ushort i=1; i<nums.Length; i++)
        {
            // whenever we found something larger, swap it to the front.
            if (nums[i] > smallest)
            {
                Console.WriteLine($"num[{i}]={nums[i]} > smallest={smallest}, should swap]");
                temp = nums[idxToSwap];
                nums[idxToSwap] = nums[i];
                nums[i] = temp;
                smallest = nums[idxToSwap];
                idxToSwap++;
                Console.WriteLine($"nums={string.Join(",", nums)}, i={i}, idxToSwap={idxToSwap}, smallest={smallest}");
            }
        }
        
        return idxToSwap;
    }
}