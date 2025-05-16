class EventEmitter {
    constructor() {
        this.events = new Map();
        this.subscriptions = [];
    }

    /**
     * @param {string} eventName
     * @param {Function} callback
     * @return {Object}
     */
    
    subscribe(eventName, callback) 
    {
        if (!this.events.has(eventName)) 
        {
            this.events.set(eventName, []);
        }

        const subscription = { eventName, callback };
        this.events.get(eventName).push(subscription);
        this.subscriptions.push(subscription);

        const unsubscribe = () => 
        {
            const subs = this.events.get(eventName);
            if(subs) 
            {
                const index = subs.indexOf(subscription);
                if (index !== -1) {
                    subs.splice(index, 1);
                }
            }
        };

        return { unsubscribe };
    }

    /**
     * @param {string} eventName
     * @param {Array} args
     * @return {Array}
     */

    emit(eventName, args = []) {
        const callbacks = this.events.get(eventName) || [];
        return callbacks.map(sub => sub.callback(...args));
    }
}
