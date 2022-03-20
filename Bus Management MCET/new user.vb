Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Public Class new_user
    Dim cn As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim dr As MySqlDataReader
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim dv As DataView
    Dim drv As DataRowView
    Dim dt As New DataTable
    Dim bsource As New BindingSource
    Private Sub new_user_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cn = New MySqlConnection

            With cn
                .ConnectionString = "server=db4free.net; port= 3306;User id = mcetcse309; Password = vengatesh ; Database = college_bus; connect timeout=100000000;pooling=true"
                .Open()
                .Close()

            End With

        Catch ex As Exception
            MsgBox(ex.Message & "Unable to Connect. Please Contact the System Administrator!", vbExclamation)
            cn.Close()
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        login.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            cn.Open()
            cm = New MySqlCommand("INSERT INTO admin_login (name , staff_id , ph_no, mail_id, password )values ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "' )", cn)

            cm.ExecuteNonQuery()


            MsgBox("Details have Registered Successfully", vbInformation)

            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()

            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If TextBox5.UseSystemPasswordChar = True Then
            ' show password

            TextBox5.UseSystemPasswordChar = False

        Else
            ' hide password
            TextBox5.UseSystemPasswordChar = True

        End If
    End Sub
End Class