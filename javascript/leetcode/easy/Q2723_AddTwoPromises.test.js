var addTwoPromises = async function (promise1, promise2) {
  return Promise.all([promise1, promise2]).then(([p1, p2]) => p1 + p2);
};

describe("Q2723 Add Two Promises", () => {
  test("Test case 1", async () => {
    let p1 = new Promise((resolve) => setTimeout(() => resolve(2), 20));
    let p2 = new Promise((resolve) => setTimeout(() => resolve(5), 60));
    let result = addTwoPromises(p1, p2);

    await result.then((value) => {
      expect(value).toBe(7);
    });
  });
  test("Test case 2", async () => {
    let p1 = new Promise((resolve) => setTimeout(() => resolve(10), 50));
    let p2 = new Promise((resolve) => setTimeout(() => resolve(-12), 30));
    let result = addTwoPromises(p1, p2);

    await result.then((value) => {
      expect(value).toBe(-2);
    });
  });
});
