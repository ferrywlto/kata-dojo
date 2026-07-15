describe("Q2721. Execute Asynchronous Functions in Parallel", () => {
  const promiseAll = function(functions) {
    return new Promise((resolve, reject) => {
      const results = new Array(functions.length);

      let completed = 0;
      for(let i=0; i<functions.length; i++)
      {
        functions[i]().then(result => {
          results[i] = result;
          completed++;
          if(completed === functions.length) {
            resolve(results);
          }
        }).catch(reject);
      }
    })
  };

  test("case 1", async () => {
    promiseAll([
      () => new Promise(res => res(42))
    ])
    .then(result => expect(result).toStrictEqual([42]))
  });

  test("case 2", async () => {
    promiseAll([
      () => new Promise(resolve => setTimeout(() => resolve(5), 200))
    ])
    .then(result => expect(result).toStrictEqual([5]))
  });

  test("case 3", async () => {
    promiseAll([
      () => new Promise(resolve => setTimeout(() => resolve(1), 200)),
      () => new Promise((resolve, reject) => setTimeout(() => reject("Error"), 100))
    ])
    .catch(error => expect(error).toStrictEqual('Error'))
  });

  test("case 4", async () => {
    promiseAll([
      () => new Promise(resolve => setTimeout(() => resolve(4), 50)),
      () => new Promise(resolve => setTimeout(() => resolve(10), 150)),
      () => new Promise(resolve => setTimeout(() => resolve(16), 100))
    ])
    .then(result => expect(result).toStrictEqual([4,10,16]))
  });
});
