USE [master]
GO
/****** Object:  Database [Arweqa]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE DATABASE [Arweqa]
 CONTAINMENT = NONE


GO
USE [Arweqa]
GO
/****** Object:  Schema [Arweqa]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE SCHEMA [Arweqa]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/27/2022 3:25:42 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[About]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[AboutUs] [nvarchar](max) NULL,
	[Provide] [nvarchar](max) NULL,
	[Terms] [nvarchar](max) NULL,
	[Egabat] [nvarchar](max) NULL,
	[Contact] [nvarchar](max) NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Advertisements]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisements](
	[Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[File] [nvarchar](max) NULL,
	[Index] [int] NOT NULL,
	[SlideNumber] [int] NOT NULL,
	[Url] [nvarchar](max) NULL,
 CONSTRAINT [PK_Advertisements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[UserFullName] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[DeviceToken] [nvarchar](max) NULL,
	[SectionId] [uniqueidentifier] NULL,
	[GradeId] [uniqueidentifier] NULL,
	[UserType] [nvarchar](max) NULL,
	[UserImage] [nvarchar](max) NULL,
	[OldIdentityId] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[Country_Name] [nvarchar](max) NULL,
	[Country_Code] [nvarchar](max) NULL,
	[Flag_Path] [nvarchar](max) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExceptionLoggers]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionLoggers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text1] [nvarchar](max) NULL,
	[Text2] [nvarchar](max) NULL,
	[Controller] [nvarchar](max) NULL,
	[Action] [nvarchar](max) NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ExceptionLoggers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Governorate]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Governorate](
	[Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Governorate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LessonVideoRoomConnections]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LessonVideoRoomConnections](
	[Connection_Id] [nvarchar](450) NOT NULL,
	[Room_Id] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[User_Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_LessonVideoRoomConnections] PRIMARY KEY CLUSTERED 
(
	[Connection_Id] ASC,
	[Room_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionsBank]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionsBank](
	[Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[Answer_Id] [uniqueidentifier] NOT NULL,
	[Question] [nvarchar](450) NULL,
 CONSTRAINT [PK_QuestionsBank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionsBankAnswer]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionsBankAnswer](
	[Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[Answer] [nvarchar](max) NULL,
	[SubjectId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_QuestionsBankAnswer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialLinks]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialLinks](
	[Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[Facebook] [nvarchar](max) NULL,
	[Twitter] [nvarchar](max) NULL,
	[Youtube] [nvarchar](max) NULL,
	[Linkedin] [nvarchar](max) NULL,
	[Instagram] [nvarchar](max) NULL,
	[WhatsApp] [nvarchar](max) NULL,
 CONSTRAINT [PK_SocialLinks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Answer]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Answer](
	[pk_Answer_Id] [uniqueidentifier] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[fk_Request_Answer_RequestId] [uniqueidentifier] NOT NULL,
	[fk_Student_Answer_StudentId] [uniqueidentifier] NOT NULL,
	[fk_Subject_Answer_SubjectId] [uniqueidentifier] NOT NULL,
	[fk_Teacher_Answer_TeacherId] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_tbl_Answer] PRIMARY KEY CLUSTERED 
(
	[pk_Answer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_AnswerAttachment]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_AnswerAttachment](
	[pk_AnswerAttachment_Id] [uniqueidentifier] NOT NULL,
	[fk_Answer_AnswerAttachment_AnswerId] [uniqueidentifier] NOT NULL,
	[File] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_tbl_AnswerAttachment] PRIMARY KEY CLUSTERED 
(
	[pk_AnswerAttachment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ExtraRequest]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ExtraRequest](
	[pk_ExtraRequest_Id] [uniqueidentifier] NOT NULL,
	[fk_Student_ExtraRequest_StudentId] [uniqueidentifier] NOT NULL,
	[fk_Subject_ExtraRequest_SubjectId] [uniqueidentifier] NOT NULL,
	[RequestCount] [int] NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_tbl_ExtraRequest] PRIMARY KEY CLUSTERED 
(
	[pk_ExtraRequest_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Grade]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Grade](
	[pk_Grade_Id] [uniqueidentifier] NOT NULL,
	[GradeName] [nvarchar](max) NOT NULL,
	[fk_Stage_Grade_StageId] [uniqueidentifier] NOT NULL,
	[Index] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_tbl_Grade] PRIMARY KEY CLUSTERED 
(
	[pk_Grade_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Lesson]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Lesson](
	[pk_Lesson_Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[fk_Unit_Lesson_UnitId] [uniqueidentifier] NOT NULL,
	[LessonName] [nvarchar](max) NULL,
	[Index] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Lesson] PRIMARY KEY CLUSTERED 
(
	[pk_Lesson_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_LessonAttachment]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_LessonAttachment](
	[pk_LessonAttachment_Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[fk_Lesson_LessonAttachment_LessonId] [uniqueidentifier] NOT NULL,
	[File] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[ContentTypeFor] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[FileImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_LessonAttachment] PRIMARY KEY CLUSTERED 
(
	[pk_LessonAttachment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_LessonQuestion]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_LessonQuestion](
	[pk_LessonQuestion_Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[LessonId] [uniqueidentifier] NOT NULL,
	[ContentType] [nvarchar](max) NULL,
	[Question] [nvarchar](max) NULL,
	[Index] [int] NOT NULL,
 CONSTRAINT [PK_tbl_LessonQuestion] PRIMARY KEY CLUSTERED 
(
	[pk_LessonQuestion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_lessonQuestionAnswer]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_lessonQuestionAnswer](
	[pk_lessonQuestionAnswer_Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[LessonQuestionId] [uniqueidentifier] NOT NULL,
	[ContentType] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
	[IsRight] [bit] NOT NULL,
	[Index] [int] NOT NULL,
 CONSTRAINT [PK_tbl_lessonQuestionAnswer] PRIMARY KEY CLUSTERED 
(
	[pk_lessonQuestionAnswer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_LessonVideoRoom]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_LessonVideoRoom](
	[Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[LessonId] [uniqueidentifier] NOT NULL,
	[RoomId] [nvarchar](450) NULL,
	[Attenendence] [int] NOT NULL,
	[LiveDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_tbl_LessonVideoRoom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Library]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Library](
	[pk_Library_Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[fk_Grade_Library_GradeId] [uniqueidentifier] NOT NULL,
	[fk_Semester_Library_SemesterId] [uniqueidentifier] NOT NULL,
	[CategoryCode] [nvarchar](450) NULL,
	[Name] [nvarchar](max) NULL,
	[FileImage] [nvarchar](max) NULL,
	[File] [nvarchar](max) NULL,
	[FileType] [nvarchar](max) NULL,
	[Index] [int] NOT NULL,
	[IsPremium] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_Library] PRIMARY KEY CLUSTERED 
(
	[pk_Library_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_LibraryType]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_LibraryType](
	[pk_LibraryType_Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[Category] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_tbl_LibraryType] PRIMARY KEY CLUSTERED 
(
	[pk_LibraryType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_tbl_LibraryType_Category] UNIQUE NONCLUSTERED 
(
	[Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Message]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Message](
	[pk_Message_Id] [uniqueidentifier] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsAdmin] [bit] NOT NULL,
	[IsTeacher] [bit] NOT NULL,
	[fk_ApplicationUser_Message_ApplicationUserReceiverId] [uniqueidentifier] NOT NULL,
	[fk_ApplicationUser_Message_ApplicationUserSenderId] [uniqueidentifier] NOT NULL,
	[SenderName] [nvarchar](max) NULL,
	[Attachment] [nvarchar](max) NULL,
	[IsFile] [bit] NOT NULL,
	[Type] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_tbl_Message] PRIMARY KEY CLUSTERED 
(
	[pk_Message_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Notification]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Notification](
	[pk_Notification_Id] [uniqueidentifier] NOT NULL,
	[fk_ApplicationUser_Notification_ApplicationUserId] [uniqueidentifier] NOT NULL,
	[StudentName] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Discription] [nvarchar](max) NULL,
	[Date] [datetime2](7) NOT NULL,
	[Seen] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_tbl_Notification] PRIMARY KEY CLUSTERED 
(
	[pk_Notification_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Request]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Request](
	[pk_Request_Id] [uniqueidentifier] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Replied] [bit] NOT NULL,
	[fk_Student_Request_StudentId] [uniqueidentifier] NOT NULL,
	[fk_Subject_Request_SubjectId] [uniqueidentifier] NOT NULL,
	[fk_Teacher_Request_TeacherId] [uniqueidentifier] NOT NULL,
	[RequestNo] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[RepliedInTime] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_tbl_Request] PRIMARY KEY CLUSTERED 
(
	[pk_Request_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_RequestAttachment]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_RequestAttachment](
	[pk_RequestAttachment_Id] [uniqueidentifier] NOT NULL,
	[pk_Request_RequestAttachment_RequestId] [uniqueidentifier] NOT NULL,
	[File] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_tbl_RequestAttachment] PRIMARY KEY CLUSTERED 
(
	[pk_RequestAttachment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Section]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Section](
	[pk_Section_Id] [uniqueidentifier] NOT NULL,
	[SectionName] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[Index] [int] NOT NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tbl_Section] PRIMARY KEY CLUSTERED 
(
	[pk_Section_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Semester]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Semester](
	[pk_Semester_Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[SemesterName] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Index] [int] NOT NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tbl_Semester] PRIMARY KEY CLUSTERED 
(
	[pk_Semester_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Stage]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Stage](
	[pk_Stage_Id] [uniqueidentifier] NOT NULL,
	[StageName] [nvarchar](max) NOT NULL,
	[Index] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tbl_Stage] PRIMARY KEY CLUSTERED 
(
	[pk_Stage_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Student]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Student](
	[pk_Student_Id] [uniqueidentifier] NOT NULL,
	[PremiumSubscription] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[ProfileImage] [nvarchar](max) NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[EducationalLevel] [nvarchar](max) NULL,
	[EducationalYear] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[InstitueName] [nvarchar](max) NULL,
	[InstituteType] [nvarchar](max) NULL,
	[ScientificDivision] [nvarchar](max) NULL,
	[GovernorateId] [uniqueidentifier] NULL,
	[City] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Student] PRIMARY KEY CLUSTERED 
(
	[pk_Student_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_StudentlessonQuestionAnswer]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_StudentlessonQuestionAnswer](
	[pk_StudentlessonQuestionAnswer_Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[StudentId] [uniqueidentifier] NOT NULL,
	[LessonQuestionAnswerId] [uniqueidentifier] NULL,
	[IsRight] [bit] NOT NULL,
	[LessonQuestionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tbl_StudentlessonQuestionAnswer] PRIMARY KEY CLUSTERED 
(
	[pk_StudentlessonQuestionAnswer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SubjectGrade]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SubjectGrade](
	[pk_SubjectGrade_Id] [uniqueidentifier] NOT NULL,
	[fk_Grade_SubjectGrade_GradeId] [uniqueidentifier] NOT NULL,
	[SubjectName] [nvarchar](max) NOT NULL,
	[fk_Section_SubjectGrade_SectionId] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[SubjectImage] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[Index] [int] NOT NULL,
	[SubjectSmallImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_SubjectGrade] PRIMARY KEY CLUSTERED 
(
	[pk_SubjectGrade_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Teacher]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Teacher](
	[pk_Teacher_Id] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[PremiumSubscription] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_Teacher] PRIMARY KEY CLUSTERED 
(
	[pk_Teacher_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TeacherSubject]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TeacherSubject](
	[pk_TeacherSubject_Id] [uniqueidentifier] NOT NULL,
	[fk_Teacher_TeacherSubject_TeacherId] [uniqueidentifier] NOT NULL,
	[fk_Subject_TeacherSubject_SubjectId] [uniqueidentifier] NOT NULL,
	[Role] [int] NOT NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Deleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_tbl_TeacherSubject] PRIMARY KEY CLUSTERED 
(
	[pk_TeacherSubject_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TeacherSubjectPermessions]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TeacherSubjectPermessions](
	[Id] [uniqueidentifier] NOT NULL,
	[Teacher_Subject_Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[Permession] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_TeacherSubjectPermessions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Teacher_Subject_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Unit]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Unit](
	[pk_Unit_Id] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime2](7) NULL,
	[LastModifiedBy] [uniqueidentifier] NULL,
	[LastModifyDate] [datetime2](7) NULL,
	[fk_Subject_Unit_SubjectId] [uniqueidentifier] NOT NULL,
	[fk_Semester_Unit_SemesterId] [uniqueidentifier] NOT NULL,
	[UnitName] [nvarchar](max) NULL,
	[Index] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Unit] PRIMARY KEY CLUSTERED 
(
	[pk_Unit_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_GradeId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_GradeId] ON [dbo].[AspNetUsers]
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_SectionId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_SectionId] ON [dbo].[AspNetUsers]
(
	[SectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LessonVideoRoomConnections_Room_Id]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_LessonVideoRoomConnections_Room_Id] ON [dbo].[LessonVideoRoomConnections]
(
	[Room_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_QuestionsBank_Answer_Id]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuestionsBank_Answer_Id] ON [dbo].[QuestionsBank]
(
	[Answer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_QuestionsBank_Question]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuestionsBank_Question] ON [dbo].[QuestionsBank]
(
	[Question] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_QuestionsBankAnswer_SubjectId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuestionsBankAnswer_SubjectId] ON [dbo].[QuestionsBankAnswer]
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Answer_fk_Request_Answer_RequestId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Answer_fk_Request_Answer_RequestId] ON [dbo].[tbl_Answer]
(
	[fk_Request_Answer_RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Answer_fk_Student_Answer_StudentId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Answer_fk_Student_Answer_StudentId] ON [dbo].[tbl_Answer]
(
	[fk_Student_Answer_StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Answer_fk_Subject_Answer_SubjectId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Answer_fk_Subject_Answer_SubjectId] ON [dbo].[tbl_Answer]
(
	[fk_Subject_Answer_SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Answer_fk_Teacher_Answer_TeacherId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Answer_fk_Teacher_Answer_TeacherId] ON [dbo].[tbl_Answer]
(
	[fk_Teacher_Answer_TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_AnswerAttachment_fk_Answer_AnswerAttachment_AnswerId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_AnswerAttachment_fk_Answer_AnswerAttachment_AnswerId] ON [dbo].[tbl_AnswerAttachment]
(
	[fk_Answer_AnswerAttachment_AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_ExtraRequest_fk_Student_ExtraRequest_StudentId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_ExtraRequest_fk_Student_ExtraRequest_StudentId] ON [dbo].[tbl_ExtraRequest]
(
	[fk_Student_ExtraRequest_StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_ExtraRequest_fk_Subject_ExtraRequest_SubjectId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_ExtraRequest_fk_Subject_ExtraRequest_SubjectId] ON [dbo].[tbl_ExtraRequest]
(
	[fk_Subject_ExtraRequest_SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Grade_fk_Stage_Grade_StageId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Grade_fk_Stage_Grade_StageId] ON [dbo].[tbl_Grade]
(
	[fk_Stage_Grade_StageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Lesson_fk_Unit_Lesson_UnitId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Lesson_fk_Unit_Lesson_UnitId] ON [dbo].[tbl_Lesson]
(
	[fk_Unit_Lesson_UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_LessonAttachment_fk_Lesson_LessonAttachment_LessonId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_LessonAttachment_fk_Lesson_LessonAttachment_LessonId] ON [dbo].[tbl_LessonAttachment]
(
	[fk_Lesson_LessonAttachment_LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_LessonQuestion_LessonId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_LessonQuestion_LessonId] ON [dbo].[tbl_LessonQuestion]
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_lessonQuestionAnswer_LessonQuestionId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_lessonQuestionAnswer_LessonQuestionId] ON [dbo].[tbl_lessonQuestionAnswer]
(
	[LessonQuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_LessonVideoRoom_LessonId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_LessonVideoRoom_LessonId] ON [dbo].[tbl_LessonVideoRoom]
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_tbl_LessonVideoRoom_RoomId_Deleted]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tbl_LessonVideoRoom_RoomId_Deleted] ON [dbo].[tbl_LessonVideoRoom]
(
	[RoomId] ASC,
	[Deleted] ASC
)
WHERE ([RoomId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_tbl_Library_CategoryCode]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Library_CategoryCode] ON [dbo].[tbl_Library]
(
	[CategoryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Library_fk_Grade_Library_GradeId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Library_fk_Grade_Library_GradeId] ON [dbo].[tbl_Library]
(
	[fk_Grade_Library_GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Library_fk_Semester_Library_SemesterId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Library_fk_Semester_Library_SemesterId] ON [dbo].[tbl_Library]
(
	[fk_Semester_Library_SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Message_fk_ApplicationUser_Message_ApplicationUserReceiverId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Message_fk_ApplicationUser_Message_ApplicationUserReceiverId] ON [dbo].[tbl_Message]
(
	[fk_ApplicationUser_Message_ApplicationUserReceiverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Message_fk_ApplicationUser_Message_ApplicationUserSenderId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Message_fk_ApplicationUser_Message_ApplicationUserSenderId] ON [dbo].[tbl_Message]
(
	[fk_ApplicationUser_Message_ApplicationUserSenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Notification_fk_ApplicationUser_Notification_ApplicationUserId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Notification_fk_ApplicationUser_Notification_ApplicationUserId] ON [dbo].[tbl_Notification]
(
	[fk_ApplicationUser_Notification_ApplicationUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Request_fk_Student_Request_StudentId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Request_fk_Student_Request_StudentId] ON [dbo].[tbl_Request]
(
	[fk_Student_Request_StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Request_fk_Subject_Request_SubjectId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Request_fk_Subject_Request_SubjectId] ON [dbo].[tbl_Request]
(
	[fk_Subject_Request_SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Request_fk_Teacher_Request_TeacherId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Request_fk_Teacher_Request_TeacherId] ON [dbo].[tbl_Request]
(
	[fk_Teacher_Request_TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_RequestAttachment_pk_Request_RequestAttachment_RequestId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_RequestAttachment_pk_Request_RequestAttachment_RequestId] ON [dbo].[tbl_RequestAttachment]
(
	[pk_Request_RequestAttachment_RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Section_CountryId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Section_CountryId] ON [dbo].[tbl_Section]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Semester_CountryId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Semester_CountryId] ON [dbo].[tbl_Semester]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Stage_CountryId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Stage_CountryId] ON [dbo].[tbl_Stage]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Student_GovernorateId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Student_GovernorateId] ON [dbo].[tbl_Student]
(
	[GovernorateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_StudentlessonQuestionAnswer_LessonQuestionAnswerId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_StudentlessonQuestionAnswer_LessonQuestionAnswerId] ON [dbo].[tbl_StudentlessonQuestionAnswer]
(
	[LessonQuestionAnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_StudentlessonQuestionAnswer_LessonQuestionId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_StudentlessonQuestionAnswer_LessonQuestionId] ON [dbo].[tbl_StudentlessonQuestionAnswer]
(
	[LessonQuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_StudentlessonQuestionAnswer_StudentId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_StudentlessonQuestionAnswer_StudentId] ON [dbo].[tbl_StudentlessonQuestionAnswer]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_SubjectGrade_fk_Grade_SubjectGrade_GradeId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_SubjectGrade_fk_Grade_SubjectGrade_GradeId] ON [dbo].[tbl_SubjectGrade]
(
	[fk_Grade_SubjectGrade_GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_SubjectGrade_fk_Section_SubjectGrade_SectionId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_SubjectGrade_fk_Section_SubjectGrade_SectionId] ON [dbo].[tbl_SubjectGrade]
(
	[fk_Section_SubjectGrade_SectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_TeacherSubject_fk_Subject_TeacherSubject_SubjectId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_TeacherSubject_fk_Subject_TeacherSubject_SubjectId] ON [dbo].[tbl_TeacherSubject]
(
	[fk_Subject_TeacherSubject_SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_TeacherSubject_fk_Teacher_TeacherSubject_TeacherId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_TeacherSubject_fk_Teacher_TeacherSubject_TeacherId] ON [dbo].[tbl_TeacherSubject]
(
	[fk_Teacher_TeacherSubject_TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_TeacherSubjectPermessions_Teacher_Subject_Id]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_TeacherSubjectPermessions_Teacher_Subject_Id] ON [dbo].[tbl_TeacherSubjectPermessions]
(
	[Teacher_Subject_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Unit_fk_Semester_Unit_SemesterId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Unit_fk_Semester_Unit_SemesterId] ON [dbo].[tbl_Unit]
(
	[fk_Semester_Unit_SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_Unit_fk_Subject_Unit_SubjectId]    Script Date: 11/27/2022 3:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_Unit_fk_Subject_Unit_SubjectId] ON [dbo].[tbl_Unit]
(
	[fk_Subject_Unit_SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Advertisements] ADD  DEFAULT ((0)) FOR [SlideNumber]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF__AspNetUse__Delet__4E88ABD4]  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[Governorate] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[QuestionsBankAnswer] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [SubjectId]
GO
ALTER TABLE [dbo].[tbl_Answer] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [fk_Request_Answer_RequestId]
GO
ALTER TABLE [dbo].[tbl_Answer] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [fk_Student_Answer_StudentId]
GO
ALTER TABLE [dbo].[tbl_Answer] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [fk_Subject_Answer_SubjectId]
GO
ALTER TABLE [dbo].[tbl_Answer] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [fk_Teacher_Answer_TeacherId]
GO
ALTER TABLE [dbo].[tbl_Answer] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_Answer] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_AnswerAttachment] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_AnswerAttachment] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_ExtraRequest] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_ExtraRequest] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Grade] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [fk_Stage_Grade_StageId]
GO
ALTER TABLE [dbo].[tbl_Grade] ADD  DEFAULT ((0)) FOR [Index]
GO
ALTER TABLE [dbo].[tbl_Grade] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Grade] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_Lesson] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_LessonAttachment] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_LessonQuestion] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_lessonQuestionAnswer] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Library] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Library] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsPremium]
GO
ALTER TABLE [dbo].[tbl_LibraryType] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Message] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Date]
GO
ALTER TABLE [dbo].[tbl_Message] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[tbl_Message] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsTeacher]
GO
ALTER TABLE [dbo].[tbl_Message] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsFile]
GO
ALTER TABLE [dbo].[tbl_Message] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_Message] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Notification] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Seen]
GO
ALTER TABLE [dbo].[tbl_Notification] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_Notification] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Request] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Replied]
GO
ALTER TABLE [dbo].[tbl_Request] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [fk_Student_Request_StudentId]
GO
ALTER TABLE [dbo].[tbl_Request] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [fk_Subject_Request_SubjectId]
GO
ALTER TABLE [dbo].[tbl_Request] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [fk_Teacher_Request_TeacherId]
GO
ALTER TABLE [dbo].[tbl_Request] ADD  DEFAULT ((0)) FOR [RequestNo]
GO
ALTER TABLE [dbo].[tbl_Request] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_Request] ADD  DEFAULT (CONVERT([bit],(0))) FOR [RepliedInTime]
GO
ALTER TABLE [dbo].[tbl_Request] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_RequestAttachment] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_RequestAttachment] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Section] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Section] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_Section] ADD  DEFAULT ((0)) FOR [Index]
GO
ALTER TABLE [dbo].[tbl_Section] ADD  DEFAULT ('d8723c35-a588-4a17-9292-eef3252b7228') FOR [CountryId]
GO
ALTER TABLE [dbo].[tbl_Semester] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Semester] ADD  DEFAULT ('d8723c35-a588-4a17-9292-eef3252b7228') FOR [CountryId]
GO
ALTER TABLE [dbo].[tbl_Stage] ADD  DEFAULT (N'') FOR [StageName]
GO
ALTER TABLE [dbo].[tbl_Stage] ADD  DEFAULT ((0)) FOR [Index]
GO
ALTER TABLE [dbo].[tbl_Stage] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Stage] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_Stage] ADD  DEFAULT ('d8723c35-a588-4a17-9292-eef3252b7228') FOR [CountryId]
GO
ALTER TABLE [dbo].[tbl_Student] ADD  DEFAULT (CONVERT([bit],(0))) FOR [PremiumSubscription]
GO
ALTER TABLE [dbo].[tbl_Student] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_Student] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Student] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [BirthDate]
GO
ALTER TABLE [dbo].[tbl_StudentlessonQuestionAnswer] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_StudentlessonQuestionAnswer] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [LessonQuestionId]
GO
ALTER TABLE [dbo].[tbl_SubjectGrade] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_SubjectGrade] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_SubjectGrade] ADD  DEFAULT ((0)) FOR [Index]
GO
ALTER TABLE [dbo].[tbl_Teacher] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_Teacher] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Teacher] ADD  DEFAULT (CONVERT([bit],(0))) FOR [PremiumSubscription]
GO
ALTER TABLE [dbo].[tbl_TeacherSubject] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Deleted]
GO
ALTER TABLE [dbo].[tbl_TeacherSubject] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Unit] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_tbl_Grade_GradeId] FOREIGN KEY([GradeId])
REFERENCES [dbo].[tbl_Grade] ([pk_Grade_Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_tbl_Grade_GradeId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_tbl_Section_SectionId] FOREIGN KEY([SectionId])
REFERENCES [dbo].[tbl_Section] ([pk_Section_Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_tbl_Section_SectionId]
GO
ALTER TABLE [dbo].[LessonVideoRoomConnections]  WITH CHECK ADD  CONSTRAINT [FK_LessonVideoRoomConnections_tbl_LessonVideoRoom_Room_Id] FOREIGN KEY([Room_Id])
REFERENCES [dbo].[tbl_LessonVideoRoom] ([Id])
GO
ALTER TABLE [dbo].[LessonVideoRoomConnections] CHECK CONSTRAINT [FK_LessonVideoRoomConnections_tbl_LessonVideoRoom_Room_Id]
GO
ALTER TABLE [dbo].[QuestionsBank]  WITH CHECK ADD  CONSTRAINT [FK_QuestionsBank_QuestionsBankAnswer_Answer_Id] FOREIGN KEY([Answer_Id])
REFERENCES [dbo].[QuestionsBankAnswer] ([Id])
GO
ALTER TABLE [dbo].[QuestionsBank] CHECK CONSTRAINT [FK_QuestionsBank_QuestionsBankAnswer_Answer_Id]
GO
ALTER TABLE [dbo].[QuestionsBankAnswer]  WITH CHECK ADD  CONSTRAINT [FK_QuestionsBankAnswer_tbl_SubjectGrade_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[tbl_SubjectGrade] ([pk_SubjectGrade_Id])
GO
ALTER TABLE [dbo].[QuestionsBankAnswer] CHECK CONSTRAINT [FK_QuestionsBankAnswer_tbl_SubjectGrade_SubjectId]
GO
ALTER TABLE [dbo].[tbl_Answer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Answer_tbl_Request_fk_Request_Answer_RequestId] FOREIGN KEY([fk_Request_Answer_RequestId])
REFERENCES [dbo].[tbl_Request] ([pk_Request_Id])
GO
ALTER TABLE [dbo].[tbl_Answer] CHECK CONSTRAINT [FK_tbl_Answer_tbl_Request_fk_Request_Answer_RequestId]
GO
ALTER TABLE [dbo].[tbl_Answer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Answer_tbl_Student_fk_Student_Answer_StudentId] FOREIGN KEY([fk_Student_Answer_StudentId])
REFERENCES [dbo].[tbl_Student] ([pk_Student_Id])
GO
ALTER TABLE [dbo].[tbl_Answer] CHECK CONSTRAINT [FK_tbl_Answer_tbl_Student_fk_Student_Answer_StudentId]
GO
ALTER TABLE [dbo].[tbl_Answer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Answer_tbl_SubjectGrade_fk_Subject_Answer_SubjectId] FOREIGN KEY([fk_Subject_Answer_SubjectId])
REFERENCES [dbo].[tbl_SubjectGrade] ([pk_SubjectGrade_Id])
GO
ALTER TABLE [dbo].[tbl_Answer] CHECK CONSTRAINT [FK_tbl_Answer_tbl_SubjectGrade_fk_Subject_Answer_SubjectId]
GO
ALTER TABLE [dbo].[tbl_Answer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Answer_tbl_Teacher_fk_Teacher_Answer_TeacherId] FOREIGN KEY([fk_Teacher_Answer_TeacherId])
REFERENCES [dbo].[tbl_Teacher] ([pk_Teacher_Id])
GO
ALTER TABLE [dbo].[tbl_Answer] CHECK CONSTRAINT [FK_tbl_Answer_tbl_Teacher_fk_Teacher_Answer_TeacherId]
GO
ALTER TABLE [dbo].[tbl_AnswerAttachment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_AnswerAttachment_tbl_Answer_fk_Answer_AnswerAttachment_AnswerId] FOREIGN KEY([fk_Answer_AnswerAttachment_AnswerId])
REFERENCES [dbo].[tbl_Answer] ([pk_Answer_Id])
GO
ALTER TABLE [dbo].[tbl_AnswerAttachment] CHECK CONSTRAINT [FK_tbl_AnswerAttachment_tbl_Answer_fk_Answer_AnswerAttachment_AnswerId]
GO
ALTER TABLE [dbo].[tbl_ExtraRequest]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ExtraRequest_tbl_Student_fk_Student_ExtraRequest_StudentId] FOREIGN KEY([fk_Student_ExtraRequest_StudentId])
REFERENCES [dbo].[tbl_Student] ([pk_Student_Id])
GO
ALTER TABLE [dbo].[tbl_ExtraRequest] CHECK CONSTRAINT [FK_tbl_ExtraRequest_tbl_Student_fk_Student_ExtraRequest_StudentId]
GO
ALTER TABLE [dbo].[tbl_ExtraRequest]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ExtraRequest_tbl_SubjectGrade_fk_Subject_ExtraRequest_SubjectId] FOREIGN KEY([fk_Subject_ExtraRequest_SubjectId])
REFERENCES [dbo].[tbl_SubjectGrade] ([pk_SubjectGrade_Id])
GO
ALTER TABLE [dbo].[tbl_ExtraRequest] CHECK CONSTRAINT [FK_tbl_ExtraRequest_tbl_SubjectGrade_fk_Subject_ExtraRequest_SubjectId]
GO
ALTER TABLE [dbo].[tbl_Grade]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Grade_tbl_Stage_fk_Stage_Grade_StageId] FOREIGN KEY([fk_Stage_Grade_StageId])
REFERENCES [dbo].[tbl_Stage] ([pk_Stage_Id])
GO
ALTER TABLE [dbo].[tbl_Grade] CHECK CONSTRAINT [FK_tbl_Grade_tbl_Stage_fk_Stage_Grade_StageId]
GO
ALTER TABLE [dbo].[tbl_Lesson]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Lesson_tbl_Unit_fk_Unit_Lesson_UnitId] FOREIGN KEY([fk_Unit_Lesson_UnitId])
REFERENCES [dbo].[tbl_Unit] ([pk_Unit_Id])
GO
ALTER TABLE [dbo].[tbl_Lesson] CHECK CONSTRAINT [FK_tbl_Lesson_tbl_Unit_fk_Unit_Lesson_UnitId]
GO
ALTER TABLE [dbo].[tbl_LessonAttachment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_LessonAttachment_tbl_Lesson_fk_Lesson_LessonAttachment_LessonId] FOREIGN KEY([fk_Lesson_LessonAttachment_LessonId])
REFERENCES [dbo].[tbl_Lesson] ([pk_Lesson_Id])
GO
ALTER TABLE [dbo].[tbl_LessonAttachment] CHECK CONSTRAINT [FK_tbl_LessonAttachment_tbl_Lesson_fk_Lesson_LessonAttachment_LessonId]
GO
ALTER TABLE [dbo].[tbl_LessonQuestion]  WITH CHECK ADD  CONSTRAINT [FK_tbl_LessonQuestion_tbl_Lesson_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[tbl_Lesson] ([pk_Lesson_Id])
GO
ALTER TABLE [dbo].[tbl_LessonQuestion] CHECK CONSTRAINT [FK_tbl_LessonQuestion_tbl_Lesson_LessonId]
GO
ALTER TABLE [dbo].[tbl_lessonQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_lessonQuestionAnswer_tbl_LessonQuestion_LessonQuestionId] FOREIGN KEY([LessonQuestionId])
REFERENCES [dbo].[tbl_LessonQuestion] ([pk_LessonQuestion_Id])
GO
ALTER TABLE [dbo].[tbl_lessonQuestionAnswer] CHECK CONSTRAINT [FK_tbl_lessonQuestionAnswer_tbl_LessonQuestion_LessonQuestionId]
GO
ALTER TABLE [dbo].[tbl_LessonVideoRoom]  WITH CHECK ADD  CONSTRAINT [FK_tbl_LessonVideoRoom_tbl_Lesson_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[tbl_Lesson] ([pk_Lesson_Id])
GO
ALTER TABLE [dbo].[tbl_LessonVideoRoom] CHECK CONSTRAINT [FK_tbl_LessonVideoRoom_tbl_Lesson_LessonId]
GO
ALTER TABLE [dbo].[tbl_Library]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Library_tbl_Grade_fk_Grade_Library_GradeId] FOREIGN KEY([fk_Grade_Library_GradeId])
REFERENCES [dbo].[tbl_Grade] ([pk_Grade_Id])
GO
ALTER TABLE [dbo].[tbl_Library] CHECK CONSTRAINT [FK_tbl_Library_tbl_Grade_fk_Grade_Library_GradeId]
GO
ALTER TABLE [dbo].[tbl_Library]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Library_tbl_LibraryType_CategoryCode] FOREIGN KEY([CategoryCode])
REFERENCES [dbo].[tbl_LibraryType] ([Category])
GO
ALTER TABLE [dbo].[tbl_Library] CHECK CONSTRAINT [FK_tbl_Library_tbl_LibraryType_CategoryCode]
GO
ALTER TABLE [dbo].[tbl_Library]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Library_tbl_Semester_fk_Semester_Library_SemesterId] FOREIGN KEY([fk_Semester_Library_SemesterId])
REFERENCES [dbo].[tbl_Semester] ([pk_Semester_Id])
GO
ALTER TABLE [dbo].[tbl_Library] CHECK CONSTRAINT [FK_tbl_Library_tbl_Semester_fk_Semester_Library_SemesterId]
GO
ALTER TABLE [dbo].[tbl_Message]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Message_AspNetUsers_fk_ApplicationUser_Message_ApplicationUserReceiverId] FOREIGN KEY([fk_ApplicationUser_Message_ApplicationUserReceiverId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tbl_Message] CHECK CONSTRAINT [FK_tbl_Message_AspNetUsers_fk_ApplicationUser_Message_ApplicationUserReceiverId]
GO
ALTER TABLE [dbo].[tbl_Message]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Message_AspNetUsers_fk_ApplicationUser_Message_ApplicationUserSenderId] FOREIGN KEY([fk_ApplicationUser_Message_ApplicationUserSenderId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tbl_Message] CHECK CONSTRAINT [FK_tbl_Message_AspNetUsers_fk_ApplicationUser_Message_ApplicationUserSenderId]
GO
ALTER TABLE [dbo].[tbl_Notification]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Notification_AspNetUsers_fk_ApplicationUser_Notification_ApplicationUserId] FOREIGN KEY([fk_ApplicationUser_Notification_ApplicationUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Notification] CHECK CONSTRAINT [FK_tbl_Notification_AspNetUsers_fk_ApplicationUser_Notification_ApplicationUserId]
GO
ALTER TABLE [dbo].[tbl_Request]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Request_tbl_Student_fk_Student_Request_StudentId] FOREIGN KEY([fk_Student_Request_StudentId])
REFERENCES [dbo].[tbl_Student] ([pk_Student_Id])
GO
ALTER TABLE [dbo].[tbl_Request] CHECK CONSTRAINT [FK_tbl_Request_tbl_Student_fk_Student_Request_StudentId]
GO
ALTER TABLE [dbo].[tbl_Request]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Request_tbl_SubjectGrade_fk_Subject_Request_SubjectId] FOREIGN KEY([fk_Subject_Request_SubjectId])
REFERENCES [dbo].[tbl_SubjectGrade] ([pk_SubjectGrade_Id])
GO
ALTER TABLE [dbo].[tbl_Request] CHECK CONSTRAINT [FK_tbl_Request_tbl_SubjectGrade_fk_Subject_Request_SubjectId]
GO
ALTER TABLE [dbo].[tbl_Request]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Request_tbl_Teacher_fk_Teacher_Request_TeacherId] FOREIGN KEY([fk_Teacher_Request_TeacherId])
REFERENCES [dbo].[tbl_Teacher] ([pk_Teacher_Id])
GO
ALTER TABLE [dbo].[tbl_Request] CHECK CONSTRAINT [FK_tbl_Request_tbl_Teacher_fk_Teacher_Request_TeacherId]
GO
ALTER TABLE [dbo].[tbl_RequestAttachment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RequestAttachment_tbl_Request_pk_Request_RequestAttachment_RequestId] FOREIGN KEY([pk_Request_RequestAttachment_RequestId])
REFERENCES [dbo].[tbl_Request] ([pk_Request_Id])
GO
ALTER TABLE [dbo].[tbl_RequestAttachment] CHECK CONSTRAINT [FK_tbl_RequestAttachment_tbl_Request_pk_Request_RequestAttachment_RequestId]
GO
ALTER TABLE [dbo].[tbl_Section]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Section_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[tbl_Section] CHECK CONSTRAINT [FK_tbl_Section_Countries_CountryId]
GO
ALTER TABLE [dbo].[tbl_Semester]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Semester_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[tbl_Semester] CHECK CONSTRAINT [FK_tbl_Semester_Countries_CountryId]
GO
ALTER TABLE [dbo].[tbl_Stage]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Stage_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[tbl_Stage] CHECK CONSTRAINT [FK_tbl_Stage_Countries_CountryId]
GO
ALTER TABLE [dbo].[tbl_Student]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Student_AspNetUsers_pk_Student_Id] FOREIGN KEY([pk_Student_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tbl_Student] CHECK CONSTRAINT [FK_tbl_Student_AspNetUsers_pk_Student_Id]
GO
ALTER TABLE [dbo].[tbl_Student]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Student_Governorate_GovernorateId] FOREIGN KEY([GovernorateId])
REFERENCES [dbo].[Governorate] ([Id])
GO
ALTER TABLE [dbo].[tbl_Student] CHECK CONSTRAINT [FK_tbl_Student_Governorate_GovernorateId]
GO
ALTER TABLE [dbo].[tbl_StudentlessonQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_StudentlessonQuestionAnswer_tbl_LessonQuestion_LessonQuestionId] FOREIGN KEY([LessonQuestionId])
REFERENCES [dbo].[tbl_LessonQuestion] ([pk_LessonQuestion_Id])
GO
ALTER TABLE [dbo].[tbl_StudentlessonQuestionAnswer] CHECK CONSTRAINT [FK_tbl_StudentlessonQuestionAnswer_tbl_LessonQuestion_LessonQuestionId]
GO
ALTER TABLE [dbo].[tbl_StudentlessonQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_StudentlessonQuestionAnswer_tbl_lessonQuestionAnswer_LessonQuestionAnswerId] FOREIGN KEY([LessonQuestionAnswerId])
REFERENCES [dbo].[tbl_lessonQuestionAnswer] ([pk_lessonQuestionAnswer_Id])
GO
ALTER TABLE [dbo].[tbl_StudentlessonQuestionAnswer] CHECK CONSTRAINT [FK_tbl_StudentlessonQuestionAnswer_tbl_lessonQuestionAnswer_LessonQuestionAnswerId]
GO
ALTER TABLE [dbo].[tbl_StudentlessonQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_StudentlessonQuestionAnswer_tbl_Student_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[tbl_Student] ([pk_Student_Id])
GO
ALTER TABLE [dbo].[tbl_StudentlessonQuestionAnswer] CHECK CONSTRAINT [FK_tbl_StudentlessonQuestionAnswer_tbl_Student_StudentId]
GO
ALTER TABLE [dbo].[tbl_SubjectGrade]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SubjectGrade_tbl_Grade_fk_Grade_SubjectGrade_GradeId] FOREIGN KEY([fk_Grade_SubjectGrade_GradeId])
REFERENCES [dbo].[tbl_Grade] ([pk_Grade_Id])
GO
ALTER TABLE [dbo].[tbl_SubjectGrade] CHECK CONSTRAINT [FK_tbl_SubjectGrade_tbl_Grade_fk_Grade_SubjectGrade_GradeId]
GO
ALTER TABLE [dbo].[tbl_SubjectGrade]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SubjectGrade_tbl_Section_fk_Section_SubjectGrade_SectionId] FOREIGN KEY([fk_Section_SubjectGrade_SectionId])
REFERENCES [dbo].[tbl_Section] ([pk_Section_Id])
GO
ALTER TABLE [dbo].[tbl_SubjectGrade] CHECK CONSTRAINT [FK_tbl_SubjectGrade_tbl_Section_fk_Section_SubjectGrade_SectionId]
GO
ALTER TABLE [dbo].[tbl_Teacher]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Teacher_AspNetUsers_pk_Teacher_Id] FOREIGN KEY([pk_Teacher_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tbl_Teacher] CHECK CONSTRAINT [FK_tbl_Teacher_AspNetUsers_pk_Teacher_Id]
GO
ALTER TABLE [dbo].[tbl_TeacherSubject]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TeacherSubject_tbl_SubjectGrade_fk_Subject_TeacherSubject_SubjectId] FOREIGN KEY([fk_Subject_TeacherSubject_SubjectId])
REFERENCES [dbo].[tbl_SubjectGrade] ([pk_SubjectGrade_Id])
GO
ALTER TABLE [dbo].[tbl_TeacherSubject] CHECK CONSTRAINT [FK_tbl_TeacherSubject_tbl_SubjectGrade_fk_Subject_TeacherSubject_SubjectId]
GO
ALTER TABLE [dbo].[tbl_TeacherSubject]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TeacherSubject_tbl_Teacher_fk_Teacher_TeacherSubject_TeacherId] FOREIGN KEY([fk_Teacher_TeacherSubject_TeacherId])
REFERENCES [dbo].[tbl_Teacher] ([pk_Teacher_Id])
GO
ALTER TABLE [dbo].[tbl_TeacherSubject] CHECK CONSTRAINT [FK_tbl_TeacherSubject_tbl_Teacher_fk_Teacher_TeacherSubject_TeacherId]
GO
ALTER TABLE [dbo].[tbl_TeacherSubjectPermessions]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TeacherSubjectPermessions_tbl_TeacherSubject_Teacher_Subject_Id] FOREIGN KEY([Teacher_Subject_Id])
REFERENCES [dbo].[tbl_TeacherSubject] ([pk_TeacherSubject_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_TeacherSubjectPermessions] CHECK CONSTRAINT [FK_tbl_TeacherSubjectPermessions_tbl_TeacherSubject_Teacher_Subject_Id]
GO
ALTER TABLE [dbo].[tbl_Unit]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Unit_tbl_Semester_fk_Semester_Unit_SemesterId] FOREIGN KEY([fk_Semester_Unit_SemesterId])
REFERENCES [dbo].[tbl_Semester] ([pk_Semester_Id])
GO
ALTER TABLE [dbo].[tbl_Unit] CHECK CONSTRAINT [FK_tbl_Unit_tbl_Semester_fk_Semester_Unit_SemesterId]
GO
ALTER TABLE [dbo].[tbl_Unit]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Unit_tbl_SubjectGrade_fk_Subject_Unit_SubjectId] FOREIGN KEY([fk_Subject_Unit_SubjectId])
REFERENCES [dbo].[tbl_SubjectGrade] ([pk_SubjectGrade_Id])
GO
ALTER TABLE [dbo].[tbl_Unit] CHECK CONSTRAINT [FK_tbl_Unit_tbl_SubjectGrade_fk_Subject_Unit_SubjectId]
GO
/****** Object:  StoredProcedure [dbo].[DashboardReport]    Script Date: 11/27/2022 3:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DashboardReport]
        AS
        BEGIN
        DECLARE 
        @Section int,
        @Stage int,
		@Grade int,
		@Subject int,
		@Student int,
		@Teacher int,
		@Request int,
		@RepliedRequest int,
		@RepliedInTimeRequest int,
		@NotRepliedRequest int
		
         set @Section= (select COUNT(*) from tbl_Section);
		 set @Stage= (select COUNT(*) from tbl_Stage);
         set @Grade= (select COUNT(*) from tbl_Grade);
		 set @Subject= (select COUNT(*) from tbl_SubjectGrade);
         set @Student= (select COUNT(*) from tbl_Student);
		 set @Teacher= (select COUNT(*) from tbl_Teacher);
		 set @Request= (select COUNT(*) from tbl_Request);
		 set @RepliedRequest= (select COUNT(*) from tbl_Request Where Replied = 'True'); 
		 set @RepliedInTimeRequest= (select COUNT(*) from tbl_Request Where RepliedInTime = 'True'); 
		 set @NotRepliedRequest= (select COUNT(*) from tbl_Request Where Replied = 'false');

		 SELECT @Section 'Section', @Stage 'Stage', @Grade 'Grade' , @Subject 'Subject' ,  @Student 'Student' ,  @Teacher 'Teacher' ,  @Request 'Request' ,  @RepliedRequest 'RepliedRequest' , @RepliedInTimeRequest 'RepliedInTimeRequest', @NotRepliedRequest 'NotRepliedRequest'
        
		END
GO
USE [master]
GO
ALTER DATABASE [Arweqa] SET  READ_WRITE 
GO
