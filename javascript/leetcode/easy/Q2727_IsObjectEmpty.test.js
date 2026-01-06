let isEmpty = function (obj) {
  if (obj instanceof Object) {
    return Object.keys(obj).length === 0;
  } else if (obj instanceof Array) {
    return obj.length === 0;
  }
  return false;
};

describe("Q2727 Is Object Empty", () => {
  test.each([
    [{ x: 5, y: 42 }, false],
    [{}, true],
    [[null, false, 0], false],
  ])("%# input: %p, expected: %s", (obj, expected) => {
    let actual = isEmpty(obj);
    expect(actual).toStrictEqual(expected);
  });
});
