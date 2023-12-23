using dojo.leetcode;

public class Q21_MergeTwoListsTests(ITestOutputHelper output) : ListNodeTest(output) {
    [Theory]
    [InlineData(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 })]
    [InlineData(new int[] {}, new int[] {}, new int[] {})]
    [InlineData(new int[] {}, new int[] {0}, new int[] {0})]
    public void OfficialTestCases(int[] l1, int[] l2, int[] expected) {
        var list1 = ListNode.FromArray(l1);
        var list2 = ListNode.FromArray(l2);
        var expectedList = ListNode.FromArray(expected);
        var actual = Q21_MergeTwoLists.MergeTwoLists(list1, list2);
        AssertListNodeEquals(expectedList, actual);
    }
}

public class Q21_MergeTwoLists {
    
    // Speed: 45ms (100%), Memory: 41.4MB (8.83%)
    // Don't think there is room to use less memory as there is only references to the nodes, no data/node created. 
    public static ListNode? MergeTwoLists(ListNode? l1, ListNode? l2) {
        if (l1 == null && l2 == null)
            return null;
        else if(l1 == null)
            return l2;
        else if(l2 == null)
            return l1;
        
        ListNode current;
        if(l1.val >= l2.val) {
            current = l2;
            l2 = l2.next;
        } else {
            current = l1;
            l1 = l1.next;
        }
        var head = current;

        while (l1 != null && l2 != null) {
            if (l1.val >= l2.val) {
                current.next = l2;
                l2 = l2.next;
            } else {
                current.next = l1;
                l1 = l1.next;
            }
            current = current.next;
        }

        if (l1 != null)
            current.next = l1;
        else if (l2 != null)
            current.next = l2;

        return head;
    }
}
