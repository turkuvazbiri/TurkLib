Public Class Form3
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.surumkontrol = CheckBox1.Checked
        ' Değişikliği kaydetmek için Save yöntemini çağırın
        My.Settings.Save()

        ' Değişikliği uygulamak için Reload yöntemini çağırın (isteğe bağlı)
        My.Settings.Reload()

        ' Değişiklik yapıldı mesajını gösterin
        MessageBox.Show("Ayarlar değiştirildi.", "Ayar Değiştirildi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.surumkontrol = True Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
    End Sub
End Class