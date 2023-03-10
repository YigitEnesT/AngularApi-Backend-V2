--USE [AngularAPI]
--GO
--CREATE DATABASE AngularApiDB
--GO
USE [AngularApiDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10.02.2023 15:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10.02.2023 15:02:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [bigint] NOT NULL,
	[Salary] [bigint] NOT NULL,
	[Department] [nvarchar](max) NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230131104220_FirstAdd', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230207140921_Order', N'7.0.2')
GO
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [Salary], [Department], [Order]) VALUES (N'b972af65-b2fb-43ab-ae5d-4d272643ebdf', N'Enes', N'enes@mail.com', 4545, 6500, N'SF', 1)
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [Salary], [Department], [Order]) VALUES (N'6dcd5c88-61d1-4ae4-88f9-578c1c7360a1', N'Enes', N'Enes@enes.com', 10000, 2500, N'SHF', 22)
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [Salary], [Department], [Order]) VALUES (N'15fddb8b-a1f8-49f1-a373-79a72a4da743', N'Ankara', N'ank@mail.com', 4545, 7500, N'IT', 7)
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [Salary], [Department], [Order]) VALUES (N'4803df2b-736d-45b5-9cbf-8bf69555441e', N'Cihan', N'c.a@ostim.com', 7845, 8400, N'MT', 2)
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [Salary], [Department], [Order]) VALUES (N'6c59d650-0e64-4be3-84ad-9022cac233b4', N'Eren', N'eposta@mail.com', 858000, 12000, N'SQL', 9)
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [Salary], [Department], [Order]) VALUES (N'e37a725e-6576-47c1-bada-92b5fb1e1f6e', N'First', N'second@mail.com', 7500, 7500, N'ST', 3)
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [Salary], [Department], [Order]) VALUES (N'66b804ee-15a6-44a1-85f3-bf5702778cb4', N'Mert', N'emp@mail.com', 9636, 9800, N'ST', 5)
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [Salary], [Department], [Order]) VALUES (N'f018b690-8b26-40bc-8da5-c4e6b0250602', N'Yigit', N'tuncay@mail.com', 545310, 6500, N'IT', 4)
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [Salary], [Department], [Order]) VALUES (N'38dcec8a-3cf5-4fa1-9959-e53e7e946074', N'Görkem', N'gm.c@mail.com', 3125060, 4500, N'FN', 8)
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [Salary], [Department], [Order]) VALUES (N'767454c6-750b-4c7e-8221-e95810f06301', N'Fatih', N'f.k@.com', 90363, 7450, N'S', 6)
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [Salary], [Department], [Order]) VALUES (N'18428484-ccd4-4280-b233-ef5032a1c7f4', N'Umit', N'eren@mail.com', 81160, 8110, N'SQL', 10)
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT ((0)) FOR [Order]
GO
