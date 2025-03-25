var debounce = function (fn, t) {
    let debounceTime = t;
    let cb;
  return function (...args) {
    if(cb) {
        clearTimeout(cb);
    }
    cb = setTimeout(() => fn(...args), debounceTime);
  };
};

describe("Q2627 Debounce", () => {
    let sum = 0;
    function log(...inputs) {
        let num = new Number(inputs); 
        sum += num;
    }
  test("The first call should cancelled", async () => {
        const dlog = debounce(log, 50);
        setTimeout(() => dlog(2), 50);
        setTimeout(() => dlog(3), 60);
        setTimeout(() => dlog(4), 120);
        
        await new Promise(r => setTimeout(r, 500));
        expect(sum).toStrictEqual(7);
    });
});
