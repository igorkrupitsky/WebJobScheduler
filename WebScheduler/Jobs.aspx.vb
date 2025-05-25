Public Class Subscriptions
    Inherits ScheduleBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Expires = 0

        If Request.Form("btnDelete") <> "" Then
            Delete()
        End If

        Dim oHelper As New Helper
        Dim sSql = "SELECT JobId, JobName, ScheduleId, LastRunTime, LastStatus FROM Job"
        Dim oTable As DataTable = oHelper.GetTable(sSql)

        oTable.Columns.Add("ScheduleDesc")
        For i As Integer = 0 To oTable.Rows.Count - 1
            oTable.Rows(i).Item("ScheduleDesc") = GetScheduleName(oTable.Rows(i).Item("ScheduleId"))
        Next

        DataGrid1.DataSource = oTable
        DataGrid1.DataBind()

    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand

        Select Case e.CommandName
            Case "JobEdit"
                Dim lblJobId As Label = e.Item.FindControl("lblJobId")
                Dim iJobId As Long = lblJobId.Text
                Response.Redirect("Job.aspx?&id=" & iJobId)
        End Select

    End Sub

    Private Sub Delete()
        For i As Integer = 0 To DataGrid1.Items.Count - 1
            Dim lblJobId As Label = DataGrid1.Items(i).FindControl("lblJobId")
            Dim iJobId As Long = lblJobId.Text
            Dim chkDelete As CheckBox = DataGrid1.Items(i).FindControl("chkDelete")

            If chkDelete.Checked = True Then
                DeleteJob(iJobId)
            End If
        Next

        DeleteOrphanedPrivateSchedules()
    End Sub

    Private Sub DeleteJob(ByVal sId As String)
        Dim sSql = "DELETE FROM Job WHERE JobId = " & sId
        Dim oHelper As New Helper
        oHelper.ExecuteSql(sSql)
    End Sub

    Private Sub DeleteOrphanedPrivateSchedules()
        Dim oHelper As New Helper
        Dim sSql As String = "DELETE s " & vbCrLf
        sSql += " FROM Schedule s "
        sSql += " LEFT JOIN Job j ON j.ScheduleId = s.ScheduleId"
        sSql += " WHERE	s.IsPublic = 0 and j.ScheduleId is null"
        oHelper.ExecuteSql(sSql)
    End Sub

    Private Function GetScheduleName(ByVal sScheduleId As String) As String
        Dim oHelper As New Helper
        Dim sSql = "SELECT ScheduleName, IsPublic, ScheduleType, StartDate, EndDate, StartHour, StartMin, EveryHour, EveryMinute, WeekOfMonth, RepeatDays, RepeatWeeks FROM Schedule WHERE ScheduleId = " & sScheduleId
        Dim dr As OleDb.OleDbDataReader = oHelper.GetDataReader(sSql)
        Dim sRet As String = ""

        If dr.Read Then

            Dim sScheduleName As String = dr.GetValue(dr.GetOrdinal("ScheduleName")) & ""
            Dim sMonths As String = GetMonthDesc(sScheduleId)
            Dim sWeekdays As String = GetWeekDesc(sScheduleId)
            Dim sMonthDays As String = GetDayDesc(sScheduleId)

            Dim sTime As String = dr.GetValue(dr.GetOrdinal("StartHour")) & ":" & _
                                  PadMinute(dr.GetValue(dr.GetOrdinal("StartMin")) & "") 

            Dim sDesc As String = GetScheduleDescription( _
                        dr.GetValue(dr.GetOrdinal("ScheduleType")) & "", _
                        dr.GetValue(dr.GetOrdinal("EveryHour")) & "", _
                        dr.GetValue(dr.GetOrdinal("EveryMinute")) & "", _
                        dr.GetValue(dr.GetOrdinal("RepeatDays")) & "", _
                        dr.GetValue(dr.GetOrdinal("RepeatWeeks")) & "", _
                        dr.GetValue(dr.GetOrdinal("WeekOfMonth")) & "", _
                        sWeekdays, sMonths, sMonthDays)

            Dim sStartDate As String = dr.GetValue(dr.GetOrdinal("StartDate")) & ""
            Dim sEndDate As String = dr.GetValue(dr.GetOrdinal("EndDate")) & ""

            If sEndDate = "" Then
                sDesc = "Start Date: " & sStartDate & _
                        "; Time: " & sTime & "; " & sDesc
            Else
                sDesc = "Date Range: " & sStartDate & _
                        " - " & sEndDate & _
                        "; Time: " & sTime & "; " & sDesc
            End If

            If dr.GetBoolean(dr.GetOrdinal("IsPublic")) Then
                sRet = sScheduleName & " (" & sDesc & ")"
            Else
                sRet = sDesc
            End If

        End If

        dr.Close()

        If sRet = "" Then
            Return "No schedule defined"
        Else
            Return sRet
        End If

    End Function

End Class
