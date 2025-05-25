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
        Return "File Name = " & System.Web.HttpContext.Current.Server.MapPath("connect.udl")
    End Function

    Public Sub SetSelect(ByVal oSelect As System.Web.UI.WebControls.ListBox, _
                         ByVal sSql As String)

        Dim dt As DataTable = GetTable(sSql)
        Dim sKey As String
        Dim sValue As String
        Dim bTwoColumns As Boolean = dt.Columns.Count > 1

        For i As Int32 = 0 To dt.Rows.Count - 1
            sKey = dt.Rows(i)(0).ToString()

            If bTwoColumns Then
                sValue = dt.Rows(i)(1).ToString()
            Else
                sValue = sKey
            End If

            oSelect.Items.Add(New System.Web.UI.WebControls.ListItem(sValue, sKey))
        Next
    End Sub

    Public Sub SetSelect(ByVal oSelect As System.Web.UI.WebControls.DropDownList, _
                         ByVal sSql As String)

        Dim dt As DataTable = GetTable(sSql)
        Dim sKey As String
        Dim sValue As String
        Dim bTwoColumns As Boolean = dt.Columns.Count > 1

        For i As Int32 = 0 To dt.Rows.Count - 1
            sKey = dt.Rows(i)(0).ToString()

            If bTwoColumns Then
                sValue = dt.Rows(i)(1).ToString()
            Else
                sValue = sKey
            End If

            oSelect.Items.Add(New System.Web.UI.WebControls.ListItem(sValue, sKey))
        Next
    End Sub

    Public Function GetTable(ByVal sSql As String, _
                         Optional ByVal sConnectionString As String = "") As System.Data.DataTable
        Dim cn As OleDbConnection
        cn = New OleDbConnection(GetConnectionString())
        cn.Open()

        Dim ad As OleDbDataAdapter = New OleDbDataAdapter(sSql, cn)
        Dim ds As DataSet = New DataSet

        ad.Fill(ds)
        cn.Close()
        Return ds.Tables(0)
    End Function

End Class
