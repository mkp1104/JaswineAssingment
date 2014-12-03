(function () {
  "use strict;"

  //TopicsControl Class
  var TopicsControl = function (app) {
    this.app = app;
  };


  TopicsControl.prototype.loadAll = function () {
    var store = new Stores.TopicsStore();
    store.getAll(this.onTopicsLoad.bind(this));
  };


  TopicsControl.prototype.onTopicsLoad = function (results) {
    var html = "<h3>Topics:</h3> <ol>";

    results.forEach(function (item) {
      html += "<li data-topic=\"" + item.topicId + "\">" + item.topics + "</li>";
    });
    html += "</ol>";

    $("#left-sidebar").html(html);

    $("#left-sidebar ol li").click(this.onClick.bind(this));
  };


  TopicsControl.prototype.onClick = function (event) {
    var elem = $(event.target);
    var topic = elem.data("topic");
    this.app.subTopicsControl.loadSubTopics(topic);
    $("#content").html('');
  };


  //SubTopicsControl class
  var SubTopicsControl = function (app) {
    this.app = app;
  };


  SubTopicsControl.prototype.loadSubTopics = function (topic) {
    var store = new Stores.SubTopicsStore();
    var self = this;
    store.getSubTopics(topic, function (subTopics) {
      html = "<h3>Sub-Topics:</h3><ul>";

      subTopics.forEach(function (item) {
        html += "<li data-subtopic=\"" + item.subtopicId + "\">" + item.subtopics + "</li>";
      });
      html += "</ul>";

      $("#right-sidebar").html(html);
      $("#right-sidebar ul li").click(self.onClick.bind(self));
    });

  };


  SubTopicsControl.prototype.onClick = function (event) {
    var elem = $(event.target);
    var subtopic = elem.data("subtopic");
    this.app.SubTopicsDetailsControl.loadSubTopicsDetails(subtopic);

  };
  //SubTopicsDetailsControl class
  var SubTopicsDetailsControl = function (app) {
    this.app = app;
  };

  SubTopicsDetailsControl.prototype.loadSubTopicsDetails = function (subtopic) {
    var store = new Stores.SubTopicsStoreDetails();
    store.getSubTopicsDetails(subtopic, function (subTopics) {
      html = " <h3>Sub-Topics Contents:</h3><ul>";

      subTopics.forEach(function (item) {
      
         html += "<li data-subtopicContent=\"" + item.stdID + "\">" + "Description:"+item.Description + " </br> Faculty : " + item.FACULTY + " </br> Duration : " + item.DURATION + "</li>";
      
       });
      html += "</ul>";

      $("#content").html(html);
    });
  };



  window.Controls = {
    TopicsControl: TopicsControl,
    SubTopicsControl: SubTopicsControl,
    SubTopicsDetailsControl: SubTopicsDetailsControl
  };

})();
