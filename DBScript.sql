/****** Object:  Table [dbo].[CodeLookup]    Script Date: 01/05/2014 11:49:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CodeLookup](
	[CodeLookupId] [int] NOT NULL,
	[CodeDesc] [varchar](500) NOT NULL,
	[ShortDesc] [varchar](50) NULL,
	[ParentCodeLookupId] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [nchar](10) NULL,
 CONSTRAINT [PK_CodeLookupId] PRIMARY KEY CLUSTERED 
(
	[CodeLookupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Subject]    Script Date: 01/05/2014 11:49:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Subject](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectDesc] [varchar](50) NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Course]    Script Date: 01/05/2014 11:49:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](100) NOT NULL,
	[CourseFieldId] [int] NOT NULL,
	[DegreeTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Users]    Script Date: 01/05/2014 11:48:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Gender] [int] NULL,
	[UserTypeID] [int] NULL,
	[HomeTown] [varchar](100) NULL,
	[ZipCode] [varchar](10) NULL,
	[BirthDate] [datetime] NULL,
	[MobileNo] [varchar](10) NULL,
	[AboutUser] [varchar](500) NULL,
	[UserPhoto] [varchar](100) NULL,
	[LanguagesSpoken] [xml] NULL,
	[IsUserVerified] [bit] NULL,
	[VerifiedBy] [int] NULL,
	[FieldOfInterest] [xml] NULL,
	[UserLoginID] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[UserLogin]    Script Date: 01/05/2014 11:48:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UserLogin](
	[UserLoginID] [int] IDENTITY(1,1) NOT NULL,
	[EmailAddress] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[IsFacebookLogin] [bit] NULL,
	[IsActive] [bit] NULL,
	[FBUserID] [varchar](50) NULL,
	[IsEmailVerified] [bit] NULL,
	[VerificationCode] [varchar](100) NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserLoginID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[UserFBDetails]    Script Date: 01/05/2014 11:48:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserFBDetails](
	[UserFBDetailId] [int] IDENTITY(1,1) NOT NULL,
	[UserLoginId] [int] NOT NULL,
	[FBData] [xml] NULL,
 CONSTRAINT [PK_UserFBDetails] PRIMARY KEY CLUSTERED 
(
	[UserFBDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[UserEducationDetails]    Script Date: 01/05/2014 11:48:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UserEducationDetails](
	[UserEducationDetailId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CollegeId] [int] NOT NULL,
	[PassingYear] [varchar](50) NOT NULL,
	[DegreeTypeId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[InstituitionTypeId] [int] NOT NULL,
	[SchoolName] [varchar](100) NULL,
 CONSTRAINT [PK_UserEducationDetails] PRIMARY KEY CLUSTERED 
(
	[UserEducationDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Table [College].[College]    Script Date: 01/17/2014 21:32:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[College](
	[CollegeId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeName] [varchar](100) NOT NULL,
	[CollegeLogo] [varchar](50) NULL,
	[CollegeDesc] [varchar](1000) NULL,
	[EstablishedYear] [varchar](10) NULL,
	[Address1] [varchar](100) NULL,
	[Address2] [varchar](100) NULL,
	[CityId] [int] NOT NULL,
	[StateId] [int] NULL,
	[CountryId] [int] NOT NULL,
	[PinCode] [varchar](15) NULL,
	[Longitude] [varchar](20) NULL,
	[Latitude] [varchar](20) NULL,
	[Phone] [varchar](20) NULL,
	[EmailAddress] [varchar](50) NULL,
	[TransportDetail] [varchar](150) NULL,
	[NotifEmailToCollege] [varchar](50) NULL,
	[SportsAvailable] [bit] NOT NULL,
	[WebSiteURL] [varchar](100) NULL,
	[Accreditation] [varchar](100) NULL,
	[NoOfStudents] [int] NULL,
	[CollegeTypeId] [int] NOT NULL,
	[StudentTypeId] [int] NOT NULL,
	[AffiliatedToId] [int] NULL,
	[IsAccomodation] [bit] NOT NULL,
	[AccomodationTypeId] [int] NULL,
	[Activities] [varchar](500) NULL,
	[ProspectusLink] [varchar](50) NULL,
	[AcademicSessionId] [int] NULL,
	[CampusInfrastructure] [varchar](1000) NULL,
	[SubmittedById] [int] NULL,
	[ViewCount] [bigint] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_College] PRIMARY KEY CLUSTERED 
(
	[CollegeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO