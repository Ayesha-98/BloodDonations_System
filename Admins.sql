CREATE PROCEDURE SP_SaveStaff
    @Name NVARCHAR(100),
    @Role NVARCHAR(50),
    @Phone NVARCHAR(20)
AS
BEGIN
    INSERT INTO Staff (Name, Role, Phone)
    VALUES (@Name, @Role, @Phone)
END

CREATE PROCEDURE SP_GetStaff
AS
BEGIN
    SELECT * FROM Staff
END

CREATE PROCEDURE SP_DeleteStaff
    @Id INT
AS
BEGIN
    DELETE FROM Staff WHERE Id = @Id
END

CREATE PROCEDURE SP_UpdateStaff
    @Id INT,
    @Name NVARCHAR(100),
    @Role NVARCHAR(50),
    @Phone NVARCHAR(20)
AS
BEGIN
    UPDATE Staff
    SET Name = @Name,
        Role = @Role,
        Phone = @Phone
    WHERE Id = @Id
END

SELECT * FROM Staff;

