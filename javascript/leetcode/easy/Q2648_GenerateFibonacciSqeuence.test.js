var fibGenerator = function* () {
  yield 0;
  yield 1;
  let seq = [0, 1];
  while (true) {
    let sum = seq[0] + seq[1];
    seq.shift();
    seq.push(sum);
    yield sum;
  }
};

describe("Q2648 Generate Fibonacci Sequence", () => {
  test.each([
    [5, [0, 1, 1, 2, 3]],
    [0, []],
  ])("call count: %i, sequence: %s", (n, expected) => {
    const gen = fibGenerator();
    for (var i = 0; i < n; i++) {
      let val = gen.next().value;
      expect(val).toBe(expected[i]);
    }
  });
});
