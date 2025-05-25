Public Class ScheduleBase
    Inherits System.Web.UI.Page

    Protected Function GetScheduleDescription(ByVal sScheduleType As String, _
                            ByVal sEveryHour As String, _
                            ByVal sEveryMinute As String, _
                            ByVal sRepeatDays As String, _
                            ByVal sRepeatWeeks As String, _
                            ByVal sWeekOfMonth As String, _
                            ByVal sWeekdays As String, _
                            ByVal sMonths As String, _
                            ByVal sMonthDays As String) As String
        Select Case sScheduleType
            Case "Hourly"
                Return "Run Every: " & sEveryHour & ":" & _
                       PadMinute(sEveryMinute) & ""
            Case "Daily"
                Return "Repeat after this number of days: " & sRepeatDays
            Case "Weekly"
                Return "On the following days: " & sWeekdays
            Case "WeeklySkip"
                Return "On the following days: " & sWeekdays & _
                       "; Repeat after this number of weeks: " & sRepeatWeeks
            Case "WeekNumber"
                Return "On the following days: " & sWeekdays & _
                       "; On week of month: " & sWeekOfMonth & _
                       "; Months: " & sMonths
            Case "Calendar"
                Return "Months: " & sMonths & _
                        "; Days: " & sMonthDays
            Case "Once"
                Return "Run once"
        End Select
    End Function

    Protected Function GetMonthDesc(ByVal sScheduleId As String) As String
        If sScheduleId = "" Then
            Return ""
        End If

        Dim oHelper As New Helper
        Dim sSql As String = "SELECT MonthId FROM ScheduleMonth WHERE ScheduleId = " & sScheduleId
        Dim dr As OleDb.OleDbDataReader = oHelper.GetDataReader(sSql)

        Dim sRet As String = ""

        While dr.Read
            If sRet <> "" Then
                sRet += ", "
            End If

            Select Case dr.GetValue(0) & ""
                Case 1
                    sRet += "Jan"
                Case 2
                    sRet += "Feb"
                Case 3
                    sRet += "Mar"
                Case 4
                    sRet += "Apr"
                Case 5
                    sRet += "May"
                Case 6
                    sRet += "Jun"
                Case 7
                    sRet += "Jul"
                Case 8
                    sRet += "May"
                Case 9
                    sRet += "Sep"
                Case 10
                    sRet += "Oct"
                Case 11
                    sRet += "Nov"
                Case 12
                    sRet += "Dec"
            End Select
        End While

        dr.Close()

        Return sRet
    End Function

    Protected Function PadMinute(ByVal s As String) As String
        Return Right("00" & s, 2)
    End Function

    Protected Function GetWeekDesc(ByVal sScheduleId As String) As String
        If sScheduleId = "" Then
            Return ""
        End If

        Dim oHelper As New Helper
        Dim sSql As String = "SELECT WeekDayId FROM ScheduleWeek WHERE ScheduleId = " & sScheduleId
        Dim dr As OleDb.OleDbDataReader = oHelper.GetDataReader(sSql)

        Dim sRet As String = ""

        While dr.Read
            Dim sKey As String = dr.GetValue(0) & ""

            If sRet <> "" Then
                sRet += ", "
            End If

            Select Case dr.GetValue(0) & ""
                Case 1
                    sRet += "Sun"
                Case 2
                    sRet += "Mon"
                Case 3
                    sRet += "Tue"
                Case 4
                    sRet += "Wed"
                Case 5
                    sRet += "Thu"
                Case 6
                    sRet += "Fri"
                Case 7
                    sRet += "Sat"
            End Select
        End While

        dr.Close()

        Return sRet
    End Function

    Protected Function GetDayDesc(ByVal sScheduleId As String) As String
        If sScheduleId = "" Then
            Return ""
        End If

        Dim oHelper As New Helper
        Dim sSql As String = "SELECT DayId FROM ScheduleDay WHERE ScheduleId = " & sScheduleId
        Dim dr As OleDb.OleDbDataReader = oHelper.GetDataReader(sSql)

        Dim sRet As String = ""

        While dr.Read
            Dim sKey As String = dr.GetValue(0) & ""

            If sRet <> "" Then
                sRet += ", "
            End If

            Dim sValue As String = dr.GetValue(0) & ""
            If sValue = "32" Then
                sRet += "Last"
            Else
                sRet += sValue
            End If

        End While

        dr.Close()

        Return sRet
    End Function

End Class
