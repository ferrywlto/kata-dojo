class Calculator {
  /**
   * @param {number} value
   */
  constructor(value) {}

  /**
   * @param {number} value
   * @return {Calculator}
   */
  add(value) {}

  /**
   * @param {number} value
   * @return {Calculator}
   */
  subtract(value) {}

  /**
   * @param {number} value
   * @return {Calculator}
   */
  multiply(value) {}

  /**
   * @param {number} value
   * @return {Calculator}
   */
  divide(value) {}

  /**
   * @param {number} value
   * @return {Calculator}
   */
  power(value) {}

  /**
   * @return {number}
   */
  getResult() {}
}

describe("Q2726 Calculator with Method Chaining", () => {
  test("Init with 10, Chain add 8 then substract 7 expect to be 8", () => {
    let calculator = new Calculator(10);
    let actual = calculator.add(5).subtract(7).getResult();
    expect(actual).toStrictEqual(8);
  });
  test("Init with 2, Chain multiply 5 then power 2 expect to be 100", () => {
    let calculator = new Calculator(2);
    let actual = calculator.multiply(5).power(2).getResult();
    expect(actual).toStrictEqual(100);
  });
  test("Init with 20, divide by zero should throw error", () => {
    let calculator = new Calculator(20);
    expect(() => {
      calculator.divide(0).getResult();
    }).toThrow("Division by zero is not allowed");
  });
});
