let expectfn = function (val) {
  let tmp = val;
  return {
    toBe: function (input) {
      if (tmp === input) {
        return true;
      } else {
        throw new Error("Not Equal");
      }
    },
    notToBe: function (input) {
      if (tmp !== input) {
        return true;
      } else {
        throw new Error("Equal");
      }
    },
  };
};

describe("Q2704 To be or not to be", () => {
  test("", () => {
    const x = new expectfn(5);
    expect(x.toBe(5)).toBe(true);

    expect(() => {
      x.toBe(null);
    }).toThrow("Not Equal");

    expect(() => {
      x.notToBe(5);
    }).toThrow("Equal");
  });
});
