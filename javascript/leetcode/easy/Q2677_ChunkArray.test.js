var chunk = function (arr, size) {
  let result = [];
  for (var i = 0; i < arr.length; i += size) {
    result.push(arr.slice(i, i + size));
  }
  return result;
};

describe("Q2677 Chunk Array", () => {
  test.each([
    [[1, 2, 3, 4, 5], 1, [[1], [2], [3], [4], [5]]],
    [
      [1, 9, 6, 3, 2],
      3,
      [
        [1, 9, 6],
        [3, 2],
      ],
    ],
    [[8, 5, 3, 2, 6], 6, [[8, 5, 3, 2, 6]]],
    [[], 1, []],
  ])("input: %s, size: %i, expected: %s", (input, size, expected) => {
    var actual = chunk(input, size);
    console.log(actual.length);
    for (var i = 0; i < actual.length; i++) {
      expect(actual[i]).toStrictEqual(expected[i]);
    }
  });
});
