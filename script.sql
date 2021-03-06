USE [master]
GO
/****** Object:  Database [OtherGeorgia]    Script Date: 26.01.2018 22:28:19 ******/
CREATE DATABASE [OtherGeorgia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OtherGeorgia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER2016\MSSQL\DATA\OtherGeorgia.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OtherGeorgia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER2016\MSSQL\DATA\OtherGeorgia_log.ldf' , SIZE = 2304KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [OtherGeorgia] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OtherGeorgia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OtherGeorgia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OtherGeorgia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OtherGeorgia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OtherGeorgia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OtherGeorgia] SET ARITHABORT OFF 
GO
ALTER DATABASE [OtherGeorgia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OtherGeorgia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OtherGeorgia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OtherGeorgia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OtherGeorgia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OtherGeorgia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OtherGeorgia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OtherGeorgia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OtherGeorgia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OtherGeorgia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OtherGeorgia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OtherGeorgia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OtherGeorgia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OtherGeorgia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OtherGeorgia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OtherGeorgia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OtherGeorgia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OtherGeorgia] SET RECOVERY FULL 
GO
ALTER DATABASE [OtherGeorgia] SET  MULTI_USER 
GO
ALTER DATABASE [OtherGeorgia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OtherGeorgia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OtherGeorgia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OtherGeorgia] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [OtherGeorgia] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OtherGeorgia] SET QUERY_STORE = OFF
GO
USE [OtherGeorgia]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [OtherGeorgia]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 26.01.2018 22:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 26.01.2018 22:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Logo] [nvarchar](50) NULL,
	[Rating] [int] NULL,
	[Email] [varchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactForm]    Script Date: 26.01.2018 22:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactForm](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varbinary](50) NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_ContactForm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Freelancer]    Script Date: 26.01.2018 22:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Freelancer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Field] [nvarchar](50) NOT NULL,
	[Rating] [int] NOT NULL,
	[Photo] [nvarchar](50) NULL,
	[Bio] [nvarchar](max) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Freelancer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Freelancer_Skill]    Script Date: 26.01.2018 22:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Freelancer_Skill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SkillID] [int] NOT NULL,
	[FreelancerID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Freelancer_Skill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Issue]    Script Date: 26.01.2018 22:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Issue](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Body] [nvarchar](50) NOT NULL,
	[AdminID] [int] NOT NULL,
	[isCompleted] [bit] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Issue] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Issue_Status]    Script Date: 26.01.2018 22:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Issue_Status](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IssueID] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
	[Dae] [datetime] NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 26.01.2018 22:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[FreelancerID] [int] NULL,
	[FreelancerRating] [int] NULL,
	[CompanyRating] [int] NULL,
	[FreelancerEvaluation] [nvarchar](max) NULL,
	[CompanyEvaluation] [nvarchar](max) NULL,
	[Progress] [int] NULL,
	[DateAdded] [datetime] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project_Status]    Script Date: 26.01.2018 22:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project_Status](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StatusID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Project_Status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 26.01.2018 22:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 26.01.2018 22:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([ID], [Name], [Description], [Logo], [Rating], [Email], [Password], [Mobile], [Date]) VALUES (1, N'საქართველოს ბანკი', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Company] ([ID], [Name], [Description], [Logo], [Rating], [Email], [Password], [Mobile], [Date]) VALUES (2, N'TBC ბანკი', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Freelancer] ON 

INSERT [dbo].[Freelancer] ([ID], [Name], [Surname], [Field], [Rating], [Photo], [Bio], [Email], [Password], [Mobile], [Date]) VALUES (1, N'ანა', N'კეკუა', N'Front End დეველოპერი', 10, NULL, N'<p><span>მე ვარ ანა კეკუა, 17 წლის. ვცხოვრობ ქალაქ ზუგდიდში. ვსწავლობ აფხაზეთის N1 საჯარო სკოლაში.</span></p><p><span>2014 წელს გავიარე &bdquo;სამშვიდობო განათლების&ldquo; 6 თვიანი ტრენინგ-კურსი და მონაწილეობა მივიღე პროექტში &bdquo;მოსწავლე ახალგაზრდობის სამშვიდობო განათლება ნდობის აღდგენისთვის&ldquo;.</span></p><p><span>2016 წელს გავიარე &bdquo;English Access Microscolarship Program&ldquo;, ინგლისურის ენის შესწავლის სასტიპენდიო პროგრამა.</span></p><p><span>2016 წელს მონაწილეობა მივიღე პროექტ &bdquo;ეტალონში&ldquo;.</span></p><p><span>2016 წელს გავიმარჯვე &bdquo;ჩემი სამყაროს&ldquo; ვიქტორინაში.</span></p><p><span>2017 წელს ვმონაწილეობდი კონკურსში &bdquo;ჩაერთე შენი ქალაქის კულტურული მემკვიდრეობის &nbsp;კვლევაში&ldquo;, სადაც ავიღე პირველი ადგილი.</span></p><p><span>მიმდინარე წელს ჩართული ვარ ჯეოლაბის პროექტში &bdquo;ვებპროგრამირების კურსი რეგიონებისათვის&ldquo;.</span></p>', NULL, NULL, NULL, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer] ([ID], [Name], [Surname], [Field], [Rating], [Photo], [Bio], [Email], [Password], [Mobile], [Date]) VALUES (2, N'ცოტნე', N'გვაჯაია', N'Front End დეველოპერი', 10, NULL, N'<p>ბიოგრაფია - დაბადების თარიღი, რიცხვი, თვე, წელი: 10/07/1990<br />ამჟამინდელი საცხოვრებელი ადგილი: ზუგდიდი<br />ტელ.: 568912248 ელ.ფოსტა:tsotne.gvajaia@gmail.com<br />IT სპეციალისტი</p><p><br />განათლება:</p><p>სასწავლებლის დასახელება: საქართველოს ტექნიკური უნივერსიტეტი&nbsp;<br />სწავლების წლები:2008-2012<br />ფაკულტეტი:ინფორმატიკისა და მართვის ავტომატიზებული სისტემები<br />ხარისხი:ბაკალავრი</p><p>&nbsp;</p><p><br />სამუშაო გამოცდილება:</p><p>1.ორგანიზაციის დასახელება: Service +<br />&nbsp; თანამდებობა: IT - სპეციალისტი<br />&nbsp; ფუნქცია-მოვალობები:ორგანიზაციებში ქსელისა და კომპიუტერების გამართვა როგორც პროგრამულად ასევე ტექნიკურადაც ..<br />&nbsp; მუშაობის პერიოდი:2012-2014<br />2.ამჟამად ვარ თვითდასაქმებული IT სფეროში (კომპიუტერებისა და სმარტფონების &nbsp;&nbsp;&nbsp;&nbsp;პროგრამული გამართვა) აგრეთვე კლინიკაში IT სპეციალისტად<br /><br /><br /><br />კვალიფიკაციის ასამაღლებელი კურსები(ტრეინინგები):<br /><br />1.ტრეინინგის დასახელება:კომპიუტერების პროგრამული და აპარატურული გამართვა<br />&nbsp; ტრეინინგის ჩატარების პერიოდი:2012-2012<br />&nbsp; ორგანიზაციის დასახელება:კომპანია SERVICE +<br />&nbsp; ტრეინინგის ჩატარების ადგილი:თბილისი<br />2. ტრეინინგის დასახელება: HTML/CSS/JAVACSRIPT/ შემსწავლელი კურსები<br />&nbsp; &nbsp;ტრეინინგის ჩატარების პერიოდი:2017 დან დღემდე<br />&nbsp; &nbsp;ორგანიზაციის დასახელება:GEOLAB<br />&nbsp; &nbsp;ტრეინინგის ჩატარების ადგილი:Tbilisi</p>', NULL, NULL, NULL, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer] ([ID], [Name], [Surname], [Field], [Rating], [Photo], [Bio], [Email], [Password], [Mobile], [Date]) VALUES (3, N'ნიკა', N'ახალაია', N'Front End დეველოპერი', 10, NULL, N'<p>ასაკი : 15<br />საცხოვრებელი ადგილი: ზუგდიდი, სოფ. დარჩელი<br />სკოლა : სოფ.დარჩელის №1 საჯარო<br />ტრენინგები: ზუგდიდში, ტექნოპარკში, Front-end 1 თვიანი კურსი.(ამ ეტაპისთვის მხოლოდ ესაა ჯეოლაბის გარდა)<br />სამომავლო გეგმები: ამ ეტაპისთვის ვაპირებ back end ის სწავლას, კერძოდ php. შემდგომში დიდი ალბათობით ვაპირებ ამ განხრით ჩაბარებას უმაღლეს სასწავლებელში.<br />&nbsp;</p>', NULL, NULL, NULL, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer] ([ID], [Name], [Surname], [Field], [Rating], [Photo], [Bio], [Email], [Password], [Mobile], [Date]) VALUES (4, N'გიორგი', N'ქოჩიაშვილი', N'Front End დეველოპერი', 10, NULL, N'<p>ვარ 15 წლის. დავიბადე ხარაგაულის რაიონის სოფელ წყალაფორეთში. ვსწავლობ ილმის საჯარო სკოლაში.</p><p>მონაწილეობა მაქვს მიღებული &ldquo;ახალგაზრდები ინოვაციური განვითარებისთვის&rdquo;. გავიმარჯვე კრეათონში ხარაგაულის ინოვაციების ცენტრში.</p><p>ამჟამად &nbsp;ვიღებ მონაწილეობას &ldquo;ვებ პროგრამირების კურსი რეგიონებისთვის&rdquo;. ასევე, ვსწავლობ პროგრამირების ენა php-ის ჯეოლაბში და გავდივარ სტაჟირებას ჯეოლაბში.</p><p>დაინტერესეული ვარ ლაშქრობებით, ნადირობით და წიგნების კითხვით.</p><p>მომავალში ვაპირებ, რომ უფრო გავიღრმაო ჩემი ცოდნა პროგრამირების მხრივ და რაღაც სერიოზული შევქმნა, რაც ხალხს დააინტერესებს.</p>', NULL, NULL, NULL, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer] ([ID], [Name], [Surname], [Field], [Rating], [Photo], [Bio], [Email], [Password], [Mobile], [Date]) VALUES (5, N'ავთანდილ', N'გაჩეჩილაძე', N'Back End დეველოპერი', 10, NULL, N'<p>ავთანდილ გაჩეჩილაძე (themarshall)<br />17 წლის<br />საცხოვრებელი ადგილი: &nbsp;ბაღდათი<br />როხის საჯარო სკოლის მოსწავლე..(2006-...)<br />ონლაინ კურსები ქოდაქადემიზე Front End-ის განხრით..</p><p>ჯეოლაბის Back End-ის პროგრამირების კურსი..</p><p>არასამთავრობო ორგანიზაცია youth2georgia-სთან ერთად გავლილი მაქვს ფოტო და ვიდეო გადაღების, ადვოკატირებისა და ლიდერობის ტრენინგები..<br />არდუინოს პროგრამირების კურსსაც გავდივარ და გეგმაში გვაქვს რობოტის შექმნა ბაღდათის ინოვაციების ცენტრში..<br />მომავალში ვაპირებ სწავლის გაგრძელებას პროგრამირების განხრით, როგორც უნივერსიტეტში, ისე მის გარეთ..<br />&nbsp;</p>', NULL, NULL, NULL, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer] ([ID], [Name], [Surname], [Field], [Rating], [Photo], [Bio], [Email], [Password], [Mobile], [Date]) VALUES (6, N'გიგა', N'ლაფანაშვილი', N'Back End დეველოპერი', 10, NULL, N'<p>ვარ 17 წლის, &nbsp;ვცხოვრობ დუშეთის რაიონის სოფელ ჭოპორტში.</p><p>ამჟამად ვსწავლობ ჭოპორტის საჯარო სკოლის მე-12 კლასში და გავდივარ ჯეოლაბის ვებპროგრამირების კურსს. ასევე, გავლილი მაქვს გაცნობითი ტრენინგი კომპიუტრულ პროგრამირებაში, გრაფიკულ დიზაინსა და სოციალურ მედიასთან დაკავშირებით.</p><p>ვმონაწილეობდი მათემატიკისა და სამოქალაქო განათლების ოლიმპიადებში, მაქვს სიგელები, ვიყავი &bdquo;ინტელექტ- ჩემპიონატ ეტალონის&ldquo; რეგიონალური ფინალური ტურების მონაწილე და პრიზიორი, აგრეთვე ავიღე პირველი ადგილი საქართველოს პარლამენტის ეროვნული ბიბლიოთეკის მიერ ჩატარებულ ინტელექტუალურ თამაშში &bdquo;ჩვენი მკითხველი&ldquo;.</p><p>დაინტერესებული ვარ მიკროელექტროობითა და კომპიუტერული მეცნიერებებით, ვაპირებ ამავე მიმართულებით გავაგრძელო სწავლა უნივერსიტეტში.<br />&nbsp;</p>', NULL, NULL, NULL, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer] ([ID], [Name], [Surname], [Field], [Rating], [Photo], [Bio], [Email], [Password], [Mobile], [Date]) VALUES (7, N'ზვიად', N'ჭანტურია', N'Back End დეველოპერი', 10, NULL, N'<p>ვცხოვრობ ქალაქ თბილისში. ვარ 24 წლის.</p><p>ვსწავლობდი &nbsp;შოთა რუსთაველის სახელმწიფო უნივერსიტეტში ფიზიკა-მათემატიკის და კომპიუტერული მეცნიერებების ფაკულტეტზე 2012-17 წლებში.</p><p>გავლილი მაქვს IT პროექტების მენეჯერის ტრენინგი.</p><p>ამჟამად ვსწავლობ ჯეოლაბში ვებპროგრამირებას და ვმუშაობ ლივინგსტონში ვებდეველოპერად.</p>', NULL, NULL, NULL, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer] ([ID], [Name], [Surname], [Field], [Rating], [Photo], [Bio], [Email], [Password], [Mobile], [Date]) VALUES (8, N'ცოტნე', N'გუჩუა', N'Back End დეველოპერი', 10, NULL, N'<p>ვარ 18 წლის, ვცხოვრობ ქალაქ ხობში, ამჟამად კი თბილისში.</p><p>დავამთავრე სსიპ ქ. ხობის #2 საჯარო სკოლა (2005-2017).</p><p>ჩავაბარე - &nbsp;თბილისის სახელმწიფო სამედიცინო უნივერსიტეტში, მედიცინის ფაკულტეტზე (2017).</p><p>ვიღებდი მონაწილეობას სახელმწიფო ოლიმპიადებში და პროექტებში: &ldquo;ალიანტე&ldquo;, &nbsp;&bdquo;წიგნების თარო&ldquo;(სატელევიზიო შოუ).</p><p>მაინტერესებს კომპიუტერული მეცნიერებები და მედიცინა.</p><p>მსურს, საფუძვლიანად შევისწავლო კომპ. მეცნიერერები და შევძლო ამ სფეროს განვითარებაში წვლილის შეტანა.</p>', NULL, NULL, NULL, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Freelancer] OFF
SET IDENTITY_INSERT [dbo].[Freelancer_Skill] ON 

INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (1, 1, 1, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (2, 2, 1, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (3, 3, 1, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (4, 4, 1, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (5, 5, 1, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (6, 1, 2, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (7, 2, 2, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (8, 3, 2, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (9, 4, 2, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (10, 5, 2, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (11, 1, 3, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (12, 2, 3, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (13, 3, 3, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (14, 4, 3, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (15, 5, 3, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (16, 6, 3, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (17, 1, 4, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (18, 2, 4, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (19, 3, 4, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (20, 4, 4, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (21, 5, 4, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (22, 6, 4, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (23, 1, 5, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (24, 2, 5, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (25, 7, 5, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (26, 8, 5, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (27, 9, 5, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (28, 7, 6, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (29, 8, 6, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (30, 9, 6, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (31, 7, 7, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (32, 8, 7, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (33, 9, 7, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (34, 10, 7, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (35, 7, 8, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (36, 8, 8, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Freelancer_Skill] ([ID], [SkillID], [FreelancerID], [Date]) VALUES (37, 9, 8, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Freelancer_Skill] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([ID], [Name], [Description], [CompanyID], [StartDate], [EndDate], [FreelancerID], [FreelancerRating], [CompanyRating], [FreelancerEvaluation], [CompanyEvaluation], [Progress], [DateAdded]) VALUES (2, N'tsnuli.ge', N'სოციალური საწარმო „წნული“ შეიქმნა კასპის შშმ პირთა კავშირის მიერ, საქართველოს ბანკის ფონდ „ სიცოცხლის ხის“ დაფინანსებით. 2016 წელს ფონდ „ სიცოცხლის ხის“ მიერ გამოცხადებულ სოციალური მეწარმეობის მხარდამჭერ კონკურსში კასპის შშმ პირთა კავშირის მიერ წარმოდგენილმა პროექტმა, ქ. კასპში მცხოვრებ შეზღუდული შესაძლებლობების მქონე პირთა შინ დასაქმების ქსელის შექმნასთან დაკავშირებით, 154 საკონკურსო პროექტს შორის გაიმარჯვა, მოიპოვა გრანტი და შექმნა სოციალური საწარმო.', 1, NULL, NULL, 1, 10, NULL, NULL, NULL, NULL, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Project] ([ID], [Name], [Description], [CompanyID], [StartDate], [EndDate], [FreelancerID], [FreelancerRating], [CompanyRating], [FreelancerEvaluation], [CompanyEvaluation], [Progress], [DateAdded]) VALUES (3, N'gaakartule.ge', N'კომპიუტერული ტექნოლოგიები ადამიანის საქმიანობის ყველა სფეროს განუყოფელი ნაწილი გახდა. სხვადასხვა ქვეყნებში აქტიურად მიმდინარეობს კომპიუტერული პროგრამებისა და მათი ინტერფეისების ლოკალურ ენებზე ადაპტირება. თუკი ის აპლიკაციები, და პროგრამები რომლებსაც მომავალში სასწავლო პროცესის მიმდინარეობისას და მუშაობისას გამოვიყენებთ არ იქნება ქართულ ენაზე თარგმნილი, ადაპტირებული მაშინ ქართული ენა დაკარგავს აქტუალობას და მისი მნიშვნელობა, გამოყენების არეალი კიდევ უფრო შემცირდება. ამგვარად აუცილებელია ქართული ენის კომპიუტერულ პროგრამებში ინტეგრირება.ეს პროექტი ამ მიმართულებით ერთ-ერთი პატარა ნაბიჯია. პროექტის ფარგლებში, თქვენი დახმარებით თარგმნილი, ქართული წინადადებები ჩაიტვირთება Microsoft-ის მიერ შექმნილ მანქანური სწავლის (Machine Learning) პლათფორმაში. მას შემდეგ რაც პლათფორმა მიღებულ ინფორმაციას გაანალიზებს, “შეისწავლის ქართულს” მივიღებთ პროგრამას, რომელსაც შეეძლება ქართული ტექსტის ინგლისურად თარგმნა და ინგლისური ტექსტის ქართულად თარგმნა. მართალია ქართული ენა უკვე წარმოდგენილია Microsoft-ის ზოგიერთ პროდუქტში, მაგრამ მთარგმნელობითი პროგრამა იქნება პირველი ნაბიჯი Microsoft-ის სხვადასხვა პროგრამებში, მათ შორის Windows ოპერაციულ სისტემაში ქართული ენის მთარგმნელობითი ფუნქციონალის სრულფასოვანი ინტეგრაციისაკენ. პროექტის წარატებით განხორციელება შესაძლებელს გახდის Microsoft-ის უამრავ პროგრამულ პროდუქტში ქართულ ინგლისური მთარგმნელობითი პროგრამის გამოყენებას. ამის გარდა, ვებ დეველოპერებს და იმ პროგრამისტებს რომლებიც Windows სისტემისათვის შექმნიან თავიანთ პროგრამულ პროდუქტს საშუალება ექნებათ გამოიყენონ, ავტომატურად მიაბან ჩვენი ძალიასხმევით შექმნილი ავტომატური თარგმნის პროგრამა.', 2, NULL, NULL, 1, 10, NULL, NULL, NULL, NULL, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Project] ([ID], [Name], [Description], [CompanyID], [StartDate], [EndDate], [FreelancerID], [FreelancerRating], [CompanyRating], [FreelancerEvaluation], [CompanyEvaluation], [Progress], [DateAdded]) VALUES (4, N'blackseahostel.ge', N'სოციალური საწარმო Black Sea Hostel შეიქმნა ა(ა)იპ ''აჭარის ახალგაზრდული უმაღლესი საბჭოს'''' მიერ, საქართველოს ბანკის ფონდ „სიცოცხლის ხის“ დაფინანსებით. 2016 წელს ფონდ „ სიცოცხლის ხის“ მიერ გამოცხადებულ სოციალური მეწარმეობის მხარდამჭერ კონკურსში ''აჭარის ახალგაზრდული უმაღლესი საბჭოს'''' მიერ, წარმოდგენილ პროექტმა, აჭარაში, კერძოდ ბათუმში ადაპტირებული ჰოსტელის შექმნის თაობაზე, 154 საკონკურსო პროექტს შორის გაიმარჯვა, მოიპოვა გრანტი და შექმნა სოციალური საწარმო. საწარმოს მისია და და მიზანი საწარმოს სოციალური მისიაა აჭარის ახალგაზრდების განათლების ხელშეწყობა. Black Sea Hostel-ის მიზანია ინკლუზიური ტურიზმის განვითარება და ყველასათვის თანაბრად ხელმისაწვდომი გარემოს შექმნა. Black Sea Hostel შეიქმნა იმისათვის, რომ მომხმარებელს ფასის და ფიზიკური სივრცის თვალსაზრისით ხელმისაწვდომი და კომფორტული სერვისი შესთავაზოს. სოციალური საწარმოს ახალგაზრდებისაგან დაკომპლექტებულმა გუნდმა შექმნა სივრცე, სადაც კომფორტული სამუშაო გარემოა შეზღუდული შესაძლებლობების მქონე პირებისთვისაც და სულ დასაქმებულია 6 ადამიანი.', 1, NULL, NULL, 4, 10, NULL, NULL, NULL, NULL, CAST(N'2018-01-22T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[Skill] ON 

INSERT [dbo].[Skill] ([ID], [Name], [Date]) VALUES (1, N'HTML', CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Skill] ([ID], [Name], [Date]) VALUES (2, N'CSS', CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Skill] ([ID], [Name], [Date]) VALUES (3, N'JavaScript', CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Skill] ([ID], [Name], [Date]) VALUES (4, N'jQuery', CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Skill] ([ID], [Name], [Date]) VALUES (5, N'Bootstrap', CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Skill] ([ID], [Name], [Date]) VALUES (6, N'WordPress', CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Skill] ([ID], [Name], [Date]) VALUES (7, N'C#', CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Skill] ([ID], [Name], [Date]) VALUES (8, N'ASP .NET MVC', CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Skill] ([ID], [Name], [Date]) VALUES (9, N'MS SQL', CAST(N'2018-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Skill] ([ID], [Name], [Date]) VALUES (10, N'Unity', CAST(N'2018-01-22T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Skill] OFF
ALTER TABLE [dbo].[Freelancer_Skill]  WITH CHECK ADD  CONSTRAINT [FK_Freelancer_Skill_Freelancer] FOREIGN KEY([FreelancerID])
REFERENCES [dbo].[Freelancer] ([ID])
GO
ALTER TABLE [dbo].[Freelancer_Skill] CHECK CONSTRAINT [FK_Freelancer_Skill_Freelancer]
GO
ALTER TABLE [dbo].[Freelancer_Skill]  WITH CHECK ADD  CONSTRAINT [FK_Freelancer_Skill_Skill] FOREIGN KEY([SkillID])
REFERENCES [dbo].[Skill] ([ID])
GO
ALTER TABLE [dbo].[Freelancer_Skill] CHECK CONSTRAINT [FK_Freelancer_Skill_Skill]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_Admin] FOREIGN KEY([AdminID])
REFERENCES [dbo].[Admin] ([ID])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_Admin]
GO
ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ID])
GO
ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_Project]
GO
ALTER TABLE [dbo].[Issue_Status]  WITH CHECK ADD  CONSTRAINT [FK_Issue_Status_Issue] FOREIGN KEY([IssueID])
REFERENCES [dbo].[Issue] ([ID])
GO
ALTER TABLE [dbo].[Issue_Status] CHECK CONSTRAINT [FK_Issue_Status_Issue]
GO
ALTER TABLE [dbo].[Issue_Status]  WITH CHECK ADD  CONSTRAINT [FK_Issue_Status_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([ID])
GO
ALTER TABLE [dbo].[Issue_Status] CHECK CONSTRAINT [FK_Issue_Status_Status]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([ID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Company]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Freelancer] FOREIGN KEY([FreelancerID])
REFERENCES [dbo].[Freelancer] ([ID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Freelancer]
GO
ALTER TABLE [dbo].[Project_Status]  WITH CHECK ADD  CONSTRAINT [FK_Project_Status_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ID])
GO
ALTER TABLE [dbo].[Project_Status] CHECK CONSTRAINT [FK_Project_Status_Project]
GO
ALTER TABLE [dbo].[Project_Status]  WITH CHECK ADD  CONSTRAINT [FK_Project_Status_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([ID])
GO
ALTER TABLE [dbo].[Project_Status] CHECK CONSTRAINT [FK_Project_Status_Status]
GO
USE [master]
GO
ALTER DATABASE [OtherGeorgia] SET  READ_WRITE 
GO
