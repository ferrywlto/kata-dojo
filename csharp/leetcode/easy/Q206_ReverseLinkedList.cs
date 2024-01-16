
namespace dojo.leetcode;

public class Q206_ReverseLinkedList
{
    public ListNode ReverseList(ListNode? head)
    {
        return new ListNode();
    }
}

public class Q206_ReverseLinkedListTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[]{ 1, 2, 3, 4, 5 },
            new int[]{ 5, 4, 3, 2, 1 }
        ],
        [
            new int[] { 1, 2 },
            new int[] { 2, 1 }
        ],
        [
            Array.Empty<int>(),
            Array.Empty<int>(),
        ]
    ];
}

public class Q206_ReverseLinkedListTests(ITestOutputHelper output) : ListNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q206_ReverseLinkedListTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var expectedList = ListNode.FromArray(expected);
        var inputList = ListNode.FromArray(input);
        var sut = new Q206_ReverseLinkedList();
        var actualList = sut.ReverseList(inputList);
        PrintList(inputList);
        PrintList(actualList);


        AssertListNodeEquals(expectedList, actualList);
    }
}