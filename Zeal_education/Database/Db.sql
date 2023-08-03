CREATE DATABASE zeal_education;

USE zeal_education;

CREATE TABLE `User` (
  `Id` int Primary Key AUTO_INCREMENT,
  `email` varchar(50),
  `password` varchar(50),
  `RoleId` int DEFAULT 2,
  `fullName` varchar(50),
  `dob` timestamp,
  `create_at` timestamp DEFAULT CURRENT_TIMESTAMP(),
  `is_active` boolean DEFAULT true
);

CREATE TABLE `Role` (
  `Id` int Primary Key AUTO_INCREMENT,
  `roleName` varchar(50),
  `is_active` boolean DEFAULT true
);

CREATE TABLE `Category` (
  `id` int Primary Key AUTO_INCREMENT,
  `name` varchar(50),
  `description` varchar(50),
  `create_at` timestamp DEFAULT CURRENT_TIMESTAMP(),
  `create_by` varchar(50),
  `modify_at` timestamp,
  `modify_by` varchar(50),
  `is_active` boolean DEFAULT true
);

CREATE TABLE `Teacher` (
  `Id` int Primary Key AUTO_INCREMENT,
  `fullName` varchar(50),
  `dob` timestamp,
  `description` varchar(50),
    `create_at` timestamp DEFAULT CURRENT_TIMESTAMP(),
    `create_by` varchar(50),
    `modify_at` timestamp,
  `modify_by` varchar(50),
	`is_active` boolean DEFAULT true
);

CREATE TABLE `Course` (
  `Id` int Primary Key AUTO_INCREMENT,
  `courseName` varchar(50),
  `title` varchar(50),
  `fee` long,
  `CategoryId` int,
  `description` varchar(1000),
  `teacherId` int,
  `create_at` timestamp DEFAULT CURRENT_TIMESTAMP(),
  `create_by` varchar(50),
  `modify_at` timestamp,
  `modify_by` varchar(50),
  `is_active` boolean DEFAULT true
);

CREATE TABLE `Cart` (
  `Id` int Primary Key AUTO_INCREMENT,
  `UserId` int,
  `is_active` boolean DEFAULT true
);

CREATE TABLE `CartItem` (
  `Id` int Primary Key AUTO_INCREMENT,
  `CourseId` int,
  `CartId` int,
  `is_active` boolean DEFAULT true
);

CREATE TABLE `Order` (
  `Id` int Primary Key AUTO_INCREMENT,
  `UserId` int,
  `note` varchar(50),
  `orderDate` timestamp DEFAULT CURRENT_TIMESTAMP(),
  `Status` boolean,
  `is_active` boolean DEFAULT true
);

CREATE TABLE `OrderDetail` (
  `Id` int Primary Key AUTO_INCREMENT,
  `CourseId` int,
  `OrderId` int,
  `is_active` boolean DEFAULT true
);

CREATE TABLE `Exam` (
  `Id` int Primary Key AUTO_INCREMENT,
  `CourseId` int,
  `UserId` int,
  `Score` int,
  `testDate` timestamp,
  `is_active` boolean DEFAULT true
);

ALTER TABLE `User` ADD FOREIGN KEY (`RoleId`) REFERENCES `Role` (`Id`);

ALTER TABLE `Course` ADD FOREIGN KEY (`CategoryId`) REFERENCES `Category` (`id`);

ALTER TABLE `Course` ADD FOREIGN KEY (`teacherId`) REFERENCES `Teacher` (`Id`);

ALTER TABLE `OrderDetail` ADD FOREIGN KEY (`CourseId`) REFERENCES `Course` (`Id`);

ALTER TABLE `OrderDetail` ADD FOREIGN KEY (`OrderId`) REFERENCES `Order` (`Id`);

ALTER TABLE `CartItem` ADD FOREIGN KEY (`CourseId`) REFERENCES `Course` (`Id`);

ALTER TABLE `CartItem` ADD FOREIGN KEY (`CartId`) REFERENCES `Cart` (`Id`);

ALTER TABLE `Exam` ADD FOREIGN KEY (`CourseId`) REFERENCES `Course` (`Id`);

ALTER TABLE `Exam` ADD FOREIGN KEY (`UserId`) REFERENCES `User` (`Id`);

INSERT INTO `Role`(`roleName`) Value ('Admin');
INSERT INTO `Role`(`roleName`) VALUE ('User');

INSERT INTO `user`(`email`,`password`,`RoleId`,`fullName`,`dob`) VALUE ('zealeducationa@gmail.com',SHA1('123456'),1,'admin',current_timestamp());

INSERT INTO `Teacher`(`fullName`, `dob`,`create_by`) VALUE ('Do Duy Quang', "2003-08-03",'zealeducationa@gmail.com');
INSERT INTO `Teacher`(`fullName`, `dob`,`create_by`) VALUE ('Nguyen Minh Hieu', "2003-08-03",'zealeducationa@gmail.com');
INSERT INTO `Teacher`(`fullName`, `dob`,`create_by`) VALUE ('Dao Quoc Truong', "2003-08-03",'zealeducationa@gmail.com');

INSERT INTO `Category`(`name`, `description`,`create_by`) VALUE ('Basic', 'For Beginner','zealeducationa@gmail.com');
INSERT INTO `Category`(`name`, `description`,`create_by`) VALUE ('Front-End', 'Build UI','zealeducationa@gmail.com');
INSERT INTO `Category`(`name`, `description`,`create_by`) VALUE ('Back-End', 'Learn API','zealeducationa@gmail.com');


INSERT INTO `Course`(`courseName`, `title`,`fee`,`CategoryId`,`description`,`teacherId`,`create_by`) VALUE ('C++', 'Getting started with C++',200,1,'C++ is an object-oriented programming language which gives a clear structure to programs and allows code to be reused, lowering development costs',1,'zealeducationa@gmail.com');
INSERT INTO `Course`(`courseName`, `title`,`fee`,`CategoryId`,`description`,`teacherId`,`create_by`) VALUE ('Python', 'Programming with Python',200,1,'Python is a computer programming language often used to build websites and software, automate tasks, and conduct data analysis',1,'zealeducationa@gmail.com');
INSERT INTO `Course`(`courseName`, `title`,`fee`,`CategoryId`,`description`,`teacherId`,`create_by`) VALUE ('SQL Sever', 'Working with Database by Microsoft SQL Sever',200,1,'Microsoft SQL Server is a relational database management system. As a database server that stores and retrieves data as requested by other software applications on the same computer or a remote computer using the client-server model.',1,'zealeducationa@gmail.com');
INSERT INTO `Course`(`courseName`, `title`,`fee`,`CategoryId`,`description`,`teacherId`,`create_by`) VALUE ('HTML/CSS/Javascript', 'Bulding simple website',200,1,'HTML stands for Hyper Text Markup Language. HTML is the standard markup language for creating Web pages. HTML describes the structure of a Web page. HTML consists of a series of elements. HTML elements tell the browser how to display the content.',2,'zealeducationa@gmail.com');
INSERT INTO `Course`(`courseName`, `title`,`fee`,`CategoryId`,`description`,`teacherId`,`create_by`) VALUE ('Reactjs', 'Bulding website/Call API with Reactjs',200,2,'The React.js framework is an open-source JavaScript framework and library developed by Facebook. It is used for building interactive user interfaces and web applications quickly and efficiently with significantly less code than you would with vanilla JavaScript.',2,'zealeducationa@gmail.com');
INSERT INTO `Course`(`courseName`, `title`,`fee`,`CategoryId`,`description`,`teacherId`,`create_by`) VALUE ('Vuejs', 'Bulding website/Call API with Vuejs',200,2,'Vue. js is a library for building interactive web interfaces. The goal of Vue. js is to provide the benefits of reactive data binding and composable view components with an API that is as simple as possible.',2,'zealeducationa@gmail.com');
INSERT INTO `Course`(`courseName`, `title`,`fee`,`CategoryId`,`description`,`teacherId`,`create_by`) VALUE ('Angularjs', 'Bulding website/Call API with Angularjs',200,2,'AngularJS is a structural framework for dynamic web apps. It lets you use HTML as your template language and lets you extend HTML''s syntax to express your application''s components clearly and succinctly. AngularJS is data binding and dependency injection eliminate much of the code you would otherwise have to write.',2,'zealeducationa@gmail.com');
INSERT INTO `Course`(`courseName`, `title`,`fee`,`CategoryId`,`description`,`teacherId`,`create_by`) VALUE ('Bootstrap', 'Bulding website with Bootstrap',200,2,'Bootstrap is a free, open source front-end development framework for the creation of websites and web apps. Designed to enable responsive development of mobile-first websites, Bootstrap provides a collection of syntax for template designs.',2,'zealeducationa@gmail.com');
INSERT INTO `Course`(`courseName`, `title`,`fee`,`CategoryId`,`description`,`teacherId`,`create_by`) VALUE ('Java', 'Programming with Java',200,3,'Java is a widely-used programming language for coding web applications. It has been a popular choice among developers for over two decades, with millions of Java applications in use today. Java is a multi-platform, object-oriented, and network-centric language that can be used as a platform in itself.',3,'zealeducationa@gmail.com');
INSERT INTO `Course`(`courseName`, `title`,`fee`,`CategoryId`,`description`,`teacherId`,`create_by`) VALUE ('Java Spring Boot', 'Working with API and Spring Boot',200,3,'Spring Boot is an open-source, microservice-based Java web framework offered by Spring, particularly useful for software engineers developing web apps and microservices.',3,'zealeducationa@gmail.com');
INSERT INTO `Course`(`courseName`, `title`,`fee`,`CategoryId`,`description`,`teacherId`,`create_by`) VALUE ('C#', 'Programming with C#',200,3,'C# (pronounced "See Sharp") is a modern, object-oriented, and type-safe programming language. C# enables developers to build many types of secure and robust applications that run in .NET.',3,'zealeducationa@gmail.com');
INSERT INTO `Course`(`courseName`, `title`,`fee`,`CategoryId`,`description`,`teacherId`,`create_by`) VALUE ('ASP.NET CORE', 'Working with API and .NET CORE 6',200,3,'NET 6 is the fastest full stack web framework, which lowers compute costs if you are running in the cloud. Ultimate productivity: . NET 6 and Visual Studio 2022 provide hot reload, new git tooling, intelligent code editing, robust diagnostics and testing tools, and better team collaboration.',3,'zealeducationa@gmail.com');
INSERT INTO `Course`(`courseName`, `title`,`fee`,`CategoryId`,`description`,`teacherId`,`create_by`) VALUE ('Nodejs', 'Working with API and Nodejs',200,3,'js (Node) is an open source, cross-platform runtime environment for executing JavaScript code. Node is used extensively for server-side programming, making it possible for developers to use JavaScript for client-side and server-side code without needing to learn an additional language.',3,'zealeducationa@gmail.com');



