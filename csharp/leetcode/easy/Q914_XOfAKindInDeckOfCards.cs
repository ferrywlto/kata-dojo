
class Q914_XOfAKindInDeckOfCards
{
    public bool HasGroupsSizeX(int[] deck) 
    {
        return false;    
    }
}

class Q914_XOfAKindInDeckOfCardsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,2,3,4,4,3,2,1}, true],
        [new int[]{1,1,1,2,2,2,3,3}, false],
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