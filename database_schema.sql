-- SQL script generated based on current models

CREATE TABLE Program (
    Prog_ID INT PRIMARY KEY IDENTITY(1,1),
    Prog_Name NVARCHAR(100),
    Prog_Year INT
);

CREATE TABLE Admin (
    Admin_ID INT PRIMARY KEY IDENTITY(1,1),
    Admin_Name NVARCHAR(100),
    Admin_DOB DATE,
    Admin_Address NVARCHAR(255),
    Admin_Contact NVARCHAR(20),
    Admin_Email NVARCHAR(100),
    Admin_Pass NVARCHAR(100)
);

CREATE TABLE Student (
    Stud_ID INT PRIMARY KEY IDENTITY(1,1),
    Stud_FName NVARCHAR(100),
    Stud_LName NVARCHAR(100),
    Stud_MName NVARCHAR(100),
    Stud_DOB DATE,
    Stud_Home_Address NVARCHAR(255),
    Stud_Conn_Dstrict NVARCHAR(100),
    Stud_City_Address NVARCHAR(100),
    Stud_Contact NVARCHAR(20),
    Stud_Email NVARCHAR(100),
    Stud_Is_First_Gen BIT,
    Stud_Yr_Lvl INT,
    Stud_Status NVARCHAR(50),
    Stud_JrSg NVARCHAR(50),
    Stud_Pass NVARCHAR(100),
    Prog_ID INT FOREIGN KEY REFERENCES Program(Prog_ID),
    Admin_ID INT FOREIGN KEY REFERENCES Admin(Admin_ID)
);

CREATE TABLE Student_History (
    Stud_ID INT,
    StudHist_Entry NVARCHAR(255),
    PRIMARY KEY (Stud_ID, StudHist_Entry),
    FOREIGN KEY (Stud_ID) REFERENCES Student(Stud_ID)
);

CREATE TABLE Admin_History (
    Admin_ID INT,
    AdHist_Entry NVARCHAR(255),
    PRIMARY KEY (Admin_ID, AdHist_Entry),
    FOREIGN KEY (Admin_ID) REFERENCES Admin(Admin_ID)
);

CREATE TABLE Instructor (
    Instr_ID INT PRIMARY KEY IDENTITY(1,1),
    Instr_Name NVARCHAR(100)
);

CREATE TABLE Room (
    Room_ID INT PRIMARY KEY IDENTITY(1,1),
    Room_Hours NVARCHAR(50),
    Room_Days NVARCHAR(50)
);

CREATE TABLE Semester_Year (
    Sem_Code INT PRIMARY KEY IDENTITY(1,1),
    Sem_Num INT,
    Sem_Year INT,
    Sem_TotUnits INT,
    Prog_ID INT FOREIGN KEY REFERENCES Program(Prog_ID)
);

CREATE TABLE Course (
    Course_Code INT PRIMARY KEY IDENTITY(1,1),
    Course_Name NVARCHAR(100),
    Course_Units INT,
    Course_Lec_Hours INT,
    Course_Lab_Hours INT,
    Course_Tot_Hours INT,
    Sem_Code INT FOREIGN KEY REFERENCES Semester_Year(Sem_Code)
);

CREATE TABLE Teach_Assignment (
    Mis_Code INT PRIMARY KEY IDENTITY(1,1),
    Instr_ID INT FOREIGN KEY REFERENCES Instructor(Instr_ID),
    Course_Code INT FOREIGN KEY REFERENCES Course(Course_Code),
    Room_ID INT FOREIGN KEY REFERENCES Room(Room_ID),
    TA_Room_Hours NVARCHAR(50),
    TA_Room_Day NVARCHAR(50)
);

CREATE TABLE Enrollment (
    Enroll_ID INT PRIMARY KEY IDENTITY(1,1),
    Enroll_Sem NVARCHAR(20),
    Enroll_Yr_Lvl INT,
    Enroll_Curr_SY NVARCHAR(20),
    Enroll_Status NVARCHAR(50),
    Enroll_Time TIME,
    Enroll_Day NVARCHAR(20),
    Stud_ID INT FOREIGN KEY REFERENCES Student(Stud_ID)
);

CREATE TABLE Schedule (
    Sched_ID INT PRIMARY KEY IDENTITY(1,1),
    Enroll_ID INT FOREIGN KEY REFERENCES Enrollment(Enroll_ID),
    Mis_Code INT FOREIGN KEY REFERENCES Teach_Assignment(Mis_Code)
);

-- Additional tables or columns can be added as needed
