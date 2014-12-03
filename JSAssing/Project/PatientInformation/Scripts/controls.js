(function () {
  "use strict;"

  //PatientsControl Class
  var PatientsControl = function (app) {
    this.app = app;
  };


  PatientsControl.prototype.loadAll = function () {
    var store = new Stores.PatientsStore();
    store.getAll(this.onPatientsLoad.bind(this));
    //createMethods
    var createform = new CreatePatientControl();

    createform.onCreatePatientsLoad();

  };


  PatientsControl.prototype.onPatientsLoad = function (results) {
    var html = "<h3>Patients:</h3><ol>";

    results.forEach(function (item) {
      html += "<li data-patientid=\"" + item.patientId + "\">" + item.patientName + "</li>";
    });
    html += "</ol>";

    $("#left-sidebar").html(html);

    $("#left-sidebar ol li").click(this.onClick.bind(this));
  };

  PatientsControl.prototype.onClick = function (event) {
    var elem = $(event.target);
    var patientid = elem.data("patientid");
    this.app.patientInfoControl.loadPatientInfo(patientid);

  };

  //CreatePatientControl Class
  var CreatePatientControl = function (app) {
    this.app = app;
  };


  CreatePatientControl.prototype.createPatients = function (data) {
    var store = new Stores.CreatePatientStore();
    var self = this;
    store.createNewPatients(data, function () {
      store.getAll(self.onPatientsLoad.bind(self));
    });

  };


  CreatePatientControl.prototype.onCreatePatientsLoad = function () {






    $("#submitButton").click(this.onClick.bind(this));
  };

  CreatePatientControl.prototype.onClick = function (event) {

    var patientName = $('#PatientName').val();

    var patientAge = $('#PatientAge').val();

    var note = $('#Description').val()

    var data = { "PatientName": patientName, "PatientAge": patientAge, "note": note };

    this.createPatients(data);
    return false;

  };
  //PatientInfoControl class
  var PatientInfoControl = function (app) {
    this.app = app;
  };


  PatientInfoControl.prototype.loadPatientInfo = function (patientid) {
    var store = new Stores.PatientInfoStore();
    var self = this;
    store.getPatientInfo(patientid, function (patientInfo) {
      html = "<h3>Patient Information:</h3><ul>";

      patientInfo.forEach(function (item) {
        html += "<li data-patientId=\"" + item.patientId + "\">" + "PatientName : " + item.patientName + " , PatientAge : " + item.patientAge + " , Description : " + item.note + "</li>";
      });
      html += "</ul>";

      $("#right-sidebar").html(html);

    });

  };






  window.Controls = {
    PatientsControl: PatientsControl,
    PatientInfoControl: PatientInfoControl,
    CreatePatientControl: CreatePatientControl

  };

})();
