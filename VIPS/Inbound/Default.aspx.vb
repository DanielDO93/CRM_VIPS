Imports System.Data.SqlClient

Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim x As New Funciones
    Dim Alerta As New Alertas
    Dim msgtipo(20) As Integer
    Dim msgmensaje(20) As String
    Public Function GetPassStatus(UserName As String) As Boolean

        Dim sql As String = "SELECT COUNT(*) FROM SYS_empleados WHERE id_ccs = @user AND (status = 2 OR status = 7) AND su IS NOT NULL"
        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("db").ToString())

            conn.Open()
            Dim cmd As New SqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@user", UserName)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If count = 0 Then
                Return False
            Else
                Return True

            End If

        End Using

    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("RVT") = Request.QueryString("rvt")
        Session("ANI") = Request.QueryString("ani")
        Session("ID_MITROL") = Request.QueryString("id_mitrol")
        Session("CAMPANIA") = Request.QueryString("campania")


        If Request.QueryString("sucess") = "true" Then
            msgtipo(0) = 1
            msgmensaje(0) = "¡Registro Guardado con Éxito!"
            Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
        Else
            Insert_Interaccion()
        End If


        Response.Redirect("http://10.0.0.40/Vips/js.html")
        'Response.Redirect("http://localhost:59264/js.html")

    End Sub


    Function Insert_Interaccion()

        If Not IsPostBack Then

            'Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
            'Dim strQuery As String = "INSERT INTO SYS_Interacciones (medio,fecha_ini,fecha_base,rvt,campania,id_interaccion,ani) OUTPUT Inserted.ID VALUES ('1',GETDATE(),GETDATE(),'" & Session("RVT") & "', '" & Session("CAMPANIA") & "','" & Session("ID_MITROL") & "','" & Session("ANI") & "')"
            'Dim con As New SqlConnection(strConnString)
            'Dim cmd As New SqlCommand()
            'cmd.CommandType = CommandType.Text
            'cmd.CommandText = strQuery
            'cmd.Connection = con

            'con.Open()
            'cmd.ExecuteNonQuery()

            'con.Close()


            Dim conexion As New SqlConnection(ConfigurationManager.ConnectionStrings("VIPS").ToString)
            Dim da As New System.Data.SqlClient.SqlDataAdapter
            Dim ds As New System.Data.DataSet
            Dim cmd As SqlCommand = New SqlCommand("INSERT INTO SYS_Interacciones (medio,fecha_ini,fecha_base,rvt,campania,id_interaccion,ani) OUTPUT Inserted.ID VALUES ('1',GETDATE(),GETDATE(),'" & Session("RVT") & "', '" & Session("CAMPANIA") & "','" & Session("ID_MITROL") & "','" & Session("ANI") & "')", conexion)

            conexion.Open()
            cmd.CommandType = CommandType.Text
            da.SelectCommand = cmd
            da.Fill(ds)
            conexion.Close()

            Session("ID") = ds.Tables(0).Rows(0).Item(0).ToString



        End If

        Return True
    End Function

End Class