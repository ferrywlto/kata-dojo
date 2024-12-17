var once = function (fn) {
  let called = false;
  return function (...args) {
    if (!called) {
      called = true;
      return fn(...args);
    } else return undefined;
  };
};

describe("Q2666 Allow One Function Call", () => {
  test.each([
    [
      (a, b, c) => a + b + c,
      [
        [1, 2, 3],
        [2, 3, 6],
      ],
      [6, undefined],
    ],
    [
      (a, b, c) => a * b * c,
      [
        [5, 7, 4],
        [2, 3, 6],
        [4, 6, 8],
      ],
      [140, undefined, undefined],
    ],
  ])("fn: %s, calls: %s, expected: %s", (fn, calls, expected) => {
    let onceFn = once(fn);

    for (var i = 0; i < calls.length; i++) {
      let actual = onceFn(...calls[i]);
      expect(actual).toBe(expected[i]);
    }
  });
});
