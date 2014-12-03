(function () {
  "use strict;"

  var getViaAjax = function (url, callback) {
    $.ajax({
      url: url,
      type: "get",
      success: function (data) {
        var res = data;
        callback(res);
      }
    });

  };
  var TopicsStore = function () {
  };

  TopicsStore.prototype.getAll = function (callback) {
    getViaAjax("/Home/GetTopicDetails", function (results) {
      callback(results);
    });
  }

  var CreateTopicsStore = function () {
  };

  CreateTopicsStore.prototype.createNewTopics = function (formData) {
    $.ajax({
      url: "/Topic/Create",
      type: "POST",
      data: formData,
      success: function (data) {
//        var store = new Stores.TopicsStore();
//        store.getAll(Controls.TopicsControl.loadAll());

       
      }
    });
  }

  var SubTopicsStore = function () {
  };

  SubTopicsStore.prototype.getSubTopics = function (topic, callback) {



    getViaAjax("/Home/GetSubTopicDetails?topicid=" + topic, function (results) {
      callback(results);
    });
  };


  // Gone everything above


  window.Stores = {
    TopicsStore: TopicsStore,
    SubTopicsStore: SubTopicsStore,
    CreateTopicsStore: CreateTopicsStore

  };

})();
