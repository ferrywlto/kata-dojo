
namespace dojo.leetcode;

public class Q242_ValidAnagram
{
    public bool IsAnagram(string s, string t) 
    {
        // First analysis s
        // Then analysis t

        var dict_s = new Dictionary<string, int>();
        var dict_t = new Dictionary<string, int>();

        foreach(var str in s)
        {
            if(dict_s.TryGetValue(str.ToString(), out var value)) 
            {
                dict_s[str.ToString()]++;
            }
            else 
            {
                dict_s.Add(str.ToString(), 1);
            }
        }

        foreach(var str in t)
        {
            if(dict_t.TryGetValue(str.ToString(), out var value)) 
            {
                dict_t[str.ToString()]++;
            }
            else 
            {
                dict_t.Add(str.ToString(), 1);
            }
        }

        foreach(var pair in dict_t)
        {
            if (!dict_s.TryGetValue(pair.Key, out int value)) return false;

            if (!(value == pair.Value)) return false;
        }

        foreach(var pair in dict_s)
        {
            if (!dict_t.TryGetValue(pair.Key, out int value)) return false;

            if (!(value == pair.Value)) return false;
        }

        return true;
    }
}

public class Q242_ValidAnagramTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["anagram", "nagaram", true],
        ["anagram😀", "😀nagaram", true],
        ["rat", "car", false],
        ["ab", "a", false],
    ];
}

public class Q242_ValidAnagramTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q242_ValidAnagramTestData))]
    public void OfficialTestCases(string input1, string input2, bool expected)
    {
        var sut = new Q242_ValidAnagram();
        var actual = sut.IsAnagram(input1, input2);
        Assert.Equal(expected, actual);
    }
}