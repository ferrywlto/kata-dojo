using dojo.leetcode;

public class Q21_MergeTwoListsTests(ITestOutputHelper output) : ListNodeTest(output) {
    [Theory]
    [InlineData(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 })]
    [InlineData(new int[] {}, new int[] {}, new int[] {})]
    [InlineData(new int[] {}, new int[] {0}, new int[] {0})]
    public void OfficialTestCases(int[] l1, int[] l2, int[] expected) {
        var list1 = ListNode.FromArray(l1);
        var list2 = ListNode.FromArray(l2);
        var actual = Q21_MergeTwoLists.MergeTwoLists(list1, list2);
        var expectedList = ListNode.FromArray(expected);
        AssertListNodeEquals(expectedList, actual);
    }
}

public class Q21_MergeTwoLists {
    
    public static ListNode? MergeTwoLists(ListNode? l1, ListNode? l2) {
        if (l1 == null && l2 == null)
            return null;
        else if(l1 == null)
            return l2;
        else if(l2 == null)
            return l1;
        

        return new ListNode(0);
    }
}
