IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'GetJobsToRun' 
	   AND 	  type = 'P')
    DROP PROCEDURE GetJobsToRun
GO

CREATE PROCEDURE GetJobsToRun
AS

SELECT	JobId, JobType, JobName, CommandText
FROM	Job
WHERE	JobId in (

	SELECT	j.JobId
	FROM	Schedule s 
		INNER JOIN Job j ON s.ScheduleId = j.ScheduleId
	WHERE	s.ScheduleType = 'Hourly'
		and GetDate() between DATEADD(Hour, s.StartHour, DATEADD(minute, s.StartMin, s.StartDate)) and Coalesce(s.EndDate,'12/12/2078') 
		and (j.LastRunTime is null or DATEDIFF(minute, j.LastRunTime, GetDate()) >= (EveryHour*60) + EveryMinute)
	
	UNION
	
	SELECT	j.JobId
	FROM	Schedule s 
		INNER JOIN Job j ON s.ScheduleId = j.ScheduleId
	WHERE	s.ScheduleType = 'Daily'
		and GetDate() between s.StartDate and Coalesce(s.EndDate,'12/12/2078') 
		and (j.LastRunTime is null or DATEDIFF(Day, j.LastRunTime, GetDate()) > s.RepeatDays)
		and (s.StartHour*60) + s.StartMin = (DatePart(hour,GetDate())*60) + DatePart(minute,GetDate())
	
	UNION
	
	SELECT	j.JobId
	FROM	Schedule s 
		INNER JOIN Job j ON s.ScheduleId = j.ScheduleId
		INNER JOIN ScheduleWeek w ON w.ScheduleId = j.ScheduleId
	WHERE	s.ScheduleType = 'Weekly'
		and GetDate() between s.StartDate and Coalesce(s.EndDate,'12/12/2078') 
		and DATEPART (weekday , GetDate()) = w.WeekDayId
		and ((s.StartHour*60) + s.StartMin) <= (DatePart(hour,GetDate())*60) + DatePart(minute,GetDate()) 
		and (j.LastRunTime is null or DATEDIFF(Day, j.LastRunTime, GetDate()) > 0) -- run once a day
	
	UNION
	
	SELECT	j.JobId
	FROM	Schedule s 
		INNER JOIN Job j ON s.ScheduleId = j.ScheduleId
		INNER JOIN ScheduleWeek w ON w.ScheduleId = j.ScheduleId
	WHERE	s.ScheduleType = 'WeeklySkip'
		and GetDate() between s.StartDate and Coalesce(s.EndDate,'12/12/2078') 
		and DATEPART (weekday , GetDate()) = w.WeekDayId
		and DATEDIFF(week, j.LastRunTime, GetDate()) >= s.RepeatWeeks --j.LastRunTime
		and ((s.StartHour*60) + s.StartMin) <= (DatePart(hour,GetDate())*60) + DatePart(minute,GetDate()) -- time
		and (j.LastRunTime is null or DATEDIFF(Day, j.LastRunTime, GetDate()) > 0) -- run once a day
	
	UNION
	
	SELECT	j.JobId
	FROM	Schedule s 
		INNER JOIN Job j ON s.ScheduleId = j.ScheduleId
		INNER JOIN ScheduleWeek w ON w.ScheduleId = j.ScheduleId
		INNER JOIN ScheduleMonth m ON m.ScheduleId = j.ScheduleId
	WHERE	s.ScheduleType = 'WeekNumber'
		and GetDate() between s.StartDate and Coalesce(s.EndDate,'12/12/2078') 
		and w.WeekDayId = DATEPART (weekday , GetDate())
		and m.MonthId = DATEPART (month , GetDate())
		and s.WeekOfMonth = (datepart(ww,GetDate())) + 1 - datepart(ww,dateadd(dd,-(datepart(dd,GetDate())-1),GetDate()))
		and ((s.StartHour*60) + s.StartMin) <= (DatePart(hour,GetDate())*60) + DatePart(minute,GetDate()) 
		and (j.LastRunTime is null or DATEDIFF(Day, j.LastRunTime, GetDate()) > 0) -- run once a day
	
	UNION
	
	SELECT	j.JobId
	FROM	Schedule s 
		INNER JOIN Job j ON s.ScheduleId = j.ScheduleId
		INNER JOIN ScheduleMonth m ON m.ScheduleId = j.ScheduleId
		INNER JOIN ScheduleDay d ON d.ScheduleId = j.ScheduleId
	WHERE	s.ScheduleType = 'Calendar'
		and GetDate() between s.StartDate and Coalesce(s.EndDate,'12/12/2078') 
		and DATEPART (month , GetDate()) = m.MonthId
		and (DATEPART (day , GetDate()) = d.DayId
			or (d.DayId = 32 and DAY(DATEADD(d, -DAY(DATEADD(m,1,GetDate())),DATEADD(m,1,GetDate()))) = DATEPART(day ,GetDate()))
		    )
		and ((s.StartHour*60) + s.StartMin) <= (DatePart(hour,GetDate())*60) + DatePart(minute,GetDate()) 
		and (j.LastRunTime is null or DATEDIFF(Day, j.LastRunTime, GetDate()) > 0) -- run once a day
	
	UNION
	
	SELECT	j.JobId
	FROM	Schedule s 
		INNER JOIN Job j ON s.ScheduleId = j.ScheduleId
	WHERE	s.ScheduleType = 'Once'
		and GetDate() between s.StartDate and Coalesce(s.EndDate,'12/12/2078') 
		and ((s.StartHour*60) + s.StartMin) <= (DatePart(hour,GetDate())*60) + DatePart(minute,GetDate()) 
		and (j.LastRunTime is null) -- run once

)

grant execute on GetJobsToRun to public

