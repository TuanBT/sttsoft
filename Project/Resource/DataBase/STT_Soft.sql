USE [STTSOFT]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 10/23/2013 22:05:16 ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 10/23/2013 22:05:16 ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 10/23/2013 22:05:16 ******/
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
	[ProPrice] [float] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (1, N'STTSoft', N'Very good', N'../../Content/img/productImage/CallOfDuty.jpg', 1, 10000000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (2, N'Call of duty', N'Good godd', N'../../Content/img/productImage/CallOfDuty.jpg', 1, 1000000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (3, N'Battle Field', N'Normal', N'../../Content/img/productImage/CallOfDuty.jpg', 1, 500000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (4, N'Word2013', N'Ok', N'../../Content/img/productImage/CallOfDuty.jpg', 2, 100000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (5, N'PDF', N'OK', N'../../Content/img/productImage/CallOfDuty.jpg', 2, 200000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (6, N'Foxit Reader', N'Normal', N'../../Content/img/productImage/CallOfDuty.jpg', 2, 300000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (7, N'CS1.6', N'Free', N'../../Content/img/productImage/CallOfDuty.jpg', 1, 0)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (8, N'Angry Bird', N'Normal', N'../../Content/img/productImage/CallOfDuty.jpg', 1, 50000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (9, N'ExcelPro2015', N'Good', N'../../Content/img/productImage/CallOfDuty.jpg', 2, 2000000)
INSERT [dbo].[Product] ([ProId], [ProName], [ProDetail], [ProImage], [CatId], [ProPrice]) VALUES (10, N'NoteTextPro 2020', N'Good', N'~/Content/img/productImage/CallOfDuty.jpg', 2, 10000)
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  Table [dbo].[Account]    Script Date: 10/23/2013 22:05:16 ******/
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
INSERT [dbo].[Account] ([AccName], [AccRole], [AccLevel], [AccMail], [AccPhone], [AccPass]) VALUES (N'ADMIN', N'A', 1, N'a', N'a', N'1')
INSERT [dbo].[Account] ([AccName], [AccRole], [AccLevel], [AccMail], [AccPhone], [AccPass]) VALUES (N'Sinhcv', N'D', 2, N'abc@gmail.com', NULL, N'1234')
INSERT [dbo].[Account] ([AccName], [AccRole], [AccLevel], [AccMail], [AccPhone], [AccPass]) VALUES (N'TuanBT', N'D', 2, N'tuanbtse60824@fpt.edu.vn', N'0123456789', N'123')
INSERT [dbo].[Account] ([AccName], [AccRole], [AccLevel], [AccMail], [AccPhone], [AccPass]) VALUES (N'TuanNH', N'U', NULL, N'tuannhse60635@fpt.edu.vn', N'0999988880', N'12')
/****** Object:  Table [dbo].[Order]    Script Date: 10/23/2013 22:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrId] [int] IDENTITY(1,1) NOT NULL,
	[AccName] [nvarchar](50) NULL,
	[OrDate] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Order] ON
INSERT [dbo].[Order] ([OrId], [AccName], [OrDate]) VALUES (46, N'tuannh', CAST(0x0000A260016A9B0D AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
/****** Object:  Table [dbo].[Comment]    Script Date: 10/23/2013 22:05:16 ******/
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
SET IDENTITY_INSERT [dbo].[Comment] ON
INSERT [dbo].[Comment] ([ComId], [ProId], [ComContent], [AccName]) VALUES (3, 1, N'a', NULL)
INSERT [dbo].[Comment] ([ComId], [ProId], [ComContent], [AccName]) VALUES (4, 1, N'a', NULL)
INSERT [dbo].[Comment] ([ComId], [ProId], [ComContent], [AccName]) VALUES (5, 1, N'abcd', NULL)
INSERT [dbo].[Comment] ([ComId], [ProId], [ComContent], [AccName]) VALUES (6, 1, N'k', NULL)
INSERT [dbo].[Comment] ([ComId], [ProId], [ComContent], [AccName]) VALUES (7, 1, N'ke', NULL)
INSERT [dbo].[Comment] ([ComId], [ProId], [ComContent], [AccName]) VALUES (8, 1, N'thang co` ho'' tuan^''', NULL)
INSERT [dbo].[Comment] ([ComId], [ProId], [ComContent], [AccName]) VALUES (9, 1, N'haiz', NULL)
INSERT [dbo].[Comment] ([ComId], [ProId], [ComContent], [AccName]) VALUES (10, 1, N'a', NULL)
INSERT [dbo].[Comment] ([ComId], [ProId], [ComContent], [AccName]) VALUES (11, 2, N'ngon', NULL)
INSERT [dbo].[Comment] ([ComId], [ProId], [ComContent], [AccName]) VALUES (12, 2, N'1', NULL)
SET IDENTITY_INSERT [dbo].[Comment] OFF
/****** Object:  Table [dbo].[Bank]    Script Date: 10/23/2013 22:05:16 ******/
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
INSERT [dbo].[Bank] ([AccName], [BanMoney]) VALUES (N'Sinhcv', 69500000)
INSERT [dbo].[Bank] ([AccName], [BanMoney]) VALUES (N'TuanBT', 93200000)
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 10/23/2013 22:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrdId] [int] IDENTITY(1,1) NOT NULL,
	[ProId] [int] NULL,
	[OrdQuantity] [int] NULL,
	[OrId] [int] NULL,
	[OrdSaler] [nvarchar](50) NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrdId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON
INSERT [dbo].[OrderDetail] ([OrdId], [ProId], [OrdQuantity], [OrId], [OrdSaler]) VALUES (48, 1, 1, 46, N'TuanBT')
INSERT [dbo].[OrderDetail] ([OrdId], [ProId], [OrdQuantity], [OrId], [OrdSaler]) VALUES (49, 2, 1, 46, N'TuanBT')
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
/****** Object:  ForeignKey [FK_Account_Discount]    Script Date: 10/23/2013 22:05:16 ******/
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Discount] FOREIGN KEY([AccLevel])
REFERENCES [dbo].[Discount] ([AccLevel])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Discount]
GO
/****** Object:  ForeignKey [FK_Bank_Account]    Script Date: 10/23/2013 22:05:16 ******/
ALTER TABLE [dbo].[Bank]  WITH CHECK ADD  CONSTRAINT [FK_Bank_Account] FOREIGN KEY([AccName])
REFERENCES [dbo].[Account] ([AccName])
GO
ALTER TABLE [dbo].[Bank] CHECK CONSTRAINT [FK_Bank_Account]
GO
/****** Object:  ForeignKey [FK_Comment_Product]    Script Date: 10/23/2013 22:05:16 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Product] FOREIGN KEY([ProId])
REFERENCES [dbo].[Product] ([ProId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Product]
GO
/****** Object:  ForeignKey [FK_Order_Account]    Script Date: 10/23/2013 22:05:16 ******/
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Account] FOREIGN KEY([AccName])
REFERENCES [dbo].[Account] ([AccName])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Account]
GO
/****** Object:  ForeignKey [FK_OrderDetail_Order]    Script Date: 10/23/2013 22:05:16 ******/
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrId])
REFERENCES [dbo].[Order] ([OrId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
/****** Object:  ForeignKey [FK_OrderDetail_Product]    Script Date: 10/23/2013 22:05:16 ******/
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProId])
REFERENCES [dbo].[Product] ([ProId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
/****** Object:  ForeignKey [FK_Product_Category]    Script Date: 10/23/2013 22:05:16 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CatId])
REFERENCES [dbo].[Category] ([CatId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
