Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Data.OleDb

Public Class student_insert
    Dim cn As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim dr As MySqlDataReader
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim dv As DataView
    Dim drv As DataRowView
    Dim dt As New DataTable
    Dim bsource As New BindingSource

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        student_details.Show()
        Me.Close()
    End Sub


    Private Sub student_insert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AutoScroll = True
        Try
            cn = New MySqlConnection

            With cn
                .ConnectionString = "Server=db4free.net; port= 3306;User id = mcetcse309; Password = vengatesh ; Database = college_bus; connect timeout=100000000;pooling=true"
                .Open()
                .Close()

            End With

        Catch ex As Exception
            MsgBox(ex.Message & "Unable to connect. please contact the system administrator!", vbExclamation)
            cn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            cn.Open()
            cm = New MySqlCommand("INSERT into student_details (`name`, `roll_no`,`department`, `year`, `stage`, `route`, `validity`, `date_of_fee_paid`, `bus_no`, `fee_status`) VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & ComboBox1.SelectedItem & "','" & ComboBox2.SelectedItem & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox3.SelectedItem & "','" & DateTimePicker1.Text & "','" & TextBox5.Text & "','" & ComboBox4.SelectedItem & "')", cn)
            cm.ExecuteNonQuery()

            MsgBox("Details have Registered Successfully", vbInformation)

            TextBox1.Clear()
            TextBox2.Clear()
            ComboBox1.ResetText()
            ComboBox2.ResetText()
            TextBox3.Clear()
            TextBox4.Clear()
            ComboBox3.ResetText()
            TextBox5.Clear()
            ComboBox4.ResetText()

           
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub
End Class