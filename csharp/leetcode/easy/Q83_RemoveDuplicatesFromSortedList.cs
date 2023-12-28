using dojo.leetcode;

public class Q83_RemoveDuplicatesFromSortedListTests(ITestOutputHelper output) : ListNodeTest(output) {

    [Theory]
    [InlineData(new int[]{1,1,2}, new int[]{1,2})]
    [InlineData(new int[]{1,1,2,3,3}, new int[]{1,2,3})]
    public void OfficialTestCases(int[] input, int[] expected) {
        
        var sut = new Q83_RemoveDuplicatesFromSortedList();
        var head = ListNode.FromArray(input);
        var actual = sut.DeleteDuplicates(head!);
        var expectedList = ListNode.FromArray(expected);
        AssertListNodeEquals(expectedList, actual);
    }
}

public class Q83_RemoveDuplicatesFromSortedList {
    public ListNode DeleteDuplicates(ListNode head) {
        return new ListNode();    
    }
}