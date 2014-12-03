(function () {
  "use strict";

  var App = function () {
  }

  App.prototype.loadTopics = function () {
    this.topicsControl = new Controls.TopicsControl(this);
    this.subTopicsControl = new Controls.SubTopicsControl(this);
    this.createTopicsControl = new Controls.CreateTopicsControl(this);
    this.topicsControl.loadAll();
  }

  window.App = App;

})();
