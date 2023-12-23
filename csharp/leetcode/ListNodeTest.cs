using dojo.leetcode;

public class ListNodeTest(ITestOutputHelper output) {
    protected readonly ITestOutputHelper output = output;
    public static ListNode GenerateListNode(int numDigits, int digitValue) {
        var head = new ListNode(digitValue);
        var current = head;
        for (int i = 1; i < numDigits; i++) {
            current.next = new ListNode(digitValue);
            current = current.next;
        }
        return head;
    }

    protected void AssertListNodeEquals(ListNode? expected, ListNode? actual) {
        if (expected == null && actual == null)
            return;
            
        Assert.Equal(CountList(expected), CountList(actual));

        while (expected != null && actual != null) {
            Assert.Equal(expected.val, actual.val);
            expected = expected.next;
            actual = actual.next;
        }
    }

    protected long CountList(ListNode? list) {
        var count = 0;
        while (list != null) {
            count++;
            list = list.next;
        }
        output.WriteLine($"count:{count}");
        return count;
    }

    protected void PrintList(ListNode? list) {
        var numList = new List<int>();
        while (list != null) {
            numList.Add(list.val);
            list = list.next;
        }
        var outputTxt = $"[{string.Join(",", numList)}]";
        output.WriteLine(outputTxt);
    }
}
