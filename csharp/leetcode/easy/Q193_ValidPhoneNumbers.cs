namespace dojo.leetcode;

public class Q193_ValidPhoneNumbersTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            """
            987-123-4567
            123 456 7890
            (123) 456-7890
            0(001) 345-0000
            (001) 345-00001
            """,
            """
            987-123-4567
            (123) 456-7890
            """
        ]
    ];
}

public class Q193_ValidPhoneNumbersTests(ITestOutputHelper output) : ShellTest(output)
{
    [Theory]
    [ClassData(typeof(Q193_ValidPhoneNumbersTestData))]
    public void Test(string input, string expected) 
    {
        File.WriteAllText("./q193.txt", input.Trim());

        var sut = new Q193_ValidPhoneNumbers();
        var actual = Run(sut.Command);
        
        File.Delete("./q193.txt");

        var expectedLines = expected.Trim().Split(Environment.NewLine);
        var actualLines = actual.Trim().Split(Environment.NewLine);

        foreach(var line in actualLines)
        {
            output.WriteLine(line);
            Assert.Contains(line, expectedLines);
        }
    }
}

public class Q193_ValidPhoneNumbers
{
    public string Command =>
    """
    cat q193.txt | awk '/^([0-9]{3}-|\([0-9]{3}\) )[0-9]{3}-[0-9]{4}$/'
    """;
}