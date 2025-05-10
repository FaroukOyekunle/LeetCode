/**
 * @param {Generator} generator
 * @return {[Function, Promise]}
 */
 
var cancellable = function(generator) {
    let cancelled = false;
    let cancel;   

    const promise = new Promise((resolve, reject) => {

        function step(method, arg) {
            let result;
            try {
                result = generator[method](arg);
            } catch (err) 
            {
                return reject(err);
            }
            const { value, done } = result;
            if(done) 
            {
                return resolve(value);
            }

            value.then(
                v => {
                    if(cancelled) 
                    {
                        step('throw', 'Cancelled');
                    } 
                    
                    else 
                    {
                        step('next', v);
                    }
                },
                err => 
                {
                    step('throw', err);
                }
            );
        }

        cancel = () =>
        {
            if(!cancelled) 
            {
                cancelled = true;
            }
        };

        step('next');
    });

    return [cancel, promise];
};

/**
 * function* tasks() {
 *   const val = yield new Promise(resolve => resolve(2 + 2));
 *   yield new Promise(resolve => setTimeout(resolve, 100));
 *   return val + 1;
 * }
 * const [cancel, promise] = cancellable(tasks());
 * setTimeout(cancel, 50);
 * promise.catch(console.log); // logs "Cancelled" at t=50ms
 */