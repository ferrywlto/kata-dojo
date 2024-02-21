namespace dojo.leetcode;

public class Q551_StudentAttendanceRecordI
{
    public bool CheckRecord(string s)
    {
        return true;
    }
}

public class Q551_StudentAttendanceRecordITestData : TestData
{
    protected override List<object[]> Data => new()
    {
        new object[] {"PPALLP", true},
        new object[] {"PPALLL", false},
    };
}

public class Q551_StudentAttendanceRecordITests
{
    [Theory]
    [ClassData(typeof(Q551_StudentAttendanceRecordITestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q551_StudentAttendanceRecordI();
        var actual = sut.CheckRecord(input);
        Assert.Equal(expected, actual);
    }
}