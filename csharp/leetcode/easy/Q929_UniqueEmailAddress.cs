class Q929_UniqueEmailAddress
{
    // TC: O(n), n is number of emails, iterate each element once
    // SC: O(n), n is number of unique emails
    public int NumUniqueEmails(string[] emails)
    {
        var dict = new Dictionary<string, HashSet<string>>();
        foreach (var email in emails)
        {
            var parts = email.Split('@');
            var localName = parts[0];
            var domainName = parts[1];

            var firstPlusIdx = localName.IndexOf('+');
            var cleansed = firstPlusIdx == -1 ? localName : localName[..firstPlusIdx];
            cleansed = cleansed.Replace(".", string.Empty);

            if (dict.TryGetValue(domainName, out var localNames))
            {
                localNames.Add(cleansed);
            }
            else
            {
                dict.Add(domainName, [cleansed]);
            }
        }
        return dict.Sum(p => p.Value.Count);
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
