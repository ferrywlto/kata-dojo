var inorderTraversal = function* (arr) {
  // without flatten to a new array
  /*
  var inorderTraversal = function*(arr) {
      if (Array.isArray(arr)) {
          for (var thing of arr) {
              yield* inorderTraversal(thing);
          }
      } else {
          yield arr;
      }
  };
  */
    let val = arr.flat(Infinity);
    let idx = 0;
    while (idx < val.length) {
      yield val[idx++];
    }
};
describe("Q2649 Nested Array Generator", () => {
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
