
namespace dojo.leetcode;

// Not gonna do the follow up part as it is out of kata scope 
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
        var actual = sut.Intersect_Inefficient(input1, input2);
        output.WriteLine(string.Join(",", actual));
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}