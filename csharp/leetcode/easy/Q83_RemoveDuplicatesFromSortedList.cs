public class Q83_RemoveDuplicatesFromSortedListTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] { 1, 1, 2 }, new int[] { 1, 2 }],
        [new int[] { 1, 1, 2, 3, 3 }, new int[] { 1, 2, 3 }],
        [new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 }]
    ];
}

public class Q83_RemoveDuplicatesFromSortedListTests(ITestOutputHelper output) : ListNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q83_RemoveDuplicatesFromSortedListTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {

        var sut = new Q83_RemoveDuplicatesFromSortedList();
        var head = ListNode.FromArray(input);
        var actual = sut.DeleteDuplicates(head!);
        var expectedList = ListNode.FromArray(expected);
        PrintList(actual);
        AssertListNodeEquals(expectedList, actual);
    }

    [Fact]
    public void ExtraCases()
    {
        var input = Enumerable.Repeat(1, 300).ToArray();
        var longList = ListNode.FromArray(input);
        var sut = new Q83_RemoveDuplicatesFromSortedList();
        var expected = ListNode.FromArray([1]);
        AssertListNodeEquals(expected, sut.DeleteDuplicates(longList!));
    }
}

public class Q83_RemoveDuplicatesFromSortedList
{
    // TC: O(n), SC: O(1)
    public ListNode DeleteDuplicates(ListNode head)
    {
        var current = head;

        while (current != null)
        {
            var input = current;
            var nextNode = input.next;
            // For each node, skip all the duplicates behind
            while (nextNode != null)
            {

                if (input.val != nextNode.val)
                {
                    input.next = nextNode;
                    break;
                }
                if (nextNode.next == null)
                {
                    // Terminate the last duplicate pointer
                    input.next = null;
                    break;
                }
                nextNode = nextNode.next;
            }
            current = current.next;
        }

        return head;
    }
}