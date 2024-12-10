Array.prototype.last = function () {
  if (this.length === 0) return -1;
  return this[this.length - 1];
};

describe("Q2619 Array Prototype Last", () => {
  test.each([
    [[null, {}, 3], 3],
    [[], -1],
  ])("Array.last() when input is %s should return %s", (arr, expected) => {
    expect(arr.last()).toBe(expected);
  });
});
