USE [master]
GO
/****** Object:  Database [CourseManager]    Script Date: 17/11/2022 4:04:03 CH ******/
CREATE DATABASE [CourseManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CourseManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CourseManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CourseManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CourseManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CourseManager] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CourseManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CourseManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CourseManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CourseManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CourseManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CourseManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [CourseManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CourseManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CourseManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CourseManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CourseManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CourseManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CourseManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CourseManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CourseManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CourseManager] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CourseManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CourseManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CourseManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CourseManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CourseManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CourseManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CourseManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CourseManager] SET RECOVERY FULL 
GO
ALTER DATABASE [CourseManager] SET  MULTI_USER 
GO
ALTER DATABASE [CourseManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CourseManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CourseManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CourseManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CourseManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CourseManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CourseManager', N'ON'
GO
ALTER DATABASE [CourseManager] SET QUERY_STORE = OFF
GO
USE [CourseManager]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 17/11/2022 4:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 17/11/2022 4:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassId] [uniqueidentifier] NOT NULL,
	[ClassName] [nvarchar](50) NULL,
	[ClassCode] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[TeacherId] [uniqueidentifier] NULL,
	[TeacherName] [nvarchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConfigSystem]    Script Date: 17/11/2022 4:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigSystem](
	[SystemId] [uniqueidentifier] NOT NULL,
	[Image] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NULL,
	[IdNo] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Hotline1] [nvarchar](50) NULL,
	[Hotline2] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[TitleDefault] [nvarchar](500) NULL,
	[Information] [nvarchar](2000) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_ConfigSystem] PRIMARY KEY CLUSTERED 
(
	[SystemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 17/11/2022 4:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[TeacherId] [uniqueidentifier] NULL,
	[EnglishName] [nvarchar](max) NULL,
	[CourseName] [nvarchar](500) NULL,
	[title] [nvarchar](max) NULL,
	[Image] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[CourseCategoryId] [uniqueidentifier] NULL,
	[Note] [nvarchar](max) NULL,
	[CountLesson] [int] NULL,
	[Price] [money] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Status] [bit] NULL,
	[UpdateBy] [nvarchar](50) NULL,
	[CreateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseCategory]    Script Date: 17/11/2022 4:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseCategory](
	[CourseCategoryId] [uniqueidentifier] NOT NULL,
	[CourseCategoryCode] [nvarchar](max) NULL,
	[CourseCategoryName] [nvarchar](500) NULL,
	[ParentId] [bigint] NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[Createdate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_CourseCategory] PRIMARY KEY CLUSTERED 
(
	[CourseCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[New]    Script Date: 17/11/2022 4:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[New](
	[NewId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[NewCategoryId] [uniqueidentifier] NULL,
	[Description] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NULL,
	[Image] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[LastEditBy] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[Status] [bit] NULL,
	[UpdateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[NewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewCategory]    Script Date: 17/11/2022 4:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewCategory](
	[NewCategoryId] [uniqueidentifier] NOT NULL,
	[NewCategoryCode] [nvarchar](max) NULL,
	[NewCategoryName] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[Createdate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [nvarchar](250) NULL,
 CONSTRAINT [PK_NewCategory] PRIMARY KEY CLUSTERED 
(
	[NewCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentOfCouse]    Script Date: 17/11/2022 4:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentOfCouse](
	[PaymentId] [uniqueidentifier] NOT NULL,
	[Money] [money] NULL,
	[StudentId] [uniqueidentifier] NOT NULL,
	[CourseId] [uniqueidentifier] NULL,
	[ContentPayment] [nvarchar](500) NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[StatusPayment] [bit] NULL,
 CONSTRAINT [PK_PaymentOfCouse] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentOfExpense]    Script Date: 17/11/2022 4:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentOfExpense](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TypeOfPaymentId] [bigint] NULL,
	[Money] [money] NULL,
	[Reason] [nvarchar](500) NULL,
	[Bill] [nvarchar](500) NULL,
	[Accreditative] [nvarchar](500) NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_PaymentOfExpense] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Register]    Script Date: 17/11/2022 4:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Register](
	[RegisterId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[CompanyAddress] [nvarchar](max) NULL,
	[CourseId] [uniqueidentifier] NULL,
	[Level] [nvarchar](max) NULL,
	[Know] [nvarchar](50) NULL,
	[Note] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[CreateDate] [date] NULL,
	[UpdateDate] [date] NULL,
	[ClassId] [uniqueidentifier] NULL,
	[ClassCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Register] PRIMARY KEY CLUSTERED 
(
	[RegisterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 17/11/2022 4:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [uniqueidentifier] NOT NULL,
	[StudentCode] [nvarchar](50) NULL,
	[StudentName] [nvarchar](250) NULL,
	[Image] [nvarchar](250) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](150) NULL,
	[Description] [nvarchar](max) NULL,
	[Address] [nvarchar](500) NULL,
	[Gender] [int] NULL,
	[DateOfBirth] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Status] [bit] NULL,
	[UpdateBy] [nvarchar](250) NULL,
	[CreateBy] [nvarchar](250) NULL,
	[CourseId] [uniqueidentifier] NULL,
	[ClassId] [uniqueidentifier] NULL,
	[ClassName] [nvarchar](50) NULL,
	[Level] [nvarchar](50) NULL,
	[Know] [nvarchar](50) NULL,
	[WorkLocation] [nvarchar](max) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 17/11/2022 4:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [uniqueidentifier] NOT NULL,
	[TeacherCode] [nvarchar](50) NULL,
	[Image] [nvarchar](250) NULL,
	[TeacherName] [nvarchar](250) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](150) NULL,
	[Address] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[Gender] [int] NULL,
	[say] [nvarchar](max) NULL,
	[regular] [nvarchar](max) NULL,
	[DateOfBirth] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Status] [bit] NULL,
	[UpdateBy] [nvarchar](50) NULL,
	[CreateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfPayment]    Script Date: 17/11/2022 4:04:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfPayment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_TypeOfPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Teacher]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_CourseCategory] FOREIGN KEY([CourseCategoryId])
REFERENCES [dbo].[CourseCategory] ([CourseCategoryId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_CourseCategory]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Teacher]
GO
ALTER TABLE [dbo].[New]  WITH CHECK ADD  CONSTRAINT [FK_New_NewCategory] FOREIGN KEY([NewCategoryId])
REFERENCES [dbo].[NewCategory] ([NewCategoryId])
GO
ALTER TABLE [dbo].[New] CHECK CONSTRAINT [FK_New_NewCategory]
GO
ALTER TABLE [dbo].[PaymentOfCouse]  WITH CHECK ADD  CONSTRAINT [FK_PaymentOfCouse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[PaymentOfCouse] CHECK CONSTRAINT [FK_PaymentOfCouse_Course]
GO
ALTER TABLE [dbo].[PaymentOfCouse]  WITH CHECK ADD  CONSTRAINT [FK_PaymentOfCouse_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[PaymentOfCouse] CHECK CONSTRAINT [FK_PaymentOfCouse_Student]
GO
ALTER TABLE [dbo].[PaymentOfExpense]  WITH CHECK ADD  CONSTRAINT [FK_PaymentOfExpense_TypeOfPayment] FOREIGN KEY([TypeOfPaymentId])
REFERENCES [dbo].[TypeOfPayment] ([Id])
GO
ALTER TABLE [dbo].[PaymentOfExpense] CHECK CONSTRAINT [FK_PaymentOfExpense_TypeOfPayment]
GO
ALTER TABLE [dbo].[Register]  WITH CHECK ADD  CONSTRAINT [FK_Register_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Register] CHECK CONSTRAINT [FK_Register_Course]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Class]
GO
USE [master]
GO
ALTER DATABASE [CourseManager] SET  READ_WRITE 
GO
