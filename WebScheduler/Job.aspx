<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Job.aspx.vb" Inherits="WebScheduler.Job" %>
<%@ Register TagPrefix="uc1" TagName="Scheduler" Src="Scheduler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
<title>Job</title>
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
	ScheduleTypeChanged();
	UpdateScheduleType();
}

function ScheduleTypeChanged(){
	if(form1.selSchedule.value!="0"){
		idScheduler.style.display = "none";
	}else{
		idScheduler.style.display = "";
	}	
}
//-->
</script>
</HEAD>
<body onload="OnLoad()">
<form id="form1" method="post" runat="server">

<h1>Job</h1>

<p>
<TABLE BORDER="1" CELLSPACING="0" CELLPADDING="2">
<TR>
	<TD>Name</TD>
	<TD width=450>
		<asp:TextBox id=txtJobName runat="server" Width="100%"></asp:TextBox>
	</TD>
</TR>

<TR width>
	<TD>Schedule</TD>
	<TD>
	
		<table bordercolor=0 cellpadding=0 cellspacing=0 width="100%">
			<tr>
				<td width="99%">
					<asp:DropDownList id=selSchedule runat="server" onchange="ScheduleTypeChanged()" Width="100%"></asp:DropDownList>
				</td>
				<td>
					<INPUT type="button" value="Edit" name=btnEditSchedules onclick="location='Schedules.aspx'">
				</td>
			</tr>
		</table>	

		<div id=idScheduler style="display:none">
			<uc1:Scheduler id=Scheduler1 runat="server"></uc1:Scheduler>
		</div>
	</TD>
</TR>

<TR>
	<TD>
		Command Text
	</TD>
	<TD>
<asp:TextBox id=txtCommandText runat="server"  Width="100%" TextMode="MultiLine" Rows="6"></asp:TextBox>
	</TD>
</TR>

</TABLE>
</p>

<INPUT type="submit" value="Save" name="btnSave" style="WIDTH:70px">
<INPUT type="button" value="Cancel" name=btnCancel style="WIDTH:70px" onclick="location='Jobs.aspx'">

</form>

</body>
</HTML>
