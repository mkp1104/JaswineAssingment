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
  var PatientsStore = function () {
  };

  PatientsStore.prototype.getAll = function (callback) {
    getViaAjax("/Home/GetPatientDetails", function (results) {
      callback(results);
    });
  }

  var CreatePatientStore = function () {
  };

  CreatePatientStore.prototype.createNewPatients = function (formData) {
    $.ajax({
      url: "/PatientInformation/Create",
      type: "POST",
      data: formData,
      success: function (data) {
        callback(data);

      }
    });
  }

  var PatientInfoStore = function () {
  };

  PatientInfoStore.prototype.getPatientInfo = function (patientid, callback) {



    getViaAjax("/Home/GetSubPatientDetails?patientid=" + patientid, function (results) {
      callback(results);
    });
  };


  // Gone everything above


  window.Stores = {
    PatientsStore: PatientsStore,
    PatientInfoStore: PatientInfoStore,
    CreatePatientStore: CreatePatientStore

  };

})();
