CREATE PROCEDURE GetPagedHistory
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize
    DECLARE @Next INT = @PageNumber * @PageSize

    SELECT *
    FROM (
        SELECT *,
               ROW_NUMBER() OVER (ORDER BY Date DESC) AS RowNum
        FROM History
    ) AS HistoryWithRowNum
    WHERE RowNum > @Offset AND RowNum <= @Next
    ORDER BY RowNum;
END
