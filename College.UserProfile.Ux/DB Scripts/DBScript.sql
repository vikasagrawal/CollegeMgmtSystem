
/****** Object:  Schema [College]    Script Date: 01/20/2014 13:05:42 ******/
CREATE SCHEMA [College] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Globalization]    Script Date: 01/20/2014 13:05:42 ******/
CREATE SCHEMA [Globalization] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Logging]    Script Date: 01/20/2014 13:05:42 ******/
CREATE SCHEMA [Logging] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Lookup]    Script Date: 01/20/2014 13:05:42 ******/
CREATE SCHEMA [Lookup] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Master]    Script Date: 01/20/2014 13:05:42 ******/
CREATE SCHEMA [Master] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Security]    Script Date: 01/20/2014 13:05:42 ******/
CREATE SCHEMA [Security] AUTHORIZATION [dbo]
GO
/****** Object:  Table [dbo].[UserShortlistedColleges]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserShortlistedColleges](
	[UserShortlistedCollegeId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CollegeId] [int] NOT NULL,
 CONSTRAINT [PK_UserShortlistedColleges] PRIMARY KEY CLUSTERED 
(
	[UserShortlistedCollegeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Security].[Users]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Security].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserLoginID] [int] NOT NULL,
	[Prefix] [int] NULL,
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
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Security].[UserLogin]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Security].[UserLogin](
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
/****** Object:  Table [Security].[UserFBDetails]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Security].[UserFBDetails](
	[UserFBDetailId] [int] IDENTITY(1,1) NOT NULL,
	[UserLoginId] [int] NOT NULL,
	[FBData] [xml] NULL,
 CONSTRAINT [PK_UserFBDetails] PRIMARY KEY CLUSTERED 
(
	[UserFBDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserEducationDetails]    Script Date: 01/20/2014 13:05:43 ******/
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
/****** Object:  Table [Master].[Subject]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Master].[Subject](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectDesc] [varchar](50) NOT NULL,
	[CourseID] [int] NULL,	 
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Master].[State]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Master].[State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Master].[PlacementCompany]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Master].[PlacementCompany](
	[PlacementCompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[CompanyLogo] [varchar](100) NOT NULL,
 CONSTRAINT [PK_PlacementCompany] PRIMARY KEY CLUSTERED 
(
	[PlacementCompanyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[NotificationId] [int] IDENTITY(1,1) NOT NULL,
	[NotificationTypeId] [int] NOT NULL,
	[ToUserId] [int] NOT NULL,
	[IsNew] [bit] NOT NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Master].[Facility]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Master].[Facility](
	[FacilityId] [int] IDENTITY(1,1) NOT NULL,
	[FacilityName] [varchar](50) NOT NULL,
	[FacilityIcon] [varchar](100) NULL,
 CONSTRAINT [PK_Facility] PRIMARY KEY CLUSTERED 
(
	[FacilityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExpertReview]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ExpertReview](
	[ExpertReviewId] [int] IDENTITY(1,1) NOT NULL,
	[ExpertId] [int] NOT NULL,
	[CollegeCourseId] [int] NOT NULL,
	[ReviewTitle] [varchar](100) NOT NULL,
	[ReviewInDetail] [varchar](5000) NOT NULL,
	[Rating] [int] NOT NULL,
 CONSTRAINT [PK_ExpertReview] PRIMARY KEY CLUSTERED 
(
	[ExpertReviewId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Master].[Expert]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Master].[Expert](
	[ExpertId] [int] IDENTITY(1,1) NOT NULL,
	[ExpertName] [varchar](50) NOT NULL,
	[ExpertPhoto] [varchar](50) NULL,
	[ExpertDesc] [varchar](1000) NULL,
 CONSTRAINT [PK_Expert] PRIMARY KEY CLUSTERED 
(
	[ExpertId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Logging].[ErrorLog]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Logging].[ErrorLog](
	[ErrorLogId] [bigint] IDENTITY(1,1) NOT NULL,
	[ErrorNumber] [bigint] NULL,
	[ErrorSeverity] [int] NULL,
	[ErrorState] [int] NULL,
	[ErrorProcedure] [varchar](250) NULL,
	[ErrorLine] [int] NULL,
	[ErrorMessage] [varchar](max) NULL,
	[ErrorDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[ErrorLogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Master].[Course]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Master].[Course](
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
/****** Object:  Table [Master].[Country]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Master].[Country](
	[CountryId] [int] NOT NULL,
	[CountryName] [varchar](50) NOT NULL,
	[CountryCode] [char](2) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [College].[CollegePhotos]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [College].[CollegePhotos](
	[CollegePhotoId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeId] [int] NOT NULL,
	[ImageURL] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CollegePhotos] PRIMARY KEY CLUSTERED 
(
	[CollegePhotoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [College].[CollegeFamousAlumni]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [College].[CollegeFamousAlumni](
	[CollegeFamousAlumniId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeId] [int] NOT NULL,
	[AlumniName] [varchar](50) NOT NULL,
	[AlumniDesc] [varchar](1000) NOT NULL,
	[AlumniPhoto] [varchar](50) NOT NULL,
	[AlumniLink] [varchar](100) NULL,
 CONSTRAINT [PK_CollegeFamousAlumni] PRIMARY KEY CLUSTERED 
(
	[CollegeFamousAlumniId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [College].[CollegeFacility]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeFacility](
	[CollegeFacilityId] [int] IDENTITY(1,1) NOT NULL,
	[FacilityId] [int] NOT NULL,
	[CollegeId] [int] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
 CONSTRAINT [PK_CollegeFacility] PRIMARY KEY CLUSTERED 
(
	[CollegeFacilityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [UK_CollegeFacility] ON [College].[CollegeFacility] 
(
	[CollegeId] ASC,
	[FacilityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseTimeLine]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [College].[CollegeCourseTimeLine](
	[CollegeCourseTimeLineId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseId] [int] NOT NULL,
	[EntranceDate] [date] NULL,
	[ApplicationDate] [date] NULL,
	[Campus] [varchar](500) NULL,
	[Scholarship] [varchar](500) NULL,
 CONSTRAINT [PK_CollegeCourseTimeLine] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseTimeLineId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [College].[CollegeCourseSeats]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseSeats](
	[CollegeCourseSeatId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseId] [int] NOT NULL,
	[StudentCategoryId] [int] NOT NULL,
	[TotalSeats] [int] NOT NULL,
 CONSTRAINT [PK_CollegeCourseSeats] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseSeatId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseSameQuestion]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseSameQuestion](
	[CollegeCourseSameQuestionId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseQuestionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CollegeCourseSameQuestion] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseSameQuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseReviewDetailSubscribe]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseReviewDetailSubscribe](
	[CollegeCourseReviewDetailSubscribeId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseReviewDetailId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CollegeCourseReviewDetailSubscribe] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseReviewDetailSubscribeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseReviewDetailSpam]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseReviewDetailSpam](
	[CollegeCourseReviewDetailSpamId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseReviewDetailId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsReviewed] [bit] NOT NULL,
 CONSTRAINT [PK_CollegeCourseReviewDetailSpam] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseReviewDetailSpamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseReviewDetailShare]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseReviewDetailShare](
	[CollegeCourseReviewDetailShareId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseReviewDetailId] [int] NOT NULL,
	[SharingMediaId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_CollegeCourseReviewDetailShare] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseReviewDetailShareId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseReviewDetails]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [College].[CollegeCourseReviewDetails](
	[CollegeCourseReviewDetailId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseReviewId] [int] NOT NULL,
	[ReviewCategoryId] [int] NOT NULL,
	[ReviewTitle] [varchar](200) NULL,
	[GreatDesc] [varchar](5000) NULL,
	[NotGreatDesc] [varchar](5000) NULL,
	[WhyDesc] [varchar](5000) NULL,
	[Rating] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Action] [char](1) NULL,
 CONSTRAINT [PK_CollegeCourseReviewDetails] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseReviewDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [College].[CollegeCourseReviewDetailLike]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseReviewDetailLike](
	[CollegeCourseReviewDetailLikeId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseReviewDetailId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CollegeCourseReviewDetailLike] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseReviewDetailLikeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseReviewDetailCommentSpam]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseReviewDetailCommentSpam](
	[CollegeCourseReviewDetailCommentSpamId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseReviewDetailCommentId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsReviewed] [bit] NOT NULL,
 CONSTRAINT [PK_CollegeCourseReviewDetailCommentSpam] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseReviewDetailCommentSpamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseReviewDetailComments]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [College].[CollegeCourseReviewDetailComments](
	[CollegeCourseReviewDetailCommentId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseReviewDetailId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Comment] [varchar](500) NOT NULL,
	[ParentReviewCommentId] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[Action] [char](1) NULL,
 CONSTRAINT [PK_CollegeCourseReviewDetailComments] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseReviewDetailCommentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [College].[CollegeCourseReview]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [College].[CollegeCourseReview](
	[CollegeCourseReviewId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ReviewDate] [datetime] NOT NULL,
	[CollegeCourseId] [int] NOT NULL,
	[IsAnonymousUser] [bit] NOT NULL,
	[NickName] [varchar](50) NULL,
	[AvatarImage] [varchar](50) NULL,
	[IsCompleted] [bit] NOT NULL,
 CONSTRAINT [PK_CollegeCourseReview] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseReviewId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [College].[CollegeCourseQuestionSpam]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseQuestionSpam](
	[CollegeCourseQuestionSpamId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseQuestionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsReviewed] [bit] NOT NULL,
 CONSTRAINT [PK_CollegeCourseQuestionSpam] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseQuestionSpamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseQuestionShare]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseQuestionShare](
	[CollegeCourseQuestionShareId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseQuestionId] [int] NOT NULL,
	[SharingMediaId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_CollegeCourseQuestionShare] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseQuestionShareId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseQuestionLike]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseQuestionLike](
	[CollegeCourseQuestionLikeId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseQuestionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CollegeCourseQuestionLike] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseQuestionLikeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseQuestionAnswerSpam]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseQuestionAnswerSpam](
	[CollegeCourseQuestionAnswerSpamId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseQuestionAnswerId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsReviewed] [bit] NOT NULL,
 CONSTRAINT [PK_CollegeCourseQuestionAnswerSpam] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseQuestionAnswerSpamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseQuestionAnswerLike]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseQuestionAnswerLike](
	[CollegeCourseQuestionAnswerLikeId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseQuestionAnswerId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CollegeCourseQuestionAnswerLike] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseQuestionAnswerLikeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseQuestionAnswer]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [College].[CollegeCourseQuestionAnswer](
	[CollegeCourseQuestionAnswerId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseQuestionId] [int] NOT NULL,
	[Description] [varchar](1000) NOT NULL,
	[UserId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Action] [char](1) NOT NULL,
 CONSTRAINT [PK_CollegeCourseQuestionAnswer] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseQuestionAnswerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [College].[CollegeCourseQuestion]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [College].[CollegeCourseQuestion](
	[CollegeCourseQuestionId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Question] [varchar](200) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Action] [char](1) NOT NULL,
 CONSTRAINT [PK_CollegeCourseQuestion] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseQuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [College].[CollegeCoursePlacements]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [College].[CollegeCoursePlacements](
	[CollegeCoursePlacementId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseId] [int] NOT NULL,
	[NumberOfStudentsPlaced] [int] NULL,
	[PercentOfStudentsPlaced] [decimal](5, 2) NULL,
	[PlacementDesc] [varchar](1000) NULL,
	[CompanyList] [xml] NOT NULL,
	[HighestPackage] [decimal](10, 0) NULL,
	[AvgSalaryReceived] [decimal](10, 0) NULL,
 CONSTRAINT [PK_CollegeCoursePlacements] PRIMARY KEY CLUSTERED 
(
	[CollegeCoursePlacementId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [College].[CollegeCourseFee]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseFee](
	[CollegeCourseFeeId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseId] [int] NOT NULL,
	[StudentCategoryId] [int] NOT NULL,
	[TotalFee] [int] NOT NULL,
 CONSTRAINT [PK_CollegeCourseFee] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseFeeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseEligibility]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [College].[CollegeCourseEligibility](
	[CollegeCourseEligibilityId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseId] [int] NOT NULL,
	[StudentCategoryId] [int] NOT NULL,
	[Percentage] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_CollegeCourseEligibility] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseEligibilityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [College].[CollegeCourseApplProcess]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [College].[CollegeCourseApplProcess](
	[CollegeCourseApplProcessId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeCourseId] [int] NOT NULL,
	[ExtranceExams] [xml] NOT NULL,
	[Description] [varchar](500) NULL,
	[Syllabus] [varchar](max) NULL,
 CONSTRAINT [PK_CollegeCourseApplProcess] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseApplProcessId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [College].[CollegeCourse]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [College].[CollegeCourse](
	[CollegeCourseId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[SubjectId] [int] NULL,
	[TimingId] [int] NOT NULL,
	[Duration] [varchar](10) NOT NULL,
	[TotalFee] [int] NULL,
	[TotalSeats] [int] NULL,
	[EligibilityDesc] [varchar](1000) NOT NULL,
	[Accreditation] [varchar](100) NULL,
	[IsPlacementDone] [bit] NOT NULL,
 CONSTRAINT [PK_CollegeCourse] PRIMARY KEY CLUSTERED 
(
	[CollegeCourseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [College].[CollegeClaimDetails]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [College].[CollegeClaimDetails](
	[CollegeClaimDetailId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[EmailAddress] [varchar](50) NOT NULL,
	[MobileNo] [varchar](20) NOT NULL,
 CONSTRAINT [PK_CollegeClaimDetails] PRIMARY KEY CLUSTERED 
(
	[CollegeClaimDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [College].[College]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [College].[College](
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
CREATE UNIQUE NONCLUSTERED INDEX [UK_CollegeName] ON [College].[College] 
(
	[CollegeName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [Lookup].[CodeLookup]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Lookup].[CodeLookup](
	[CodeLookupId] [int] NOT NULL,
	[CodeDesc] [varchar](500) NOT NULL,
	[ShortDesc] [varchar](50) NULL,
	[ParentCodeLookupId] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [nchar](10) NULL,
 CONSTRAINT [PK_CodeLookup] PRIMARY KEY CLUSTERED 
(
	[CodeLookupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Master].[City]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Master].[City](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](50) NOT NULL,
	[IsMetroCity] [bit] NULL,
	[CityURL] [varchar](150) NULL,
	[StateId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Master].[Affiliation]    Script Date: 01/20/2014 13:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Master].[Affiliation](
	[AffiliatedToId] [int] IDENTITY(1,1) NOT NULL,
	[AffiliatedTo] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Affiliation] PRIMARY KEY CLUSTERED 
(
	[AffiliatedToId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
