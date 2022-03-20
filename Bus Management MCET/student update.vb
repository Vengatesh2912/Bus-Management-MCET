Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Data.OleDb

Public Class student_update
    Dim cn As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim dr As MySqlDataReader
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim dv As DataView
    Dim drv As DataRowView
    Dim dt As New DataTable
    Dim bsource As New BindingSource

    Private Sub student_update_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.AutoScroll = True
        Try
            cn = New MySqlConnection
            cm = New MySqlCommand
            cn.ConnectionString = "Server=db4free.net; port= 3306;User id = mcetcse309; Password = vengatesh ; Database = college_bus; connect timeout=100000000; pooling=true"
            cn.Open()
            cm.Connection = cn
            da = New MySqlDataAdapter("select * from student_details where roll_no='" & student_update1.ComboBox1.SelectedItem & "' ", cn)
            ds = New Data.DataSet
            If da.Fill(ds, "student_details") Then
                dv = New Data.DataView(ds.Tables("student_details"))
                drv = dv(0)
                TextBox1.Text = drv(1)
                TextBox2.Text = drv(0)
                ComboBox1.SelectedItem = drv(2)
                ComboBox2.SelectedItem = drv(3)
                TextBox3.Text = drv(4)
                TextBox4.Text = drv(5)
                ComboBox3.SelectedItem = drv(6)
                DateTimePicker1.Text = drv(7)
                TextBox5.Text = drv(8)
                ComboBox4.SelectedItem = drv(9)

            End If
        Catch ex As Exception
            MsgBox(ex.Message & "Unable to connect. please contact the system administrator!", vbExclamation)
            cn.Close()
        End Try
    End Sub
 

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        student_update1.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cm.CommandText = "UPDATE `student_details` SET roll_no = '" & TextBox1.Text & "', name= '" & TextBox2.Text & "', department = '" & ComboBox1.SelectedItem & "', year = '" & ComboBox2.SelectedItem & "', stage= '" & TextBox3.Text & "', route='" & TextBox4.Text & "',validity = '" & ComboBox3.SelectedItem & "', date_of_fee_paid = '" & DateTimePicker1.Text & "', bus_no = '" & TextBox5.Text & "', fee_status = '" & ComboBox4.SelectedItem & "' where roll_no= '" & TextBox1.Text & "'"
        cm.Connection = cn
        cm.ExecuteNonQuery()

        MsgBox("Details have Updated Successfully", vbInformation)

        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.ResetText()
        ComboBox2.ResetText()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        ComboBox3.ResetText()
        ComboBox4.ResetText()


    End Sub

End Class