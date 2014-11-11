Public Class Form1

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox3.Text = CStr(CInt(TextBox1.Text) - CInt(TextBox2.Text))
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox3.Text = CStr(CInt(TextBox1.Text) + CInt(TextBox2.Text))
    End Sub
End Class
