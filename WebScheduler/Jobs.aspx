<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Jobs.aspx.vb" Inherits="WebScheduler.Subscriptions" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
<title>Jobs</title>
<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
<meta name=vs_defaultClientScript content="JavaScript">
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<LINK rel="stylesheet" type="text/css" href="StyleSheet.css">
<script language=javascript>
<!--
function AddNew(){
	location = "Job.aspx?new=1";

}
//-->
</script>
</HEAD>
<body>
<form id="form1" method="post" runat="server">

<h1>Jobs</h1>

<P>
<INPUT type="submit" value="Delete" name=btnDelete style="WIDTH:100px">
<INPUT type="button" value="Add New" style="WIDTH:100px" onclick="AddNew()"> 
</P>

<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Width="100%">
<HeaderStyle CssClass="ColHeader"></HeaderStyle>

<Columns>
 	<asp:TemplateColumn>
		<ItemTemplate>
			<asp:CheckBox Runat="server" ID="chkDelete" Visible="True"></asp:CheckBox>
		</ItemTemplate>
	</asp:TemplateColumn>

	<asp:TemplateColumn HeaderText="JobId" Visible=False>
		<ItemTemplate>
			<asp:Label runat="server" ID="lblJobId" Text='<%# DataBinder.Eval(Container, "DataItem.JobId") %>'>
			</asp:Label>
		</ItemTemplate>
	</asp:TemplateColumn>
	
	<asp:TemplateColumn HeaderText="Job Name">
		<ItemTemplate>
			<asp:linkbutton Runat="server" ID="lnkJob" CommandName="JobEdit" Text='<%# DataBinder.Eval(Container, "DataItem.JobName") %>'>
			</asp:linkbutton>
		</ItemTemplate>
	</asp:TemplateColumn>

	<asp:BoundColumn DataField="ScheduleDesc" HeaderText="Schedule"></asp:BoundColumn>

	<asp:BoundColumn DataField="LastRunTime" HeaderText="Last Run"></asp:BoundColumn>
	<asp:BoundColumn DataField="LastStatus" ReadOnly="True" HeaderText="Last Status"></asp:BoundColumn>

</Columns>

</asp:datagrid>
								

</form>
</body>
</HTML>
