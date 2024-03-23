
namespace dojo.leetcode;

public class Q744_FindSmallestLetterGreaterThanTarget
{
    public char NextGreatestLetter(char[] letters, char target) 
    {
        return letters[0];    
    }
}

public class Q744_FindSmallestLetterGreaterThanTargetTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new char[] {'c','f','j'}, 'a', 'c'],
        [new char[] {'c','f','j'}, 'c', 'f'],
        [new char[] {'x','x','y','y'}, 'z', 'x'],
    ];
}

public class Q744_FindSmallestLetterGreaterThanTargetTests
{
    [Theory]
    [ClassData(typeof(Q744_FindSmallestLetterGreaterThanTargetTestData))]
    public void OfficialTestCases(char[] input, char target, char expected)
    {
        var sut = new Q744_FindSmallestLetterGreaterThanTarget();
        var actual = sut.NextGreatestLetter(input, target);
        Assert.Equal(expected, actual);
    }
}
