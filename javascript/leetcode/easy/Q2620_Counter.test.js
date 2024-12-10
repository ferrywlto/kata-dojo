var createCounter = function (n) {
  var x = n;
  return function () {
    var y = x;
    x = y + 1;
    return y;
  };
};

describe("Q2620 counter", () => {
  test.each([
    [10, [10, 11, 12]],
    [-2, [-2, -1, 0, 1, 2]],
  ])(
    "Counter should start at %s and produce %s each time counter() is called",
    (n, expected) => {
      const counter = createCounter(n);
      for (var i = 0; i < expected.length; i++) {
        expect(expected[i]).toBe(counter());
      }
    }
  );
});
