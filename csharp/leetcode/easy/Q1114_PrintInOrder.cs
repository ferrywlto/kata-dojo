public abstract class Foo
{
    public virtual void First(Action printFirst)
    {
        // printFirst() outputs "first". Do not change or remove this line.
        printFirst();
    }

    public virtual void Second(Action printSecond)
    {
        // printSecond() outputs "second". Do not change or remove this line.
        printSecond();
    }

    public virtual void Third(Action printThird)
    {
        // printThird() outputs "third". Do not change or remove this line.
        printThird();
    }
}

class Q1114_PrintInOrder : Foo
{

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
        var sut = new Q1114_PrintInOrder();
        var output = new StringWriter();
        Console.SetOut(output);

        await Parallel.ForEachAsync(input, (idx, CancellationToken) =>
        {
            switch (idx)
            {
                case 1: sut.First(CallAction(idx)); break;
                case 2: sut.Second(CallAction(idx)); break;
                case 3: sut.Third(CallAction(idx)); break;
                default: break;
            }
            return ValueTask.CompletedTask;
        });
        Assert.Equal(expected, output.ToString());
    }

    Action CallAction(int methodId) =>
     methodId switch
     {
         1 => () => Console.Write("first"),
         2 => () => Console.Write("second"),
         3 => () => Console.Write("third"),
         _ => () => Console.Write("unknown")
     };
}
