CREATE DATABASE TodoListDB;

USE TodoListDB;

CREATE TABLE Todos (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(100) NOT NULL,
	IsDone BIT NOT NULL /* BIT : C#에서 bool 형과 1:1 매핑, 참/거짓 표현 데이터형 */
)
;

SELECT 
  * FROM Todos
;

INSERT INTO Todos (Title, IsDone) VALUES ('test2', 0);

