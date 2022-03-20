Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Data.OleDb

Public Class student_view
    Dim cn As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim dr As MySqlDataReader
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim dv As DataView
    Dim drv As DataRowView
    Dim dt As New DataTable
    Dim bsource As New BindingSource

    Private Sub student_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New MySqlConnection
        cm = New MySqlCommand
        cn.ConnectionString = "Server=db4free.net; port= 3306;User id = mcetcse309; Password = vengatesh ; Database = college_bus; connect timeout=100000000; pooling=true"
        cn.Open()
        cm.Connection = cn
        cm.CommandText = "select roll_no, bus_no from student_details"
        dr = cm.ExecuteReader
        While dr.Read
            ComboBox1.Items.Add(dr.GetString(0))

        End While
        dr.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cn = New MySqlConnection
        cn.ConnectionString = "Server=db4free.net; port= 3306;User id = mcetcse309; Password = vengatesh ; Database = college_bus; connect timeout=100000000; pooling=true"
        Dim da As New MySqlDataAdapter
        Dim dt As New DataTable
        Dim bsource As New BindingSource
        Try
            cn.Open()
            Dim Query As String
            Query = "SELECT * FROM `student_details` WHERE `roll_no` = '" & ComboBox1.SelectedItem & "'  "
            cm = New MySqlCommand(Query, cn)
            da.SelectCommand = cm
            da.Fill(dt)
            bsource.DataSource = dt
            DataGridView1.DataSource = bsource
            da.Update(dt)

            cn.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            cn.Dispose()

        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        student_details.Show()
        Me.Close()

    End Sub
End Class