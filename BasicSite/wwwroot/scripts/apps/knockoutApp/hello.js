"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ko = require("knockout");
var HelloViewModel = (function () {
    function HelloViewModel(language, framework) {
        this.language = ko.observable(language);
        this.framework = ko.observable(framework);
    }
    return HelloViewModel;
}());
ko.applyBindings(new HelloViewModel("TypeScript", "Knockout"));
//# sourceMappingURL=hello.js.map