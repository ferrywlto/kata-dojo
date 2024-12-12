var filter = function (arr, fn) {
  var result = new Array();
  for (var i = 0; i < arr.length; i++) {
    var temp = fn(arr[i], i);
    result.push(temp);
  }
  return result;
};

describe("Q2635 Apply Transform Over Each Element in Array", () => {
  test.each([
    [[1, 2, 3], (n) => n + 1, [2, 3, 4]],
    [[1, 2, 3], (n, i) => n + i, [1, 3, 5]],
    [[10, 20, 30], () => 42, [42, 42, 42]],
  ])("array: %s,  function: %s, expected: %s", (arr, fn, expected) => {
    var actual = filter(arr, fn);
    expect(actual).toStrictEqual(expected);
  });
});
