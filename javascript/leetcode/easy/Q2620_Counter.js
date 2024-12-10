var createCounter = function(n) {
    var x = n;
    return function() {
        var y = x;
        x = y + 1;
        return y;
    };
};