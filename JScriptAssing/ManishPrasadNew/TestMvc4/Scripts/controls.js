(function () {
  "use strict;"

  //TopicsControl Class
  var TopicsControl = function (app) {
    this.app = app;
  };


  TopicsControl.prototype.loadAll = function () {
    var store = new Stores.TopicsStore();
    store.getAll(this.onTopicsLoad.bind(this));
    //createMethods
    var createform = new CreateTopicsControl();

    createform.onCreateTopicsLoad();



  };


  TopicsControl.prototype.onTopicsLoad = function (results) {
    var html = "<h3>Topics:</h3> <ol>";

    results.forEach(function (item) {
      html += "<li data-topic=\"" + item.TopicId + "\">" + item.TopicName + "</li>";
    });
    html += "</ol>";

    $("#left-sidebar").html(html);

    $("#left-sidebar ol li").click(this.onClick.bind(this));
  };


  TopicsControl.prototype.onClick = function (event) {
    var elem = $(event.target);
    var topic = elem.data("topic");
    this.app.subTopicsControl.loadSubTopics(topic);

  };

  //CreateTopicsControl Class
  var CreateTopicsControl = function (app) {
    this.app = app;
  };


  CreateTopicsControl.prototype.createTopics = function (data) {
    var store = new Stores.CreateTopicsStore();
    store.createNewTopics(data);

  };


  CreateTopicsControl.prototype.onCreateTopicsLoad = function () {


    $("#submitButton").click(this.onClick.bind(this));
  };

  CreateTopicsControl.prototype.onClick = function (event) {
    //var elem = $(event.target);
    //    var formid = elem.data("formid");

    var topicName = $('#TopicName').val();

    var duration = $('#Duration').val();

    var faculty = $('#Faculty').val()

    var data = { "topicName": topicName, "duration": duration, "faculty": faculty };

    this.createTopics(data);
    return false;

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
        html += "<li data-subtopic=\"" + item.TopicId + "\">" + "TopicName : " + item.TopicName + " , Duration : " + item.Duration + " , Faculty : " + item.faculty + "</li>";
      });
      html += "</ul>";

      $("#right-sidebar").html(html);

    });

  };






  window.Controls = {
    TopicsControl: TopicsControl,
    SubTopicsControl: SubTopicsControl,
    CreateTopicsControl: CreateTopicsControl

  };

})();
