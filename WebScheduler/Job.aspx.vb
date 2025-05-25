Public Class Job
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtJobName As System.Web.UI.WebControls.TextBox
    Protected WithEvents selSchedule As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents selConnection As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCommandText As System.Web.UI.WebControls.TextBox
    Protected WithEvents Scheduler1 As Scheduler

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

        If txtJobName.Text = "" Then
            txtJobName.Text = "New Job"
        End If

        If Page.IsPostBack = False Then
            selSchedule.Items.Add(New ListItem("Private Schedule", "0"))
            Dim oHelper As New Helper
            oHelper.SetSelect(selSchedule, "SELECT ScheduleId, ScheduleName FROM Schedule WHERE IsPublic = 1")
        End If

        Dim sJobId As String = Request.QueryString("id")

        If Request.Form("btnSave") <> "" Then

            If sJobId <> "" Then
                UpdateJob(sJobId)
            Else
                sJobId = AddJob()
            End If

            If selSchedule.SelectedValue <> "0" Then 'Public
                Response.Redirect("Jobs.aspx")
            End If
        End If

        Scheduler1.sJobId = sJobId

        If Request.QueryString("id") <> "" Then
            GetJob(Request.QueryString("id"))
        End If

    End Sub

    Private Sub GetJob(ByVal iJobId As String)
        Dim sSql As String = "SELECT j.JobName, j.CommandText, s.ScheduleId FROM Job j LEFT  JOIN Schedule s ON j.ScheduleId = s.ScheduleId AND s.IsPublic = 1" & vbCrLf
        sSql += " WHERE j.JobId = " & iJobId

        Dim oHelper As New Helper
        Dim dr As OleDb.OleDbDataReader = oHelper.GetDataReader(sSql)
        If dr.Read Then
            txtJobName.Text = dr(dr.GetOrdinal("JobName")) & ""
            txtCommandText.Text = dr(dr.GetOrdinal("CommandText")) & ""

            Dim sScheduleId As String = dr(dr.GetOrdinal("ScheduleId")) & ""
            If sScheduleId <> "" Then
                selSchedule.SelectedValue = sScheduleId
            Else
                selSchedule.SelectedValue = "0"
            End If
        End If
        dr.Close()
    End Sub

    Private Sub UpdateJob(ByVal iJobId As String)
        Dim bPublic As Boolean = False

        Dim oHelper As New Helper
        Dim sSql As String = "UPDATE Job SET " & vbCrLf

        sSql += "JobName = '" & txtJobName.Text & "'" 'JobName

        If selSchedule.SelectedValue <> "0" Then
            sSql += ",ScheduleId = " & selSchedule.SelectedValue & "" 'ScheduleId
        End If

        sSql += ",CommandText = '" & txtCommandText.Text & "'" 'CommandText

        sSql += " WHERE JobId=" & iJobId

        oHelper.ExecuteSql(sSql)

        DeleteOrphanedPrivateSchedules()
    End Sub

    Private Sub DeleteOrphanedPrivateSchedules()
        Dim oHelper As New Helper
        Dim sSql As String = "DELETE s " & vbCrLf
        sSql += " FROM	Schedule s "
        sSql += " LEFT JOIN Job j ON j.ScheduleId = s.ScheduleId"
        sSql += " WHERE	s.IsPublic = 0 and j.ScheduleId is null"
        oHelper.ExecuteSql(sSql)
    End Sub

    Private Function AddJob() As String
        Dim oHelper As New Helper
        Dim sSql As String = "INSERT INTO Job (JobName, JobType, ScheduleId, CommandText)" & vbCrLf

        sSql += " VALUES ("
        sSql += "'" & txtJobName.Text & "'" 'JobName
        sSql += ",1" 'JobType

        If selSchedule.SelectedValue <> "0" And selSchedule.SelectedValue <> "" Then
            sSql += "," & selSchedule.SelectedValue 'ScheduleId
        Else
            sSql += ", NULL" 'ScheduleId
        End If

        sSql += ",'" & txtCommandText.Text & "'" 'CommandText
        sSql += ")"

        oHelper.ExecuteSql(sSql)
        Return oHelper.ExecuteScalar("Select Max(JobId) FROM Job")
    End Function

End Class
