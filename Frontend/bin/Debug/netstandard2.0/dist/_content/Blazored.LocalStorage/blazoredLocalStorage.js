var blazored = {
    localStorage: {
        setItem: function (key, data) {
            window.localStorage.setItem(key, data);
        },
        getItem: function (key) {
            return window.localStorage.getItem(key);
        },
        removeItem: function (key) {
            window.localStorage.removeItem(key);
        },
        clear: function () {
            window.localStorage.clear();
        },
        length: function () {
            return window.localStorage.length;
        },
        key: function (index) {
            return window.localStorage.key(index);
        }
    }
};
window['blazored'] = blazored;
//# sourceMappingURL=blazoredLocalStorage.js.map