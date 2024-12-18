var createHelloWorld = function () {
  return function (...args) {
    return "Hello World";
  };
};

describe("Q2667 Create Hello World Function", () => {
  test.each([
    [[], "Hello World"],
    [[{}, null, 42], "Hello World"],
  ])("input: %s, expected: %s", (args, expected) => {
    let fn = createHelloWorld();
    expect(fn(...args)).toBe(expected);
  });
});
