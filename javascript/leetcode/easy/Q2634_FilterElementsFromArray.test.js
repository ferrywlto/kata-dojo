var filter = function (arr, fn) {
    var result = new Array();
    for (var i = 0; i < arr.length; i++)
    {
        var temp = fn(arr[i], i);
        if (temp) result.push(arr[i]);
    }
    return result;
};

describe("Q2634 Filter Elements from Array", () => {
  test.each([
    [[0, 10, 20, 30], (n) => n > 10, [20, 30]],
    [[1, 2, 3], (n, i) => i === 0, [1]],
    [[-2, -1, 0, 1, 2], (n) => n + 1, [-2, 0, 1, 2]],
  ])("array: %s,  function: %s, expected: %s", (arr, fn, expected) => {
    var actual = filter(arr, fn);
    expect(actual).toStrictEqual(expected);
  });
});
