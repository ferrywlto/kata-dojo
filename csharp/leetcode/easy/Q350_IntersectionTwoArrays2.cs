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
        int[] longer, shorter;
        (longer, shorter) = Longer(nums1, nums2);
        List<int> longerList = longer.ToList();

        var result = new List<int>();
        foreach(var i in shorter) 
        {            
            for(var j=0; j<longerList.Count; j++)
            {
                if(longer[j] == i)
                {
                    result.Add(i);
                    longerList.RemoveAt(j);
                    break;
                }
            }
        }
        return result.ToArray();
    }

    // TC: O(n), SC: O(n), most efficient in all three approaches
    public int[] Intersect_Analysis(int[] nums1, int[] nums2)
    {
        int[] longer, shorter;
        (longer, shorter) = Longer(nums1, nums2);

        var dict = shorter.Analyze();
         
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

    // TC: O(n), SC: O(n)
    public int[] Intersect_Sorted(int[] nums1, int[] nums2)
    {
        int[] longer, shorter;
        (longer, shorter) = Longer(nums1, nums2);

        Array.Sort(longer);
        Array.Sort(shorter);

        var startIdx = 0;
        var result = new List<int>();
        foreach(var s in shorter)
        {
            for(var i=startIdx; i<longer.Length; i++)
            {
                if (longer[i] < s) startIdx++;
                else if (longer[i] == s)
                {
                    result.Add(s);
                    startIdx++;
                    break;
                } 
            }
        }
        
        return result.ToArray();
    }

    public (int[] longer, int[] shorter) Longer(int[] input1, int[] input2) =>
        input1.Length > input2.Length
            ? (input1, input2)
            : (input2, input1);
}

public class Q350_IntersectionTwoArrays2TestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,2,2,1}, new int[]{2,2}, new int[] {2,2}],
        [new int[]{4,9,5}, new int[]{9,4,9,8,4}, new int[] {4,9}],
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
        var actual = sut.Intersect_Sorted(input1, input2);
        output.WriteLine(string.Join(",", actual));
        Assert.Equal(expected, actual);
    }
}