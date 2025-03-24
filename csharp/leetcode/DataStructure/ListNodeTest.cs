public abstract class ListNodeTest(ITestOutputHelper output) : TestBase(output) 
{
    public static void AssertListNodeEquals(ListNode? expected, ListNode? actual) 
    {
        if (expected == null && actual == null)
            return;
            
        Assert.Equal(CountList(expected), CountList(actual));

        while (expected != null && actual != null) {
            Assert.Equal(expected.val, actual.val);
            expected = expected.next;
            actual = actual.next;
        }
    }

    public static long CountList(ListNode? list, ITestOutputHelper? output = null)
    {
        var count = 0;
        while (list != null) {
            count++;
            list = list.next;
        }
        output?.WriteLine($"count:{count}");
        return count;
    }

    public static void PrintList(ListNode? list, ITestOutputHelper? output = null) 
    {
        var numList = new List<int>();
        while (list != null) {
            output?.WriteLine(list.val.ToString());
            numList.Add(list.val);
            list = list.next;
        }
        var outputTxt = $"[{string.Join(",", numList)}]";
        output?.WriteLine(outputTxt);
    }
}
