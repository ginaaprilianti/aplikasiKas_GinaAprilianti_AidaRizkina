Imports System.Data.Odbc
Public Class Form1
    Sub TampilGrid()
        bukakoneksi()

        DA = New OdbcDataAdapter("select * From tb_kas", CONN)
        DS = New DataSet
        DA.Fill(DS, "tb_kas")
        DataGridView1.DataSource = DS.Tables("tb_kas")

        tutupkoneksi()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label7.Text = "500000"
        TampilGrid()
    End Sub
    Sub KosongkanData()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox1.Items.Add("Masuk")
        ComboBox1.Items.Add("Keluar")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or DateTimePicker1.Text = "" Or ComboBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Silahkan Isi Semua Form")
        Else
            bukakoneksi()
            Dim simpan As String = "insert into tb_kas values ('" & TextBox1.Text & "','" & DateTimePicker1.Text & "','" & ComboBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"

            CMD = New OdbcCommand(simpan, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Input data berhasil")
            TampilGrid()
            KosongkanData()

            tutupkoneksi()
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        bukakoneksi()
        Dim edit As String = "update tb_kas set
        id = '" & TextBox1.Text & "'
        tanggal = '" & DateTimePicker1.Text & "'
        jenis = '" & ComboBox1.Text & "'
        jumlah = '" & TextBox2.Text & "'
        keterangan = '" & TextBox3.Text & "' where id = '" & TextBox1.Text & "'"

        CMD = New OdbcCommand(edit, CONN)
        CMD.ExecuteNonQuery()
        MsgBox("Data Berhasil diUpdate")
        TampilGrid()
        KosongkanData()
        tutupkoneksi()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MsgBox("Silahkan Pilih Data yang akan di hapus dengan Masukan id dan Enter")
        Else
            If MessageBox.Show("Yakin akan dihapus..?", "", MessageBoxButtons.YesNo) = Windows.Form1.DialogResults.Yes Then
                bukakoneksi()
                Dim hapus As String = "delete From tb_kas where tanggal ='" & TextBox1.Text & "'"
                CMD = New OdbcCommand(hapus, CONN)
                CMD.ExecuteNonQuery()
                TampilGrid()
                KosongkanData()
                tutupkoneksi()
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
