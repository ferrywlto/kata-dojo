using System.Text;

public class Q3823_ReverseLettersThenSpecialCharactersInString
{
    // TC: O(n), n scale with length of s
    // SC: O(n)
    public string ReverseByType(string s)
    {
        var charPos = new List<int>();
        var nonCharPos = new List<int>();

        for(var i=s.Length-1; i>=0; i--)
        {
            if(char.IsAsciiLetterLower(s[i]))
            {
                charPos.Add(i);
            }
            else
            {
                nonCharPos.Add(i);
            }
        }

        var sb = new StringBuilder(s);
        var charIdx = 0;
        var nonCharIdx = 0;
        for(var i=0; i<s.Length; i++)
        {
            if(char.IsAsciiLetterLower(s[i]))
            {
                sb[charPos[charIdx++]] = s[i];
            }
            else
            {
                sb[nonCharPos[nonCharIdx++]] = s[i];
            }            
        }
        return sb.ToString();
    }

    public string ReverseByTypeFast(string s)
    {
        var sb = new StringBuilder(s);
        var charIdx = sb.Length - 1;
        var nonCharIdx = sb.Length - 1;

        for(var i=0; i<s.Length; i++)
        {
            if(char.IsAsciiLetterLower(s[i]))
            {
                // swap with first encounter char
                while(!char.IsAsciiLetterLower(sb[charIdx])) { charIdx--; }
                if(charIdx > i)
                {                    
                    (sb[charIdx], sb[i]) = (sb[i], sb[charIdx]);
                    charIdx--;
                }
            }
            else
            {
                // swap with first encounter non-char
                while(char.IsAsciiLetterLower(sb[nonCharIdx])) { nonCharIdx--; }
                if(nonCharIdx > i)
                {                    
                    (sb[nonCharIdx], sb[i]) = (sb[i], sb[nonCharIdx]);
                    nonCharIdx--;
                }
            }            
        }
        return sb.ToString();
    }
    
    public static TheoryData<string, string> TestData => new()
    {
        {")ebc#da@f(", "(fad@cb#e)"},
        {"z", "z"},
        {"!@#$%^&*()", ")(*&^%$#@!"},
        {"#zq", "#qz"},
        {"fk#", "kf#"},
        {"$!lv", "!$vl"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = ReverseByTypeFast(input);
        Assert.Equal(expected, actual);
    }
}
