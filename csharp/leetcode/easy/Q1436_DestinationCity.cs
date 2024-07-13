
class Q1436_DestinationCity
{
    public string DestCity(IList<IList<string>> paths) 
    {
        return string.Empty;    
    }    
}
class Q1436_DestinationCityTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            new List<List<string>>
            {
                new() {"London","New York"},
                new() {"New York","Lima"},
                new() {"Lima","Sao Paulo"} 
            }, "Sao Paulo"
        ],
        [
            new List<List<string>>
            {
                new() {"B","C"},
                new() {"D","B"},
                new() {"C","A"} 
            }, "A"
        ],
        [
            new List<List<string>>
            {
                new() {"A","Z"},
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