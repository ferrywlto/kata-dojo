let isEmpty = function (obj) {};

describe("Q2727 Is Object Empty", () => {
  test.each([
    [{ x: 5, y: 42 }, false],
    [{}, true],
    [[null, false, 0], false],
  ])("", (obj, expected) => {
    let actual = isEmpty(obj);
    expect(actual).toStrictEqual(expected);
  });
});
