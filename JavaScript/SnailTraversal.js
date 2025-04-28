/**
 * @param {number} rowsCount
 * @param {number} colsCount
 * @return {Array<Array<number>>}
 */
Array.prototype.snail = function(rowsCount, colsCount) {
    const nums = this;
    if(rowsCount * colsCount !== nums.length) 
    {
        return [];
    }

    const res = new Array(rowsCount).fill(0).map(() => new Array(colsCount));
    let idx = 0;

    for(let col = 0; col < colsCount; col++) 
    {
        if(col % 2 === 0) 
        { 
            for(let row = 0; row < rowsCount; row++) 
            {
                res[row][col] = nums[idx++];
            }
        } 
        
        else 
        { 
            for(let row = rowsCount - 1; row >= 0; row--) 
            {
                res[row][col] = nums[idx++];
            }
        }
    }

    return res;
}

/**
 * const arr = [1,2,3,4];
 * arr.snail(1,4); // [[1,2,3,4]]
 */