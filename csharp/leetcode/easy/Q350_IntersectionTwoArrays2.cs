
namespace dojo.leetcode;

/*
Follow up:

What if the given array is already sorted? How would you optimize your algorithm?
- If is sorted can use 2 pointers approach to achieve TC: O(n), SC: O(n), but the sorting itself is already O(n log n)

What if nums1's size is small compared to nums2's size? Which algorithm is better?
- Done with longer/shorter approach, can pass all tests no matter nums1 or nums2 longer

What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements into the memory at once?
- Not gonna do the follow up part as it is out of kata scope, it can still possible and efficient by loading the longer list bit by bit
 in Intersect_Analysis() method 
*/
public class Q350_IntersectionTwoArrays2
{
    // Use trival approach, TC: O(n^2), SC: O(n) 
    public int[] Intersect_Inefficient(int[] nums1, int[] nums2)
    {
        List<int> longer;
        int[] shorter;
        if (nums1.Length > nums2.Length) 
        {
            longer = nums1.ToList();
            shorter = nums2;
        }
        else
        {
            longer = nums2.ToList();
            shorter = nums1;
        }

        var result = new List<int>();
        foreach(var i in shorter) 
        {            
            for(var j=0; j<longer.Count; j++)
            {
                if(longer[j] == i)
                {
                    result.Add(i);
                    longer.RemoveAt(j);
                    break;
                }
            }
        }
        return result.ToArray();
    }

    // TC: O(n), SC: O(n)
    public int[] Intersect_Analysis(int[] nums1, int[] nums2)
    {
        int[] longer, shorter;
        if (nums1.Length > nums2.Length) 
        {
            longer = nums1;
            shorter = nums2;
        }
        else
        {
            longer = nums2;
            shorter = nums1;
        }

        var dict = new Dictionary<int, int>();
        foreach (var n in shorter)
        {
            if(dict.TryGetValue(n, out var value))
            {
                dict[n]++;
            }
            else
            {
                dict[n] = 1;
            }
        } 
        var result = new List<int>();
        foreach (var l in longer)
        {
            if(dict.TryGetValue(l, out var value))
            {
                result.Add(l);
                if (--dict[l] == 0) dict.Remove(l);
                if (dict.Count <= 0) break;
            }
        }

        return result.ToArray();
    }
}

public class Q350_IntersectionTwoArrays2TestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,2,2,1}, new int[]{2,2}, new int[] {2,2}],
        [new int[]{4,9,5}, new int[]{9,4,9,8,4}, new int[] {9,4}],
        [new int[]{1,2}, new int[]{1,1}, new int[]{1}],
        [new int[]{1,2,2,1}, new int[]{2}, new int[]{2}],
        [new int[]{3,1,2}, new int[]{1,1}, new int[]{1}],
    ];
}

public class Q350_IntersectionTwoArrays2Tests(ITestOutputHelper output)
{
    [Theory]
    [ClassData(typeof(Q350_IntersectionTwoArrays2TestData))]
    public void OfficialTestCases(int[] input1, int[] input2, int[] expected)
    {
        var sut = new Q350_IntersectionTwoArrays2();
        var actual = sut.Intersect_Analysis(input1, input2);
        output.WriteLine(string.Join(",", actual));
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}