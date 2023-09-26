Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing



Public Class Form1
    Dim yoneticitiki As Boolean = False
    ' INI dosyasının yolu
    Private ayarDosyaYolu As String = "ayar.ini"


    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Ayarları kaydet
        AyarlariKaydet()
    End Sub

    Private Sub AyarlariOku()
        ' INI dosyasını oku
        If File.Exists(ayarDosyaYolu) Then
            Using sr As New StreamReader(ayarDosyaYolu)
                While Not sr.EndOfStream
                    Dim satir As String = sr.ReadLine()
                    Dim veriler As String() = satir.Split(","c) ' Ayarları virgülle ayır

                    If veriler.Length = 3 Then
                        ' ListView'e öğe ekleyin
                        Dim item As New ListViewItem(veriler(0))
                        item.SubItems.Add(veriler(1))
                        item.SubItems.Add(veriler(2))
                        ListView1.Items.Add(item)
                    End If
                End While
            End Using
        End If
    End Sub

    Private Sub AyarlariKaydet()
        ' INI dosyasına ayarları kaydet
        Using sw As New StreamWriter(ayarDosyaYolu)
            For Each item As ListViewItem In ListView1.Items
                Dim oyunAdi As String = item.SubItems(0).Text
                Dim oyunBoyutu As String = item.SubItems(1).Text
                Dim oyunYolu As String = item.SubItems(2).Text

                ' Ayarları virgülle ayırarak INI dosyasına yaz
                sw.WriteLine($"{oyunAdi},{oyunBoyutu},{oyunYolu}")
            Next
        End Using
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim yoneticitiki As Boolean = False

        Dim kullaniciAdi As String = Environment.UserName
        Label2.Text = kullaniciAdi

        AyarlariOku()
        Dim itemSayisi As String = ListView1.Items.Count.ToString()
        Label3.Text = "Şu anda " + itemSayisi + " adet oyunun var."
    End Sub

    Public Sub ListViewItemEkle(ad_v As String, boyut_v As String, yol_v As String)
        Dim item As New ListViewItem(ad_v)
        item.SubItems.Add(boyut_v)
        item.SubItems.Add(yol_v)
        ListView1.Items.Add(item)


    End Sub



    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim itemSayisi As String = ListView1.Items.Count.ToString()
        Label3.Text = "Şu anda " + itemSayisi + " adet oyunun var."
        Dim form2 As New Form2(Me) ' Form1 referansını Form2'ye iletiyoruz

        form2.Show()

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim itemSayisi As String = ListView1.Items.Count.ToString()
        Label3.Text = "Şu anda " + itemSayisi + " adet oyunun var."
        If ListView1.SelectedItems.Count > 0 Then
            Dim secilenItem As ListViewItem = ListView1.SelectedItems(0) ' İlk seçili öğeyi al
            Dim dosyaYolu As String = secilenItem.SubItems(2).Text ' "Dosya Yolu" alt öğesini al

            ' dosyaYolu'nu kullanarak bir programı başlatma işlemi
            Try
                Process.Start(dosyaYolu)
            Catch ex As Exception
                MessageBox.Show("Program başlatma hatası: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim itemSayisi As String = ListView1.Items.Count.ToString()
        Label3.Text = "Şu anda " + itemSayisi + " adet oyunun var."

        If ListView1.SelectedItems.Count > 0 Then
            For Each item As ListViewItem In ListView1.SelectedItems
                ListView1.Items.Remove(item)
            Next
        Else
            MessageBox.Show("Lütfen silmek istediğiniz öğeyi seçin.")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        If ListView1.SelectedItems.Count > 0 Then
            Dim subItem2 As String = ListView1.SelectedItems(0).SubItems(2).Text ' subitem2'deki dosya yolu
            If File.Exists(subItem2) AndAlso subItem2.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) Then
                ' .exe dosyasının simgesini al
                Dim icon As Icon = Icon.ExtractAssociatedIcon(subItem2)

                ' İlgili simgeyi ListViewItem'e ekleyin
                ListView1.SelectedItems(0).ImageKey = subItem2
                ImageList1.Images.Add(subItem2, icon)
            Else
                MessageBox.Show("Geçerli bir .exe dosyası bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub


End Class
