Imports System.Data.Odbc

Module Conexion_ODBC

    Dim conexionODBC As New OdbcConnection

    Public Sub Conectar(conexion As String)
        conexionODBC.ConnectionString = conexion

        Try

            conexionODBC.Open()

        Catch ex As OdbcException
            MsgBox(ex.ToString())
        End Try

    End Sub

    Public Sub Cerrar()
        conexionODBC.Close()
    End Sub


    Public Function Consultar(query As String) As DataTable
        Dim datos As New DataTable
        Dim adaptador As New OdbcDataAdapter(query, conexionODBC)
        adaptador.Fill(datos)
        Return datos
    End Function

    Public Function ConexionInformix() As String
        Dim cnx As String

        cnx = "
            
        Driver ={IBM INFORMIX ODBC DRIVER};
        Database = miBD;
        Host = MI IP desde donde me estoy conectando;
        Server = miServidor;
        Services = 50000;
        Protocol = onsoctcp;
        UID = miuser;
        PWD = mipwd;

        "
        Return cnx

    End Function


End Module
