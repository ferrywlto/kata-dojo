public class Q3304_FindKthCharacterInStringGameI
{
    public char KthCharacter(int k)
    {
        return 'a';
    }
    public static TheoryData<int, char> TestData => new()
    {
        {5, 'b'},
        {10, 'c'},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, char expected)
    {
        var actual = KthCharacter(input);
        Assert.Equal(expected, actual);
    }
}