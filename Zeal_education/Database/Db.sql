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
	`is_active` boolean DEFAULT true
);

CREATE TABLE `Course` (
  `Id` int Primary Key AUTO_INCREMENT,
  `courceName` varchar(50),
  `title` varchar(50),
  `fee` long,
  `CategoryId` int,
  `description` varchar(50),
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



