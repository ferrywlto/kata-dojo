
namespace dojo.leetcode;

public class Q744_FindSmallestLetterGreaterThanTarget
{
    // TC: O(log n)
    // SC: O(1)
    public char NextGreatestLetter(char[] letters, char target) 
    {
        var left = 0;
        var right = letters.Length;

        while (left < right) 
        {
            int mid = left + (right - left) / 2;
            if (letters[mid] <= target) left = mid + 1;
            else right = mid;
        }

        return letters[left % letters.Length];
    }
}

public class Q744_FindSmallestLetterGreaterThanTargetTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new char[] {'c','f','j'}, 'a', 'c'],
        [new char[] {'c','f','j'}, 'c', 'f'],
        [new char[] {'x','x','y','y'}, 'z', 'x'],
        [new char[] {'e','e','e','e','e','e','n','n','n','n'}, 'e', 'n'],
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
