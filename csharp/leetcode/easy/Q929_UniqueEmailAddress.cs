
class Q929_UniqueEmailAddress
{
    public int NumUniqueEmails(string[] emails)
    {
        return 0;
    }
}

class Q929_UniqueEmailAddressTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            new string[] {
                "test.email+alex@leetcode.com",
                "test.e.mail+bob.cathy@leetcode.com",
                "testemail+david@lee.tcode.com",
            }, 2
        ],
        [
            new string[] {
                "a@leetcode.com",
                "b@leetcode.com",
                "c@leetcode.com",
            }, 3
        ],
    ];
}

public class Q929_UniqueEmailAddressTests
{
    [Theory]
    [ClassData(typeof(Q929_UniqueEmailAddressTestData))]
    public void OfficialTestCases(string[] input, int expected)
    {
        var sut = new Q929_UniqueEmailAddress();
        var actual = sut.NumUniqueEmails(input);
        Assert.Equal(expected, actual);
    }
}