public class Q20_ValidParenthesesTests
{
    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("]", false)]
    [InlineData("){", false)]
    [InlineData("(){}}{", false)]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q20_ValidParentheses();
        var result = sut.IsValid(input);
        Assert.Equal(expected, result);
    }
}

public class Q20_ValidParentheses
{
    private readonly Dictionary<char, char> _dict = new()
    {
        {')', '('},
        {']', '['},
        {'}', '{'},
    };

    // Speed: 53ms (98.57%), Memory: 39.4MB (9.55%)
    public bool IsValid(string input) {
        if (input.Length % 2 != 0) {
            return false;
        }

        var charArr = input.ToCharArray();
        var stack = new Stack<char>();
        for(ushort i=0; i<charArr.Length; i++)
        {
            if(charArr[i] == '(' || charArr[i] == '[' || charArr[i] == '{') {
                Console.WriteLine($"Push: {charArr[i]}");
                stack.Push(charArr[i]);
            }
            else if(stack.Count == 0) {
                return false;
            }
            else {
                var last = stack.Pop();
                if(_dict[charArr[i]] != last) {
                    return false;
                }
            }   
        }
        return stack.Count == 0;
    }
}