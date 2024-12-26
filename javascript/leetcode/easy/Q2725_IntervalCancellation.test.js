let cancellable = function (fn, args, t) {
  let callCount = 1;
  let cancelHandler = setInterval(() => {
    callCount++;
  }, t);
  return {
    cancel: () => clearInterval(cancelHandler),
    inspect: () => callCount,
  };
};

describe("Q2725 Interval Cancellation", () => {
  test.each([
    [(x) => x * 2, [4], 35, 190, 6],
    [(x1, x2) => x1 * x2, [2, 5], 30, 165, 6],
    [(x1, x2, x3) => x1 + x2 + x3, [5, 1, 3], 50, 180, 4],
  ])("fn: %s, args: %s, t: %i, cancelTime: %i, expected: %i", (fn, args, t, cancelTimeMs, expected, done) => {
    let { cancel, inspect } = cancellable(fn, args, t);
    setTimeout(() => {
      cancel();
      expect(inspect()).toStrictEqual(expected);
      done();
    }, cancelTimeMs);
  });
});
