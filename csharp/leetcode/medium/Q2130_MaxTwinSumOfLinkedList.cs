
public class Q2130_MaxTwinSumOfLinkedList(ITestOutputHelper output) : ListNodeTest(output)
{
    // TC: O(n), n scale with the length of the linked list
    // SC: O(n) for the list
    public int PairSum(ListNode head)
    {
        var count = 0;
        var node = head;
        var list = new List<int>();
        while (node != null)
        {
            count++;
            list.Add(node.Val);
            node = node.Next;
        }

        var max = int.MinValue;
        for (var i = 0; i < count / 2; i++)
        {
            var twinSum = list[i] + list[count - i - 1];
            if (twinSum > max)
                max = twinSum;
        }
        return max;
    }

    // TC: O(n), n scale with the length of the linked list
    // SC: O(1), no extra space used
    public int PairSumOptimized(ListNode head)
    {
        // This technique use a fast pointer to find the middle of the linked list
        // while reverse the first half of the linked list, after running the loop it will have:
        // slow tail-> 4 3 2 1 0 
        // slow:    -> 5 6 7 8 9
        var slow = head;
        var fast = head;
        var slowReverse = head;
        while (fast != null)
        {
            fast = fast.Next!.Next;
            var temp = slowReverse!.Next;
            slowReverse.Next = slow;
            slow = slowReverse;
            slowReverse = temp;
        }

        var max = int.MinValue;
        while (slowReverse != null)
        {
            max = Math.Max(max, slow!.Val + slowReverse!.Val);
            slow = slow.Next;
            slowReverse = slowReverse.Next;
        }

        return max;
    }
    public static TheoryData<ListNode, int> TestData => new()
    {
        {  ListNode.FromArray([5, 4, 2, 1])!, 6 },
        {  ListNode.FromArray([4, 2, 2, 3])!, 7 },
        {  ListNode.FromArray([1, 100000])!, 100001 },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(ListNode input, int expected)
    {
        var result = PairSumOptimized(input);
        Assert.Equal(expected, result);
    }
}
