namespace dojo.leetcode;

public class ListNode 
{
    public int val;
    public ListNode? next;
    public ListNode(int val=0, ListNode? next=null) 
    {
        this.val = val;
        this.next = next;
    }

    public static ListNode? FromArray(int[] arr) 
    {
        if (arr.Length == 0)
            return null;

        var head = new ListNode(arr[0]);
        var current = head;
        for (int i = 1; i < arr.Length; i++) 
        {
            current.next = new ListNode(arr[i]);
            current = current.next;
        }
        return head;
    }
}

public class ListNodeTest(ITestOutputHelper output) : TestBase(output) 
{
    public static ListNode GenerateListNode(int numDigits, int digitValue) 
    {
        var head = new ListNode(digitValue);
        var current = head;
        for (int i = 1; i < numDigits; i++) {
            current.next = new ListNode(digitValue);
            current = current.next;
        }
        return head;
    }

    protected void AssertListNodeEquals(ListNode? expected, ListNode? actual) 
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

    protected long CountList(ListNode? list) 
    {
        var count = 0;
        while (list != null) {
            count++;
            list = list.next;
        }
        output.WriteLine($"count:{count}");
        return count;
    }

    protected void PrintList(ListNode? list) 
    {
        var numList = new List<int>();
        while (list != null) {
            output.WriteLine(list.val.ToString());
            numList.Add(list.val);
            list = list.next;
        }
        var outputTxt = $"[{string.Join(",", numList)}]";
        output.WriteLine(outputTxt);
    }
}
