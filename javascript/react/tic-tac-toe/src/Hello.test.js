import Hello from './Hello' 

test('1 + 1 should equals 2', () => {
    expect(new Hello().name).toBe('Hello');
});