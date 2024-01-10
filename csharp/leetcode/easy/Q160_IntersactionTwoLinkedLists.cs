using dojo.leetcode;

public class Q160_IntersactionTwoLinkedListTestData : TestDataBase
{
    protected override List<object[]> Data =>
    [
        [new int[]{4,1}, new int[]{5,6,1}, new int[]{8,4,5}],
        [new int[]{1,9,1}, new int[]{3}, new int[]{2}],
        [new int[]{2,6,4}, new int[]{1,5}, Array.Empty<int>()],
    ];
}
public class Q160_IntersactionTwoLinkedListTests(ITestOutputHelper output) : ListNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q160_IntersactionTwoLinkedListTestData))]
    public void OfficialTestCases(int[] listA, int[] listB, int[] listTail)
    {
        var sut = new Q160_IntersactionTwoLinkedList();

        var tail = ListNode.FromArray(listTail);
        var headA = ListNode.FromArray(listA);
        while (headA!.next != null) headA = headA.next;
        headA.next = tail;
        var headB = ListNode.FromArray(listB);
        while (headB!.next != null) headB = headB.next;
        headB.next = tail;

        var actual = sut.GetIntersectionNodeO1(headA, headB);

        if (listTail.Length == 0)
            Assert.Null(actual);
        else
            Assert.Equal(tail, actual);
    }
}
public class Q160_IntersactionTwoLinkedList
{
    // TC: O(length of list A + length of list B), SC: O(length of listA)
    public ListNode? GetIntersectionNode(ListNode? headA, ListNode? headB)
    {
        if (headA == headB) return headA;
        if (headA?.next == null && headB?.next == null) return null;

        var hashTable = new HashSet<ListNode>();
        while (headA != null)
        {
            hashTable.Add(headA);
            headA = headA.next;
        }
        while (headB != null)
        {
            if (hashTable.Contains(headB)) return headB;
            headB = headB.next;
        }
        return null;
    }

    // TC: O(length of list A + length of list B), SC: O(1)
    // This make use a technique to form a loop in a linked list
    // Then eventually the two pointers will meet at the intersection node
    public ListNode? GetIntersectionNodeO1(ListNode? headA, ListNode? headB)
    {
        if (headA == null || headB == null) return null;

        ListNode? pointer1 = headA, pointer2 = headB;

        // if there is no intersection, then the loop is not formed.
        // pointer1 will be null after run through the list A then B 
        // pointer2 will be null after run through the list B then A
        // which break the while loop and return null
        while (pointer1 != pointer2)
        {
            pointer1 = (pointer1 == null)
                    ? headB
                    : pointer1.next;
            pointer2 = (pointer2 == null)
                    ? headA
                    : pointer2.next;
        }

        return pointer1;
    }
}