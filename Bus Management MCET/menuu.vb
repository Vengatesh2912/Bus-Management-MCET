Public Class menuu

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        student_details.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        login.Show()
        Me.Close()

    End Sub
End Class