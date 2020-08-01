USE BookShopAPI;

DECLARE @BookID integer = 18;

SELECT * FROM Book WHERE BookID=@BookID;

SELECT * FROM Author as au
LEFT JOIN BookAuthor as ba ON au.AuthorID=ba.AuthorID
WHERE ba.BookID = @BookID;

SELECT * FROM Genre as ge
LEFT JOIN BookGenre as bg ON ge.GenreID=bg.GenreID
WHERE bg.BookID = @BookID;