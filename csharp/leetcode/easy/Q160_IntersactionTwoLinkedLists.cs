using dojo.leetcode;

public class Q160_IntersactionTwoLinkedListTestData : LeetCodeTestData
{
    protected override List<object[]> Data() =>
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

        var actual = sut.GetIntersectionNode(headA, headB);

        if (listTail.Length == 0)
            Assert.Null(actual);
        else
            Assert.Equal(tail, actual);
    }
}
public class Q160_IntersactionTwoLinkedList 
{
    public ListNode? GetIntersectionNode(ListNode? headA, ListNode? headB) 
    {
        if (headA == headB) return headA;
        if (headA?.next == null && headB?.next == null) return null;

        var hashTable = new HashSet<ListNode>();
        while(headA != null) 
        {
            hashTable.Add(headA);
            headA = headA.next;
        }
        while(headB != null) 
        {
            if (hashTable.Contains(headB)) return headB;
            headB = headB.next;
        }
        return null;
    }
}