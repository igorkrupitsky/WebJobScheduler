Imports System.ServiceProcess

Public Class JobScheduler
    Inherits System.ServiceProcess.ServiceBase

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        ' This call is required by the Component Designer.
        InitializeComponent()

        If (Not System.Diagnostics.EventLog.SourceExists("JobSchedulerSourse")) Then
            System.Diagnostics.EventLog.CreateEventSource("JobSchedulerSourse", "JobSchedulerLog")
        End If

        EventLog1.Source = "JobSchedulerSourse"
        EventLog1.Log = "JobSchedulerLog"

        Timer1.Interval = 1000 * 60
        Timer1.Enabled = True

    End Sub

    'UserService overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' The main entry point for the process
    <MTAThread()> _
    Shared Sub Main()
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase

        ' More than one NT Service may run within the same process. To add
        ' another service to this process, change the following line to
        ' create a second service object. For example,
        '
        '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
        '
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New JobScheduler}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  
    ' Do not modify it using the code editor.
    Friend WithEvents EventLog1 As System.Diagnostics.EventLog
    Friend WithEvents Timer1 As System.Timers.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.EventLog1 = New System.Diagnostics.EventLog
        Me.Timer1 = New System.Timers.Timer
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 60000
        '
        'JobScheduler
        '
        Me.ServiceName = "Service1"
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private sServiceName As String = "Web Job Scheduler"

    Protected Overrides Sub OnStart(ByVal args() As String)
        EventLog1.WriteEntry(sServiceName & " started")
        Timer1.Enabled = True
    End Sub

    Protected Overrides Sub OnStop()
        EventLog1.WriteEntry(sServiceName & " stoped")
        Timer1.Enabled = False
    End Sub

    Protected Overrides Sub OnContinue()
        EventLog1.WriteEntry(sServiceName & " is continuing in working")
        Timer1.Enabled = True
    End Sub

    Protected Overrides Sub OnPause()
        EventLog1.WriteEntry(sServiceName & " is pausing")
        Timer1.Enabled = False
    End Sub

    Protected Overrides Sub OnShutdown()
        EventLog1.WriteEntry(sServiceName & " is shuting down")
    End Sub

    Private Sub Timer1_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer1.Elapsed

        Dim sSql As String
        Dim oHelper As New Helper
        Dim dr As OleDb.OleDbDataReader = oHelper.GetDataReader("exec GetJobsToRun")
        While dr.Read
            'JobId, JobType, CommandText, JobName
            Dim sJobId As String = dr.GetValue(dr.GetOrdinal("JobId")) & ""
            Dim sJobType As String = dr.GetValue(dr.GetOrdinal("JobType")) & ""
            Dim sCommandText As String = dr.GetValue(dr.GetOrdinal("CommandText")) & ""

            sSql = "INSERT INTO JobHistory (JobId, StartTime) VALUES (" & sJobId & ", GETDATE()); select @@IDENTITY"
            Dim sJobHistoryId As String = oHelper.ExecuteScalar(sSql)

            'System.Diagnostics.Debugger.Launch()

            'Do Action
            Dim sStatus As String = "Done"
            Dim sRet As String

            Try
                sRet = RunDosCommand(sCommandText, 10)
            Catch ex As Exception
                sStatus = "Error"
                sRet = Err.Description
            End Try

            If sRet.IndexOf("ExitCode: ") <> -1 Then
                sStatus = "Error"
            ElseIf sRet = "Timeout" Then
                sStatus = "Timeout"
            End If

            sSql = "UPDATE Job SET LastRunTime = GETDATE(), LastStatus = '" & sStatus & "' WHERE JobId = " & sJobId
            oHelper.ExecuteSql(sSql)

            sSql = "UPDATE JobHistory SET ReturnText = '" & oHelper.PadQuotes(sRet) & "', EndTime = GETDATE(), Status = '" & sStatus & "' WHERE HistoryId = " & sJobHistoryId
            oHelper.ExecuteSql(sSql)

        End While

    End Sub

    Function RunDosCommand(ByVal sCommandText As String, Optional ByVal iTimeOutSec As Integer = 1) As String

        Dim iPos As Integer = sCommandText.IndexOf(" ")
        Dim sFileName As String
        Dim sArguments As String = ""

        If iPos = -1 Then
            sFileName = sCommandText
        Else
            sFileName = sCommandText.Substring(0, iPos)
            sArguments = sCommandText.Substring(iPos + 1)
        End If

        Dim sRet As String
        Dim oProcess As Process = New Process

        oProcess.StartInfo.UseShellExecute = False
        oProcess.StartInfo.RedirectStandardOutput = True
        oProcess.StartInfo.FileName = sFileName
        oProcess.StartInfo.Arguments = sArguments
        oProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        oProcess.StartInfo.CreateNoWindow = True
        oProcess.Start()

        oProcess.WaitForExit(1000 * iTimeOutSec)
        If Not oProcess.HasExited Then
            oProcess.Kill()
            Return "Timeout"
        End If

        sRet = oProcess.StandardOutput.ReadToEnd()

        If oProcess.ExitCode <> 0 And sRet = "" Then
            sRet = "ExitCode: " & oProcess.ExitCode
        End If

        oProcess.Close()

        Return sRet
    End Function

End Class
