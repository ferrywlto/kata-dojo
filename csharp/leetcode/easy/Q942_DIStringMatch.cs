
class Q942_DIStringMatch
{
    // TC: O(n), n is length of s
    // SC: O(n), n is result size, if not counting it is O(1) as no interim space used 
    public int[] DiStringMatch(string s)
    {
        var max = s.Length;
        var min = 0;
        var result = new int[max + 1];

        for(var i=0; i<result.Length - 1; i++)
        {
            if (s[i] == 'D') result[i] = max--;
            else result[i] = min++;
        }
        result[^1] = min;
        return result;
    }
}

class Q942_DIStringMatchTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["IDID", new int[] {0,4,1,3,2}],
        ["III", new int[] {0,1,2,3}],
        ["DDI", new int[] {3,2,0,1}],
    ];
}

public class Q942_DIStringMatchTests
{
    [Theory]
    [ClassData(typeof(Q942_DIStringMatchTestData))]
    public void OfficialTestCases(string input, int[] expected)
    {
        var sut = new Q942_DIStringMatch();
        var actual = sut.DiStringMatch(input);
        Assert.Equal(expected, actual);
    }
}