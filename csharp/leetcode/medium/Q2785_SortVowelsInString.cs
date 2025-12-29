using System.Text;

// TC: O(n), n scale with length of s
// SC: O(n), for string builder to hold the result
public class Q2785_SortVowelsInString
{
    readonly int[] charCount = new int[123]; // z is 122
    readonly int[] vowelIdx = [65, 69, 73, 79, 85, 97, 101, 105, 111, 117];
    readonly HashSet<char> vowels = ['A','E','I','O','U','a','e','i','o','u'];

    public string SortVowels(string s)
    {        
        foreach(var c in s) charCount[c]++;

        var currVowelIdx = 0;

        for(var i = 0; i<vowelIdx.Length; i++)
        {
            if(charCount[vowelIdx[i]] != 0)
            {
                currVowelIdx = i;
                break;
            }
        }

        // No vowel at all.
        if (currVowelIdx > 117) return s;

        var sb = new StringBuilder();
        foreach(var c in s)
        {
            if(vowels.Contains(c))
            {
                var currVowel = (char)vowelIdx[currVowelIdx];
                sb.Append(currVowel);

                charCount[currVowel]--;
                if(charCount[currVowel] == 0)
                {
                    // Get the next non empty vowel
                    while(currVowelIdx < 10 && charCount[vowelIdx[currVowelIdx]] == 0)
                    {
                        currVowelIdx++;
                    }
                }
            }
            else sb.Append(c);
        }
        return sb.ToString();
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"lEetcOde", "lEOtcede" },
        {"lYmpH", "lYmpH" },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = SortVowels(input);
        Assert.Equal(expected, actual);
    }
}
