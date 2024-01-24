namespace dojo.leetcode;

public class Q234_PalindromeLinkedList
{
    // Use 2 pointer, turtle-hare race technique to find the half of the list
    public bool IsPalindrome(ListNode head)
    {
        if (head == null) return false;
        if (head.next == null) return true;
        if (head.next.next == null) return head.val == head.next.val;

        var middle = FindMiddle(head);
        var reverse = ReverseList(middle);

        var listA = head;
        var listB = reverse;
        while(listA != middle) 
        {
            if (listA?.val != listB?.val) return false;
            listA = listA?.next;
            listB = listB?.next;
        }

        return true;
    }

    // the technique is here: if fast reach to end, slow must be at the middle of the list
    public ListNode? FindMiddle(ListNode head)
    {
        if (head == null) return null;
        if (head.next == null) return head;
        var slow = head;
        var fast = head;

        while(fast != null && fast.next != null) 
        {
            slow = slow?.next;
            fast = fast.next?.next;
        }

        return slow;
    }

    // Copy from Q206
    public ListNode? ReverseList(ListNode? head)
    {
        if (head == null) return null;
        if (head.next == null) return head;
        if (head.next.next == null)
        {
            var tail = head.next;
            tail.next = head;
            head.next = null;
            head = tail;
            return head;
        }

        var prev = head;
        var curr = prev.next;
        var next = curr.next;
        // important, end the loop
        prev.next = null;

        while (next != null)
        {
            curr!.next = prev;
            prev = curr;
            curr = next;
            next = next?.next;
        }
        curr!.next = prev;
        head = curr;
        return head;
    }
}

public class Q234_PalindromeLinkedListTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,2,2,1}, true],
        [new int[]{1,2,3,2,1}, true],
        [new int[]{1,2,3,4,2,1}, false],
        [new int[]{1,2,3,4,3,2,1}, true],
        [new int[]{1,1,1,1,1,1,1}, true],
        [new int[]{1,1,2,2,1,1}, true],
        [new int[]{1,1,2,2,1,2}, false],
        [new int[]{1,2}, false],
    ];
}


public class Q234_PalindromeLinkedListTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q234_PalindromeLinkedListTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q234_PalindromeLinkedList();
        var linkedList = ListNode.FromArray(input);
        var actual = sut.IsPalindrome(linkedList!);
        Assert.Equal(expected, actual);
    }
}