using dojo.leetcode;

public class Q234_PalindromeLinkedList
{
    // Use 2 pointer, turtle-hare race technique to find the half of the list
    public bool IsPalindrome(ListNode head)
    {
        return false;
    }
}

public class Q234_PalindromeLinkedListTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,2,2,1}, true],
        [new int[]{1,2}, false],
    ];
}


public class Q234_PalindromeLinkedListTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q234_PalindromeLinkedListTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q234_PalindromeLinkedList();
        var linkedList = ListNode.FromArray(input);
        var actual = sut.IsPalindrome(linkedList!);
        Assert.Equal(expected, actual);
    }
}