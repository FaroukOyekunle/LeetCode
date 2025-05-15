/**
 * @param {Object} context
 * @param {Array} args
 * @return {null|boolean|number|string|Array|Object}
 */
Function.prototype.callPolyfill = function(context, ...args) {
    if(context === null || context === undefined) 
    {
        context = globalThis;
    }

    const tempKey = Symbol('fn');
    context[tempKey] = this;

    const result = context[tempKey](...args);

    delete context[tempKey];

    return result;
}

/**
 * function increment() { this.count++; return this.count; }
 * increment.callPolyfill({count: 1}); // 2
 */