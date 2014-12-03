(function() {
    "use strict";

    var App = function() {
    }

    App.prototype.loadTopics = function() {
        this.topicsControl = new Controls.TopicsControl(this);
        this.subTopicsControl = new Controls.SubTopicsControl(this);
        this.SubTopicsDetailsControl = new Controls.SubTopicsDetailsControl(this);
        this.topicsControl.loadAll();
    }

    window.App = App;

})();
