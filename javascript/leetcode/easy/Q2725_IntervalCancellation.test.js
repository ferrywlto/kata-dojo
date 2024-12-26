let result = 0;

let cancellable = function (fn, args, t) {
  result = fn(...args);
  let cancelHandler = setInterval(() => {
    result = fn(...args);
  }, t);
  return () => {
    clearInterval(cancelHandler);
  };
};

describe("Q2725 Interval Cancellation", () => {
  test("", (done) => {
    const fn = (x) => x * 2;
    const args = [4],
      t = 35,
      cancelTimeMs = 190;

    let cancelFn = cancellable(fn, args, t);
    setTimeout(() => {
      cancelFn();
      expect(result).toStrictEqual(8);
      done();
    }, cancelTimeMs);
  });
});