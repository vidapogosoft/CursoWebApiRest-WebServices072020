Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conectar(ConexionInformix)

        dgTabla.DataSource = Consultar("Select * from MiTabla")

    End Sub
End Class
