public class Q2683_NeighboringBitwiseXOR
{
    // TC: O(n), n scale with length of derived
    // SC: O(1), space used does not scale with input    
    public bool DoesValidArrayExist(int[] derived)
    {
        var result = derived[0];
        /*
        Hint 1:
        Understand that from the original element, we are using each element twice to construct the derived array
        let assume original = [a , b , c];
        then derived = (a^b)^(b^c)^(c^a)

        Hint 2:
        The xor-sum of the derived array should be 0 since there is always a duplicate occurrence of each element.

        Explanation:
        First, for any number A, A ^ A = 0. You can easily prove this with the definition of XOR.
        Second, for any number A, A ^ 0 = A. You can easily prove this with the definition of XOR.
        Third, for any numbers: A, B, C, we have that: (A ^ B) ^ C = A ^ (B ^ C). You can prove this using a truth table.

        Now using these 3 properties, we have the following:

        (a ^ b) ^ (b ^ c) ^ (c ^ a) = a ^ (b ^ b) ^ (c ^ c) ^ a, using property 3.
        = a ^ 0 ^ 0 ^ a, using property 1.
        = a ^ a, using property 2.
        = 0, using property 1.

        Hence, we have that XOR-sum(derived) = 0.
         */
        for (var i = 1; i < derived.Length; i++)
        {
            result ^= derived[i];
        }

        return result == 0;
    }

    public static TheoryData<int[], bool> TestData => new()
    {
        { [1, 1, 0], true }, { [1, 1], true }, { [1, 0], false },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = DoesValidArrayExist(input);
        Assert.Equal(expected, actual);
    }
}
