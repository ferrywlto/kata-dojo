public class Q1079_LetterTilePossibilities
{
    public int NumTilePossibilities(string tiles)
    {

        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        // AAA
        // A + A + A
        // AA + A
        // A + AA
        // A + A
        // AA 
        // A
        // BB
        // B + B
        // B
        // C
        {"AAB", 8},
        // A
        // A + A
        // AA
        // B
        {"AAABBC", 188},
        {"V", 1},
        // VV = 2 (V, VV) = len 2, char count 1, repeat 2 = len^char count = 2^1 = 2
        // VX = V, VX, XV, X, len = 2, char count 2 = 2^2 = 4
        // AAA = A, AA, AAA = len = 3, char count 1 = 3^1 = 3
        // AAB = len3, char count =2 = 3^2 = 9, A, B, AA, AB, BA, AAB, ABA, BAA
        // ABC = len3, char count =3, A, B, C, AB, AC, BC, BA, CA, CB, ABC, ACB, BAC, BCA, CAB, CBA = 15
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = NumTilePossibilities(input);
        Assert.Equal(expected, actual);
    }
}