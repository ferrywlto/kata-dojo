async function sleep(millis) {
    return new Promise((resolve, reject) => setTimeout(() => {resolve()}, millis));
}

describe('test sleep', () => {
    test.each(
        [
            [100],
            [200]
        ])('sleep function should delays %i milliseconds', async (millis) => {
        const start = Date.now();
        await sleep(millis);
        const end = Date.now();
        const elapsed = end - start;
        
        // Allow a small margin of error for the elapsed time
        expect(elapsed).toBeGreaterThanOrEqual(millis);
        expect(elapsed).toBeLessThan(millis + 100); // 100ms margin
    }
)
});