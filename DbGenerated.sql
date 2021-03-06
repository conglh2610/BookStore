USE master

IF EXISTS(select * from sys.databases where name='BookStoreDB')
DROP DATABASE [BookStoreDB]

CREATE DATABASE [BookStoreDB]

USE [BookStoreDB]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 6/26/2017 1:41:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Author](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Title] [varchar](150) NOT NULL,
    [Cover] [varchar](250) NULL,
    [Description] [varchar](250) NULL,
    [CreateTime] [datetime] NOT NULL,
    [LastUpdateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Book]    Script Date: 6/26/2017 1:41:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Book](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Title] [varchar](150) NOT NULL,
    [AuthorId] [int] NULL,
    [CategoryId] [int] NULL,
    [Cover] [varchar](250) NULL,
    [Description] [varchar](250) NULL,
    [Publisher] [varchar](100) NOT NULL,
    [Year] [int] NOT NULL,
    [CreateTime] [datetime] NOT NULL,
    [LastUpdateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/26/2017 1:41:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Title] [varchar](150) NOT NULL,
    [Description] [varchar](250) NULL,
    [CreateTime] [datetime] NOT NULL,
    [LastUpdateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/26/2017 1:41:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [RoleType] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/26/2017 1:41:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Email] [varchar](150) NOT NULL,
    [Password] [varchar](100) NOT NULL,
    [FirstName] [varchar](20) NULL,
    [LastName] [varchar](20) NULL,
    [RoleId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

GO
INSERT [dbo].[Author] ([Id], [Title], [Cover], [Description], [CreateTime], [LastUpdateTime]) VALUES (15, N'J. K. Rowling', N'\0bba0dfc-b66a-4c04-8e47-6a9336cf1c6b.jpg', N'Joanne Rowling, CH, OBE, FRSL, pen names J. K. Rowling and Robert Galbraith, is a British novelist, film and television producer, screenwriter and philanthropist, best known as the author of the Harry Potter fantasy series.', CAST(N'2017-06-26 01:03:47.950' AS DateTime), NULL)
GO
INSERT [dbo].[Author] ([Id], [Title], [Cover], [Description], [CreateTime], [LastUpdateTime]) VALUES (16, N'Stephen King', N'\27db5a7c-953b-4b44-a4b6-12ee291ecc1f.jpg', N'Stephen Edwin King is an American author of horror, supernatural fiction, suspense, science fiction, and fantasy', CAST(N'2017-06-26 01:04:17.823' AS DateTime), NULL)
GO
INSERT [dbo].[Author] ([Id], [Title], [Cover], [Description], [CreateTime], [LastUpdateTime]) VALUES (17, N'Salman Rushdie', N'\b39ba8ba-c30c-4fa7-8ea3-e92e919878d3.jpg', N'Sir Ahmed Salman Rushdie, FRSL is a British Indian novelist and essayist. His second novel, Midnight''s Children, won the Booker Prize in 1981 and was deemed to be "the best novel of all winners" on two', CAST(N'2017-06-26 01:04:55.007' AS DateTime), CAST(N'2017-06-26 01:05:22.8018454' AS DateTime2))
GO
INSERT [dbo].[Author] ([Id], [Title], [Cover], [Description], [CreateTime], [LastUpdateTime]) VALUES (18, N'Dr. Seuss', N'\29dbb26e-69dc-438d-81c9-217b15a50998.jpg', N'Theodor Seuss Geisel was an American author, political cartoonist, poet, animator, book publisher, and artist, best known for authoring children''s books under the pen name Dr. Seuss.', CAST(N'2017-06-26 01:07:11.467' AS DateTime), NULL)
GO
INSERT [dbo].[Author] ([Id], [Title], [Cover], [Description], [CreateTime], [LastUpdateTime]) VALUES (19, N'Enid Blyton', N'\2e3f6395-d224-4e01-a7b4-330b80b69874.jpg', N'Enid Mary Blyton was an English children''s writer whose books have been among the world''s best-sellers since the 1930s, selling more than 600 million copies', CAST(N'2017-06-26 01:08:51.210' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [CategoryId], [Cover], [Description], [Publisher], [Year], [CreateTime], [LastUpdateTime]) VALUES (11, N'The Philosopher''s Stone (1997)', 15, 42, N'\c4fded8b-9094-4ca7-bca6-06f500e80213.jpg', N'Harry Potter is a series of fantasy novels written by British author J. K. Rowling. The novels chronicle the life of a young wizard, Harry Potter, and his friends Hermione Granger and Ron Weasley, all ...', N'Scholastic Corporation (US)', 1997, CAST(N'2017-06-26 01:10:51.190' AS DateTime), NULL)
GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [CategoryId], [Cover], [Description], [Publisher], [Year], [CreateTime], [LastUpdateTime]) VALUES (12, N'The Chamber of Secrets (1998)', 15, 42, N'\54f2b634-8e45-46e4-bbec-fed502e5b17b.jpg', N'Harry Potter is a series of fantasy novels written by British author J. K. Rowling. The novels chronicle the life of a young wizard, Harry Potter, and his friends Hermione Granger and Ron Weasley, all ', N'Scholastic Corporation (US)', 1998, CAST(N'2017-06-26 01:11:44.327' AS DateTime), NULL)
GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [CategoryId], [Cover], [Description], [Publisher], [Year], [CreateTime], [LastUpdateTime]) VALUES (13, N'The Prisoner of Azkaban (1999)', 15, 42, N'\ab2d282d-d5b6-4ca7-8581-2a2b80d173de.jpg', N'Harry Potter is a series of fantasy novels written by British author J. K. Rowling. The novels chronicle the life of a young wizard, Harry Potter, and his friends Hermione Granger and Ron Weasley, all ...', N'Scholastic Corporation (US)', 1999, CAST(N'2017-06-26 01:12:39.290' AS DateTime), NULL)
GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [CategoryId], [Cover], [Description], [Publisher], [Year], [CreateTime], [LastUpdateTime]) VALUES (14, N'The Goblet of Fire (2000)', 15, 49, N'\1b442c80-cfe1-4e29-be2b-b3a20be082aa.jpg', N'Harry Potter is a series of fantasy novels written by British author J. K. Rowling. The novels chronicle the life of a young wizard, Harry Potter, and his friends Hermione Granger and Ron Weasley, all ..', N'Scholastic Corporation (US)', 2000, CAST(N'2017-06-26 01:13:59.490' AS DateTime), NULL)
GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [CategoryId], [Cover], [Description], [Publisher], [Year], [CreateTime], [LastUpdateTime]) VALUES (15, N'The Order of the Phoenix (2003)', 15, 51, N'\bc43cc85-a728-4dc2-a606-5203e83ac6ae.jpg', N'Harry Potter is a series of fantasy novels written by British author J. K. Rowling. The novels chronicle the life of a young wizard, Harry Potter, and his friends Hermione Granger and Ron Weasley, all ... ', N'Bloomsbury Publishing (UK)', 2004, CAST(N'2017-06-26 01:15:22.667' AS DateTime), CAST(N'2017-06-26 01:15:39.4122149' AS DateTime2))
GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [CategoryId], [Cover], [Description], [Publisher], [Year], [CreateTime], [LastUpdateTime]) VALUES (16, N'The Half-Blood Prince (2005)', 15, 49, N'\0ccb1664-78b5-4766-8253-9c6b740231a0.jpg', N'Harry Potter is a series of fantasy novels written by British author J. K. Rowling. The novels chronicle the life of a young wizard, Harry Potter, and his friends Hermione Granger and Ron Weasley, all ... ', N'Bloomsbury Publishing (UK)', 2005, CAST(N'2017-06-26 01:17:03.210' AS DateTime), CAST(N'2017-06-26 01:17:19.4674127' AS DateTime2))
GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [CategoryId], [Cover], [Description], [Publisher], [Year], [CreateTime], [LastUpdateTime]) VALUES (17, N'The Shining', 16, 45, N'\e3f1672a-d42e-4b6c-b039-fb5331471bb0.jpg', N'The Shining is a horror novel by American author Stephen King. Published in 1977, it is King''s third published novel and first hardback bestseller: the success of the book firmly established King as a preeminent author in the horror genre.', N'unknown', 1977, CAST(N'2017-06-26 01:20:23.647' AS DateTime), NULL)
GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [CategoryId], [Cover], [Description], [Publisher], [Year], [CreateTime], [LastUpdateTime]) VALUES (18, N'Carrie (novel)', 16, 45, N'\21f623fb-f0f3-4513-a26e-5f36afd8a306.jpg', N'Carrie is a novel by American author Stephen King. It was his first published novel, released on April 5, 1974, with an approximate first print-run of 30,000 copies', N'1974', 1974, CAST(N'2017-06-26 01:21:58.870' AS DateTime), NULL)
GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [CategoryId], [Cover], [Description], [Publisher], [Year], [CreateTime], [LastUpdateTime]) VALUES (20, N'The Cat in the Hat', 18, 52, N'\e68028ca-25e4-4757-9526-ea213ae03eee.jpg', N'The Cat in the Hat is a children''s book written and illustrated by Theodor Geisel under the pen name Dr. Seuss and first published in 1957. ', N'Houghton Mifflin Harcourt', 1957, CAST(N'2017-06-26 01:26:56.743' AS DateTime), NULL)
GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [CategoryId], [Cover], [Description], [Publisher], [Year], [CreateTime], [LastUpdateTime]) VALUES (21, N'The Lorax', 18, 52, N'\b2025c37-d576-431f-8c67-585a07ed6307.jpg', N'The Lorax is a children''s book written by Dr. Seuss and first published in 1971. It chronicles the plight of the environment and the Lorax, who speaks for the trees against the Once-ler.', N'Random House', 1971, CAST(N'2017-06-26 01:28:01.537' AS DateTime), NULL)
GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [CategoryId], [Cover], [Description], [Publisher], [Year], [CreateTime], [LastUpdateTime]) VALUES (25, N'Midnight''s Children', 17, NULL, N'\5221bfd1-744a-4ca6-afa9-061caa4b2c6c.jpg', N'Midnight''s Children is a 1981 novel by Salman Rushdie that deals with India''s transition from British colonialism to independence and the partition of British India. ', N'Unknown', 1981, CAST(N'2017-06-26 01:40:39.477' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

GO
INSERT [dbo].[Category] ([Id], [Title], [Description], [CreateTime], [LastUpdateTime]) VALUES (42, N'Science fiction', N'Science fiction.', CAST(N'2017-06-26 00:58:50.943' AS DateTime), NULL)
GO
INSERT [dbo].[Category] ([Id], [Title], [Description], [CreateTime], [LastUpdateTime]) VALUES (43, N'Action and Adventure', N'Action and Adventure.', CAST(N'2017-06-26 00:59:05.357' AS DateTime), NULL)
GO
INSERT [dbo].[Category] ([Id], [Title], [Description], [CreateTime], [LastUpdateTime]) VALUES (44, N'Romance', N'Romance.', CAST(N'2017-06-26 00:59:17.113' AS DateTime), NULL)
GO
INSERT [dbo].[Category] ([Id], [Title], [Description], [CreateTime], [LastUpdateTime]) VALUES (45, N'Horror', N'Horror.', CAST(N'2017-06-26 00:59:33.847' AS DateTime), NULL)
GO
INSERT [dbo].[Category] ([Id], [Title], [Description], [CreateTime], [LastUpdateTime]) VALUES (46, N'History', N'History.', CAST(N'2017-06-26 00:59:49.183' AS DateTime), NULL)
GO
INSERT [dbo].[Category] ([Id], [Title], [Description], [CreateTime], [LastUpdateTime]) VALUES (47, N'Religion, Spirituality & New Age', N'Religion, Spirituality & New Age', CAST(N'2017-06-26 01:00:14.060' AS DateTime), NULL)
GO
INSERT [dbo].[Category] ([Id], [Title], [Description], [CreateTime], [LastUpdateTime]) VALUES (48, N'Anthology', N'Anthology', CAST(N'2017-06-26 01:00:37.127' AS DateTime), NULL)
GO
INSERT [dbo].[Category] ([Id], [Title], [Description], [CreateTime], [LastUpdateTime]) VALUES (49, N'Fantasy', N'Fantasy.', CAST(N'2017-06-26 01:01:10.153' AS DateTime), NULL)
GO
INSERT [dbo].[Category] ([Id], [Title], [Description], [CreateTime], [LastUpdateTime]) VALUES (50, N'Journals', N'Journals.', CAST(N'2017-06-26 01:01:31.220' AS DateTime), NULL)
GO
INSERT [dbo].[Category] ([Id], [Title], [Description], [CreateTime], [LastUpdateTime]) VALUES (51, N'Travel', N'Travel.', CAST(N'2017-06-26 01:01:41.247' AS DateTime), NULL)
GO
INSERT [dbo].[Category] ([Id], [Title], [Description], [CreateTime], [LastUpdateTime]) VALUES (52, N'Children''s literature', N'Children''s literature.', CAST(N'2017-06-26 01:26:06.430' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

GO
INSERT [dbo].[Role] ([Id], [RoleType]) VALUES (1, N'ADMIN')
GO
INSERT [dbo].[Role] ([Id], [RoleType]) VALUES (2, N'USER')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([Id], [Email], [Password], [FirstName], [LastName], [RoleId]) VALUES (5, N'lhcongtk32@gmail.com', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', N'Cong', N'Le', 2)
GO
INSERT [dbo].[User] ([Id], [Email], [Password], [FirstName], [LastName], [RoleId]) VALUES (6, N'admin@bookstore.com', N'40BD001563085FC35165329EA1FF5C5ECBDBBEEF', N'Administrator', N'', 1)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Author]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Category]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
