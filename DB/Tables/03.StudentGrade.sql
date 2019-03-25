USE [KestraStudent]
GO

/****** Object:  Table [dbo].[StudentGrade]    Script Date: 3/24/2019 11:41:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StudentGrade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
 CONSTRAINT [PK_StudentGrade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StudentGrade]  WITH CHECK ADD  CONSTRAINT [FK_GradeStudent_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO

ALTER TABLE [dbo].[StudentGrade] CHECK CONSTRAINT [FK_GradeStudent_Student]
GO

ALTER TABLE [dbo].[StudentGrade]  WITH CHECK ADD  CONSTRAINT [FK_StudentGrade_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO

ALTER TABLE [dbo].[StudentGrade] CHECK CONSTRAINT [FK_StudentGrade_Subject]
GO


