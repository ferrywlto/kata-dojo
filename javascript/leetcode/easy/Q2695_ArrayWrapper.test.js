let ArrayWrapper = function (nums) {
  this.arr = nums;
};

ArrayWrapper.prototype.arr = [];

ArrayWrapper.prototype.valueOf = function () {
  if (this.arr.length === 0) return 0;
  return this.arr.reduce((prev, curr) => prev + curr);
};

ArrayWrapper.prototype.toString = function () {
  let str = "[";
  const len = this.arr.length;

  for (let i = 0; i < len; i++) {
    const item = this.arr[i];
    if (i != len - 1) {
      str += item + ",";
    } else {
      str += item;
    }
  }
  return str + "]";
};

describe("Q2695 Array Wrapper", () => {
  test.each([
    [
      [
        [1, 2],
        [3, 4],
      ],
      "Add",
      10,
    ],
    [[[23, 98, 42, 70]], "String", "[23,98,42,70]"],
    [[[], []], "Add", 0],
  ])("args: %s, cmd: %s, expected: %s", (input, command, expected) => {
    if (command === "String") {
      const obj = new ArrayWrapper(input);
      expect(obj.toString()).toBe(expected);
    } else {
      let actual = 0;
      for (const item of input) {
        const obj = new ArrayWrapper(item);
        actual += obj;
      }
      expect(actual).toBe(expected);
    }
  });
});
