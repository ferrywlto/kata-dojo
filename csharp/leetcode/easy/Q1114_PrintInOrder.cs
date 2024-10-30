using System.Text;
public class Foo
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
class Q1114_PrintInOrderTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,2,3}, "firstsecondthird"],
        [new int[]{1,3,2}, "firstsecondthird"],
    ];
}
public class Q1114_PrintInOrderTests
{
    [Theory]
    [ClassData(typeof(Q1114_PrintInOrderTestData))]
    public async void OfficialTestCases(int[] input, string expected)
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
