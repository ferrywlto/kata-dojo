using System.Text;

public class Q3461_CheckIfDigitsAreEqualInStringAfterOperationsI
{
    // TC: O(n^2), n scale with length of s, iterates whole string until length is 2
    // SC: O(n), most space used in the first iteration, n + n - 1
    public bool HasSameDigits(string s)
    {
        var arr = new int[s.Length];
        var currentSize = s.Length;
        var chArr = s.ToCharArray();
        // init;
        for (var i = 0; i < currentSize; i++)
        {
            arr[i] = chArr[i] - '0';
        }

        while (currentSize > 2)
        {
            for (var i = 1; i < currentSize; i++)
            {
                arr[i - 1] = (arr[i] + arr[i - 1]) % 10;
            }
            currentSize--;
        }
        return arr[0] == arr[1];
    }
    public static TheoryData<string, bool> TestData => new()
    {
        {"3902", true},
        {"34789", false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = HasSameDigits(input);
        Assert.Equal(expected, actual);
    }
}
