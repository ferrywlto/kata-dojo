class Q434_NumberOfSegmentsInString
{

    // Constraints
    // Allowed characters "!@#$%^&*()_+-=',.:"
    // TC: O(n), SC: O(1)
    public int CountSegments(string s)
    {
        int count = 0;
        bool inSegment = false;
        for(var i=0; i<s.Length; i++) 
        {
            if(s[i] != ' ' && !inSegment) 
            {
                count++;
                inSegment = true;
            }
            else if(s[i] == ' ' && inSegment)
            {
                inSegment = false;
            }
        }
        
        return count;
    }
}

class Q434_NumberOfSegmentsInStringTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["Hello, my name is John", 5],
        ["Hello", 1],
        ["", 0],
        ["                ", 0],
        ["                a", 1],
    ];
}

public class Q434_NumberOfSegmentsInStringTests
{
    [Theory]
    [ClassData(typeof(Q434_NumberOfSegmentsInStringTestData))]
    public void OfficerTestCase(string input, int expected)
    {
        var sut = new Q434_NumberOfSegmentsInString();
        var actual = sut.CountSegments(input);
        Assert.Equal(expected, actual);
    }
}