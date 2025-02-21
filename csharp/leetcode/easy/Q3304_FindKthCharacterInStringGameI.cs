using System.Text;

public class Q3304_FindKthCharacterInStringGameI(ITestOutputHelper output)
{
    // TC: O(log k)
    // SC: O(k), the string builder will have minimum k characters
    public char KthCharacter(int k)
    {
        var x = (k-1) % 16;
        var y = (k-1) / 16;
        var str = "abbcbccdbccdcdde";
        var result = str[x] + y;
        output.WriteLine("x: {0}, y: {1}, r: {2}", x, y, (char)result);
        
        return (char)result;
        // var sb1 = new StringBuilder("a");
        // var sb2 = new StringBuilder();
        // var sb3 = new StringBuilder();
        // while (sb1.Length < k)
        // {
        //     sb3.Clear();
        //     for (var i = 0; i < sb2.Length; i++)
        //     {
        //         var c = sb1[i];
        //         if (c == 'z') c = 'a';
        //         else c++;
        //         sb2.Append(c);
        //     }
        //     sb1.Append(sb2);
        // }
        // a b bc bccd bccdcdde
        // a 1
        // ab 12
        // abbc 1223
        // abbcbccd 
        // 1223
        // 2334
        // 2334
        // 3445
        
        // 2334
        // 3445
        // 3445
        // 4556
        
        // 2334
        // 3445
        // 3445
        // 4556
        
        // 3445
        // 4556
        // 4556
        // 5667

        // 0 1
        // 1 2
        // 2 2
        // 3 3
        // 4 2
        // 5 3
        // 6 3
        // 7 4
        // return sb1[k - 1];
    }
    public static TheoryData<int, char> TestData => new()
    {
        {1, 'a'},
        {5, 'b'},
        {10, 'c'},
        {16, 'e'},
        {17, 'b'},
        {33, 'b'},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, char expected)
    {
        var actual = KthCharacter(input);
        Assert.Equal(expected, actual);
    }
}