using System.Text;

class Q1309_DecryptStringFromAlphabetToIntegerMapping
{
    private readonly Dictionary<string, string> Mapping = new()
    {
        {"1", "a"},
        {"2", "b"},
        {"3", "c"},
        {"4", "d"},
        {"5", "e"},
        {"6", "f"},
        {"7", "g"},
        {"8", "h"},
        {"9", "i"},
        {"10#", "j"},
        {"11#", "k"},
        {"12#", "l"},
        {"13#", "m"},
        {"14#", "n"},
        {"15#", "o"},
        {"16#", "p"},
        {"17#", "q"},
        {"18#", "r"},
        {"19#", "s"},
        {"20#", "t"},
        {"21#", "u"},
        {"22#", "v"},
        {"23#", "w"},
        {"24#", "x"},
        {"25#", "y"},
        {"26#", "z"},
    };
    // TC: O(n), n is length of s
    // SC: O(n), n is length of s, due to the stack and string builder used  
    public string FreqAlphabets(string s) 
    {
        var stack = new Stack<string>();
        for(var i=s.Length-1; i>=0; i--)
        {
            if (s[i] == '#')
            {
                stack.Push(s.Substring(i - 2, 3));
                i -= 2;
            }
            else stack.Push(s[i].ToString());
        }
        var sb = new StringBuilder();
        while (stack.Count > 0) sb.Append(Mapping[stack.Pop()]);
        return sb.ToString();   
    }
}
class Q1309_DecryptStringFromAlphabetToIntegerMappingTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["10#11#12", "jkab"],
        ["1326#", "acz"],
    ];
}
public class Q1309_DecryptStringFromAlphabetToIntegerMappingTests
{
    [Theory]
    [ClassData(typeof(Q1309_DecryptStringFromAlphabetToIntegerMappingTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1309_DecryptStringFromAlphabetToIntegerMapping();
        var actual = sut.FreqAlphabets(input);
        Assert.Equal(expected, actual);
    }
}