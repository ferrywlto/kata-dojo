
using dojo.leetcode;

public class Q141_LinkedListCycleTests : ListNodeTest
{
    public Q141_LinkedListCycleTests(ITestOutputHelper output) : base(output) { }

    [Theory]
    [InlineData(new int[] { 3, 2, 0, -4 }, 1, true)]
    [InlineData(new int[] { 1, 2 }, 0, true)]
    [InlineData(new int[] { 1 }, -1, false)]
    [InlineData(new int[] { }, -1, false)]
    public void OfficialTestCases(int[] input, int pos, bool expected)
    {
        var sut = new Q141_LinkedListCycle();
        var node = ListNode.FromArray(input);
        SetCycle(node!, pos);
        var act = sut.HasCycle(node!);
        Assert.Equal(expected, act);
    }

    private void SetCycle(ListNode node, int pos)
    {
        if (pos == -1) return;

        var current = 0;
        ListNode? loopHead = null;
        while (node.next != null)
        {
            if (current == pos)
            {
                loopHead = node;
            }
            else
            {
                current++;
            }

            node = node.next;
            if (node.next == null)
            {
                node.next = loopHead;
                return;
            }
        }
    }
}
public class Q141_LinkedListCycle
{
    // Technique: Race of Tortoise and Hare
    // The idea important thing is we need to have two pointers in different speed.
    // If there is no cycle, the fast pointer will reach the end of the list and complete.
    // If there is a cycle, the fast point will somehow meet the slow pointer again.
    // By using two pointers, there is no need to store the visited nodes in a stucture, thus TC:O(n) an SC:O(1) can be achieved.
    public bool HasCycle(ListNode? head)
    {
        if (head == null) return false;

        var fast = head;
        var slow = head;
        while (fast.next != null && fast.next.next != null)
        {
            fast = fast.next.next;
            slow = slow!.next;
            if (fast == slow)
                return true;
        }
        return false;
    }
}