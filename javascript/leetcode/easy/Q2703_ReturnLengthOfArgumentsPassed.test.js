var argumentsLength = function (...args) {
  return args.length;
};

describe("Q2703 Return Length of Arguments Passed", () => {
  test.each([
    [[5], 1],
    [[{}, null, "3"], 3],
  ])("input: %s, expected: %i", (input, expected) => {
    expect(argumentsLength(...input)).toBe(expected);
  });
});
