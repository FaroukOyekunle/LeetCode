/**
 * @param {*} obj
 * @param {*} classFunction
 * @return {boolean}
 */

var checkIfInstanceOf = function(obj, classFunction) 
{
    if(obj === null || obj === undefined || typeof classFunction !== 'function') 
    {
        return false;
    }

    if(typeof obj !== 'object' && typeof obj !== 'function') 
    {
        obj = Object(obj);
    }

    let prototype = classFunction.prototype;
    let currentProto = Object.getPrototypeOf(obj);

    while(currentProto !== null) 
    {
        if(currentProto === prototype)
        {
            return true;
        } 
        currentProto = Object.getPrototypeOf(currentProto);
    }

    return false;
};

/**
 * checkIfInstanceOf(new Date(), Date); // true
 */