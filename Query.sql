CREATE DATABASE TodoListDB;

USE TodoListDB;

CREATE TABLE Todos (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(100) NOT NULL,
	IsDone BIT NOT NULL /* BIT : C#���� bool ���� 1:1 ����, ��/���� ǥ�� �������� */
)
;

SELECT 
  * FROM Todos
;

INSERT INTO Todos (Title, IsDone) VALUES ('test2', 0);

