class Q345_ReverseVowels
{
    private readonly HashSet<char> vows = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];
    // TC: O(n), SC: O(n)
    public string ReverseVowels(string s)
    {
        var temp = ' ';
        var charArr = s.ToCharArray();
        var start = 0;
        var end = s.Length - 1;

        while (start < end)
        {
            while (!vows.Contains(charArr[start]))
            {
                start++;
                if (start >= end) break;
            }
            while (!vows.Contains(charArr[end]))
            {
                end--;
                if (start >= end) break;
            }

            if (vows.Contains(charArr[start]) && vows.Contains(charArr[end]))
            {
                temp = charArr[start];
                charArr[start] = charArr[end];
                charArr[end] = temp;
            }
            start++;
            end--;
        }

        var result = string.Join(string.Empty, charArr);
        return result;
    }
}

class Q345_ReverseVowelsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["hello", "holle"],
        ["leetcode", "leotcede"],
    ];
}

public class Q345_ReverseVowelsTests
{
    [Theory]
    [ClassData(typeof(Q345_ReverseVowelsTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q345_ReverseVowels();
        var actual = sut.ReverseVowels(input);
        Assert.Equal(expected, actual);
    }
}
