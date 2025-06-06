if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_JobHistory_Job]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[JobHistory] DROP CONSTRAINT FK_JobHistory_Job
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Subscription_SubscriptionSchedule]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Job] DROP CONSTRAINT FK_Subscription_SubscriptionSchedule
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ScheduleDay_Schedule]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ScheduleDay] DROP CONSTRAINT FK_ScheduleDay_Schedule
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ScheduleMonth_Schedule]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ScheduleMonth] DROP CONSTRAINT FK_ScheduleMonth_Schedule
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ScheduleWeek_Schedule]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ScheduleWeek] DROP CONSTRAINT FK_ScheduleWeek_Schedule
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Job]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Job]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JobHistory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[JobHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Schedule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Schedule]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ScheduleDay]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ScheduleDay]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ScheduleMonth]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ScheduleMonth]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ScheduleWeek]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ScheduleWeek]
GO

CREATE TABLE [dbo].[Job] (
	[JobId] [int] IDENTITY (1, 1) NOT NULL ,
	[JobName] [varchar] (50) NOT NULL ,
	[JobType] [int] NOT NULL ,
	[ScheduleId] [int] NULL ,
	[CommandText] [text] NULL ,
	[LastRunTime] [datetime] NULL ,
	[LastStatus] [varchar] (250) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[JobHistory] (
	[HistoryId] [int] IDENTITY (1, 1) NOT NULL ,
	[JobId] [int] NOT NULL ,
	[StartTime] [datetime] NOT NULL ,
	[EndTime] [datetime] NULL ,
	[Status] [varchar] (10) NULL ,
	[ReturnText] [text] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Schedule] (
	[ScheduleId] [int] IDENTITY (1, 1) NOT NULL ,
	[ScheduleName] [varchar] (50) NOT NULL ,
	[IsPublic] [bit] NOT NULL ,
	[ScheduleType] [varchar] (20) NOT NULL ,
	[StartDate] [smalldatetime] NULL ,
	[EndDate] [smalldatetime] NULL ,
	[StartHour] [smallint] NULL ,
	[StartMin] [smallint] NULL ,
	[EveryHour] [int] NULL ,
	[EveryMinute] [smallint] NULL ,
	[WeekOfMonth] [char] (1) NULL ,
	[RepeatDays] [int] NULL ,
	[RepeatWeeks] [smallint] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ScheduleDay] (
	[ScheduleId] [int] NOT NULL ,
	[DayId] [smallint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ScheduleMonth] (
	[ScheduleId] [int] NOT NULL ,
	[MonthId] [smallint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ScheduleWeek] (
	[ScheduleId] [int] NOT NULL ,
	[WeekDayId] [smallint] NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Job] ADD 
	CONSTRAINT [DF_Job_JobType] DEFAULT (1) FOR [JobType],
	CONSTRAINT [PK_Job] PRIMARY KEY  CLUSTERED 
	(
		[JobId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[JobHistory] ADD 
	CONSTRAINT [DF_JobHistory_StartTime] DEFAULT (getdate()) FOR [StartTime],
	CONSTRAINT [PK_JobHistory] PRIMARY KEY  CLUSTERED 
	(
		[HistoryId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Schedule] ADD 
	CONSTRAINT [DF_Schedule_IsPublic] DEFAULT (1) FOR [IsPublic],
	CONSTRAINT [DF_SubscriptionSchedule_ScheduleType] DEFAULT ('D') FOR [ScheduleType],
	CONSTRAINT [PK_Schedule] PRIMARY KEY  CLUSTERED 
	(
		[ScheduleId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ScheduleDay] ADD 
	CONSTRAINT [PK_ScheduleDay] PRIMARY KEY  CLUSTERED 
	(
		[ScheduleId],
		[DayId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ScheduleMonth] ADD 
	CONSTRAINT [PK_ScheduleMonth] PRIMARY KEY  CLUSTERED 
	(
		[ScheduleId],
		[MonthId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ScheduleWeek] ADD 
	CONSTRAINT [PK_ScheduleWeek] PRIMARY KEY  CLUSTERED 
	(
		[ScheduleId],
		[WeekDayId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Job] ADD 
	CONSTRAINT [FK_Subscription_SubscriptionSchedule] FOREIGN KEY 
	(
		[ScheduleId]
	) REFERENCES [dbo].[Schedule] (
		[ScheduleId]
	)
GO

ALTER TABLE [dbo].[JobHistory] ADD 
	CONSTRAINT [FK_JobHistory_Job] FOREIGN KEY 
	(
		[JobId]
	) REFERENCES [dbo].[Job] (
		[JobId]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[ScheduleDay] ADD 
	CONSTRAINT [FK_ScheduleDay_Schedule] FOREIGN KEY 
	(
		[ScheduleId]
	) REFERENCES [dbo].[Schedule] (
		[ScheduleId]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[ScheduleMonth] ADD 
	CONSTRAINT [FK_ScheduleMonth_Schedule] FOREIGN KEY 
	(
		[ScheduleId]
	) REFERENCES [dbo].[Schedule] (
		[ScheduleId]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[ScheduleWeek] ADD 
	CONSTRAINT [FK_ScheduleWeek_Schedule] FOREIGN KEY 
	(
		[ScheduleId]
	) REFERENCES [dbo].[Schedule] (
		[ScheduleId]
	) ON DELETE CASCADE 
GO

