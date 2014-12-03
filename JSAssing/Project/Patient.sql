
CREATE TABLE Patient(patientId INT IDENTITY(1,1) PRIMARY KEY,patientName VARCHAR(20),patientAge INT,note VARCHAR(20));

INSERT INTO Patient VALUES
('PRACHI',23,'OK'),
('Manish',23,'Allergy'),
('Sruti',23,'Not Ok')