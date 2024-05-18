
class Q914_XOfAKindInDeckOfCards
{
    // TC: O(n^2), n is length of deck, m is distinct values in deck, 
    // which need to interate twice, one to check if there is a number occured only once,
    // second is to get the minimum, third is to check if all divisible
    public bool HasGroupsSizeX(int[] deck) 
    {
        if (deck.Length == 1) return false;
        Console.WriteLine($"count: {deck.Length}");
        var freq = deck.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        if (freq.Any(x => x.Value == 1)) return false;

        var min = freq.Min(x => x.Value);
        var hashset = new HashSet<int>();

        // the trick here is to get all divisor of the smallest number, 
        // a HCF that can divide all numbers, must be divisible even the smallest number
        for(var i = 2; i<=Math.Sqrt(min); i++)
        {
            if (min % i == 0)
            {
                hashset.Add(i);
                hashset.Add(min / i);
            }
        }
        hashset.Add(min);
        foreach(var n in hashset)
        {
            if (freq.All(x => x.Value % n == 0)) return true;
        }

        return false;
    }
}

class Q914_XOfAKindInDeckOfCardsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,2,3,4,4,3,2,1}, true],
        [new int[]{1,1,2,2,2,2}, true],
        [new int[]{1,1,1,1,2,2,2,2,2,2}, true],
        [new int[]{1,1,1,2,2,2,3,3}, false],
        [new int[]{0,0,0,1,1,1,1,1,1,2,2,2,3,3,3}, true],
        [new int[]{0,0,0,0,0,1,1,2,3,4}, false],
    ];
}

public class Q914_XOfAKindInDeckOfCardsTests
{
    [Theory]
    [ClassData(typeof(Q914_XOfAKindInDeckOfCardsTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q914_XOfAKindInDeckOfCards();
        var actual = sut.HasGroupsSizeX(input);
        Assert.Equal(expected, actual);
    }
}