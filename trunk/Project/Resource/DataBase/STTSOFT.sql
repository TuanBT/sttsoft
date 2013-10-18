USE [STTSOFT]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 10/18/2013 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[AccLevel] [int] NOT NULL,
	[DisPercent] [int] NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[AccLevel] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Discount] ([AccLevel], [DisPercent]) VALUES (1, 10)
INSERT [dbo].[Discount] ([AccLevel], [DisPercent]) VALUES (2, 20)
/****** Object:  Table [dbo].[Category]    Script Date: 10/18/2013 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CatId] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CatId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([CatId], [CatName]) VALUES (1, N'Games')
INSERT [dbo].[Category] ([CatId], [CatName]) VALUES (2, N'Office')
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Table [dbo].[Product]    Script Date: 10/18/2013 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProId] [int] IDENTITY(1,1) NOT NULL,
	[ProName] [nvarchar](50) NULL,
	[ProDetail] [nvarchar](50) NULL,
	[ProImage] [nvarchar](50) NULL,
	[CatId] [int] NULL,
	[ProPrice] [float] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (1, N'STTSoft', N'Very good', NULL, 1, 10000000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (2, N'Call of duty', N'Good godd', NULL, 1, 1000000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (3, N'Battle Field', N'Normal', NULL, 1, 500000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (4, N'Word2013', N'Ok', NULL, 2, 100000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (5, N'PDF', N'OK', NULL, 2, 200000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (6, N'Foxit Reader', N'Normal', NULL, 2, 300000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (7, N'CS1.6', N'Free', NULL, 1, 0)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (8, N'Angry Bird', N'Normal', NULL, 1, 50000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (9, N'ExcelPro2015', N'Good', NULL, 2, 2000000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (10, N'NoteTextPro 2020', N'Good', NULL, 2, 10000)
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  Table [dbo].[Account]    Script Date: 10/18/2013 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccName] [nvarchar](50) NOT NULL,
	[AccRole] [nvarchar](50) NULL,
	[AccLevel] [int] NULL,
	[AccMail] [nvarchar](50) NULL,
	[AccPhone] [nvarchar](50) NULL,
	[AccPass] [nvarchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([AccName], [AccRole], [AccLevel], [AccMail], [AccPhone], [AccPass]) VALUES (N'ADMIN', N'A', NULL, NULL, NULL, N'1')
INSERT [dbo].[Account] ([AccName], [AccRole], [AccLevel], [AccMail], [AccPhone], [AccPass]) VALUES (N'TuanBT', N'D', 2, N'tuanbtse60824@fpt.edu.vn', N'0123456789', N'123')
INSERT [dbo].[Account] ([AccName], [AccRole], [AccLevel], [AccMail], [AccPhone], [AccPass]) VALUES (N'TuanNH', N'U', NULL, N'tuannhse60635@fpt.edu.vn', N'0999988880', N'12')
/****** Object:  Table [dbo].[Order]    Script Date: 10/18/2013 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrId] [int] IDENTITY(1,1) NOT NULL,
	[AccName] [nvarchar](50) NULL,
	[OrTotal] [money] NULL,
	[OrDate] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 10/18/2013 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[ComId] [int] IDENTITY(1,1) NOT NULL,
	[ProId] [int] NULL,
	[ComContent] [nvarchar](max) NULL,
	[AccName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ComId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 10/18/2013 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[AccName] [nvarchar](50) NOT NULL,
	[BanMoney] [float] NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[AccName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Bank] ([AccName], [BanMoney]) VALUES (N'TuanBT', 1000000000)
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 10/18/2013 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrdId] [int] IDENTITY(1,1) NOT NULL,
	[ProId] [int] NULL,
	[OrdQuantity] [int] NULL,
	[OrId] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrdId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Account_Discount]    Script Date: 10/18/2013 11:15:30 ******/
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Discount] FOREIGN KEY([AccLevel])
REFERENCES [dbo].[Discount] ([AccLevel])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Discount]
GO
/****** Object:  ForeignKey [FK_Bank_Account]    Script Date: 10/18/2013 11:15:30 ******/
ALTER TABLE [dbo].[Bank]  WITH CHECK ADD  CONSTRAINT [FK_Bank_Account] FOREIGN KEY([AccName])
REFERENCES [dbo].[Account] ([AccName])
GO
ALTER TABLE [dbo].[Bank] CHECK CONSTRAINT [FK_Bank_Account]
GO
/****** Object:  ForeignKey [FK_Comment_Product]    Script Date: 10/18/2013 11:15:30 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Product] FOREIGN KEY([ProId])
REFERENCES [dbo].[Product] ([ProId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Product]
GO
/****** Object:  ForeignKey [FK_Order_Account]    Script Date: 10/18/2013 11:15:30 ******/
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Account] FOREIGN KEY([AccName])
REFERENCES [dbo].[Account] ([AccName])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Account]
GO
/****** Object:  ForeignKey [FK_OrderDetail_Order]    Script Date: 10/18/2013 11:15:30 ******/
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrId])
REFERENCES [dbo].[Order] ([OrId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
/****** Object:  ForeignKey [FK_OrderDetail_Product]    Script Date: 10/18/2013 11:15:30 ******/
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProId])
REFERENCES [dbo].[Product] ([ProId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
/****** Object:  ForeignKey [FK_Product_Category]    Script Date: 10/18/2013 11:15:30 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CatId])
REFERENCES [dbo].[Category] ([CatId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
