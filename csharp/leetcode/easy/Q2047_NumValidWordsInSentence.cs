public class Q2047_NumValidWordsInSentence
{
    // TC: O(n), n scale with length of sentence
    // SC: O(1), space used does not scale with input
    public int CountValidWords(string sentence)
    {
        var wordCount = 0;
        var wordStartIdx = -1;

        for (var i = 0; i < sentence.Length; i++)
        {
            var c = sentence[i];
            if (c == ' ')
            {
                if (wordStartIdx != -1)
                {
                    if (IsValid(sentence[wordStartIdx..i])) wordCount++;
                    wordStartIdx = -1;
                }
            }
            else if (wordStartIdx == -1) wordStartIdx = i;
        }
        if (wordStartIdx != -1)
        {
            if (IsValid(sentence[wordStartIdx..])) wordCount++;
        }
        return wordCount;
    }
    static readonly HashSet<char> Punctuations = ['!', '.', ','];
    const char Hyphen = '-';
    public bool IsValid(string input)
    {
        var hyphenCount = 0;
        var punctuationCount = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];
            if (char.IsAsciiDigit(c)) return false;
            if (c == Hyphen)
            {
                if (hyphenCount > 0) return false;
                if (i == 0 || i == input.Length - 1) return false;
                if (!(char.IsAsciiLetterLower(input[i - 1]) &&
                char.IsAsciiLetterLower(input[i + 1]))) return false;
                hyphenCount++;
            }
            else if (Punctuations.Contains(c))
            {
                if (punctuationCount > 0) return false;
                if (i != input.Length - 1) return false;
                punctuationCount++;
            }
        }
        return true;
    }

    public static List<object[]> TestData =>
    [
        ["c", 1],
        ["1", 0],
        ["1 a-b!", 1],
        ["!", 1],
        ["c-", 0],
        ["c-b-a", 0],
        ["c--a", 0],
        ["-a-c", 0],
        ["a-c-", 0],
        ["f    6c x2", 1],
        ["a-b. afad ba-c a! !", 5],
        ["cat and  dog", 3],
        ["!this  1-s b8d!", 0],
        ["alice and  bob are playing stone-game10", 5],
        ["he bought 2 pencils, 3 erasers, and 1  pencil-sharpener.", 6],
        [" 62   nvtk0wr4f  8 qt3r! w1ph 1l ,e0d 0n 2v 7c.  n06huu2n9 s9   ui4 nsr!d7olr  q-, vqdo!btpmtmui.bb83lf g .!v9-lg 2fyoykex uy5a 8v whvu8 .y sc5 -0n4 zo pfgju 5u 4 3x,3!wl  fv4   s  aig cf j1 a i  8m5o1  !u n!.1tz87d3 .9    n a3  .xb1p9f  b1i a j8s2 cugf l494cx1! hisceovf3 8d93 sg 4r.f1z9w   4- cb r97jo hln3s h2 o .  8dx08as7l!mcmc isa49afk i1 fk,s e !1 ln rt2vhu 4ks4zq c w  o- 6  5!.n8ten0 6mk 2k2y3e335,yj  h p3 5 -0  5g1c  tr49, ,qp9 -v p  7p4v110926wwr h x wklq u zo 16. !8  u63n0c l3 yckifu 1cgz t.i   lh w xa l,jt   hpi ng-gvtk8 9 j u9qfcd!2  kyu42v dmv.cst6i5fo rxhw4wvp2 1 okc8!  z aribcam0  cp-zp,!e x  agj-gb3 !om3934 k vnuo056h g7 t-6j! 8w8fncebuj-lq    inzqhw v39,  f e 9. 50 , ru3r  mbuab  6  wz dw79.av2xp . gbmy gc s6pi pra4fo9fwq k   j-ppy -3vpf   o k4hy3 -!..5s ,2 k5 j p38dtd   !i   b!fgj,nx qgif ", 49],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = CountValidWords(input);
        Assert.Equal(expected, actual);
    }
}
