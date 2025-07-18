
public class Q2130_MaxTwinSumOfLinkedList : ListNodeTest
{
    public Q2130_MaxTwinSumOfLinkedList(ITestOutputHelper output) : base(output)
    {
    }

    public int PairSum(ListNode head)
    {
        return 0;
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
        var result = PairSum(input);
        Assert.Equal(expected, result);
    }
}