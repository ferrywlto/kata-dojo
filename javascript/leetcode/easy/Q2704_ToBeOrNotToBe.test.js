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
  test("expect 5 tobe(5) is true", () => {
    const x = new expectfn(5);
    expect(x.toBe(5)).toBe(true);
  });
  test("expect 5 tobe(null) throws not equal", () => {
    const x = new expectfn(5);
    expect(() => {
      x.toBe(null);
    }).toThrow("Not Equal");
  });
  test("expect 5 notToBe(5) throws not equal", () => {
    const x = new expectfn(5);
    expect(() => {
      x.notToBe(5);
    }).toThrow("Equal");
  });
});
