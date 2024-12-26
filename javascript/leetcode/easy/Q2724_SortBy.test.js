var sortBy = function (arr, fn) {
  let result = arr.sort((a, b) => fn(a) - fn(b));
  return result;
};

describe("Q2724 Sort By", () => {
  test("", () => {
    const arr = [5, 4, 1, 2, 3];
    let fn = (x) => x;
    const expected = [1, 2, 3, 4, 5];

    let actual = sortBy(arr, fn);
    expect(actual).toStrictEqual(expected);
  });
  test("", () => {
    const arr = [{ x: 1 }, { x: 0 }, { x: -1 }];
    let fn = (d) => d.x;
    const expected = [{ x: -1 }, { x: 0 }, { x: 1 }];

    let actual = sortBy(arr, fn);
    expect(actual).toStrictEqual(expected);
  });
  test("", () => {
    const arr = [
      [3, 4],
      [5, 2],
      [10, 1],
    ];
    let fn = (x) => x[1];
    const expected = [
      [10, 1],
      [5, 2],
      [3, 4],
    ];

    let actual = sortBy(arr, fn);
    expect(actual).toStrictEqual(expected);
  });
});
