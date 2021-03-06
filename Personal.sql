USE [Personal]
GO
/****** Object:  Table [dbo].[tblPersonal]    Script Date: 16/10/17 07:48:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPersonal](
	[Personal_Id] [uniqueidentifier] NOT NULL,
	[Personal_Identification] [varchar](15) NOT NULL,
	[Personal_FirstName] [varchar](50) NOT NULL,
	[Personal_LastName] [varchar](50) NOT NULL,
	[Personal_Phone] [varchar](15) NOT NULL,
 CONSTRAINT [PK_tblPersonal] PRIMARY KEY CLUSTERED 
(
	[Personal_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblPersonal] ([Personal_Id], [Personal_Identification], [Personal_FirstName], [Personal_LastName], [Personal_Phone]) VALUES (N'e2e03f38-5591-4dfb-b656-8c25e4caba60', N'16274371', N'Lusmery', N'Aguilera', N'0212-6835640')
INSERT [dbo].[tblPersonal] ([Personal_Id], [Personal_Identification], [Personal_FirstName], [Personal_LastName], [Personal_Phone]) VALUES (N'70b338d7-8bba-4f21-bf51-c2b8fd415818', N'17756783', N'Luis', N'Ramirez', N'0212 6835640')
