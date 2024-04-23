using System.Text;

class Q917_ReverseOnlyLetters
{
    // TC: O(n), n is length of s/2
    // SC: O(n), n is the length of s used by string builder
    public string ReverseOnlyLetters(string s)
    {
        var sb = new StringBuilder(s);
        var startIdx = 0;
        var endIdx = sb.Length - 1;
        while (startIdx < endIdx)
        {
            if (char.IsLetter(sb[startIdx]) && char.IsLetter(sb[endIdx]))
            {
                // swap
                (sb[endIdx], sb[startIdx]) = (sb[startIdx], sb[endIdx]);
                startIdx++;
                endIdx--;
            }
            if (!char.IsLetter(sb[startIdx])) startIdx++;
            if (!char.IsLetter(sb[endIdx])) endIdx--;
        }
        return sb.ToString();
    }
}

class Q917_ReverseOnlyLettersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["ab-cd", "dc-ba"],
        ["a-bC-dEf-ghIj", "j-Ih-gfE-dCba"],
        ["Test1ng-Leet=code-Q!", "Qedo1ct-eeLg=ntse-T!"],
    ];
}

public class Q917_ReverseOnlyLettersTests
{
    [Theory]
    [ClassData(typeof(Q917_ReverseOnlyLettersTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q917_ReverseOnlyLetters();
        var actual = sut.ReverseOnlyLetters(input);
        Assert.Equal(expected, actual);
    }
}