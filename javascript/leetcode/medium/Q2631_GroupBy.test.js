function groupBy(fn) {
  return this.reduce((accumulator, item) => {
    const key = fn(item);
    if (!accumulator[key]) {
      accumulator[key] = [];
    }
    accumulator[key].push(item);
    return accumulator;
  }, {});
}
describe("Q2631 Is Object Empty", () => {
  test.each([
    [
      [
        { "id": "1" },
        { "id": "1" },
        { "id": "2" }
      ],
      (item) => item.id,
      {
        "1": [{ "id": "1" }, { "id": "1" }],
        "2": [{ "id": "2" }]
      }
    ],
    [
      [
        [1, 2, 3],
        [1, 3, 5],
        [1, 5, 9]
      ],
      (list) => String(list[0]),
      {
        "1": [[1, 2, 3], [1, 3, 5], [1, 5, 9]],
      }
    ],
    [
      [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
      (n) => String(n > 5),
      {
        "false": [1, 2, 3, 4, 5],
        "true": [6, 7, 8, 9, 10]
      }
    ],
  ])("%# input: %p, key function: %s, expected: %s", (input, keyFunc, expected) => {
    Array.prototype.groupBy = groupBy;
    const actual = input.groupBy(keyFunc);

    expect(actual).toStrictEqual(expected);
  });
});
