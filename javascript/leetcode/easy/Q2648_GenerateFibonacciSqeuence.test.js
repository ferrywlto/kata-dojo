var fibGenerator = function*() {
    
};

describe('Q2648 Generate Fibonacci Sequence', () => {
    test.each([
        [5, [0,1,1,2,3]],
        [0, []],
    ])('call count: %i, sequence: %s', (n, expected) => {
        const gen = fibGenerator();
        for (var i = 0; i < n; i++)
        {
            expect(gen.next().value).toBe(expected[i]);
        }
    })
});