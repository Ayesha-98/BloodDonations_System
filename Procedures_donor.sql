CREATE PROCEDURE SP_SaveDonor
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(20),
    @BloodGroup NVARCHAR(5),
    @City NVARCHAR(50)
AS
BEGIN
    INSERT INTO Donors (Name, Email, Phone, BloodGroup, City)
    VALUES (@Name, @Email, @Phone, @BloodGroup, @City)
END

CREATE PROCEDURE SP_GetDonors
AS
BEGIN
    SELECT * FROM Donors
END

CREATE PROCEDURE SP_DeleteDonor
    @Id INT
AS
BEGIN
    DELETE FROM Donors WHERE Id = @Id
END

CREATE PROCEDURE SP_UpdateDonor
    @Id INT,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(20),
    @BloodGroup NVARCHAR(5),
    @City NVARCHAR(50)
AS
BEGIN
    UPDATE Donors
    SET Name = @Name,
        Email = @Email,
        Phone = @Phone,
        BloodGroup = @BloodGroup,
        City = @City
    WHERE Id = @Id
END
