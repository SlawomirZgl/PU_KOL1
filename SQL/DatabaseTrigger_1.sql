CREATE TRIGGER updateStudentHistory
ON dbo.Students
AFTER UPDATE
AS
BEGIN
    INSERT INTO dbo.History (FirstName, LastName, GroupID, ActionType, Date)
    SELECT
        d.FirstName,
        d.LastName,
        d.GroupID,
        1 AS ActionType,
        GETDATE() AS Date
    FROM deleted d;
END