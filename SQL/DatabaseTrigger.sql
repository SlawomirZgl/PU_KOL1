CREATE TRIGGER deleteStudentHistory
ON dbo.Students
AFTER DELETE
AS
BEGIN
    INSERT INTO dbo.History (FirstName, LastName, GroupID, ActionType, Date)
    SELECT
        d.FirstName,
        d.LastName,
        d.GroupID,
        0 AS ActionType,
        GETDATE() AS Date
    FROM deleted d;
END