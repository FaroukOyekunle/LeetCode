/**
 * @param {Function} fn
 * @return {Function}
 */
function memoize(fn) {
    
    const cache = new Map();
    return function(...args) {

        let current = cache;
        for(let i = 0; i < args.length; i++) 
        {
            if(!current.has(args[i])) 
            {
                current.set(args[i], new Map());
            }

            current = current.get(args[i]);
        }

        if(!current.has('__result__')) 
        {
            current.set('__result__', fn(...args));
        }

        return current.get('__result__');
    }
}


/** 
 * let callCount = 0;
 * const memoizedFn = memoize(function (a, b) {
 *	 callCount += 1;
 *   return a + b;
 * })
 * memoizedFn(2, 3) // 5
 * memoizedFn(2, 3) // 5
 * console.log(callCount) // 1 
 */