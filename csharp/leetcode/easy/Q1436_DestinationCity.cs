class Q1436_DestinationCity
{
    // TC: O(n), n length of paths to get the origins + n length of paths to get the destinations + n length of paths to check which destination is not origin
    // SC: O(n), n to store all origins, n to store all destinations  
    public string DestCity(IList<IList<string>> paths)
    {
        var hashset = paths.Select(x => x[0]).ToHashSet();
        var destinations = paths.Select(x => x[1]);
        foreach (var d in destinations) if (!hashset.Contains(d)) return d;
        return string.Empty;
    }
}
class Q1436_DestinationCityTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new List<IList<string>>
            {
                new List<string>() {"London","New York"},
                new List<string>() {"New York","Lima"},
                new List<string>() {"Lima","Sao Paulo"}
            }, "Sao Paulo"
        ],
        [
            new List<IList<string>>
            {
                new List<string>() {"B","C"},
                new List<string>() {"D","B"},
                new List<string>() {"C","A"}
            }, "A"
        ],
        [
            new List<IList<string>>
            {
                new List<string>() {"A","Z"},
            }, "Z"
        ]
    ];
}
public class Q1436_DestinationCityTests
{
    [Theory]
    [ClassData(typeof(Q1436_DestinationCityTestData))]
    public void OfficialTestCases(List<IList<string>> input, string expected)
    {
        var sut = new Q1436_DestinationCity();
        var actual = sut.DestCity(input);
        Assert.Equal(expected, actual);
    }
}
