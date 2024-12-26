var sortBy = function(arr, fn) {
    
};

describe('Q2724 Sort By', () => {
    test('', () => {
        const arr = [5, 4, 1, 2, 3];
        let fn = (x) => x;
        const expected = [1, 2, 3, 4, 5];

        let actual = sortBy(arr, fn);
        expect(actual).toBe(expected);
    });
});