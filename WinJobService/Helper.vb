Imports System.Data.OleDb

Public Class Helper

    Friend Sub ExecuteSql(ByVal sSql As String)
        Dim cn As New OleDb.OleDbConnection(GetConnectionString())
        cn.Open()
        Dim cm As New OleDb.OleDbCommand(sSql, cn)
        cm.ExecuteNonQuery()
        cn.Close()
    End Sub

    Friend Function ExecuteScalar(ByVal sSql As String) As String
        Dim cn As New OleDb.OleDbConnection(GetConnectionString())
        cn.Open()
        Dim cm As New OleDb.OleDbCommand(sSql, cn)
        Dim sRet As String = cm.ExecuteScalar()
        cn.Close()
        Return sRet
    End Function

    Friend Function GetDataReader(ByVal sSql As String) As OleDb.OleDbDataReader
        Dim cn As New OleDb.OleDbConnection(GetConnectionString())
        cn.Open()
        Dim cm As New OleDb.OleDbCommand(sSql, cn)
        Return cm.ExecuteReader(CommandBehavior.CloseConnection)
    End Function

    Private Function GetConnectionString() As String
        Dim sFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory() & "connect.udl"
		Return "File Name = " & sFilePath
    End Function

    Function PadQuotes(ByVal s As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(s, "'", "''")
    End Function

End Class
