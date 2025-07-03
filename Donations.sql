CREATE PROCEDURE SP_SaveDonation
    @DonorId INT,
    @DonationDate DATE,
    @VolumeML INT,
    @StaffId INT,
    @Remarks NVARCHAR(255)
AS
BEGIN
    INSERT INTO Donations (DonorId, DonationDate, VolumeML, StaffId, Remarks)
    VALUES (@DonorId, @DonationDate, @VolumeML, @StaffId, @Remarks)
END

CREATE PROCEDURE SP_GetDonations
AS
BEGIN
    SELECT D.Id, D.DonationDate, D.VolumeML, D.Remarks,
           Don.Name AS DonorName,
           S.Name AS StaffName
    FROM Donations D
    JOIN Donors Don ON D.DonorId = Don.Id
    LEFT JOIN Staff S ON D.StaffId = S.Id
END

CREATE PROCEDURE SP_DeleteDonation
    @Id INT
AS
BEGIN
    DELETE FROM Donations WHERE Id = @Id
END

CREATE PROCEDURE SP_UpdateDonation
    @Id INT,
    @DonorId INT,
    @DonationDate DATE,
    @VolumeML INT,
    @StaffId INT,
    @Remarks NVARCHAR(255)
AS
BEGIN
    UPDATE Donations
    SET DonorId = @DonorId,
        DonationDate = @DonationDate,
        VolumeML = @VolumeML,
        StaffId = @StaffId,
        Remarks = @Remarks
    WHERE Id = @Id
END

ALTER PROCEDURE SP_GetDonations
AS
BEGIN
    SELECT
        D.Id,
        D.DonorId,          --  ← now present
        D.DonationDate,
        D.VolumeML,
        D.StaffId,          --  ← now present
        D.Remarks,
        Don.Name  AS DonorName,
        S.Name    AS StaffName
    FROM Donations D
    JOIN Donors Don ON D.DonorId = Don.Id
    LEFT JOIN Staff S ON D.StaffId = S.Id;
END
