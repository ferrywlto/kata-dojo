
namespace dojo.leetcode;

public class Q709_ToLowerCase
{
    // TC: O(n)
    // SC: O(n)
    public string ToLowerCase(string s) 
    {
        var arr = s.ToCharArray();
        for (var i = 0; i < arr.Length; i++)
        {
            char c = arr[i];
            if (c >= 65 && c <= 90)
            {
                arr[i] = (char)(c + 32);
            }
        }
        return new string(arr);
    }    
}

public class Q709_ToLowerCaseTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["Hello", "hello"],
        ["here", "here"],
        ["LOVELY", "lovely"],
    ];
}

public class Q709_ToLowerCaseTests
{
    [Theory]
    [ClassData(typeof(Q709_ToLowerCaseTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q709_ToLowerCase();
        var actual = sut.ToLowerCase(input);
        Assert.Equal(expected, actual);
    }
}