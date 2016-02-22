drop schema if exists kompetansetorget;

create schema kompetansetorget;
use kompetansetorget;

create table Proficiency (
id INT NOT NULL AUTO_INCREMENT,
administasjon boolean default null,
datateknologi boolean default null,
helse boolean default null,
historie boolean default null,
Ingenior boolean default null,
Idrettsfag boolean default null,
Kunstfag boolean default null,
Lerer boolean default null,
Medie boolean default null,
Musikk boolean default null,
Realfag boolean default null,
Samfunnsfag boolean default null,
Sprak boolean default null,
Okonomi boolean default null,
Uspesifisert boolean default null,
PRIMARY KEY (id)
);

create table Student (
username VARCHAR(32) NOT NULL,
firstName VARCHAR(45) DEFAULT NULL,
lastName VARCHAR(45) DEFAULT NULL,
email VARCHAR(45) DEFAULT NULL,
idProficiency INT DEFAULT Null,
PRIMARY KEY (username),
CONSTRAINT `fk_Student_Proficiency`
 FOREIGN KEY (idProficiency)
 REFERENCES Proficiency(id)
);

CREATE TABLE Device (
deviceId VARCHAR(65) NOT NULL,
token VARCHAR(4096) NOT NULL,
deviceType VARCHAR(45) NOT NULL, 
username VARCHAR(32) NOT NULL,
PRIMARY KEY (deviceId),
CONTRAINT `fk_Device_Student`
 FOREIGN KEY (username)
 REFERENCES Student(username)
);


insert into Proficiency (datateknologi, Idrettsfag) values (true, true);
insert into Proficiency (datateknologi) values (null;

insert into Student (username, firstName, lastName, email, idProficiency) values ('viktos08', 'Viktor', 'Setervang', 'setervang@uia.no', 1);
insert into Student (username, firstName, idProficiency) values ('rolfs11', 'Rolf', 2);

// Ikke oppdatert siste insert
//insert into Device (username, deviceId) values('viktos08', 'cvi1LZzRdZ4:APA91bERsfF7kNNMmXV_4qhcwEg7_D5tQCIJhua-QbrGnyIBIsF0K7ovqVcZi9kWRRgheERodLCwbNDwXtNmZWXimZzDbwAPboR3CKcl4OkT6BeHMSSvnpgA9yvgknbqOhEFQjH4eO6Z'

use kompetansetorget;
select * from Student;