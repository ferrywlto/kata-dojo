let sortBy = function (arr, fn) {
  let result = arr.sort((a, b) => fn(a) - fn(b));
  return result;
};

describe("Q2724 Sort By", () => {
  test.each([
    [[5, 4, 1, 2, 3], (x) => x, [1, 2, 3, 4, 5]],
    [
      [{ x: 1 }, { x: 0 }, { x: -1 }],
      (d) => d.x,
      [{ x: -1 }, { x: 0 }, { x: 1 }],
    ],
    [
      [
        [3, 4],
        [5, 2],
        [10, 1],
      ],
      (x) => x[1],
      [
        [10, 1],
        [5, 2],
        [3, 4],
      ],
    ],
  ])("args: %s, fn: %s, expected: %s", (args, fn, expected) => {
    let actual = sortBy(args, fn);
    expect(actual).toStrictEqual(expected);
  });
});
