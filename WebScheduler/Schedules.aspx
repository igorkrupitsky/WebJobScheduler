<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Schedules.aspx.vb" Inherits="WebScheduler.Schedules" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
<title>Schedules</title>
<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
<meta name=vs_defaultClientScript content="JavaScript">
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<LINK rel="stylesheet" type="text/css" href="StyleSheet.css">
<script language=javascript>
<!--
function AddNew(){
	location = "Schedule.aspx?new=1&shared=1";

}
//-->
</script>
</HEAD>
<body>
<form id="form1" method="post" runat="server">

<h1>Shared Schedules</h1>

<P>
<INPUT type="submit" value="Delete" name=btnDelete style="WIDTH:100px">
<INPUT type="button" value="Add New" style="WIDTH:100px" onclick="AddNew()"> 
<INPUT type="button" value="Jobs" name=btnJobs style="WIDTH:100px" onclick="location='Jobs.aspx'">
</P>

<P>
<asp:Literal id=ltSchedules runat="server"></asp:Literal>
</P>

</form>
</body>
</HTML>
