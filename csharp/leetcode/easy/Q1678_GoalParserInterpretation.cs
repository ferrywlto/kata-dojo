
class Q1678_GoalParserInterpretation
{
    public string Interpret(string command)
    {
        return string.Empty;
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