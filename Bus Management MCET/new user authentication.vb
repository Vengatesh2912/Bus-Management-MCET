﻿Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Public Class new_user_authentication
    Dim cn As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim dr As MySqlDataReader
    Dim da As MySqlDataAdapter
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        login.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cm As New MySqlCommand("SELECT `mail_id`, `password` FROM `admin_login` WHERE `mail_id`= @mailid AND `password`= @password", cn)

        cm.Parameters.Add("@mailid", MySqlDbType.VarChar).Value = TextBox1.Text
        cm.Parameters.Add("@password", MySqlDbType.VarChar).Value = TextBox2.Text

        Dim da As New MySqlDataAdapter(cm)
        Dim table As New DataTable()

        da.Fill(table)

        If table.Rows.Count = 0 Then
            MessageBox.Show("Invalid Username Or Password")
        Else
            MessageBox.Show("Authentication Successfull")

            new_user.Show()
            Me.Close()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If TextBox2.UseSystemPasswordChar = True Then
            ' show password

            TextBox2.UseSystemPasswordChar = False

        Else
            ' hide password
            TextBox2.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub new_user_authentication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With cn
                .ConnectionString = "Server=db4free.net; port= 3306; User id = mcetcse309 ; Password = vengatesh; Database = college_bus; connect timeout=10000000; pooling=true"
                .Open()
                .Close()
            End With

        Catch ex As Exception
            MsgBox(ex.Message & "Unable to connect. Please Contact the System Administrator!", vbExclamation)
            cn.Close()
        End Try
    End Sub
End Class