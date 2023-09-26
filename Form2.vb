Imports System.IO
Imports System.Windows.Forms

Public Class Form2
    Private _form1 As Form1
    Public Sub New(form1 As Form1)
        InitializeComponent()
        _form1 = form1
    End Sub

    Dim satirlar As New List(Of String)



    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim ad_v As String = TextBox1.Text
        Dim boyut_v As String = TextBox2.Text
        Dim yol_v As String = TextBox3.Text

        ' Form1'deki ListView'e öğe eklemek için Form1 referansını kullanın

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Executable Files (*.exe)|*.exe"
        openFileDialog.Title = "Exe Dosyası Seçin"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim secilenDosyaYolu As String = openFileDialog.FileName

            ' Dosyanın .exe uzantısını kontrol edin
            If Path.GetExtension(secilenDosyaYolu).ToLower() = ".exe" Then
                TextBox3.Text = secilenDosyaYolu
            Else
                MessageBox.Show("Lütfen sadece .exe uzantılı bir dosya seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
End Class