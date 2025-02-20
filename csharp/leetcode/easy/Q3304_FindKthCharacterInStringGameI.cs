using System.Text;

public class Q3304_FindKthCharacterInStringGameI
{
    // TC: O(log k)
    // SC: O(k), the string builder will have minimum k characters
    public char KthCharacter(int k)
    {
        var sb1 = new StringBuilder("a");
        var sb2 = new StringBuilder();
        while (sb1.Length < k)
        {
            sb2.Clear();
            for (var i = 0; i < sb1.Length; i++)
            {
                var c = sb1[i];
                if (c == 'z') c = 'a';
                else c++;
                sb2.Append(c);
            }
            sb1.Append(sb2);
        }
        // a b bc bccd bccdcdde
        return sb1[k - 1];
    }
    public static TheoryData<int, char> TestData => new()
    {
        {1, 'a'},
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