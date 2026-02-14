class Q989_AddToArrayFormInteger
{
    // TC: O(n), n = length of max(num, array form of k)
    // SC: O(n), n = length of max(num, array form of k)
    public IList<int> AddToArrayForm(int[] num, int k)
    {
        var numList = num.ToList();
        var kList = ToArrayForm(k);
        List<int> longer, shorter;

        if (numList.Count >= kList.Count)
        {
            longer = numList;
            shorter = kList;
        }
        else
        {
            longer = kList;
            shorter = numList;
        }

        var idx = 1;
        var carry = false;
        while (idx <= shorter.Count)
        {
            longer[^idx] += shorter[^idx];
            if (carry) longer[^idx]++;

            if (longer[^idx] > 9)
            {
                longer[^idx] %= 10;
                carry = true;
            }
            else carry = false;
            idx++;
        }

        while (carry && idx <= longer.Count)
        {
            if (carry) longer[^idx]++;

            if (longer[^idx] > 9)
            {
                longer[^idx] %= 10;
                carry = true;
            }
            else carry = false;
            idx++;
        }

        if (carry)
        {
            var list = new List<int> { 1 };
            list.AddRange(longer);
            return list;
        }
        return longer;
    }

    public List<int> ToArrayForm(long input)
    {
        if (input == 0) return [0];
        var stack = new Stack<int>();
        while (input > 0)
        {
            stack.Push((int)(input % 10));
            input /= 10;
        }
        return [.. stack];
    }
}

class Q989_AddToArrayFormIntegerTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{0}, 23, new List<int>{2,3}],
        [new int[]{1,2,0,0}, 34, new List<int>{1,2,3,4}],
        [new int[]{2,7,4}, 181, new List<int>{4,5,5}],
        [new int[]{2,1,5}, 806, new List<int>{1,0,2,1}],
        [new int[]{9,9,9,9,9,9,9,9,9,9}, 1, new List<int>{1,0,0,0,0,0,0,0,0,0,0}],
    ];
}

public class Q989_AddToArrayFormIntegerTests
{
    [Theory]
    [ClassData(typeof(Q989_AddToArrayFormIntegerTestData))]
    public void OfficialTestCases(int[] input, int k, List<int> expected)
    {
        var sut = new Q989_AddToArrayFormInteger();
        var actual = sut.AddToArrayForm(input, k);
        Assert.Equal(expected, actual);
    }
    [Theory]
    [InlineData(100, new int[] { 1, 0, 0 })]
    [InlineData(0, new int[] { 0 })]
    public void ToArrayForm(int input, int[] expected)
    {
        var sut = new Q989_AddToArrayFormInteger();
        var actual = sut.ToArrayForm(input);
        Assert.Equal(expected.ToList(), actual);
    }
}
