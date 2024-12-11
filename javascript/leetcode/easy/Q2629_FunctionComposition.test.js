var compose = function(functions) {
    return function (x) {
        for (var i = functions.length -1 ; i >= 0; i--) {
            x = functions[i](x);
        }
        return x;
    }
};

describe('Q2629 Function Composition', () => { 
    test.each([
        [[x => x + 1, x => x * x, x => 2 * x], 4, 65],
        [[x => 10 * x, x => 10 * x, x => 10 * x], 1, 1000],
        [[], 42, 42],
    ])('After %s operations, input %i should equals to %i', (functions, n, expected) => {
        const fn = compose(functions);
        expect(fn(n)).toBe(expected);
    });
});