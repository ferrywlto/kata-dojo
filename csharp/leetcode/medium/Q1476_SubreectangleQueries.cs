internal class SubrectangleQueries {

    public SubrectangleQueries(int[][] rectangle) {
        
    }
    
    public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue) {
        
    }
    
    public int GetValue(int row, int col) {
        
    }
}
public class Q1476_SubreectangleQueries
{
    public static TheoryData<string[], int[][], int[][], int?[]> TestData => new ()
    {
        {
            ["getValue","updateSubrectangle","getValue","getValue","updateSubrectangle","getValue","getValue"],
            [
                [1,2,1],
                [4,3,4],
                [3,2,1],
                [1,1,1]
            ],
            [
                [0,2],
                [0,0,3,2,5],
                [0,2],
                [3,1],
                [3,0,3,2,10],
                [3,1],
                [0,2]
            ],
            [null,1,null,5,5,null,10,5]               
        }
    };
    public void Test(string[] commands, int[][] init, int[][] inputs, int[] expected)
    {
        var sut = new SubrectangleQueries(init);
        for(var i = 0; i<commands.Length; i++)
        {
            var cmd = commands[i];
            var input = inputs[i];
            if(cmd == "getValue") 
            {
                var actual = sut.GetValue(input[0], input[1]);
                Assert.Equal(expected[i], actual);
            }
            else if(cmd == "updateSubrectangle")
            {
                sut.UpdateSubrectangle(input[0], input[1], input[2], input[3], input[4]);
            }
        }
    }
}

