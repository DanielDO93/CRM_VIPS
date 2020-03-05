Imports System.Data.SqlClient
Public Class Tiendas
    Inherits System.Web.UI.Page

    Dim x As New Funciones
    Dim Alerta As New Alertas
    Dim msgtipo(20) As Integer
    Dim msgmensaje(20) As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load






        If IsPostBack Then
            Dim CtrlID As String = String.Empty
            If Request.Form("__EVENTTARGET") IsNot Nothing And
               Request.Form("__EVENTTARGET") <> String.Empty Then
                CtrlID = Request.Form("__EVENTTARGET")
            Else
            End If
            Session("ElControl") = Mid(CtrlID, InStrRev(CtrlID, "$") + 1)

            'Cambiale()

        End If


        LoadTiendas()
    End Sub

    Sub LoadTiendas()

        Dim conexion As New SqlConnection(ConfigurationManager.ConnectionStrings("VIPS").ToString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet
        Dim cmd As SqlCommand = New SqlCommand("SELECT id_tienda,nombre_tienda,statusDelivery FROM CRM_VIPS.dbo.SYS_Tiendas WHERE status=1 ORDER BY nombre_tienda", conexion)


        conexion.Open()
        cmd.CommandType = CommandType.Text
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()


        For Index = 1 To ds.Tables(0).Rows.Count

            Panel1.Controls.Add(New LiteralControl("<div class='form_default'>"))
            Panel1.Controls.Add(New LiteralControl("<ul>"))

            For Column = 1 To 3

                If Column = 1 Then

                    Panel1.Controls.Add(New LiteralControl("<div class='lista_aca'>"))
                    Panel1.Controls.Add(New LiteralControl("<li>"))
                    Dim Seguimiento As New Label
                    Seguimiento.ID = "LabelTienda" & Index
                    Seguimiento.Text = ds.Tables(0).Rows(Index - 1).Item(0)
                    Seguimiento.CssClass = "textos"
                    Panel1.Controls.Add(Seguimiento)
                    Panel1.Controls.Add(New LiteralControl("</div>"))

                ElseIf Column = 2 Then
                    Panel1.Controls.Add(New LiteralControl("<div class='lista_aca' style='text-align:left;'>"))
                    Dim Seguimiento As New Label
                    Seguimiento.ID = "LabelTiendaNombre" & Index
                    Seguimiento.Text = ds.Tables(0).Rows(Index - 1).Item(1)
                    Seguimiento.CssClass = "textos"
                    Panel1.Controls.Add(Seguimiento)
                    Panel1.Controls.Add(New LiteralControl("</div>"))
                ElseIf Column = 3 Then
                    Panel1.Controls.Add(New LiteralControl("<div class='lista_aca'>"))
                    Dim Seguimiento As New CheckBox
                    Seguimiento.ID = "CBT" & Index
                    If ds.Tables(0).Rows(Index - 1).Item(2) = 1 Then
                        Seguimiento.Checked = True
                    Else
                        Seguimiento.Checked = False
                    End If
                    Seguimiento.Text = " "
                    Seguimiento.CssClass = "textos"
                    Seguimiento.AutoPostBack = True
                    AddHandler Seguimiento.CheckedChanged, AddressOf Cambiale
                    Panel1.Controls.Add(Seguimiento)

                    Panel1.Controls.Add(New LiteralControl("</div>"))
                    Panel1.Controls.Add(New LiteralControl("</li>"))
                End If
            Next
            Panel1.Controls.Add(New LiteralControl("</ul>"))
            Panel1.Controls.Add(New LiteralControl("</div>"))
        Next



    End Sub


    Sub Cambiale(ByVal sender As Object, ByVal e As EventArgs)

        Dim CB As CheckBox = DirectCast(sender, CheckBox)

        CambioCheck()

    End Sub

    Function GetLD(Lista As Integer, Tienda As String) As String

        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String = "EXEC [dbo].[GET_Lista_Distribucion] @LD = " & Lista & ", @TIENDA = '" & Tienda & "'"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con

        con.Open()

        cmd.CommandText = strQuery
        cmd.CommandType = CommandType.Text
        da.SelectCommand = cmd
        da.Fill(ds)
        con.Close()

        Return ds.Tables(0).Rows(0).Item(2).ToString

    End Function

    Sub CambioCheck()
        Dim IDMODIF As String
        IDMODIF = Session("ElControl")
        IDMODIF = IDMODIF.TrimStart("C", "B", "T")
        Dim Tienda As String = CType(UpdatePanel1.Parent.FindControl("LabelTienda" & IDMODIF), Label).Text
        Dim status As Integer

        If CType(tiendasMod.Parent.FindControl(Session("ElControl")), CheckBox).Checked = True Then
            status = 1
        Else
            status = 0
        End If

        Dim conexion As New SqlConnection(ConfigurationManager.ConnectionStrings("VIPS").ToString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet
        Dim cmd As SqlCommand = New SqlCommand("UPDATE CRM_VIPS.dbo.SYS_Tiendas SET statusDelivery='" & status & "' WHERE id_tienda ='" & Tienda & "'", conexion)
        conexion.Open()
        cmd.CommandType = CommandType.Text
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()

        Dim LD As String = GetLD(1, Tienda)

        Dim MensajeOpen As String = "<html><body><h1>Se ha abierto la tienda " & Tienda & " - " & CType(UpdatePanel1.Parent.FindControl("LabelTiendaNombre" & IDMODIF), Label).Text & "</h1></body></html>"
        Dim MensajeClose As String = "<html><body><h1>Se ha cerrado la tienda " & Tienda & " - " & CType(UpdatePanel1.Parent.FindControl("LabelTiendaNombre" & IDMODIF), Label).Text & "</h1></body></html>"


        If status = 1 Then
            msgtipo(0) = 1
            msgmensaje(0) = "¡Abriste la tienda " & Tienda & " - " & CType(UpdatePanel1.Parent.FindControl("LabelTiendaNombre" & IDMODIF), Label).Text & "!"
            Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
            'Alerta.EnviarMail2(LD, "nancy.souberbielle@ccscontactcenter.com, alejandra.lopez@ccscontactcenter.com, isai.hernandez@ccscontactcenter.com,luis.velez@ccsolutions.com.mx, alberto.trejo@ccsolutions.com.mx", "***TIENDA ABIERTA***", MensajeOpen)
        Else
            msgtipo(0) = 4
            msgmensaje(0) = "¡Cerraste la tienda " & Tienda & " - " & CType(UpdatePanel1.Parent.FindControl("LabelTiendaNombre" & IDMODIF), Label).Text & "!"
            Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
            'Alerta.EnviarMail2(LD, "nancy.souberbielle@ccscontactcenter.com, alejandra.lopez@ccscontactcenter.com, isai.hernandez@ccscontactcenter.com,luis.velez@ccsolutions.com.mx, alberto.trejo@ccsolutions.com.mx", "***TIENDA CERRADA***", MensajeClose)
        End If

    End Sub

End Class