(function () {
  "use strict;"

  var getViaAjax = function (url, callback) {
    $.ajax({
      url: url,
      type: "get",
      success: function (data) {
        var res = data;
        // var json = $.parseJSON(data);
        //   callback(json);

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


  var SubTopicsStore = function () {
  };

  SubTopicsStore.prototype.getSubTopics = function (topic, callback) {
    


    getViaAjax("/Home/GetSubTopicDetails?topicid=" + topic, function (results) {
      callback(results);
    });
  };

  var SubTopicsStoreDetails = function () {
  };

  SubTopicsStoreDetails.prototype.getSubTopicsDetails = function (subtopic, callback) {
    getViaAjax("/Home/GetSubTopicContent?subtopicid=" + subtopic, function (results) {
      callback(results);
    });
  };
  // Gone everything above


  window.Stores = {
    TopicsStore: TopicsStore,
    SubTopicsStore: SubTopicsStore,
    SubTopicsStoreDetails: SubTopicsStoreDetails
  };

})();
