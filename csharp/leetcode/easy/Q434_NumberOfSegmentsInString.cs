
namespace dojo.leetcode;

public class Q434_NumberOfSegmentsInString
{
    public int CountSegments(string s)
    {
        int count = 0;

        return count;
    }
}

public class Q434_NumberOfSegmentsInStringTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["Hello, my name is John", 5],
        ["", 0],
        ["                ", 0],
        ["                a", 1],
    ];
}

public class Q434_NumberOfSegmentsInStringTest
{
    [Theory]
    [ClassData(typeof(Q434_NumberOfSegmentsInStringTestData))]
    public void OfficerTestCase(string input, int expected)
    {
        var sut = new Q434_NumberOfSegmentsInString();
        var actual = sut.CountSegments(input);
        Assert.Equal(expected, actual);
    }
}