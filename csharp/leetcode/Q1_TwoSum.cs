using System.Collections;
using System.Globalization;
using Xunit;

public class TwoSumTestData : IEnumerable<object[]> {
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[] {new int[]{2, 7, 11, 15}, 9, new int[]{0, 1}},
        new object[] {new int[]{3, 2, 4}, 6, new int[]{1, 2}},
        new object[] {new int[]{3, 3}, 6, new int[]{0, 1}},
        new object[] {new int[]{-1,-2,-3,-4,-5}, -8, new int[]{2, 4}},
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class TwoSumTests {

    [Theory]
    [ClassData(typeof(TwoSumTestData))]
    public void TwoSumTest(int[] nums, int target, int[] expected) {
        var subject = new TwoSum(); 
        var actual = subject.Solve(nums, target);
        Assert.Equal(expected, actual);
        // var actual2 = subject.Solve2(nums, target);
        // Assert.Equal(expected, actual2);
    }
}

public class TwoSum {
    // Work
    public int[] Solve(int[] input, int target) {
        if (input.Length < 2 || input.Length > 10000) {
            return new int[]{0};
        }
        for(var i=0; i<input.Length-1; i++) {
            var lookingFor = target - input[i];
            
            for (int j=i+1; j<input.Length; j++) {
                if (input[j] == lookingFor) 
                {
                    return new int[]{i, j};
                }
            }
        }
        return new[]{0};
    }

    // Try to be bettter
    public int[] Solve2(int[] input, int target) {

    }
}