--creating database
create database PMSystem

--Schema Design
Create Table Project (
    Project_id int PRIMARY KEY identity(1,1),
    Project_name varchar(60),
    Description varchar(100),
    Start_Date date,
    Status varchar(20)
)

Create Table Employee (
    Employee_id int primary key identity(1,1),
    Name varchar(100),
    Designation varchar(100),
    Gender char(1),
    Salary Decimal,
    Project_id int,
    foreign key (Project_id) references Project(Project_id)
)

Create Table Task (
    Task_id int Primary Key,
    Task_name varchar(100),
    Project_id int,
    Employee_id int,
    Status varchar(20),
    foreign key (Project_id) references Project(Project_id),
    foreign key (Employee_id) references Employee(Employee_id)
)

--inserting values
insert into Project(Project_name,Description,Start_Date,Status) values
('Project Alpha', 'Development of the Alpha platform', '2024-01-01', 'started'),
('Digital India', 'Nationwide digital infrastructure setup', '2024-02-15', 'dev'),
('Smart City Solutions', 'IoT-based city management', '2023-03-05', 'build'),
('E-commerce Revamp', 'Redesign of e-commerce platform', '2024-08-12', 'test'),
('Banking App', 'Mobile banking solution', '2024-05-20', 'deployed')

insert into Employee(Name,Designation,Gender,Salary,Project_id)values
('Fiza Saleem', 'Senior Developer', 'F', 95000, 1),
('Rahul Ganesh', 'Project Manager', 'M', 120000, 2),
('Riya Kumar', 'Business Analyst', 'F', 85000, 2),
('Jashwant Rao', 'UI/UX Designer', 'M', 70000, 3),

insert into Task values
(1001, 'Design Module', 1, 1, 'assigned'),
(1002, 'Testing Module', 1, 2, 'started'),
(1003, 'Project Planning', 2, 3, 'completed')

select * from Project
select * from Employee
select * from Task


