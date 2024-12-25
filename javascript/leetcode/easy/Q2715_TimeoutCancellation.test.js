let cancellable = function(fn, args, t) {
    let exec = setTimeout(() => {
        fn(...args)
    }, t);
    return () => clearTimeout(exec);
};

// describe('Q2715 Timeout Cancellation', () => {
//     test.each([
//         [(x) => x * 5, [2], 20, 50, 10],
//         [(x) => x**2, [2], 100, 50, [2]],
//         [(x1, x2) => x1 * x2, [2,4], 30, 100, 8],
//     ])('fn: %s, args: %s, t: %i, cancel: %i, expected: %s', async (fn, args, t, cancelTime, expected) => {
//         const cancelFn = cancellable(fn, args, t);
//         setTimeout(() => {
//             cancelFn();
//             console.log(cancelFn.answer);
//             console.log(expected);
//             expect(cancelFn.answer).toStrictEqual(expected);
//         });
//     });
// });