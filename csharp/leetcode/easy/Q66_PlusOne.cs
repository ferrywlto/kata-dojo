public class Q66_PlusOneTests {
    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 })]
    [InlineData(new int[] { 4, 3, 2, 1 }, new int[] { 4, 3, 2, 2 })]
    [InlineData(new int[] { 9 }, new int[] { 1, 0 })]
    [InlineData(new int[] { 9, 9, 9 }, new int[] { 1, 0, 0, 0 })]
    public void OfficalTestCases(int[] input, int[] expected) {
        var solution = new Q66_PlusOne();
        var result = solution.PlusOne(input);
        Assert.Equal(expected, result);
    }
}

public class Q66_PlusOne {
    // Using string representation of the number will not work as the number can be too big to parse
    // Speed: 99ms (98.33%), Memory: 45.33MB (5.01%)
    public int[] PlusOne(int[] input) {
        if (input[^1] < 9) {
            input[^1]++;
            return input;
        }
        else {
            input[^1] = 0;
        }

        bool carryOver = true;
        for (int i = input.Length - 2; i >= 0; i--) {
            if (carryOver) {
                if (input[i] == 9) {
                    input[i] = 0;
                    carryOver = true;
                } else {
                    input[i]++;
                    return input;
                }
            } else {
                return input;
            }
        }

        if (input[0] != 0) return input;

        var newArray = new int[input.Length + 1];
        newArray[0] = 1;
        Array.Copy(input, 0, newArray, 1, input.Length);
        return newArray;
    }
}