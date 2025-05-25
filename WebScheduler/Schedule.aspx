<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Schedule.aspx.vb" Inherits="WebScheduler.Schedule" %>
<%@ Register TagPrefix="uc1" TagName="Scheduler" Src="Scheduler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD>
<title>Public Schedule</title>
<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
<meta name=vs_defaultClientScript content="JavaScript">
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<LINK rel="stylesheet" type="text/css" href="StyleSheet.css">

<link rel="stylesheet" type="text/css" media="all" href="jscalendar/calendar-win2k-cold-1.css" title="win2k-cold-1" />
<script type="text/javascript" src="jscalendar/calendar.js"></script>
<script type="text/javascript" src="jscalendar/lang/calendar-en.js"></script>
<script type="text/javascript" src="jscalendar/calendar-setup.js"></script>

<script language=javascript>
<!--
function OnLoad(){
	UpdateScheduleType();
}
//-->
</script>

</HEAD>
<body onload="OnLoad()">
<form id="form1" method="post" runat="server">

<uc1:Scheduler id=Scheduler1 runat="server"></uc1:Scheduler>

<INPUT type="submit" value="Save" name="btnSave" style="WIDTH:70px">
<INPUT type="button" value="Cancel" name=btnCancel style="WIDTH:70px" onclick="location='Schedules.aspx'">

</form>
</body>
</HTML>
