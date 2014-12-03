(function () {
  "use strict";

  var App = function () {
  }

  App.prototype.loadPatients = function () {
      this.patientsControl = new Controls.PatientsControl(this);
      this.patientInfoControl = new Controls.PatientInfoControl(this);
      this.createPatientControl = new Controls.CreatePatientControl(this);
    this.patientsControl.loadAll();
  }

  window.App = App;

})();
