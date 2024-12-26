let cancellable = function (fn, args, t) {
  let answer = args;
  let exec = setTimeout(() => {
    answer = fn(...args);
  }, t);
  return {
    cancel: () => clearTimeout(exec),
    inspect: () => answer,
  };
};

describe("Q2715 Timeout Cancellation", () => {
  test.each([
    [(x) => x * 5, [2], 20, 50, 10],
    [(x) => x ** 2, [2], 100, 50, [2]],
    [(x1, x2) => x1 * x2, [2, 4], 30, 100, 8],
  ])(
    "fn: %s, args: %s, t: %i, cancel: %i, expected: %s",
    (fn, args, t, cancelTime, expected, done) => {
      const { cancel, inspect } = cancellable(fn, args, t);
      setTimeout(() => {
        cancel();
        expect(inspect()).toStrictEqual(expected);
        done();
      }, cancelTime);
    }
  );
});
