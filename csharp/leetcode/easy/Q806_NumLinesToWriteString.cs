class Q806_NumLinesToWriteString
{
    // TC: O(n), where n = total characters in string s
    // SC: O(1)
    public int[] NumberOfLines(int[] widths, string s)
    {
        var lines = 0;
        var currentWidth = 0;
        foreach (var c in s)
        {
            var charWidth = widths[c - 97];
            if (100 - currentWidth >= charWidth)
            {
                currentWidth += charWidth;
            }
            else
            {
                lines++;
                currentWidth = charWidth;
            }
        }
        return [lines + 1, currentWidth];
    }
}

class Q806_NumLinesToWriteStringTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[]{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
            "abcdefghijklmnopqrstuvwxyz",
            new int[]{3,60}
        ],
        [
            new int[]{4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10},
            "bbbcccdddaaa",
            new int[]{2,4}
        ],
    ];
}

public class Q806_NumLinesToWriteStringTests
{
    [Theory]
    [ClassData(typeof(Q806_NumLinesToWriteStringTestData))]
    public void OfficialTestCases(int[] widths, string input, int[] expected)
    {
        var sut = new Q806_NumLinesToWriteString();
        var actual = sut.NumberOfLines(widths, input);
        Assert.Equal(expected, actual);
    }
}
