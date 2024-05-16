class Q953_VerifyAlienDictionary
{
    Dictionary<char, int> alienDict = [];
    public bool IsAlienSorted(string[] words, string order)
    {
        alienDict = [];
        for (var i = 0; i < order.Length; i++)
        {
            alienDict.Add(order[i], i + 1);
        }
        var maxLength = words.Max(x => x.Length);
        var vector = new int[words.Length];

        for (var i = 0; i < maxLength; i++)
        {
            UpdateColumnVector(words, i, vector);
            var acsending = true;
            for (var j = 0; j < vector.Length - 1; j++)
            {
                if (vector[j + 1] < vector[j]) return false;
                acsending = acsending && (vector[j + 1] > vector[j]);
            }
            if (acsending) return true;
        }
        return true;
    }
    public void UpdateColumnVector(string[] words, int idx, int[] vector)
    {
        for (var i = 0; i < words.Length; i++)
        {
            if (idx >= words[i].Length) vector[i] = 0;
            else vector[i] = alienDict[words[i][idx]];
        }
    }
}

class Q953_VerifyAlienDictionaryTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"iekm","tpnhnbe"}, "loxbzapnmstkhijfcuqdewyvrg", false],
        [new string[] {"hello","hello"}, "abcdefghijklmnopqrstuvwxyz", true],
        [new string[] {"hello","leetcode"}, "hlabcdefgijkmnopqrstuvwxyz", true],
        [new string[] {"word","world","row"}, "worldabcefghijkmnpqstuvxyz", false],
        [new string[] {"apple","app"}, "abcdefghijklmnopqrstuvwxyz", false],
    ];
}

public class Q953_VerifyAlienDictionaryTests
{
    [Theory]
    [ClassData(typeof(Q953_VerifyAlienDictionaryTestData))]
    public void OfficialTestCases(string[] input, string order, bool expected)
    {
        var sut = new Q953_VerifyAlienDictionary();
        var actual = sut.IsAlienSorted(input, order);
        Assert.Equal(expected, actual);
    }
}