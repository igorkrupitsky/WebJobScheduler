Public Class Scheduler
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtScheduleName As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnName As System.Web.UI.WebControls.Panel
    Protected WithEvents selScheduleType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtEveryHour As System.Web.UI.WebControls.TextBox
    Protected WithEvents selEveryMinute As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkSun As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkMon As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkTue As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkWed As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkThu As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFri As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkSat As System.Web.UI.WebControls.CheckBox
    Protected WithEvents selWeekOfMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtRepeatDays As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRepeatWeek As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkJan As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkApr As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkJul As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkOct As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFeb As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkMay As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkAug As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkNov As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkMar As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkJun As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkSep As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDec As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay2 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay3 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay4 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay5 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay6 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay7 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay8 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay9 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay10 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay11 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay12 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay13 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay14 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay15 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay16 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay17 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay18 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay19 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay20 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay21 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay22 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay23 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay24 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay25 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay26 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay27 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay28 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay29 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay30 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay31 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDayLast As System.Web.UI.WebControls.CheckBox
    Protected WithEvents selStartHour As System.Web.UI.WebControls.DropDownList
    Protected WithEvents selStartMin As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtStartDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public sJobId As String = ""

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Expires = 0

        Dim iScheduleId As String

        If Request.QueryString("shared") = "1" Then
            iScheduleId = Request.QueryString("id")
        End If

        pnName.Visible = (Request.QueryString("shared") = "1")

        If sJobId <> "" Then 'Private Schedule
            iScheduleId = GetPrivateScheduleId(sJobId)
        End If

        If txtScheduleName.Text = "" And Request.QueryString("shared") = "1" Then
            txtScheduleName.Text = "New Schedule"
        End If

        If txtStartDate.Text = "" Then
            txtStartDate.Text = DateTime.Now.ToShortDateString()
        End If

        If Request.Form("btnSave") <> "" Then

            If iScheduleId <> "" Then
                UpdateSchedule(iScheduleId)
            Else
                iScheduleId = AddSchedule(Request.QueryString("shared") = "1")
            End If

            If sJobId <> "" Then 'Private Schedule
                UpdateJobScheduleId(sJobId, iScheduleId)
                Response.Redirect("Jobs.aspx")
            Else 'Public Schedule
                Response.Redirect("Schedules.aspx")
            End If

        End If

        If iScheduleId <> "" Then
            GetSchedule(iScheduleId)
        End If
    End Sub


    Private Sub UpdateJobScheduleId(ByVal sJobId As String, ByVal sScheduleId As String)
        Dim sSql As String = "UPDATE Job SET ScheduleId = " & sScheduleId & " WHERE JobId = " & sJobId
        Dim oHelper As New Helper
        oHelper.ExecuteSql(sSql)
    End Sub

    Private Function GetPrivateScheduleId(ByVal sJobId As String) As String
        Dim sSql As String = "SELECT j.ScheduleId FROM Job j " & _
                            " INNER JOIN Schedule s ON j.ScheduleId = s.ScheduleId " & _
                            " WHERE s.IsPublic = 0 AND j.JobId = " & sJobId
        Dim oHelper As New Helper
        Return oHelper.ExecuteScalar(sSql)
    End Function

    Private Sub GetSchedule(ByVal iScheduleId As String)
        Dim sSql As String = "SELECT ScheduleName, IsPublic, ScheduleType, StartDate, EndDate, StartHour, StartMin, EveryHour, EveryMinute, WeekOfMonth, RepeatDays, RepeatWeeks" & vbCrLf
        sSql += " FROM Schedule"
        sSql += " WHERE ScheduleId = " & iScheduleId

        Dim oHelper As New Helper
        Dim dr As OleDb.OleDbDataReader = oHelper.GetDataReader(sSql)
        If dr.Read Then
            txtScheduleName.Text = dr(dr.GetOrdinal("ScheduleName")) & ""
            selScheduleType.SelectedValue = dr(dr.GetOrdinal("ScheduleType")) & ""

            selStartHour.SelectedValue = dr(dr.GetOrdinal("StartHour")) & ""  'StartHour
            selStartMin.SelectedValue = PadMinute(dr(dr.GetOrdinal("StartMin")) & "") 'StartMin

            'Type Based Props
            txtEveryHour.Text = dr(dr.GetOrdinal("EveryHour")) & "" 'EveryHour
            selEveryMinute.SelectedValue = PadMinute(dr(dr.GetOrdinal("EveryMinute")) & "") 'EveryMinute
            selWeekOfMonth.SelectedValue = dr(dr.GetOrdinal("WeekOfMonth")) & "" 'WeekOfMonth
            txtRepeatDays.Text = dr(dr.GetOrdinal("RepeatDays")) & "" 'RepeatDays
            txtRepeatWeek.Text = dr(dr.GetOrdinal("RepeatWeeks")) & "" 'RepeatWeeks

            txtStartDate.Text = dr(dr.GetOrdinal("StartDate")) & "" 'StartDate
            txtEndDate.Text = dr(dr.GetOrdinal("EndDate")) & "" 'EndDate

            SetDays(iScheduleId)
            SetMonths(iScheduleId)
            SetWeekdays(iScheduleId)

        End If
        dr.Close()
    End Sub

    Function PadMinute(ByVal s As String) As String
        Return Right("00" & s, 2)
    End Function

    Private Sub UpdateSchedule(ByVal iScheduleId As String)
        Dim bPublic As Boolean = False

        Dim oHelper As New Helper
        Dim sSql As String = "UPDATE Schedule SET " & vbCrLf

        sSql += "ScheduleName = '" & txtScheduleName.Text & "'" 'ScheduleName
        'sSql += ",IsPublic=" & IIf(bPublic, "1", "0") 'IsPublic

        'Common Props
        sSql += ",ScheduleType='" & selScheduleType.SelectedValue & "'" 'ScheduleType

        sSql += ",StartDate=" & PadSqlString(txtStartDate.Text) 'StartDate
        sSql += ",EndDate=" & PadSqlString(txtEndDate.Text) 'EndDate

        sSql += ",StartHour=" & selStartHour.SelectedValue  'StartHour
        sSql += ",StartMin=" & selStartMin.SelectedValue 'StartMin

        'Type Based Props
        sSql += ",EveryHour=" & txtEveryHour.Text 'EveryHour
        sSql += ",EveryMinute= " & selEveryMinute.SelectedValue 'EveryMinute
        sSql += ",WeekOfMonth=" & selWeekOfMonth.SelectedValue 'WeekOfMonth
        sSql += ",RepeatDays=" & txtRepeatDays.Text 'RepeatDays
        sSql += ",RepeatWeeks=" & txtRepeatWeek.Text 'RepeatWeeks

        sSql += " WHERE ScheduleId=" & iScheduleId

        oHelper.ExecuteSql(sSql)

        UpdateWeekdays(iScheduleId)
        UpdateMonths(iScheduleId)
        UpdateDays(iScheduleId)
    End Sub

    Private Function AddSchedule(ByVal bPublic As Boolean) As String
        Dim oHelper As New Helper
        Dim sSql As String = "INSERT INTO Schedule (ScheduleName, IsPublic, ScheduleType, StartDate, EndDate, StartHour, StartMin, EveryHour, EveryMinute, WeekOfMonth, RepeatDays, RepeatWeeks)" & vbCrLf

        sSql += " VALUES ("
        sSql += "'" & txtScheduleName.Text & "'" 'ScheduleName
        sSql += "," & IIf(bPublic, "1", "0") 'IsPublic

        'Common Props
        sSql += ",'" & selScheduleType.SelectedValue & "'" 'ScheduleType

        sSql += "," & PadSqlString(txtStartDate.Text) 'StartDate
        sSql += "," & PadSqlString(txtEndDate.Text) 'EndDate

        sSql += "," & selStartHour.SelectedValue  'StartHour 'StartHour
        sSql += "," & selStartMin.SelectedValue 'StartMin

        'Type Based Props
        sSql += "," & txtEveryHour.Text 'EveryHour
        sSql += "," & selEveryMinute.SelectedValue 'EveryMinute
        sSql += "," & selWeekOfMonth.SelectedValue 'WeekOfMonth
        sSql += "," & txtRepeatDays.Text 'RepeatDays
        sSql += "," & txtRepeatWeek.Text 'RepeatWeek
        sSql += ")"

        oHelper.ExecuteSql(sSql)

        Dim sScheduleId As String = oHelper.ExecuteScalar("Select Max(ScheduleId) FROM Schedule")

        UpdateWeekdays(sScheduleId)
        UpdateMonths(sScheduleId)
        UpdateDays(sScheduleId)

        Return sScheduleId
    End Function

    Private Function PadSqlString(ByVal s As String) As String
        If s = "" Then
            Return "NULL"
        Else
            Return "'" & s & "'"
        End If
    End Function

    Private Sub SetWeekdays(ByVal sScheduleId As String)
        Dim oHelper As New Helper
        Dim sSql As String = "SELECT WeekDayId FROM ScheduleWeek WHERE ScheduleId = " & sScheduleId
        Dim dr As OleDb.OleDbDataReader = oHelper.GetDataReader(sSql)

        While dr.Read
            Dim sKey As String = dr.GetValue(0) & ""
            If sKey = "1" Then chkSun.Checked = True
            If sKey = "2" Then chkMon.Checked = True
            If sKey = "3" Then chkTue.Checked = True
            If sKey = "4" Then chkWed.Checked = True
            If sKey = "5" Then chkThu.Checked = True
            If sKey = "6" Then chkFri.Checked = True
            If sKey = "7" Then chkSat.Checked = True
        End While

        dr.Close()
    End Sub

    Private Sub UpdateWeekdays(ByVal sScheduleId As String)
        Dim oDays As ArrayList = GetWeekdays()
        Dim oHelper As New Helper
        Dim sSql As String = "DELETE FROM ScheduleWeek WHERE ScheduleId = " & sScheduleId
        oHelper.ExecuteSql(sSql)

        For Each sId As String In oDays
            sSql = "INSERT INTO ScheduleWeek(ScheduleId, WeekDayId) VALUES (" & sScheduleId & ", " & sId & ")"
            oHelper.ExecuteSql(sSql)
        Next
    End Sub

    Private Function GetWeekdays() As ArrayList
        Dim oDays As New ArrayList
        If chkSun.Checked Then oDays.Add(1)
        If chkMon.Checked Then oDays.Add(2)
        If chkTue.Checked Then oDays.Add(3)
        If chkWed.Checked Then oDays.Add(4)
        If chkThu.Checked Then oDays.Add(5)
        If chkFri.Checked Then oDays.Add(6)
        If chkSat.Checked Then oDays.Add(7)
        Return oDays
    End Function

    Private Sub UpdateMonths(ByVal sScheduleId As String)
        Dim oMonths As ArrayList = GetMonths()
        Dim oHelper As New Helper
        Dim sSql As String = "DELETE FROM ScheduleMonth WHERE ScheduleId = " & sScheduleId
        oHelper.ExecuteSql(sSql)

        For Each sId As String In oMonths
            sSql = "INSERT INTO ScheduleMonth(ScheduleId, MonthId) VALUES (" & sScheduleId & ", " & sId & ")"
            oHelper.ExecuteSql(sSql)
        Next
    End Sub

    Private Function GetMonths() As ArrayList
        Dim oList As New ArrayList
        If chkJan.Checked Then oList.Add(1)
        If chkFeb.Checked Then oList.Add(2)
        If chkMar.Checked Then oList.Add(3)
        If chkApr.Checked Then oList.Add(4)
        If chkMay.Checked Then oList.Add(5)
        If chkJun.Checked Then oList.Add(6)
        If chkJul.Checked Then oList.Add(7)
        If chkAug.Checked Then oList.Add(8)
        If chkSep.Checked Then oList.Add(9)
        If chkOct.Checked Then oList.Add(10)
        If chkNov.Checked Then oList.Add(11)
        If chkDec.Checked Then oList.Add(12)
        Return oList
    End Function

    Private Sub SetMonths(ByVal sScheduleId As String)

        Dim oHelper As New Helper
        Dim sSql As String = "SELECT MonthId FROM ScheduleMonth WHERE ScheduleId = " & sScheduleId
        Dim dr As OleDb.OleDbDataReader = oHelper.GetDataReader(sSql)

        While dr.Read
            Dim sKey As String = dr.GetValue(0) & ""
            If sKey = "1" Then chkJan.Checked = True
            If sKey = "2" Then chkFeb.Checked = True
            If sKey = "3" Then chkMar.Checked = True
            If sKey = "4" Then chkApr.Checked = True
            If sKey = "5" Then chkMay.Checked = True
            If sKey = "6" Then chkJun.Checked = True
            If sKey = "7" Then chkJul.Checked = True
            If sKey = "8" Then chkAug.Checked = True
            If sKey = "9" Then chkSep.Checked = True
            If sKey = "10" Then chkOct.Checked = True
            If sKey = "11" Then chkNov.Checked = True
            If sKey = "12" Then chkDec.Checked = True
        End While

        dr.Close()
    End Sub

    Private Sub UpdateDays(ByVal sScheduleId As String)
        Dim oDays As ArrayList = GetDays()
        Dim oHelper As New Helper
        Dim sSql As String = "DELETE FROM ScheduleDay WHERE ScheduleId = " & sScheduleId
        oHelper.ExecuteSql(sSql)

        For Each sId As String In oDays
            sSql = "INSERT INTO ScheduleDay(ScheduleId, DayId) VALUES (" & sScheduleId & ", " & sId & ")"
            oHelper.ExecuteSql(sSql)
        Next
    End Sub

    Private Function GetDays() As ArrayList
        Dim oList As New ArrayList
        If chkDay1.Checked Then oList.Add(1)
        If chkDay2.Checked Then oList.Add(2)
        If chkDay3.Checked Then oList.Add(3)
        If chkDay4.Checked Then oList.Add(4)
        If chkDay5.Checked Then oList.Add(5)
        If chkDay6.Checked Then oList.Add(6)
        If chkDay7.Checked Then oList.Add(7)
        If chkDay8.Checked Then oList.Add(8)
        If chkDay9.Checked Then oList.Add(9)

        If chkDay10.Checked Then oList.Add(10)
        If chkDay11.Checked Then oList.Add(11)
        If chkDay12.Checked Then oList.Add(12)
        If chkDay13.Checked Then oList.Add(13)
        If chkDay14.Checked Then oList.Add(14)
        If chkDay15.Checked Then oList.Add(15)
        If chkDay16.Checked Then oList.Add(16)
        If chkDay17.Checked Then oList.Add(17)
        If chkDay18.Checked Then oList.Add(18)
        If chkDay19.Checked Then oList.Add(19)

        If chkDay20.Checked Then oList.Add(20)
        If chkDay21.Checked Then oList.Add(21)
        If chkDay22.Checked Then oList.Add(22)
        If chkDay23.Checked Then oList.Add(23)
        If chkDay24.Checked Then oList.Add(24)
        If chkDay25.Checked Then oList.Add(25)
        If chkDay26.Checked Then oList.Add(26)
        If chkDay27.Checked Then oList.Add(27)
        If chkDay28.Checked Then oList.Add(28)
        If chkDay29.Checked Then oList.Add(29)
        If chkDay30.Checked Then oList.Add(30)

        If chkDay31.Checked Then oList.Add(31)
        If chkDayLast.Checked Then oList.Add(32)
        Return oList
    End Function


    Private Sub SetDays(ByVal sScheduleId As String)

        Dim oHelper As New Helper
        Dim sSql As String = "SELECT DayId FROM ScheduleDay WHERE ScheduleId = " & sScheduleId
        Dim dr As OleDb.OleDbDataReader = oHelper.GetDataReader(sSql)

        While dr.Read
            Dim sKey As String = dr.GetValue(0) & ""

            If sKey = "1" Then chkDay1.Checked = True
            If sKey = "2" Then chkDay2.Checked = True
            If sKey = "3" Then chkDay3.Checked = True
            If sKey = "4" Then chkDay4.Checked = True
            If sKey = "5" Then chkDay5.Checked = True
            If sKey = "6" Then chkDay6.Checked = True
            If sKey = "7" Then chkDay7.Checked = True
            If sKey = "8" Then chkDay8.Checked = True
            If sKey = "9" Then chkDay9.Checked = True

            If sKey = "10" Then chkDay10.Checked = True
            If sKey = "11" Then chkDay11.Checked = True
            If sKey = "12" Then chkDay12.Checked = True
            If sKey = "13" Then chkDay13.Checked = True
            If sKey = "14" Then chkDay14.Checked = True
            If sKey = "15" Then chkDay15.Checked = True
            If sKey = "16" Then chkDay16.Checked = True
            If sKey = "17" Then chkDay17.Checked = True
            If sKey = "18" Then chkDay18.Checked = True
            If sKey = "19" Then chkDay19.Checked = True

            If sKey = "20" Then chkDay20.Checked = True
            If sKey = "21" Then chkDay21.Checked = True
            If sKey = "22" Then chkDay22.Checked = True
            If sKey = "23" Then chkDay23.Checked = True
            If sKey = "24" Then chkDay24.Checked = True
            If sKey = "25" Then chkDay25.Checked = True
            If sKey = "26" Then chkDay26.Checked = True
            If sKey = "27" Then chkDay27.Checked = True
            If sKey = "28" Then chkDay28.Checked = True
            If sKey = "29" Then chkDay29.Checked = True
            If sKey = "30" Then chkDay30.Checked = True

            If sKey = "31" Then chkDay31.Checked = True
            If sKey = "32" Then chkDayLast.Checked = True
        End While

        dr.Close()

    End Sub

    '==============================================================================
    Private Function JoinArrayList(ByVal oList As ArrayList) As String
        Dim sRet As String
        For Each sLine As String In oList
            If sRet <> "" Then
                sRet += ","
            End If
            sRet += sLine
        Next
        Return sRet
    End Function

    Private Function GetHashtableFromString(ByVal sList As String) As Hashtable
        Dim oList As String() = sList.Split(",")
        Dim oRet As New Hashtable
        For Each sLine As String In oList
            oRet.Add(sLine, True)
        Next
        Return oRet
    End Function

End Class
