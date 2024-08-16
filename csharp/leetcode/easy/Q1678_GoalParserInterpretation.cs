using System.Text;

class Q1678_GoalParserInterpretation
{
    // TC: O(n), where n is length of command
    // SC: O(n), where n is the number of command in resulting string builder 
    public string Interpret(string command)
    {
        var sb = new StringBuilder();
        for(var i=0; i<command.Length; i++)
        {
            if (command[i] == 'G') sb.Append('G');
            else if(command[i] == '(')
            {
                if (command[i + 1] == ')')
                {
                    sb.Append('o');
                    i++;
                }
                else 
                {
                    sb.Append("al");
                    i += 3;
                }
            }
        }
        return sb.ToString();
    }
}
class Q1678_GoalParserInterpretationTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["G()(al)", "Goal"],
        ["G()()()()(al)", "Gooooal"],
        ["(al)G(al)()()G", "alGalooG"],
    ];
}
public class Q1678_GoalParserInterpretationTests
{
    [Theory]
    [ClassData(typeof(Q1678_GoalParserInterpretationTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1678_GoalParserInterpretation();
        var actual = sut.Interpret(input);
        Assert.Equal(expected, actual);
    }
}