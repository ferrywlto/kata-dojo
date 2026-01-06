var inorderTraversal = function* (arr) {
    let val = arr.flat(Infinity);
    let idx = 0;
    while (idx < val.length) {
      yield val[idx++];
    }
};
describe("Q2649 Is Object Empty", () => {
  test("case 1", () => {
    const expected = [6, 1, 3];
    const gen = inorderTraversal([[[6]], [1, 3], []]);
    const actual = [];
    actual.push(gen.next().value);
    actual.push(gen.next().value);
    actual.push(gen.next().value);
    expect(actual).toStrictEqual(expected);
  });
  test("case 2", () => {
    const expected = [];
    const gen = inorderTraversal([]);
    const actual = [];
    const result = gen.next();
    expect(result.done).toBe(true);
    expect(result.value).toBeUndefined();
    expect(actual).toStrictEqual(expected);
  });
});
