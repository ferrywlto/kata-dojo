var reduce = function (nums, fn, init) {
  var result = init;
  for (var i = 0; i < nums.length; i++) {
    result = fn(result, nums[i]);
  }
  return result;
};

describe("Q2626 Array Reduce Transformation", () => {
  test.each([
    [[1, 2, 3, 4], (accum, curr) => accum + curr, 0, 10],
    [[1, 2, 3, 4], (accum, curr) => accum + curr * curr, 100, 130],
    [[], (accum, curr) => 0, 25, 25],
  ])("%s, %s, init: %i, expect: %i", (nums, fn, init, expected) => {
    var actual = reduce(nums, fn, init);

    expect(actual).toBe(expected);
  });
});
