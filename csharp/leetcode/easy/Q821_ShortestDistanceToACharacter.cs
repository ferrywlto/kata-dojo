class Q821_ShortestDistanceToACharacter
{
    // TC: O(n), n is length of s
    // SC: O(n), n is queue size
    // This can also be implemented in space O(1) appraoch, but much harder to read and reason, not the purpose of kata.
    public int[] ShortestToChar(string s, char c)
    {
        var answer = new int[s.Length];
        var idxQueue = new Queue<int>();
        var lastOccur = int.MaxValue;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != c)
            {
                idxQueue.Enqueue(i);
            }
            else
            {
                answer[i] = 0;
                while (idxQueue.Count > 0)
                {
                    var idx = idxQueue.Dequeue();
                    var diffFromLast = Math.Abs(lastOccur - idx);
                    var diffFromCurrent = idxQueue.Count + 1;
                    answer[idx] = Math.Min(diffFromLast, diffFromCurrent);
                }
                lastOccur = i;
            }
        }

        while (idxQueue.Count > 0)
        {
            var idx = idxQueue.Dequeue();
            answer[idx] = Math.Abs(lastOccur - idx);
        }
        return answer;
    }
}

class Q821_ShortestDistanceToACharacterTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["loveleetcode", 'e', new int[] { 3,2,1,0,1,0,0,1,2,2,1,0 }],
        ["aaab", 'b', new int[] { 3,2,1,0 }],
        ["aaba", 'b', new int[] { 2,1,0,1 }],
        ["abaa", 'b', new int[] { 1,0,1,2 }],
        ["abaab", 'b', new int[] { 1,0,1,1,0 }],
        ["babaab", 'b', new int[] { 0,1,0,1,1,0 }],
    ];
}

public class Q821_ShortestDistanceToACharacterTests
{
    [Theory]
    [ClassData(typeof(Q821_ShortestDistanceToACharacterTestData))]
    public void OfficialTestCases(string input, char character, int[] expected)
    {
        var sut = new Q821_ShortestDistanceToACharacter();
        var actual = sut.ShortestToChar(input, character);
        Assert.Equal(expected, actual);
    }
}
