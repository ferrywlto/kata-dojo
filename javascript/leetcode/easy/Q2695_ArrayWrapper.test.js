var ArrayWrapper = function(nums) {
    
};

ArrayWrapper.prototype.valueOf = function() {
    
}

ArrayWrapper.prototype.toString = function() {
    
}

describe('Q2695 Array Wrapper', () => {
    test.each([
        [[[1,2],[3,4]], "Add", 10],
        [[[23,98,42,70]], "String", "[23,98,42,70]"],
        [[[],[]], "Add", 0],
    ])('', (input, command, expected) => {
        
        if(command === "String") {
            const obj = new ArrayWrapper(input);
            expect(obj.toString()).toBe(expected);
        }
        else
        {
            let actual = 0;
            for (const item of input) {
                const obj = new ArrayWrapper(item);
                actual += obj;
            }
            expect(actual).toBe(expected);
        }
    });
});