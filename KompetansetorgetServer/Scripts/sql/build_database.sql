drop schema if exists kompetansetorget;

create schema kompetansetorget;
use kompetansetorget;

create table Student (
id INT NOT NULL AUTO_INCREMENT,
username VARCHAR(20) DEFAULT NULL,
firstName VARCHAR(45) DEFAULT NULL,
lastName VARCHAR(45) DEFAULT NULL,
email VARCHAR(45) DEFAULT NULL,
PRIMARY KEY (id)
);

insert into Student (username, firstName, lastName, email) values ('viktos08', 'Viktor', 'Setervang', 'setervang@uia.no');
insert into Student (username, firstName) values ('rolfs11', 'Rolf');

use kompetansetorget;
select * from Student;