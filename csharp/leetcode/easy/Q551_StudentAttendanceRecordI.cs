public class Q551_StudentAttendanceRecordI
{
    // TC: O(n)
    // SC: O(1)
    public bool CheckRecord(string s)
    {
        if (s.Length == 1) return true;
        else if (s.Length == 2) return s != "AA";

        var late = 0;
        var absent = 0;

        for(var i=0; i<s.Length; i++)
        {
            if (s[i] == 'L')
            {
                if (++late == 3) return false;
            }
            else
            {
                late = 0;
                if (s[i] == 'A')
                {
                    if (++absent == 2) return false;
                }
            }
        } 
        return true;
    }
}

public class Q551_StudentAttendanceRecordITestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["PPALLP", true],
        ["PPALLL", false],
        ["AA", false],
    ];
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