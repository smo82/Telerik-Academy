USE [Supermarkets]
GO

/****** Object:  Table [dbo].[VendorSales]    Script Date: 7/23/2013 13:41:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VendorSales](
	[VendorSalesId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Expenses] [money] NOT NULL,
	[VendorId] [int] NOT NULL,
 CONSTRAINT [PK_VendorSales] PRIMARY KEY CLUSTERED 
(
	[VendorSalesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[VendorSales]  WITH CHECK ADD  CONSTRAINT [FK_VendorSales_Vendors] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendors] ([VendorId])
GO

ALTER TABLE [dbo].[VendorSales] CHECK CONSTRAINT [FK_VendorSales_Vendors]
GO

