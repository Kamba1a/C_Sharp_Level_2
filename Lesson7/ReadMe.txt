1. ������� �� � ������ Lesson7

2. ������� ������� Departments

CREATE TABLE [dbo].[Departments]
(
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
	[Name] NVARCHAR(100) NULL
)


3. ������� ������� Employees

CREATE TABLE [dbo].[Employees] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (50)  NOT NULL,
    [SecondName] NVARCHAR (50)  NOT NULL,
    [Position]   NVARCHAR (100) NOT NULL,
    [Salary]     INT            NOT NULL,
    [Department] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    FOREIGN KEY ([Department]) REFERENCES [Departments]([Id])
);

4. ��� ���������� ���������� ������� ���������:

SET IDENTITY_INSERT [dbo].[Departments] ON
INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (1, N'�������������')
INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (2, N'�����������')
INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (3, N'����������� �����')
SET IDENTITY_INSERT [dbo].[Departments] OFF

SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [SecondName], [Position], [Salary], [Department]) VALUES (1, N'����������', N'������', N'��������', 100000, 1)
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [SecondName], [Position], [Salary], [Department]) VALUES (2, N'������', N'�������', N'���������', 35000, 1)
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [SecondName], [Position], [Salary], [Department]) VALUES (3, N'����', N'��������', N'������� ���������', 75000, 2)
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [SecondName], [Position], [Salary], [Department]) VALUES (4, N'�������', N'�������', N'���������', 50000, 2)
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [SecondName], [Position], [Salary], [Department]) VALUES (5, N'�����', N'������', N'������������� ����', 75000, 3)
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [SecondName], [Position], [Salary], [Department]) VALUES (6, N'�������', N'������', N'������', 50000, 3)
SET IDENTITY_INSERT [dbo].[Employees] OFF
