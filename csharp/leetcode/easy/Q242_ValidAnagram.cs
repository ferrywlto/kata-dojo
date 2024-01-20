
namespace dojo.leetcode;

public class Q242_ValidAnagram
{
    public bool IsAnagram(string s, string t) 
    {
        return false;
    }
}

public class Q242_ValidAnagramTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["anagram", "nagaram", true],
        ["anagram😀", "😀nagaram", true],
        ["rat", "car", false],
    ];
}

public class Q242_ValidAnagramTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q242_ValidAnagramTestData))]
    public void OfficialTestCases(string input1, string input2, bool expected)
    {
        var sut = new Q242_ValidAnagram();
        var actual = sut.IsAnagram(input1, input2);
        Assert.Equal(expected, actual);
    }
}