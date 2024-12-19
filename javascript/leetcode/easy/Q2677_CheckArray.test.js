var chunk = function(arr, size) {
    
};

describe('Q2677 Chunk Array', () => {
    test.each([
        [[1,2,3,4,5], 1, [[1],[2],[3],[4],[5]]],
        [[1,9,6,3,2], 3, [[1,9,6],[3,2]]],
        [[8,5,3,2,6], 6, [[8,5,3,2,6]]],
        [[], 1, []],
    ])('input: %s, size: %i, expected: %s', (input, size, expected) => {
        var actual = chunk(input, size);
        for (var i = 0; actual.length; i++)
        {
            let arr = actual[i];
            expect(arr).toBe(expected[i]);
        }
    });
});