class Q1603_DesignParkingSystem
{
    public Q1603_DesignParkingSystem(int big, int medium, int small)
    {

    }

    public bool AddCar(int carType)
    {
        return false;
    }
}
class Q1603_DesignParkingSystemTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [(1,1,0), new int[] { 1, 2, 3, 1 }, new bool[] {true, true, false, false}]
    ];
}
public class Q1603_DesignParkingSystemTests
{
    [Theory]
    [ClassData(typeof(Q1603_DesignParkingSystemTestData))]
    public void OfficialTestCases((int big, int medium, int small) input, int[] cars, bool[] expected)
    {
        var sut = new Q1603_DesignParkingSystem(input.big, input.medium, input.small);
        for(var i=0; i<cars.Length; i++)
        {
            var actual = sut.AddCar(cars[i]);
            Assert.Equal(expected[i], actual);
        }
    }
}
