var timeLimit = function (fn, t) {
  return async function (...args) {
    return new Promise((resolve, reject) => {
      const timer = setTimeout(() => reject('Time Limit Exceeded'), t);
      Promise.resolve(fn(...args))
        .then((val) => {
          clearTimeout(timer);
          resolve(val);
        })
        .catch((err) => {
          clearTimeout(timer);
          reject(err);
        })
    })
  }
};

describe("Q2637 Promise Time Limit", () => {
  test("case 1", async () => {

    const limited = timeLimit(async (n) => {
      await new Promise(res => setTimeout(res, 100));
      return n * n;
    }, 50);

    const start = performance.now()
    let result;
    try {
      const res = await limited()
      result = { "resolved": res, "time": 100 };
    } catch (err) {
      result = { "rejected": err, "time": 50 };
    }
    expect(result).toStrictEqual({ "rejected": "Time Limit Exceeded", time: 50 });
  });

  test("case 2", async () => {
    const expected = { "resolved": 25, "time": 100 };
    const limited = timeLimit(async (n) => {
      await new Promise(res => setTimeout(res, 100));
      return n * n;
    }, 150);

    let result = undefined;
    const start = performance.now()
    try {
      const res = await limited(5)
      result = { "resolved": res, "time": 100 };
    } catch (err) {
      result = { "rejected": err, "time": 150 };
    }
    expect(result).toStrictEqual(expected);
  });

  test("case 3", async () => {
    const expected = { "resolved": 15, "time": 120 };
    const limited = timeLimit(async (a, b) => {
      await new Promise(res => setTimeout(res, 120));
      return a + b;
    }, 150);

    let result = undefined;
    const start = performance.now()
    try {
      const res = await limited(5, 10)
      result = { "resolved": res, "time": 120 };
    } catch (err) {
      result = { "rejected": err, "time": 120 };
    }
    expect(result).toStrictEqual(expected);
  });

  test("case 4", async () => {
    const limited = timeLimit(async () => {
      throw "Error"
    }, 1000);

    const start = performance.now();
    let expected = { "rejected": "Error", "time": 0 };
    let result = undefined;
    try {
      const res = await limited();
      result = { "resolved": res, "time": 1000 }
    }
    catch {
      result = { "rejected": "Error", "time": 0 };
    }
    expect(result).toStrictEqual(expected);
  });
});
