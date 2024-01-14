namespace dojo.leetcode;

public class Q203_RemoveLinkeListElementsTests(ITestOutputHelper output) : ListNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q203_RemoveLinkeListElementsTestData))]
    public void OfficialTestCases(int[] input, int val, int[] expected)
    {
        var expectedList = ListNode.FromArray(expected);
        var head = ListNode.FromArray(input);
        var sut = new Q203_RemoveLinkeListElements();
        var actual = sut.RemoveElements(head, val);

        AssertListNodeEquals(expectedList, actual);
    }
}

public class Q203_RemoveLinkeListElementsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[]{1,2,6,3,4,5,6},
            6,
            new int[]{1,2,3,4,5}
        ],
        [
            new int[]{7,7,7,7},
            7,
            Array.Empty<int>()
        ],
        [
            Array.Empty<int>(),
            1,
            Array.Empty<int>()
        ]
    ];
}

public class Q203_RemoveLinkeListElements
{
    public ListNode? RemoveElements(ListNode? head, int val)
    {
        return null;
    }   
}