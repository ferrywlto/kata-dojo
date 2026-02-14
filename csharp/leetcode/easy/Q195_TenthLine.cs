class Q195_TenthLineTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            """
            Line 1
            Line 2
            Line 3
            Line 4
            Line 5
            Line 6
            Line 7
            Line 8
            Line 9
            Line 10
            """,
            "Line 10"
        ],
        [
            """
            Line 1
            Line 2
            Line 3
            Line 4
            Line 5
            Line 6
            Line 7
            Line 8
            Line 9
            """,
            ""
        ]
    ];
}

public class Q195_TenthLineTests(ITestOutputHelper output) : ShellTest(output)
{
    [Theory]
    [ClassData(typeof(Q195_TenthLineTestData))]
    public void Test(string input, string expected)
    {
        File.WriteAllText("./q195.txt", input.Trim());

        var sut = new Q195_TenthLine();
        var actual = Run(sut.Command);

        File.Delete("./q195.txt");

        var expectedLines = expected.Trim().Split(Environment.NewLine);
        var actualLines = actual.Trim().Split(Environment.NewLine);

        foreach (var line in actualLines)
        {
            Output!.WriteLine(line);
            Assert.Contains(line, expectedLines);
        }
    }
}

class Q195_TenthLine
{
    public string Command =>
    """
    awk 'NR == 10' q195.txt
    """;
}
