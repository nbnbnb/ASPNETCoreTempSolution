"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const ko = require("knockout");
class HelloViewModel {
    constructor(language, framework) {
        this.language = ko.observable(language);
        this.framework = ko.observable(framework);
    }
}
ko.applyBindings(new HelloViewModel("TypeScript", "Knockout"));
//# sourceMappingURL=hello.js.map