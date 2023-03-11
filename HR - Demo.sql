CREATE DATABASE employee
 
 CREATE TABLE [dbo].[employee] (
    [empid]    INT           IDENTITY (1, 1) NOT NULL,
    [empName]  VARCHAR (100) NULL,
    [empEmail] VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([empid] ASC)
);
 
 INSERT Into employee (empName, empEmail) VALUES
('Johan Fernando', 'johanfernando@gmail.com'),
('Jason Henderson', 'hernderson123@gmail.com'),
('Rebecca Hendrix', 'rebecca2202@outlook.com')

Select * from employee
