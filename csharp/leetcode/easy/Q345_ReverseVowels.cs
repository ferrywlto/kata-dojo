
namespace dojo.leetcode;

public class Q345_ReverseVowels
{
    public string ReverseVowels(string s) {
        return string.Empty;   
    }
}

public class Q345_ReverseVowelsTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["hello", "holle"],    
        ["leetcode", "leotcede"],    
    ];
}

public class Q345_ReverseVowelsTests: BaseTest
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
