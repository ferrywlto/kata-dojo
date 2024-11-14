using System.Text;
class Foo
{
    protected int step = 0;
    public string First()
    {
        step++;
        return "first";
    }
    public string Second()
    {
        while(step <= 0) Thread.Sleep(1);
        step++;
        return "second";
    }
    public string Third()
    {
        while(step <= 1) Thread.Sleep(1);
        step++;
        return "third";
    }
}
public class Q1114_PrintInOrder
{
    public static List<object[]> TestData =>
    [
        [new int[]{1,2,3}, "firstsecondthird"],
        [new int[]{1,3,2}, "firstsecondthird"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public async Task OfficialTestCases(int[] input, string expected)
    {
        var sut = new Foo();
        var sb = new StringBuilder();

        await Parallel.ForEachAsync(input, (idx, CancellationToken) =>
        {
            switch (idx)
            {
                case 1: sb.Append(sut.First()); break;
                case 2: sb.Append(sut.Second()); break;
                case 3: sb.Append(sut.Third()); break;
                default: break;
            }
            return ValueTask.CompletedTask;
        });
        Assert.Equal(expected, sb.ToString());
    }
}
