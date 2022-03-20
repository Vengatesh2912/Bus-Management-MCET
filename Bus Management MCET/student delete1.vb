Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Data.OleDb

Public Class student_delete1
    Dim cn As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim dr As MySqlDataReader
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim dv As DataView
    Dim drv As DataRowView
    Dim dt As New DataTable
    Dim bsource As New BindingSource

    Private Sub student_delete1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New MySqlConnection
        cm = New MySqlCommand
        cn.ConnectionString = "Server=db4free.net; port= 3306;User id = mcetcse309; Password = vengatesh ; Database = college_bus; connect timeout=100000000; pooling=true"
        cn.Open()
        cm.Connection = cn
        cm.CommandText = "select roll_no from student_details"
        dr = cm.ExecuteReader
        While dr.Read
            ComboBox1.Items.Add(dr.GetString(0))
        End While
        dr.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.SelectedItem = "" Then
            MsgBox("Please Select any Roll Number for updating the details.")
        Else
            student_delete.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        student_details.Show()
        Me.Close()

    End Sub
End Class