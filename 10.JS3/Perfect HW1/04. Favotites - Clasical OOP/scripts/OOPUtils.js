(function () {
    if (!Object.create) {
        Object.create = function (obj) {
            function f() { };
            f.prototype = obj;
            return new f();
        }
    }

    if (!Object.prototype.extend) {
        Object.prototype.extend = function (properties) {
            function f() { };
            f.prototype = Object.create(this);
            for (var prop in properties) {
                f.prototype[prop] = properties[prop];
            }
            f.prototype._super = this;
            return new f();
        }
    }

    Class = (function () {
        function createClass(properties) {
            var f = function () {
                this.init.apply(this, arguments);
            }
            for (var prop in properties) {
                f.prototype[prop] = properties[prop];
            }
            if (!f.prototype.init) {
                f.prototype.init = function () { }
            }
            return f;
        }

        return {
            create: createClass,
        }
    })();

    Function.prototype.inherit = function (parent) {
        var oldPrototype = this.prototype;
        this.prototype = new parent();
        this.prototype._super = parent.prototype;
        for (var prop in oldPrototype) {
            this.prototype[prop] = oldPrototype[prop];
        }
    }
})()