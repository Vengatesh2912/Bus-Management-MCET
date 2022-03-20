Imports System.Data.SqlClient
Imports System.Net.Mail
Imports MySql.Data.MySqlClient

Public Class reset_password
    Dim cn As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim dr As MySqlDataReader
    Dim da As MySqlDataAdapter
    Dim dv As DataView
    Dim drv As DataRowView
    Dim ds As DataSet

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        login.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim smtp_server As New SmtpClient
        Dim gmail As New MailMessage
        smtp_server.UseDefaultCredentials = False
        smtp_server.Credentials = New Net.NetworkCredential("mcetproject309@gmail.com", "Aandavar_project309")
        smtp_server.Port = 587
        smtp_server.EnableSsl = True
        smtp_server.Host = "smtp.gmail.com"
        gmail = New MailMessage
        gmail.From = New MailAddress("mcetproject309@gmail.com")
        gmail.To.Add(TextBox1.Text)
        gmail.IsBodyHtml = False
        gmail.Subject = "Verification for changing the Password"
        gmail.Body = "Your verification request is accepted. Click this 'https://mcetmentor.000webhostapp.com/adminlogin/Reset password.html' to Reset the password.     'Please check your junk mail if the mail is not recieved'.  "
        smtp_server.Send(gmail)
        MsgBox("Mail is sent to your account")
        TextBox1.Clear()
    End Sub

End Class