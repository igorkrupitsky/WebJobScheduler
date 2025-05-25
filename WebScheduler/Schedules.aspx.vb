Public Class Schedules
    Inherits ScheduleBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ltSchedules As System.Web.UI.WebControls.Literal
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents btnNew As System.Web.UI.WebControls.Button
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
            DeleteSchedules()
        End If

        ltSchedules.Text = GetSchedules()
    End Sub

    Private Sub DeleteSchedules()
        Dim oHelper As New Helper
        Dim sSql = "SELECT ScheduleId FROM Schedule WHERE IsPublic = 1"
        Dim dr As OleDb.OleDbDataReader = oHelper.GetDataReader(sSql)

        While dr.Read
            Dim sId As String = dr.GetValue(dr.GetOrdinal("ScheduleId")) & ""
            If Request.Form("chk" & sId) <> "" Then
                DeleteSchedule(sId)
            End If
        End While
        dr.Close()
    End Sub

    Private Sub DeleteSchedule(ByVal sId As String)
        Dim oHelper As New Helper
        Dim sSql As String

        sSql = "delete j FROM Schedule s INNER JOIN Job j ON s.ScheduleId = j.ScheduleId WHERE s.ScheduleId = " & sId
        oHelper.ExecuteSql(sSql)

        sSql = "DELETE FROM Schedule WHERE ScheduleId = " & sId
        oHelper.ExecuteSql(sSql)

    End Sub

    Private Function GetSchedules() As String
        Dim sb As New System.Text.StringBuilder
        Dim oHelper As New Helper
        Dim sSql = "SELECT ScheduleId, ScheduleName, ScheduleType, StartDate, EndDate, StartHour, StartMin, EveryHour, EveryMinute, WeekOfMonth, RepeatDays, RepeatWeeks FROM Schedule WHERE IsPublic = 1"
        Dim dr As OleDb.OleDbDataReader = oHelper.GetDataReader(sSql)

        Dim bNoRecs As Boolean = True

        sb.Append("<table cellspacing=0 rules=all border=1 style=""width:100%;border-collapse:collapse;"">")
        sb.Append("<tr class=ColHeader>")
        sb.Append("<td width=10>&nbsp;</td>")
        sb.Append("<td nowrap>Schedule Name</td>")
        sb.Append("<td nowrap>Start Date</td>")
        sb.Append("<td nowrap>End Date</td>")
        sb.Append("<td nowrap>Time</td>")
        sb.Append("<td nowrap width=90%>Description</td>")
        sb.Append("</tr>")

        While dr.Read
            bNoRecs = False

            Dim sId As String = dr.GetValue(dr.GetOrdinal("ScheduleId")) & ""
            Dim sMonths As String = GetMonthDesc(sId)
            Dim sWeekdays As String = GetWeekDesc(sId)
            Dim sMonthDays As String = GetDayDesc(sId)

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

            sb.Append("<tr>")
            sb.Append("<td width=10><input type=checkbox name=chk" & sId & "></td>")
            sb.Append("<td nowrap>")
            sb.Append("<a href='Schedule.aspx?id=" & sId & "&shared=1'>")
            sb.Append(dr.GetValue(dr.GetOrdinal("ScheduleName")))
            sb.Append("</a>")
            sb.Append("</td>")
            sb.Append("<td nowrap>" & dr.GetValue(dr.GetOrdinal("StartDate")) & "</td>")
            sb.Append("<td nowrap>" & dr.GetValue(dr.GetOrdinal("EndDate")) & "&nbsp;</td>")
            sb.Append("<td nowrap>" & sTime & "&nbsp;</td>")
            sb.Append("<td>" & sDesc & "&nbsp;</td>")
            sb.Append("</tr>" & vbCrLf)
        End While

        dr.Close()

        sb.Append("</table>")

        If bNoRecs Then
            Return ""
        Else
            Return sb.ToString()
        End If

    End Function

End Class
