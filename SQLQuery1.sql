create database management_system

CREATE TABLE Donors (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    BloodGroup NVARCHAR(5),
    City NVARCHAR(50)
);

CREATE TABLE Staff (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Role NVARCHAR(50),
    Phone NVARCHAR(20)
);

CREATE TABLE Donations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DonorId INT NOT NULL,
    DonationDate DATE NOT NULL,
    VolumeML INT,
    StaffId INT,
    Remarks NVARCHAR(255),
    CONSTRAINT FK_Donations_Donors FOREIGN KEY (DonorId) REFERENCES Donors(Id),
    CONSTRAINT FK_Donations_Staff FOREIGN KEY (StaffId) REFERENCES Staff(Id)
);

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(100) UNIQUE NOT NULL
);

ALTER TABLE Donations
ADD CONSTRAINT FK_Donations_Donors
FOREIGN KEY (DonorId) REFERENCES Donors(Id)
ON DELETE SET NULL;

-- Drop the existing foreign key constraint on DonorId
ALTER TABLE Donations
DROP CONSTRAINT FK_Donations_Donors;

-- Make DonorId nullable
ALTER TABLE Donations
ALTER COLUMN DonorId INT NULL;

-- Re-add the FK with ON DELETE SET NULL
ALTER TABLE Donations
ADD CONSTRAINT FK_Donations_Donors
FOREIGN KEY (DonorId) REFERENCES Donors(Id)
ON DELETE SET NULL;


SELECT * FROM Staff;



INSERT INTO Donors (Name, Email, Phone, BloodGroup, City)
VALUES 
('Ali Khan', 'ali.khan@gmail.com', '03001234567', 'A+', 'Lahore'),

('Sara Ahmed', 'sara.ahmed@gmail.com', '03009876543', 'B-', 'Karachi'),

('Umar Siddiqui', 'umar.sid@gmail.com', '03123456789', 'O+', 'Islamabad'),

('Mehwish Raza', 'mehwish.raza@gmail.com', '03211223344', 'AB+', 'Faisalabad'),

('Bilal Shaikh', 'bilal.shaikh@gmail.com', '03334445566', 'A-', 'Rawalpindi');

INSERT INTO Staff (Name, Role, Phone)
VALUES
('Dr. Asim Qureshi', 'Doctor', '03005556677'),
('Nida Hassan', 'Nurse', '03119998877'),
('Waqas Javed', 'Lab Technician', '03224445566'),
('Hina Yousaf', 'Receptionist', '03337778899');

INSERT INTO Donations (DonorId, DonationDate, VolumeML, StaffId, Remarks)
VALUES
(2, '2025-06-01', 500, 1, 'Routine donation'),
(3, '2025-06-05', 450, 2, 'First-time donor'),
(4, '2025-06-10', 500, 3, 'Repeat donor'),
(2008, '2025-06-12', 480, 4, 'Walk-in donation');


SELECT * FROM Donors;
Select * from Users;
