Imports System.Data.Odbc

Public Class Schedule
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents chkSun As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkMon As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkTue As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkWed As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkThu As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFri As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkSat As System.Web.UI.WebControls.CheckBox

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

    Protected WithEvents chkDay13 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay28 As System.Web.UI.WebControls.CheckBox
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
    Protected WithEvents chkDay29 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay30 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDay31 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkDayLast As System.Web.UI.WebControls.CheckBox

    Protected WithEvents txtRepeatDays As System.Web.UI.WebControls.TextBox

    Protected WithEvents selWeekOfMonth As System.Web.UI.WebControls.DropDownList

    Protected WithEvents txtStartDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox

    Protected WithEvents rbAM As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbPM As System.Web.UI.WebControls.RadioButton

    Protected WithEvents selScheduleType As System.Web.UI.WebControls.DropDownList

    Protected WithEvents selStartHour As System.Web.UI.WebControls.DropDownList
    Protected WithEvents selStartMin As System.Web.UI.WebControls.DropDownList

    Protected WithEvents selEveryMinute As System.Web.UI.WebControls.DropDownList

    Protected WithEvents txtEveryHour As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRepeatWeek As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtScheduleName As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnName As System.Web.UI.WebControls.Panel

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

    End Sub


End Class
