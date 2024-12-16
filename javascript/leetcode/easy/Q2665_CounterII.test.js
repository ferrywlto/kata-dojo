var createCounter = function(init) {
    
};

describe('Q2665 Counter II', () => {
    test.each([
        [5, ["increment", "reset", "decrement"], [6, 5, 4]],
        [0, ["increment", "increment", "decrement", "reset", "reset"], [1, 2, 1, 0, 0]],
    ])('init: %i, commands: %s, expected: %s', (init, commands, expected) => {
        var counter = createCounter(init);
        for (var i = 0; i < commands.length; i++)
        {
            var cmd = commands[i];
            switch (cmd) {
                case 'increment':
                    counter.increment();
                    break;
                case 'decrement':
                    counter.decrement();
                    break;
                case 'reset':
                    counter.reset();
                    break;
            }
            expect(counter.value).toBe(expected[i]);
        }
    });
});