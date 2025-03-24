class Q234_PalindromeLinkedList
{
    // Use 2 pointer, turtle-hare race technique to find the half of the list
    public bool IsPalindrome(ListNode head)
    {
        if (head == null) return false;
        if (head.Next == null) return true;
        if (head.Next.Next == null) return head.Val == head.Next.Val;

        var middle = FindMiddle(head);
        var reverse = ReverseList(middle);

        var listA = head;
        var listB = reverse;
        while(listA != middle) 
        {
            if (listA?.Val != listB?.Val) return false;
            listA = listA?.Next;
            listB = listB?.Next;
        }

        return true;
    }

    // the technique is here: if fast reach to end, slow must be at the middle of the list
    public ListNode? FindMiddle(ListNode head)
    {
        if (head == null) return null;
        if (head.Next == null) return head;
        var slow = head;
        var fast = head;

        while(fast != null && fast.Next != null) 
        {
            slow = slow?.Next;
            fast = fast.Next?.Next;
        }

        return slow;
    }

    // Copy from Q206
    public ListNode? ReverseList(ListNode? head)
    {
        if (head == null) return null;
        if (head.Next == null) return head;
        if (head.Next.Next == null)
        {
            var tail = head.Next;
            tail.Next = head;
            head.Next = null;
            head = tail;
            return head;
        }

        var prev = head;
        var curr = prev.Next;
        var next = curr.Next;
        // important, end the loop
        prev.Next = null;

        while (next != null)
        {
            curr!.Next = prev;
            prev = curr;
            curr = next;
            next = next?.Next;
        }
        curr!.Next = prev;
        head = curr;
        return head;
    }
}

class Q234_PalindromeLinkedListTestData: TestData
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


public class Q234_PalindromeLinkedListTests
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