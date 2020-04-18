Imports System.Data.SqlClient
Imports Newtonsoft.Json
Public Class Monitoreo
    Inherits System.Web.UI.Page

    Dim x As New Funciones
    Dim Alerta As New Alertas
    Dim msgtipo(20) As Integer
    Dim msgmensaje(20) As String

    Function GetCorreo(ByVal Tienda As String) As String

        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String = "SELECT  gerente + ', ' + distrital + ', ' + regional  as LD  FROM [CRM_VIPS].[dbo].[SYS_Tiendas] WHERE id_tienda = '" & Tienda & "'"
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

        Return ds.Tables(0).Rows(0).Item(0).ToString

    End Function

    Sub ComboTiendasQuejas()



        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String = "SELECT id_tienda as ID,CONVERT(NVARCHAR(MAX),id_tienda) + ' - '+ [nombre_tienda] Tienda FROM [CRM_VIPS].[dbo].[SYS_Tiendas] WHERE status= 1 ORDER BY nombre_tienda"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()


        If Not IsPostBack Then

            DropDownList17.Items.Add(New ListItem("-Selecciona-", ""))
            DropDownList17.AppendDataBoundItems = True

            cmd.CommandType = CommandType.Text
            cmd.CommandText = strQuery
            cmd.Connection = con

            con.Open()

            DropDownList17.DataSource = cmd.ExecuteReader()
            DropDownList17.DataTextField = "Tienda"
            DropDownList17.DataValueField = "ID"
            DropDownList17.DataBind()

            con.Close()
            con.Dispose()

        End If

    End Sub

    Sub ComboTiendas()



        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String = "SELECT id_tienda as ID,CONVERT(NVARCHAR(MAX),id_tienda) + ' - '+ [nombre_tienda] Tienda FROM [CRM_VIPS].[dbo].[SYS_Tiendas] WHERE status= 1 ORDER BY nombre_tienda"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()


        If Not IsPostBack Then

            DropDownList15.Items.Add(New ListItem("-Selecciona-", ""))
            DropDownList15.AppendDataBoundItems = True

            cmd.CommandType = CommandType.Text
            cmd.CommandText = strQuery
            cmd.Connection = con

            con.Open()

            DropDownList15.DataSource = cmd.ExecuteReader()
            DropDownList15.DataTextField = "Tienda"
            DropDownList15.DataValueField = "ID"
            DropDownList15.DataBind()

            con.Close()
            con.Dispose()

        End If

    End Sub

    Sub ComboTiendasBusqueda()



        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String = "SELECT id_tienda as ID,CONVERT(NVARCHAR(MAX),id_tienda) + ' - '+ [nombre_tienda] Tienda FROM [CRM_VIPS].[dbo].[SYS_Tiendas] WHERE status= '1' ORDER BY nombre_tienda "
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()




        DropDownList16.Items.Add(New ListItem("-Selecciona-", ""))
            DropDownList16.AppendDataBoundItems = True

            cmd.CommandType = CommandType.Text
            cmd.CommandText = strQuery
            cmd.Connection = con

            con.Open()

            DropDownList16.DataSource = cmd.ExecuteReader()
            DropDownList16.DataTextField = "Tienda"
            DropDownList16.DataValueField = "ID"
            DropDownList16.DataBind()

            con.Close()
            con.Dispose()


    End Sub

    Sub ComboEstados()



        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String = "SELECT DISTINCT Estado FROM SYS_Codigos_Postales ORDER BY Estado"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()


        If Not IsPostBack Then

            DropDownList3.Items.Add(New ListItem("-Selecciona-", ""))
            DropDownList3.AppendDataBoundItems = True

            cmd.CommandType = CommandType.Text
            cmd.CommandText = strQuery
            cmd.Connection = con

            con.Open()

            DropDownList3.DataSource = cmd.ExecuteReader()
            DropDownList3.DataTextField = "estado"
            DropDownList3.DataValueField = "estado"
            DropDownList3.DataBind()

            con.Close()
            con.Dispose()

        End If

    End Sub

    Sub ComboDelMun()

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String = "SELECT DISTINCT municipio FROM SYS_Codigos_Postales WHERE estado = '" & DropDownList3.SelectedItem.Text & "' ORDER BY municipio"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()




        DropDownList2.Items.Add(New ListItem("-Selecciona-", ""))
        DropDownList2.AppendDataBoundItems = True

        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con

        con.Open()

        DropDownList2.DataSource = cmd.ExecuteReader()
        DropDownList2.DataTextField = "municipio"
        DropDownList2.DataValueField = "municipio"
        DropDownList2.DataBind()

        con.Close()
        con.Dispose()



    End Sub

    Sub ComboColonia()

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String = "SELECT DISTINCT asentamiento FROM SYS_Codigos_Postales WHERE estado = '" & DropDownList3.SelectedItem.Text & "' AND municipio = '" & DropDownList2.SelectedItem.Text & "' ORDER BY asentamiento"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()




        DropDownList1.Items.Add(New ListItem("-Selecciona-", ""))
        DropDownList1.AppendDataBoundItems = True

        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con

        con.Open()

        DropDownList1.DataSource = cmd.ExecuteReader()
        DropDownList1.DataTextField = "asentamiento"
        DropDownList1.DataValueField = "asentamiento"
        DropDownList1.DataBind()

        con.Close()
        con.Dispose()



    End Sub

    Sub ComboColoniaCP(CP As String)

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String = "SELECT DISTINCT asentamiento FROM SYS_Codigos_Postales WHERE codigo_postal = '" & CP & "' ORDER BY asentamiento"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()




        DropDownList1.Items.Add(New ListItem("-Selecciona-", ""))
        DropDownList1.AppendDataBoundItems = True

        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con

        con.Open()

        DropDownList1.DataSource = cmd.ExecuteReader()
        DropDownList1.DataTextField = "asentamiento"
        DropDownList1.DataValueField = "asentamiento"
        DropDownList1.DataBind()

        con.Close()
        con.Dispose()



    End Sub

    Sub SearchCP()

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim conexion As New SqlConnection(strConnString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        Dim cmd As SqlCommand = New SqlCommand("SELECT * FROM SYS_Codigos_Postales WHERE codigo_postal = '" & TextBox3.Text & "'", conexion)
        cmd.CommandType = CommandType.Text
        conexion.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()

        If ds.Tables(0).Rows.Count = 0 Then
            TextBox3.Text = Nothing
            msgtipo(0) = 4
            msgmensaje(0) = "¡El Código Postal no es válido!"
            Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
        ElseIf ds.Tables(0).Rows.Count = 1 Then

            DropDownList3.SelectedValue = ds.Tables(0).Rows(0).Item(3).ToString()
            DropDownList2.Items.Clear()
            ComboDelMun()
            DropDownList2.SelectedValue = ds.Tables(0).Rows(0).Item(2).ToString()

            DropDownList1.Items.Clear()
            ComboColonia()

            DropDownList1.SelectedValue = ds.Tables(0).Rows(0).Item(1).ToString()

        Else

            DropDownList3.SelectedValue = ds.Tables(0).Rows(0).Item(3).ToString()
            DropDownList2.Items.Clear()
            ComboDelMun()
            DropDownList2.SelectedValue = ds.Tables(0).Rows(0).Item(2).ToString()

            DropDownList1.Items.Clear()
            ComboColoniaCP(TextBox3.Text)

        End If



    End Sub

    Function GetMailingIndex(Tip_Index As String, Dropdown As DropDownList) As Integer

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim conexion As New SqlConnection(strConnString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        Dim cmd As SqlCommand = New SqlCommand("SELECT mailing_index FROM tip_n0" & Tip_Index & " WHERE id = '" & Dropdown.SelectedItem.Value & "'", conexion)
        cmd.CommandType = CommandType.Text
        conexion.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()

        Return ds.Tables(0).Rows(0).Item(0).ToString


    End Function

    Function GetLastLevel() As Integer

        If DropDownList11.Visible = True Then
            Return 5
        ElseIf DropDownList10.Visible = True And DropDownList5.SelectedItem.Text <> "No Venta" Then
            Return 4
        ElseIf DropDownList10.Visible = True And DropDownList5.SelectedItem.Text = "No Venta" Then
            Return 3
        ElseIf DropDownList6.Visible = True Then
            Return 3
        ElseIf DropDownList5.Visible = True Then
            Return 2
        ElseIf DropDownList4.Visible = True Then
            Return 1
        Else
            Return 0
        End If

    End Function



    Function GetLastLevelDD() As DropDownList

        If DropDownList11.Visible = True Then
            Return DropDownList11
        ElseIf DropDownList10.Visible = True And DropDownList5.SelectedItem.Text <> "No Venta" Then
            Return DropDownList10
        ElseIf DropDownList10.Visible = True And DropDownList5.SelectedItem.Text = "No Venta" Then
            Return DropDownList6
        ElseIf DropDownList6.Visible = True Then
            Return DropDownList6
        ElseIf DropDownList5.Visible = True Then
            Return DropDownList5
        ElseIf DropDownList4.Visible = True Then
            Return DropDownList5
        Else
            Return DropDownList12
        End If

    End Function

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

    Sub SearchColonia()

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim conexion As New SqlConnection(strConnString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        Dim cmd As SqlCommand = New SqlCommand("SELECT codigo_postal FROM SYS_Codigos_Postales WHERE estado = '" & DropDownList3.SelectedItem.Text & "' AND municipio = '" & DropDownList2.SelectedItem.Text & "' AND asentamiento = '" & DropDownList1.SelectedItem.Text & "'", conexion)
        cmd.CommandType = CommandType.Text
        conexion.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()

        Try
            TextBox3.Text = ds.Tables(0).Rows(0).Item(0).ToString()
        Catch ex As Exception
            TextBox3.Text = Nothing
        End Try


    End Sub

    Function NombreTienda(ByVal Tienda As String) As String

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim conexion As New SqlConnection(strConnString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        Dim cmd As SqlCommand = New SqlCommand("SELECT nombre_tienda FROM SYS_Tiendas WHERE id_tienda = '" & Tienda & "'", conexion)
        cmd.CommandType = CommandType.Text
        conexion.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()


        Return ds.Tables(0).Rows(0).Item(0).ToString()



    End Function

    Sub ComboTip1()

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String = "SELECT id,tip_n01 FROM tip_n01"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()


        If Not IsPostBack Then

            DropDownList4.Items.Add(New ListItem("-Selecciona-", ""))
            DropDownList4.AppendDataBoundItems = True

            cmd.CommandType = CommandType.Text
            cmd.CommandText = strQuery
            cmd.Connection = con

            con.Open()

            DropDownList4.DataSource = cmd.ExecuteReader()
            DropDownList4.DataTextField = "tip_n01"
            DropDownList4.DataValueField = "id"
            DropDownList4.DataBind()

            con.Close()
            con.Dispose()

        End If

    End Sub

    Function StatusDelivery(Tienda As String)


        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim conexion As New SqlConnection(strConnString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        Dim cmd As SqlCommand = New SqlCommand("SELECT id_tienda,statusDelivery FROM CRM_VIPS.dbo.SYS_Tiendas WHERE status= 1 and id_tienda = '" & Tienda & "'", conexion)
        cmd.CommandType = CommandType.Text
        conexion.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()

        Try



            If ds.Tables(0).Rows(0).Item(1) = 1 Then
                TextBox54.CssClass = "textboxGreen"
                Return True
            Else
                TextBox54.CssClass = "textboxRed"
                Return False
            End If

        Catch ex As Exception
            TextBox54.CssClass = "textbox"
            Return 404
        End Try

    End Function

    Sub StatusTienda()


        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim conexion As New SqlConnection(strConnString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        Dim cmd As SqlCommand = New SqlCommand("SELECT id_qp,token_qp,nombre_tienda,id_tienda,mercado FROM CRM_VIPS.dbo.SYS_Tiendas WHERE id_tienda = '" & DropDownList16.SelectedItem.Value & "'", conexion)
        cmd.CommandType = CommandType.Text
        conexion.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()

        Dim x As New Drive


        Try


            Dim m = JsonConvert.DeserializeObject(Of List(Of RepDisponibles))(x.GetRepDisponibles(ds.Tables(0).Rows(0).Item(0).ToString, ds.Tables(0).Rows(0).Item(1).ToString, "1", ds.Tables(0).Rows(0).Item(4).ToString))


            TextBox56.Text = ds.Tables(0).Rows(0).Item(3).ToString
            TextBox57.Text = ds.Tables(0).Rows(0).Item(2).ToString

            Dim Avail = From c In m Where c.estatus = "Libre" Select c


            TextBox58.Text = m.Count
            Dim Closest = From b In m Order By b.eta Select b
            TextBox59.Text = Avail.Count

            TextBox60.Text = Closest.ToList.Item(0).eta
            TextBox61.Text = Closest.ToList.Item(0).distancia

            GridView7.Visible = True
            GridView7.DataSource = m
            GridView7.DataBind()

        Catch ex As Exception

            GridView7.Visible = False
            TextBox56.Text = Nothing
            TextBox57.Text = Nothing
            TextBox58.Text = Nothing
            TextBox59.Text = Nothing
            TextBox60.Text = Nothing
            TextBox61.Text = Nothing

        End Try

    End Sub

    Sub UltimaInteraccion()


        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim conexion As New SqlConnection(strConnString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        Dim cmd As SqlCommand = New SqlCommand("SELECT CONVERT(NVARCHAR(10),fecha_base,103) as Fecha, Comentarios FROM [CRM_VIPS].[dbo].[SYS_Interacciones] WHERE id_cliente = '" & Session("CustomerID") & "' ORDER BY fecha_base desc", conexion)
        cmd.CommandType = CommandType.Text
        conexion.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()

        If ds.Tables(0).Rows.Count = 0 Then
            TextBox14.Text = "-"
        Else
            TextBox14.Text = ds.Tables(0).Rows(0).Item(0).ToString
            TextBox14.ToolTip = ds.Tables(0).Rows(0).Item(1).ToString
        End If



    End Sub

    Sub GetUltimoPedido()



        'Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        'Dim conexion As New SqlConnection(strConnString)
        'Dim da As New System.Data.SqlClient.SqlDataAdapter
        'Dim ds As New System.Data.DataSet

        'Dim cmd As SqlCommand = New SqlCommand("SELECT  CONVERT(NVARCHAR(10),fecha_pedido,103) as Fecha,LEFT((ISNULL(nombre_producto_1,'') +  ',' +ISNULL(nombre_producto_2,'') +  ',' +ISNULL(nombre_producto_3,'') +  ',' +ISNULL(nombre_producto_4,'') +  ',' +ISNULL(nombre_producto_5,'') +  ',' +ISNULL(nombre_producto_6,'') +  ',' +ISNULL(nombre_producto_7,'') +  ',' +ISNULL(nombre_producto_8,'') +  ',' +ISNULL(nombre_producto_9,'') +  ',' +ISNULL(nombre_producto_10,'') +  ',' +ISNULL(nombre_producto_11,'') +  ',' +ISNULL(nombre_producto_12,'') +  ',' +ISNULL(nombre_producto_13,'') +  ',' +ISNULL(nombre_producto_14,'') +  ',' +ISNULL(nombre_producto_15,'') +  ',' +ISNULL(nombre_producto_16,'') +  ',' +ISNULL(nombre_producto_17,'') +  ',' +ISNULL(nombre_producto_18,'') +  ',' +ISNULL(nombre_producto_19,'') +  ',' +ISNULL(nombre_producto_20,'') +  ',' +ISNULL(nombre_producto_21,'') +  ',' +ISNULL(nombre_producto_22,'') +  ',' +ISNULL(nombre_producto_23,'') +  ',' +ISNULL(nombre_producto_24,'') +  ',' +ISNULL(nombre_producto_25,'') +  ',' +ISNULL(nombre_producto_26,'') +  ',' +ISNULL(nombre_producto_27,'') +  ',' +ISNULL(nombre_producto_28,'') +  ',' +ISNULL(nombre_producto_29,'') +  ',' +ISNULL(nombre_producto_30,'') +  ',' +ISNULL(nombre_producto_31,'') +  ',' +ISNULL(nombre_producto_32,'') +  ',' +ISNULL(nombre_producto_33,'') +  ',' +ISNULL(nombre_producto_34,'') +  ',' +ISNULL(nombre_producto_35,'') +  ',' +ISNULL(nombre_producto_36,'') +  ',' +ISNULL(nombre_producto_37,'') +  ',' +ISNULL(nombre_producto_38,'') +  ',' +ISNULL(nombre_producto_39,'') +  ',' +ISNULL(nombre_producto_40,'') +  ',' +ISNULL(nombre_producto_41,'') +  ',' +ISNULL(nombre_producto_42,'') +  ',' +ISNULL(nombre_producto_43,'') +  ',' +ISNULL(nombre_producto_44,'') +  ',' +ISNULL(nombre_producto_45,'') +  ',' +ISNULL(nombre_producto_46,'') +  ',' +ISNULL(nombre_producto_47,'') +  ',' +ISNULL(nombre_producto_48,'') +  ',' +ISNULL(nombre_producto_49,'') +  ',' +ISNULL(nombre_producto_50,'') +  ',' +ISNULL(nombre_producto_51,'') +  ',' +ISNULL(nombre_producto_52,'') +  ',' +ISNULL(nombre_producto_53,'') +  ',' +ISNULL(nombre_producto_54,'') +  ',' +ISNULL(nombre_producto_55,'') +  ',' +ISNULL(nombre_producto_56,'') +  ',' +ISNULL(nombre_producto_57,'') +  ',' +ISNULL(nombre_producto_58,'') +  ',' +ISNULL(nombre_producto_59,'') +  ',' +ISNULL(nombre_producto_60,'') +  ',' +ISNULL(nombre_producto_61,'') +  ',' +ISNULL(nombre_producto_62,'') +  ',' +ISNULL(nombre_producto_63,'') +  ',' +ISNULL(nombre_producto_64,'') +  ',' +ISNULL(nombre_producto_65,'') +  ',' +ISNULL(nombre_producto_66,'') +  ',' +ISNULL(nombre_producto_67,'') +  ',' +ISNULL(nombre_producto_68,'') +  ',' +ISNULL(nombre_producto_69,'') +  ',' +ISNULL(nombre_producto_70,'') +  ',' +ISNULL(nombre_producto_71,'') +  ',' +ISNULL(nombre_producto_72,'') +  ',' +ISNULL(nombre_producto_73,'') +  ',' +ISNULL(nombre_producto_74,'') +  ',' +ISNULL(nombre_producto_75,'') +  ',' +ISNULL(nombre_producto_76,'') +  ',' +ISNULL(nombre_producto_77,'') +  ',' +ISNULL(nombre_producto_78,'') +  ',' +ISNULL(nombre_producto_79,'') +  ',' +ISNULL(nombre_producto_80,'') +  ',' +ISNULL(nombre_producto_81,'') +  ',' +ISNULL(nombre_producto_82,'') +  ',' +ISNULL(nombre_producto_83,'') +  ',' +ISNULL(nombre_producto_84,'') +  ',' +ISNULL(nombre_producto_85,'') +  ',' +ISNULL(nombre_producto_86,'') +  ',' +ISNULL(nombre_producto_87,'') +  ',' +ISNULL(nombre_producto_88,'') +  ',' +ISNULL(nombre_producto_89,'') +  ',' +ISNULL(nombre_producto_90,'') +  ',' +ISNULL(nombre_producto_91,'') +  ',' +ISNULL(nombre_producto_92,'') +  ',' +ISNULL(nombre_producto_93,'') +  ',' +ISNULL(nombre_producto_94,'') +  ',' +ISNULL(nombre_producto_95,'') +  ',' +ISNULL(nombre_producto_96,'') +  ',' +ISNULL(nombre_producto_97,'') +  ',' +ISNULL(nombre_producto_98,'') +  ',' +ISNULL(nombre_producto_99,'')), LEN((ISNULL(nombre_producto_1,'') +  ',' +ISNULL(nombre_producto_2,'') +  ',' +ISNULL(nombre_producto_3,'') +  ',' +ISNULL(nombre_producto_4,'') +  ',' +ISNULL(nombre_producto_5,'') +  ',' +ISNULL(nombre_producto_6,'') +  ',' +ISNULL(nombre_producto_7,'') +  ',' +ISNULL(nombre_producto_8,'') +  ',' +ISNULL(nombre_producto_9,'') +  ',' +ISNULL(nombre_producto_10,'') +  ',' +ISNULL(nombre_producto_11,'') +  ',' +ISNULL(nombre_producto_12,'') +  ',' +ISNULL(nombre_producto_13,'') +  ',' +ISNULL(nombre_producto_14,'') +  ',' +ISNULL(nombre_producto_15,'') +  ',' +ISNULL(nombre_producto_16,'') +  ',' +ISNULL(nombre_producto_17,'') +  ',' +ISNULL(nombre_producto_18,'') +  ',' +ISNULL(nombre_producto_19,'') +  ',' +ISNULL(nombre_producto_20,'') +  ',' +ISNULL(nombre_producto_21,'') +  ',' +ISNULL(nombre_producto_22,'') +  ',' +ISNULL(nombre_producto_23,'') +  ',' +ISNULL(nombre_producto_24,'') +  ',' +ISNULL(nombre_producto_25,'') +  ',' +ISNULL(nombre_producto_26,'') +  ',' +ISNULL(nombre_producto_27,'') +  ',' +ISNULL(nombre_producto_28,'') +  ',' +ISNULL(nombre_producto_29,'') +  ',' +ISNULL(nombre_producto_30,'') +  ',' +ISNULL(nombre_producto_31,'') +  ',' +ISNULL(nombre_producto_32,'') +  ',' +ISNULL(nombre_producto_33,'') +  ',' +ISNULL(nombre_producto_34,'') +  ',' +ISNULL(nombre_producto_35,'') +  ',' +ISNULL(nombre_producto_36,'') +  ',' +ISNULL(nombre_producto_37,'') +  ',' +ISNULL(nombre_producto_38,'') +  ',' +ISNULL(nombre_producto_39,'') +  ',' +ISNULL(nombre_producto_40,'') +  ',' +ISNULL(nombre_producto_41,'') +  ',' +ISNULL(nombre_producto_42,'') +  ',' +ISNULL(nombre_producto_43,'') +  ',' +ISNULL(nombre_producto_44,'') +  ',' +ISNULL(nombre_producto_45,'') +  ',' +ISNULL(nombre_producto_46,'') +  ',' +ISNULL(nombre_producto_47,'') +  ',' +ISNULL(nombre_producto_48,'') +  ',' +ISNULL(nombre_producto_49,'') +  ',' +ISNULL(nombre_producto_50,'') +  ',' +ISNULL(nombre_producto_51,'') +  ',' +ISNULL(nombre_producto_52,'') +  ',' +ISNULL(nombre_producto_53,'') +  ',' +ISNULL(nombre_producto_54,'') +  ',' +ISNULL(nombre_producto_55,'') +  ',' +ISNULL(nombre_producto_56,'') +  ',' +ISNULL(nombre_producto_57,'') +  ',' +ISNULL(nombre_producto_58,'') +  ',' +ISNULL(nombre_producto_59,'') +  ',' +ISNULL(nombre_producto_60,'') +  ',' +ISNULL(nombre_producto_61,'') +  ',' +ISNULL(nombre_producto_62,'') +  ',' +ISNULL(nombre_producto_63,'') +  ',' +ISNULL(nombre_producto_64,'') +  ',' +ISNULL(nombre_producto_65,'') +  ',' +ISNULL(nombre_producto_66,'') +  ',' +ISNULL(nombre_producto_67,'') +  ',' +ISNULL(nombre_producto_68,'') +  ',' +ISNULL(nombre_producto_69,'') +  ',' +ISNULL(nombre_producto_70,'') +  ',' +ISNULL(nombre_producto_71,'') +  ',' +ISNULL(nombre_producto_72,'') +  ',' +ISNULL(nombre_producto_73,'') +  ',' +ISNULL(nombre_producto_74,'') +  ',' +ISNULL(nombre_producto_75,'') +  ',' +ISNULL(nombre_producto_76,'') +  ',' +ISNULL(nombre_producto_77,'') +  ',' +ISNULL(nombre_producto_78,'') +  ',' +ISNULL(nombre_producto_79,'') +  ',' +ISNULL(nombre_producto_80,'') +  ',' +ISNULL(nombre_producto_81,'') +  ',' +ISNULL(nombre_producto_82,'') +  ',' +ISNULL(nombre_producto_83,'') +  ',' +ISNULL(nombre_producto_84,'') +  ',' +ISNULL(nombre_producto_85,'') +  ',' +ISNULL(nombre_producto_86,'') +  ',' +ISNULL(nombre_producto_87,'') +  ',' +ISNULL(nombre_producto_88,'') +  ',' +ISNULL(nombre_producto_89,'') +  ',' +ISNULL(nombre_producto_90,'') +  ',' +ISNULL(nombre_producto_91,'') +  ',' +ISNULL(nombre_producto_92,'') +  ',' +ISNULL(nombre_producto_93,'') +  ',' +ISNULL(nombre_producto_94,'') +  ',' +ISNULL(nombre_producto_95,'') +  ',' +ISNULL(nombre_producto_96,'') +  ',' +ISNULL(nombre_producto_97,'') +  ',' +ISNULL(nombre_producto_98,'') +  ',' +ISNULL(nombre_producto_99,''))) - (PATINDEX('%[^,]%', REVERSE((ISNULL(nombre_producto_1,'') +  ',' +ISNULL(nombre_producto_2,'') +  ',' +ISNULL(nombre_producto_3,'') +  ',' +ISNULL(nombre_producto_4,'') +  ',' +ISNULL(nombre_producto_5,'') +  ',' +ISNULL(nombre_producto_6,'') +  ',' +ISNULL(nombre_producto_7,'') +  ',' +ISNULL(nombre_producto_8,'') +  ',' +ISNULL(nombre_producto_9,'') +  ',' +ISNULL(nombre_producto_10,'') +  ',' +ISNULL(nombre_producto_11,'') +  ',' +ISNULL(nombre_producto_12,'') +  ',' +ISNULL(nombre_producto_13,'') +  ',' +ISNULL(nombre_producto_14,'') +  ',' +ISNULL(nombre_producto_15,'') +  ',' +ISNULL(nombre_producto_16,'') +  ',' +ISNULL(nombre_producto_17,'') +  ',' +ISNULL(nombre_producto_18,'') +  ',' +ISNULL(nombre_producto_19,'') +  ',' +ISNULL(nombre_producto_20,'') +  ',' +ISNULL(nombre_producto_21,'') +  ',' +ISNULL(nombre_producto_22,'') +  ',' +ISNULL(nombre_producto_23,'') +  ',' +ISNULL(nombre_producto_24,'') +  ',' +ISNULL(nombre_producto_25,'') +  ',' +ISNULL(nombre_producto_26,'') +  ',' +ISNULL(nombre_producto_27,'') +  ',' +ISNULL(nombre_producto_28,'') +  ',' +ISNULL(nombre_producto_29,'') +  ',' +ISNULL(nombre_producto_30,'') +  ',' +ISNULL(nombre_producto_31,'') +  ',' +ISNULL(nombre_producto_32,'') +  ',' +ISNULL(nombre_producto_33,'') +  ',' +ISNULL(nombre_producto_34,'') +  ',' +ISNULL(nombre_producto_35,'') +  ',' +ISNULL(nombre_producto_36,'') +  ',' +ISNULL(nombre_producto_37,'') +  ',' +ISNULL(nombre_producto_38,'') +  ',' +ISNULL(nombre_producto_39,'') +  ',' +ISNULL(nombre_producto_40,'') +  ',' +ISNULL(nombre_producto_41,'') +  ',' +ISNULL(nombre_producto_42,'') +  ',' +ISNULL(nombre_producto_43,'') +  ',' +ISNULL(nombre_producto_44,'') +  ',' +ISNULL(nombre_producto_45,'') +  ',' +ISNULL(nombre_producto_46,'') +  ',' +ISNULL(nombre_producto_47,'') +  ',' +ISNULL(nombre_producto_48,'') +  ',' +ISNULL(nombre_producto_49,'') +  ',' +ISNULL(nombre_producto_50,'') +  ',' +ISNULL(nombre_producto_51,'') +  ',' +ISNULL(nombre_producto_52,'') +  ',' +ISNULL(nombre_producto_53,'') +  ',' +ISNULL(nombre_producto_54,'') +  ',' +ISNULL(nombre_producto_55,'') +  ',' +ISNULL(nombre_producto_56,'') +  ',' +ISNULL(nombre_producto_57,'') +  ',' +ISNULL(nombre_producto_58,'') +  ',' +ISNULL(nombre_producto_59,'') +  ',' +ISNULL(nombre_producto_60,'') +  ',' +ISNULL(nombre_producto_61,'') +  ',' +ISNULL(nombre_producto_62,'') +  ',' +ISNULL(nombre_producto_63,'') +  ',' +ISNULL(nombre_producto_64,'') +  ',' +ISNULL(nombre_producto_65,'') +  ',' +ISNULL(nombre_producto_66,'') +  ',' +ISNULL(nombre_producto_67,'') +  ',' +ISNULL(nombre_producto_68,'') +  ',' +ISNULL(nombre_producto_69,'') +  ',' +ISNULL(nombre_producto_70,'') +  ',' +ISNULL(nombre_producto_71,'') +  ',' +ISNULL(nombre_producto_72,'') +  ',' +ISNULL(nombre_producto_73,'') +  ',' +ISNULL(nombre_producto_74,'') +  ',' +ISNULL(nombre_producto_75,'') +  ',' +ISNULL(nombre_producto_76,'') +  ',' +ISNULL(nombre_producto_77,'') +  ',' +ISNULL(nombre_producto_78,'') +  ',' +ISNULL(nombre_producto_79,'') +  ',' +ISNULL(nombre_producto_80,'') +  ',' +ISNULL(nombre_producto_81,'') +  ',' +ISNULL(nombre_producto_82,'') +  ',' +ISNULL(nombre_producto_83,'') +  ',' +ISNULL(nombre_producto_84,'') +  ',' +ISNULL(nombre_producto_85,'') +  ',' +ISNULL(nombre_producto_86,'') +  ',' +ISNULL(nombre_producto_87,'') +  ',' +ISNULL(nombre_producto_88,'') +  ',' +ISNULL(nombre_producto_89,'') +  ',' +ISNULL(nombre_producto_90,'') +  ',' +ISNULL(nombre_producto_91,'') +  ',' +ISNULL(nombre_producto_92,'') +  ',' +ISNULL(nombre_producto_93,'') +  ',' +ISNULL(nombre_producto_94,'') +  ',' +ISNULL(nombre_producto_95,'') +  ',' +ISNULL(nombre_producto_96,'') +  ',' +ISNULL(nombre_producto_97,'') +  ',' +ISNULL(nombre_producto_98,'') +  ',' +ISNULL(nombre_producto_99,'')))) - 1)) as Detalle_Orden,tienda FROM [CCS-CLOUD].[CRM_VIPS].[dbo].[SYS_Pedidos] WHERE id_cliente = '" & Session("CustomerID") & "' ORDER BY fecha_pedido desc", conexion)
        'cmd.CommandType = CommandType.Text
        'conexion.Open()
        'da.SelectCommand = cmd
        'da.Fill(ds)
        'conexion.Close()

        'If ds.Tables(0).Rows.Count = 0 Then
        '    TextBox15.Text = "-"
        '    TextBox15.ToolTip = Nothing
        '    TextBox54.Text = Nothing
        '    DropDownList16.SelectedIndex = 0
        'Else
        '    TextBox15.Text = ds.Tables(0).Rows(0).Item(0).ToString
        '    TextBox15.ToolTip = ds.Tables(0).Rows(0).Item(1).ToString
        '    TextBox54.Text = ds.Tables(0).Rows(0).Item(2).ToString
        '    DropDownList16.SelectedValue = ds.Tables(0).Rows(0).Item(2).ToString
        '    StatusTienda()
        'End If



    End Sub

    Sub GetUltimaQueja()



        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim conexion As New SqlConnection(strConnString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        Dim cmd As SqlCommand = New SqlCommand("SELECT Status,Descripcion,CONVERT(NVARCHAR(10),fecha_alta,103) as Alta FROM [CRM_VIPS].[dbo].[SYS_Quejas] WHERE cliente = '" & Session("CustomerID") & "' ORDER BY fecha_alta desc", conexion)
        cmd.CommandType = CommandType.Text
        conexion.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()

        If ds.Tables(0).Rows.Count = 0 Then
            TextBox16.Text = "-"
        Else
            TextBox16.Text = ds.Tables(0).Rows(0).Item(2).ToString
            TextBox16.ToolTip = ds.Tables(0).Rows(0).Item(0).ToString & ": " & ds.Tables(0).Rows(0).Item(1).ToString
        End If



    End Sub

    Public Sub GetCustomer(Tel As String)

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("db").ConnectionString
        Dim conexion As New SqlConnection(strConnString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        Dim cmd As SqlCommand = New SqlCommand("SELECT * FROM [CRM_VIPS].[dbo].[SYS_Clientes] WHERE (tel_1 = '" & Tel & "' OR tel_2 = '" & Tel & "' OR tel_3 = '" & Tel & "') AND tel_1 <>'5550831300' AND tel_2 <> '5550831300' AND tel_3 <>'5550831300'", conexion)
        cmd.CommandType = CommandType.Text
        conexion.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()


        If ds.Tables(0).Rows.Count = 0 Then

            nuevoCliente.Value = "1"
            Session("nuevoCliente") = "1"

        ElseIf ds.Tables(0).Rows.Count = 1 Then

            nuevoCliente.Value = "0"
            Session("nuevoCliente") = "0"


            Session("CustomerID") = ds.Tables(0).Rows(0).Item(0).ToString

            Try
                TextBox14.Text = CDate(ds.Tables(0).Rows(0).Item(21).ToString)
            Catch ex As Exception
                TextBox14.Text = "-"
            End Try

            Try
                TextBox15.Text = CDate(ds.Tables(0).Rows(0).Item(22).ToString)
            Catch ex As Exception
                TextBox15.Text = "-"
            End Try

            Try
                TextBox16.Text = CDate(ds.Tables(0).Rows(0).Item(23).ToString)
            Catch ex As Exception
                TextBox16.Text = "-"
            End Try

            HiddenField1.Value = ds.Tables(0).Rows(0).Item(24).ToString

            TextBox1.Text = ds.Tables(0).Rows(0).Item(1).ToString
            TextBox2.Text = ds.Tables(0).Rows(0).Item(2).ToString
            TextBox4.Text = ds.Tables(0).Rows(0).Item(3).ToString

            TextBox5.Text = ds.Tables(0).Rows(0).Item(12).ToString
            TextBox6.Text = ds.Tables(0).Rows(0).Item(13).ToString
            TextBox7.Text = ds.Tables(0).Rows(0).Item(14).ToString

            TextBox8.Text = ds.Tables(0).Rows(0).Item(4).ToString
            TextBox9.Text = ds.Tables(0).Rows(0).Item(5).ToString
            TextBox10.Text = ds.Tables(0).Rows(0).Item(6).ToString

            TextBox3.Text = ds.Tables(0).Rows(0).Item(10).ToString
            SearchCP()

            TextBox11.Text = ds.Tables(0).Rows(0).Item(11).ToString

            TextBox12.Text = ds.Tables(0).Rows(0).Item(17).ToString







            If HiddenField1.Value = 1 Then
                CL1.Style("background-image") = "../Images/0A.png"
                CL2.Style("background-image") = "../Images/1B.png"
                CL3.Style("background-image") = "../Images/2B.png"
                CL4.Style("background-image") = "../Images/3B.png"
                CL5.Style("background-image") = "../Images/4B.png"
            ElseIf HiddenField1.Value = 2 Then
                CL1.Style("background-image") = "../Images/0B.png"
                CL2.Style("background-image") = "../Images/1A.png"
                CL3.Style("background-image") = "../Images/2B.png"
                CL4.Style("background-image") = "../Images/3B.png"
                CL5.Style("background-image") = "../Images/4B.png"
            ElseIf HiddenField1.Value = 3 Then
                CL1.Style("background-image") = "../Images/0B.png"
                CL2.Style("background-image") = "../Images/1B.png"
                CL3.Style("background-image") = "../Images/2A.png"
                CL4.Style("background-image") = "../Images/3B.png"
                CL5.Style("background-image") = "../Images/4B.png"
            ElseIf HiddenField1.Value = 4 Then
                CL1.Style("background-image") = "../Images/0B.png"
                CL2.Style("background-image") = "../Images/1B.png"
                CL3.Style("background-image") = "../Images/2B.png"
                CL4.Style("background-image") = "../Images/3A.png"
                CL5.Style("background-image") = "../Images/4B.png"
            ElseIf HiddenField1.Value = 5 Then
                CL1.Style("background-image") = "../Images/0B.png"
                CL2.Style("background-image") = "../Images/1B.png"
                CL3.Style("background-image") = "../Images/2B.png"
                CL4.Style("background-image") = "../Images/3B.png"
                CL5.Style("background-image") = "../Images/4A.png"
            End If

            GetUltimaQueja()
            GetUltimoPedido()
            UltimaInteraccion()
        ElseIf ds.Tables(0).Rows.Count >= 2 Then

            HiddenField2.Value = 0


            'FillCustomer(Session("ANI"))

            GetUltimaQueja()
            GetUltimoPedido()
            UltimaInteraccion()


        End If





    End Sub

    Public Sub GetCustomerForID(ID As String)

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("db").ConnectionString
        Dim conexion As New SqlConnection(strConnString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        Dim cmd As SqlCommand = New SqlCommand("SELECT * FROM [CRM_VIPS].[dbo].[SYS_Clientes] WHERE ID = '" & ID & "'", conexion)
        cmd.CommandType = CommandType.Text
        conexion.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()


        Session("CustomerID") = ds.Tables(0).Rows(0).Item(0).ToString
        Try
            TextBox14.Text = CDate(ds.Tables(0).Rows(0).Item(21).ToString)
        Catch ex As Exception
            TextBox14.Text = "-"
        End Try

        Try
            TextBox15.Text = CDate(ds.Tables(0).Rows(0).Item(22).ToString)
        Catch ex As Exception
            TextBox15.Text = "-"
        End Try

        Try
            TextBox16.Text = CDate(ds.Tables(0).Rows(0).Item(23).ToString)
        Catch ex As Exception
            TextBox16.Text = "-"
        End Try

        HiddenField1.Value = ds.Tables(0).Rows(0).Item(24).ToString

        TextBox1.Text = ds.Tables(0).Rows(0).Item(1).ToString
        TextBox2.Text = ds.Tables(0).Rows(0).Item(2).ToString
        TextBox4.Text = ds.Tables(0).Rows(0).Item(3).ToString

        TextBox5.Text = ds.Tables(0).Rows(0).Item(12).ToString
        TextBox6.Text = ds.Tables(0).Rows(0).Item(13).ToString
        TextBox7.Text = ds.Tables(0).Rows(0).Item(14).ToString

        TextBox8.Text = ds.Tables(0).Rows(0).Item(4).ToString
        TextBox9.Text = ds.Tables(0).Rows(0).Item(5).ToString
        TextBox10.Text = ds.Tables(0).Rows(0).Item(6).ToString

        TextBox3.Text = ds.Tables(0).Rows(0).Item(10).ToString
        SearchCP()

        TextBox11.Text = ds.Tables(0).Rows(0).Item(11).ToString

        TextBox12.Text = ds.Tables(0).Rows(0).Item(17).ToString





        If HiddenField1.Value = 1 Then
            CL1.Style("background-image") = "../Images/0A.png"
            CL2.Style("background-image") = "../Images/1B.png"
            CL3.Style("background-image") = "../Images/2B.png"
            CL4.Style("background-image") = "../Images/3B.png"
            CL5.Style("background-image") = "../Images/4B.png"
        ElseIf HiddenField1.Value = 2 Then
            CL1.Style("background-image") = "../Images/0B.png"
            CL2.Style("background-image") = "../Images/1A.png"
            CL3.Style("background-image") = "../Images/2B.png"
            CL4.Style("background-image") = "../Images/3B.png"
            CL5.Style("background-image") = "../Images/4B.png"
        ElseIf HiddenField1.Value = 3 Then
            CL1.Style("background-image") = "../Images/0B.png"
            CL2.Style("background-image") = "../Images/1B.png"
            CL3.Style("background-image") = "../Images/2A.png"
            CL4.Style("background-image") = "../Images/3B.png"
            CL5.Style("background-image") = "../Images/4B.png"
        ElseIf HiddenField1.Value = 4 Then
            CL1.Style("background-image") = "../Images/0B.png"
            CL2.Style("background-image") = "../Images/1B.png"
            CL3.Style("background-image") = "../Images/2B.png"
            CL4.Style("background-image") = "../Images/3A.png"
            CL5.Style("background-image") = "../Images/4B.png"
        ElseIf HiddenField1.Value = 5 Then
            CL1.Style("background-image") = "../Images/0B.png"
            CL2.Style("background-image") = "../Images/1B.png"
            CL3.Style("background-image") = "../Images/2B.png"
            CL4.Style("background-image") = "../Images/3B.png"
            CL5.Style("background-image") = "../Images/4A.png"
        End If


        nuevoCliente.Value = "0"
        Session("nuevoCliente") = "0"


    End Sub


    Public Sub SearchCliente(Nombre As String)

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("db").ConnectionString
        Dim strQuery As String = "SELECT id as ID,nombres + ' ' + paterno + ' ' + materno as Nombre,calle + ' ' + no_ext + ' ' + no_int + ' ' + UPPER(Colonia) as Direccion FROM [CRM_VIPS].[dbo].[SYS_Clientes] WHERE nombres like '%" & Nombre & "%' OR paterno like '%" & Nombre & "%' OR materno like '%" & Nombre & "%'"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()


        cmd.CommandType = CommandType.Text
        cmd.CommandTimeout = 1800
        cmd.CommandText = strQuery
        cmd.Connection = con

        con.Open()

        GridView2.DataSource = cmd.ExecuteReader()
        GridView2.DataBind()

        con.Close()
        con.Dispose()


    End Sub

    Public Sub SearchTelefono(Telefono As String)

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("db").ConnectionString
        Dim strQuery As String = "SELECT id as ID,nombres + ' ' + paterno + ' ' + materno as Nombre,calle + ' ' + no_ext + ' ' + no_int + ' ' + UPPER(Colonia) as Direccion FROM [CRM_VIPS].[dbo].[SYS_Clientes] WHERE tel_1 like '%" & Telefono & "%' OR tel_2 like '%" & Telefono & "%' OR tel_3 like '%" & Telefono & "%'"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()


        cmd.CommandType = CommandType.Text
        cmd.CommandTimeout = 1800
        cmd.CommandText = strQuery
        cmd.Connection = con

        con.Open()

        GridView2.DataSource = cmd.ExecuteReader()
        GridView2.DataBind()

        con.Close()
        con.Dispose()


    End Sub

    Public Sub FillCustomer(Tel As String)

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("db").ConnectionString
        Dim strQuery As String = "SELECT id as ID,nombres + ' ' + paterno + ' ' + materno as Nombre,calle + ' ' + no_ext + ' ' + no_int + ' ' + UPPER(Colonia) as Direccion FROM [CRM_VIPS].[dbo].[SYS_Clientes] WHERE tel_1 = '" & Tel & "' OR tel_2 = '" & Tel & "' OR tel_3 = '" & Tel & "'"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()


        cmd.CommandType = CommandType.Text
        cmd.CommandTimeout = 1800
        cmd.CommandText = strQuery
        cmd.Connection = con

        con.Open()

        GridView1.DataSource = cmd.ExecuteReader()
        GridView1.DataBind()

        con.Close()
        con.Dispose()


    End Sub



    Function Insert_Cliente()

        Dim nombre As String = StrConv(TextBox1.Text & " " & TextBox2.Text & " " & TextBox4.Text, vbUpperCase)


        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String = "EXEC [dbo].[INSERT_Nuevo_Cliente] @NOMBRES = '" & TextBox1.Text & "',@PATERNO = '" & TextBox2.Text & "',@MATERNO = '" & TextBox4.Text & "',@CALLE = '" & TextBox8.Text & "',@NO_EXT = '" & TextBox9.Text & "',@NO_INT = '" & TextBox10.Text & "',@COLONIA = '" & DropDownList1.SelectedItem.Text & "',@DEL_MUN = '" & DropDownList2.SelectedItem.Text & "',@EDO = '" & DropDownList3.SelectedItem.Text & "',@CP = '" & TextBox3.Text & "',@REF = '" & TextBox11.Text & "',@TEL1 = '" & TextBox5.Text & "',@TEL2 = '" & TextBox6.Text & "',@TEL3 = '" & TextBox7.Text & "',@EMAIL = '" & TextBox12.Text & "',@GENERO = 'No Proporciona',@FECHA_NAC = '01/01/1990',@EDO_CIVIL = 'No Proporcina', @CUSTOMER_LEVEL = 3"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con

        con.Open()
        cmd.CommandTimeout = 1800
        cmd.ExecuteNonQuery()

        strQuery = "SELECT MAX(id) FROM [CRM_VIPS].[dbo].[SYS_Clientes]"

        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        cmd.CommandText = strQuery
        cmd.CommandType = CommandType.Text
        da.SelectCommand = cmd
        da.Fill(ds)
        con.Close()

        Return ds.Tables(0).Rows(0).Item(0).ToString

    End Function

    Function Update_Cliente()

        Dim nombre As String = StrConv(TextBox1.Text & " " & TextBox2.Text & " " & TextBox4.Text, vbUpperCase)


        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String = "EXEC [dbo].[UPDATE_Cliente] @ID = '" & Session("CustomerID") & "', @NOMBRES = '" & TextBox1.Text & "',@PATERNO = '" & TextBox2.Text & "',@MATERNO = '" & TextBox4.Text & "',@CALLE = '" & TextBox8.Text & "',@NO_EXT = '" & TextBox9.Text & "',@NO_INT = '" & TextBox10.Text & "',@COLONIA = '" & DropDownList1.SelectedItem.Text & "',@DEL_MUN = '" & DropDownList2.SelectedItem.Text & "',@EDO = '" & DropDownList3.SelectedItem.Text & "',@CP = '" & TextBox3.Text & "',@REF = '" & TextBox11.Text & "',@TEL1 = '" & TextBox5.Text & "',@TEL2 = '" & TextBox6.Text & "',@TEL3 = '" & TextBox7.Text & "',@EMAIL = '" & TextBox12.Text & "',@GENERO = 'No Proporciona',@FECHA_NAC = '01/01/1990',@EDO_CIVIL = 'No Proporciona'"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con

        con.Open()
        cmd.CommandTimeout = 1800
        cmd.ExecuteNonQuery()
        con.Close()

        Return True

    End Function

    Sub GuardarQuejaNueva()

        Dim x As New Funciones
        Dim no_queja As String = x.GetFolio()
        Dim FolioOK As String = "Q" & no_queja.PadLeft(8, "0")
        Label31.Text = FolioOK


        Dim repartidor, medio, restaurante, pedido, idcliente, idMitrol, id_ccs, tip5, tip6 As String

        medio = "1"

        If TextBox48.Text = Nothing Then
            repartidor = "'" & TextBox48.Text & "'"
        Else
            repartidor = "NULL"
        End If

        If DropDownList17.SelectedItem.Text = "-Selecciona-" Then
            restaurante = "NULL"
        Else
            restaurante = "'" & DropDownList16.SelectedItem.Text & "'"
        End If


        If TextBox46.Text = Nothing Then
            pedido = "NULL"
        Else
            pedido = "'" & TextBox46.Text & "'"
        End If


        If DropDownList11.Visible = False Then
            tip5 = ""
        Else
            tip5 = DropDownList11.SelectedItem.Text
        End If

        If DropDownList12.Visible = False Then
            tip6 = ""
        Else
            tip6 = DropDownList12.SelectedItem.Text
        End If

        idcliente = Session("CustomerID")
        idMitrol = x.GetACD(Request.Cookies("Usersettings")("Username"))
        id_ccs = Request.Cookies("Usersettings")("Username")


        Dim nombre As String = StrConv(TextBox1.Text & " " & TextBox2.Text & " " & TextBox4.Text, vbUpperCase)


        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String = "INSERT INTO SYS_Quejas " &
         "(no_queja,cliente,nombre,tip_02,tip_03,tip_04,tip_05,restaurante,repartidor,pedido,status,medio,descripcion,solucion,id_ccs,id_mitrol,fecha_alta,fecha_solucion,tiempo_solucion,asignada,interacciones,agente_cierre) " &
         "VALUES " &
        "('" & FolioOK & "','" & idcliente & "','" & nombre & "','" & DropDownList6.SelectedItem.Text & "','" & DropDownList10.SelectedItem.Text & "','" & tip5 & "','" & tip6 & "', " & restaurante & "," & repartidor & ", " & pedido & ",'" & DropDownList9.SelectedItem.Text & "','" & medio & "','" & TextBox18.Text & "','" & TextBox20.Text & "','" & id_ccs & "','" & idMitrol & "', GETDATE(), CASE WHEN '" & DropDownList9.SelectedItem.Text & "' = 'Cerrada' THEN GETDATE() ELSE NULL END,CASE WHEN '" & DropDownList9.SelectedItem.Text & "' = 'Cerrada' THEN 0 ELSE NULL END, NULL, 1, CASE WHEN '" & DropDownList9.SelectedItem.Text & "' = 'Cerrada' THEN '" & id_ccs & "' ELSE NULL END )"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con

        con.Open()
        cmd.CommandTimeout = 1800
        cmd.ExecuteNonQuery()


        strQuery = "INSERT INTO SYS_Quejas_Historico " &
         "(no_queja,cliente,nombre,tip_02,tip_03,tip_04,tip_05,restaurante,repartidor,pedido,status,medio,descripcion,solucion,id_ccs,id_mitrol,fecha_alta,fecha_solucion,tiempo_solucion,asignada,interacciones,agente_cierre) " &
         "VALUES " &
        "('" & FolioOK & "','" & idcliente & "','" & nombre & "','" & DropDownList6.SelectedItem.Text & "','" & DropDownList10.SelectedItem.Text & "','" & tip5 & "','" & tip6 & "', " & restaurante & "," & repartidor & ", " & pedido & ",'" & DropDownList9.SelectedItem.Text & "','" & medio & "','" & TextBox18.Text & "','" & TextBox20.Text & "','" & id_ccs & "','" & idMitrol & "', GETDATE(), CASE WHEN '" & DropDownList9.SelectedItem.Text & "' = 'Cerrada' THEN GETDATE() ELSE NULL END,CASE WHEN '" & DropDownList9.SelectedItem.Text & "' = 'Cerrada' THEN 0 ELSE NULL END, NULL, 1, CASE WHEN '" & DropDownList9.SelectedItem.Text & "' = 'Cerrada' THEN '" & id_ccs & "' ELSE NULL END )"


        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con
        cmd.CommandTimeout = 1800
        cmd.ExecuteNonQuery()
        con.Close()
        con.Dispose()

    End Sub

    Sub UpdateQueja()



        Dim x As New Funciones

        If DropDownList13.SelectedItem.Value = 0 Then

            Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
            Dim strQuery As String = "EXEC [dbo].[CLOSE_Queja] @ID_QUEJA = '" & Session("QuejaID") & "',@DESCRIPCION = '" & TextBox49.Text & "',@ID_CCS = '" & Request.Cookies("Usersettings")("Username") & "',@ID_MITROL = '" & x.GetACD(Request.Cookies("Usersettings")("Username")) & "'"
            Dim con As New SqlConnection(strConnString)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strQuery
            cmd.Connection = con

            con.Open()
            cmd.CommandTimeout = 1800
            cmd.ExecuteNonQuery()
            con.Close()

        Else

            Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
            Dim strQuery As String = "EXEC [dbo].[UPDATE_Queja] @ID_QUEJA = '" & Session("QuejaID") & "',@DESCRIPCION = '" & TextBox49.Text & "',@ID_CCS = '" & Request.Cookies("Usersettings")("Username") & "',@ID_MITROL = '" & x.GetACD(Request.Cookies("Usersettings")("Username")) & "'"
            Dim con As New SqlConnection(strConnString)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strQuery
            cmd.Connection = con

            con.Open()
            cmd.CommandTimeout = 1800
            cmd.ExecuteNonQuery()
            con.Close()

        End If



    End Sub

    Sub GetQuejasAbiertas()

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("db").ConnectionString
        Dim strQuery As String = "SELECT no_queja AS Queja,nombre as Cliente,tip_03 as Tipificacion,Descripcion,id_ccs as 'Agente Alta',CONVERT(NVARCHAR(10),fecha_alta,103) as Alta,CONVERT(NVARCHAR(10),fecha_seguimiento,103) as Seguimiento,Interacciones FROM [CRM_VIPS].[dbo].[SYS_Quejas] WHERE status = 'Abierta' AND cliente = '" & Session("CustomerID") & "'"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()


        cmd.CommandType = CommandType.Text
        cmd.CommandTimeout = 1800
        cmd.CommandText = strQuery
        cmd.Connection = con

        con.Open()

        GridView3.DataSource = cmd.ExecuteReader()
        GridView3.DataBind()

        con.Close()
        con.Dispose()



    End Sub

    Sub GetQuejas(Queja As String, Optional Nombre As String = "-")



        Dim strConnString As String = ConfigurationManager.ConnectionStrings("db").ConnectionString
        Dim strQuery As String = "SELECT no_queja as Queja,nombre as Cliente,tip_03 as Tipificacion,id_ccs as 'Agente Alta',CONVERT(NVARCHAR(10),fecha_alta,103) as Alta,fecha_seguimiento as Seguimiento,interacciones,Status FROM CRM_VIPS.dbo.SYS_Quejas WHERE no_queja = '" & Queja & "' OR nombre like '%" & Nombre & "%'"
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()

        cmd.CommandType = CommandType.Text
        cmd.CommandTimeout = 1800
        cmd.CommandText = strQuery
        cmd.Connection = con

        con.Open()

        GridView4.DataSource = cmd.ExecuteReader()
        GridView4.DataBind()

        con.Close()
        con.Dispose()



    End Sub


    Sub LoadHistoricoQuejas()

        Dim conexion As New SqlConnection(ConfigurationManager.ConnectionStrings("VIPS").ToString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet
        Dim cmd As SqlCommand = New SqlCommand("SELECT 'Agente: ' + id_ccs +' || Fecha Seguimiento: ' + CONVERT(NVARCHAR(10),ISNULL(fecha_seguimiento,fecha_alta),103) + ' || Tipo: ' + ISNULL(tip_05,'') +' || Descripción: ' + descripcion FROM CRM_VIPS.dbo.SYS_Quejas_Historico WHERE no_queja= '" & Session("QuejaID") & "' ORDER BY fecha_seguimiento DESC", conexion)


        conexion.Open()
        cmd.CommandType = CommandType.Text
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()

        For Seg = 1 To ds.Tables(0).Rows.Count

            Dim Seguimiento As New TextBox
            Seguimiento.ID = "Seguimiento" & Seg
            Seguimiento.Text = ds.Tables(0).Rows(Seg - 1).Item(0)
            Seguimiento.CssClass = "HistoricoQuejas"
            Seguimiento.TextMode = 1
            Seguimiento.Enabled = False
            Panel1.Controls.Add(Seguimiento)
            Panel1.Controls.Add(New LiteralControl("<br />"))

        Next


    End Sub

    Sub LoadGeneralQuejas()

        Dim conexion As New SqlConnection(ConfigurationManager.ConnectionStrings("VIPS").ToString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet
        Dim cmd As SqlCommand = New SqlCommand("SELECT ISNULL(restaurante,''),ISNULL(repartidor,''),ISNULL(pedido,''),DATEPART(DAY,GETDATE()-[fecha_alta]) as dias,cliente FROM CRM_VIPS.dbo.SYS_Quejas WHERE no_queja = '" & Session("QuejaID") & "'", conexion)


        conexion.Open()
        cmd.CommandType = CommandType.Text
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()

        TextBox19.Text = ds.Tables(0).Rows(0).Item(0)
        TextBox23.Text = ds.Tables(0).Rows(0).Item(2)
        TextBox24.Text = ds.Tables(0).Rows(0).Item(1)
        TextBox25.Text = ds.Tables(0).Rows(0).Item(3)
        Session("ClienteQueja") = ds.Tables(0).Rows(0).Item(4)


    End Sub

    Sub UpdatePedido()


        Dim x As New Drive
        Dim y As New Funciones
        Dim no_drive, id_cliente As String

        Dim Datos(2) As String
        Datos = y.GetToken(DropDownList15.SelectedItem.Value)


        'no_drive = x.SendPedido(Datos(0), Datos(1), TextBox26.Text, TextBox1.Text & " " & TextBox2.Text & " " & TextBox4.Text, TextBox5.Text, TextBox8.Text & " No. " & TextBox9.Text & " Int. " & TextBox10.Text, DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text, TextBox3.Text, "Efectivo", TextBox27.Text, TextBox29.Text, TextBox28.Text, "Normal", "", "Sad", TextBox53.Text, TextBox52.Text, Datos(2))

        id_cliente = Session("CustomerID")

        'Dim strConnString As String = ConfigurationManager.ConnectionStrings("CRM_VIPS").ConnectionString
        'Dim strQuery As String = "EXEC [dbo].[UPADTE_Pedido_CCS] @ID = '" & y.GetPedidoCS(TextBox26.Text) & "',@ID_CLIENTE = '" & id_cliente & "',@NO_DRIVE = '" & no_drive & "',@ID_CCS = '" & Request.Cookies("Usersettings")("Username") & "',@ID_LLAMADA = 'Transaccion Diferida', @MEDIO = " & DropDownList14.SelectedItem.Value & ""
        'Dim con As New SqlConnection(strConnString)
        'Dim cmd As New SqlCommand()
        'cmd.CommandType = CommandType.Text
        'cmd.CommandText = strQuery
        ' cmd.Connection = con

        'con.Open()
        'cmd.CommandTimeout = 1800
        'cmd.ExecuteNonQuery()




    End Sub

    Sub EnviarPedido()


        Dim x As New Drive
        Dim y As New Funciones
        Dim id_cliente As String

        id_cliente = Session("CustomerID")

        Dim Factura, Alterna, Poligono As Integer

        If CheckBox2.Checked = True Then
            Factura = 1
        Else
            Factura = 0
        End If

        If CheckBox3.Checked = True Then
            Alterna = 1
        Else
            Alterna = 0
        End If

        If CheckBox4.Checked = True Then
            Poligono = 1
        Else
            Poligono = 0
        End If

        'Dim strConnString As String = ConfigurationManager.ConnectionStrings("CRM_VIPS").ConnectionString
        'Dim strQuery As String = "EXEC [dbo].[INSERT_Pedido_CRM] @TEL = '" & TextBox5.Text & "',@PEDIDO = '" & TextBox26.Text & "',@TIENDA = '" & DropDownList15.SelectedItem.Value & "',@CP = '" & TextBox3.Text & "',@DOMICILIO = '" & TextBox8.Text & "', @NO_EXTERIOR = '" & TextBox9.Text & "', @NO_INTERIOR = '" & TextBox10.Text & "', @LATITUD = '" & TextBox53.Text & "', @LONGITUD = '" & TextBox52.Text & "', @DP1 = '" & TextBox27.Text & "', @PP1= '" & TextBox29.Text & "', @FACTURA = '" & Factura & "', @ALTERNA = '" & Alterna & "', @POLIGONO = '" & Poligono & "'"
        'Dim con As New SqlConnection(strConnString)
        'Dim cmd As New SqlCommand()
        'cmd.CommandType = CommandType.Text
        'cmd.CommandText = strQuery
        'cmd.Connection = con

        'con.Open()
        'cmd.CommandTimeout = 1800
        'cmd.ExecuteNonQuery()




    End Sub

    Sub Insert_Interaccion()

        Dim x As New Funciones

        'Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        'Dim da As New System.Data.SqlClient.SqlDataAdapter
        'Dim ds As New System.Data.DataSet
        'Dim strQuery As String = "INSERT INTO SYS_Interacciones (medio,fecha_ini,fecha_base,rvt,campania,id_interaccion,ani) OUTPUT Inserted.ID VALUES ('2',GETDATE(),GETDATE(),'" & x.GetACD(Request.Cookies("Usersettings")("Username")) & "', '" & DropDownList14.SelectedItem.Text & "','Transaccion Diferida','Sin ANI')"
        'Dim con As New SqlConnection(strConnString)
        'Dim cmd As New SqlCommand()
        'con.Open()
        'cmd.CommandType = CommandType.Text
        'da.SelectCommand = cmd
        'da.Fill(ds)
        'cmd.Connection = con

        'cmd.CommandTimeout = 1800

        'con.Close()

        Dim conexion As New SqlConnection(ConfigurationManager.ConnectionStrings("VIPS").ToString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet
        Dim cmd As SqlCommand = New SqlCommand("INSERT INTO SYS_Interacciones (medio,fecha_ini,fecha_base,rvt,campania,id_interaccion,ani) OUTPUT Inserted.ID VALUES ('2',GETDATE(),GETDATE(),'" & x.GetACD(Request.Cookies("Usersettings")("Username")) & "', '" & DropDownList14.SelectedItem.Text & "','Transaccion Diferida','Sin ANI')")

        conexion.Open()
        cmd.CommandType = CommandType.Text
        cmd.Connection = conexion
        da.SelectCommand = cmd
        da.Fill(ds)


        cmd.CommandTimeout = 1800
        conexion.Close()

        Session("ID") = ds.Tables(0).Rows(0).Item(0).ToString

    End Sub

    Sub UpdateInteracciones()

        Dim tip1, tip2, tip3, tip4, tip5, tip6 As String

        If DropDownList4.Items.Count = 0 Or DropDownList4.Items.Count = 1 Then
            tip1 = "''"
        Else
            tip1 = "'" & DropDownList4.SelectedItem.Text & "'"
        End If

        If DropDownList5.Items.Count = 0 Or DropDownList5.Items.Count = 1 Then
            tip2 = "''"
        Else
            tip2 = "'" & DropDownList5.SelectedItem.Text & "'"
        End If

        If DropDownList6.Items.Count = 0 Or DropDownList6.Items.Count = 1 Then
            tip3 = "''"
        Else
            tip3 = "'" & DropDownList6.SelectedItem.Text & "'"
        End If

        If DropDownList10.Items.Count = 0 Or DropDownList10.Items.Count = 1 Then
            tip4 = "''"
        Else
            tip4 = "'" & DropDownList10.SelectedItem.Text & "'"
        End If


        If DropDownList5.SelectedItem.Text = "No Venta" Then
            tip5 = "'" & TextBox13.Text & "'"
        Else
            If DropDownList11.Items.Count = 0 Or DropDownList11.Items.Count = 1 Then
                tip5 = "''"
            Else
                tip5 = "'" & DropDownList11.SelectedItem.Text & "'"
            End If
        End If

        If DropDownList12.Visible = False Then
            tip6 = "''"
        Else
            tip6 = "'" & DropDownList12.SelectedItem.Text & "'"
        End If


        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim strQuery As String
        If DropDownList5.SelectedItem.Text = "Cancelacion" Or DropDownList5.SelectedItem.Text = "Retribucion" Then
            strQuery = "EXEC [dbo].[UPDATE_Interacciones_CRM] @ID = '" & Session("ID") & "', @NOMBRES = '" & TextBox1.Text & "', @PATERNO = '" & TextBox2.Text & "', @MATERNO = '" & TextBox4.Text & "', @TEL1 = '" & TextBox5.Text & "', @TEL2 = '" & TextBox6.Text & "', @TEL3 = '" & TextBox7.Text & "', @CALLE = '" & TextBox8.Text & "', @NO_EXT = '" & TextBox9.Text & "', @NO_INT = '" & TextBox10.Text & "', @COLONIA = '" & DropDownList1.SelectedItem.Text & "', @DELMUN = '" & DropDownList2.SelectedItem.Text & "', @EDO = '" & DropDownList3.SelectedItem.Text & "', @CP = '" & TextBox3.Text & "', @REFERENCIAS = '" & TextBox11.Text & "', @EMAIL = '" & TextBox12.Text & "', @GENERO = 'No Proporciona', @FECHA_NAC = '01/01/1990', @ESTADO_CIVIL = 'Soltero', @TIP1 = " & tip1 & ", @TIP2 = " & tip2 & ", @TIP3 = " & tip3 & ", @TIP4 = " & tip4 & ", @TIP5 = " & tip5 & ", @TIP6 = " & tip6 & ", @COMENTARIOS = 'NA', @ID_CLIENTE = '" & Session("CustomerID") & "', @PEDIDO = '" & TextBox30.Text & "'"
        Else
            strQuery = "EXEC [dbo].[UPDATE_Interacciones_CRM] @ID = '" & Session("ID") & "', @NOMBRES = '" & TextBox1.Text & "', @PATERNO = '" & TextBox2.Text & "', @MATERNO = '" & TextBox4.Text & "', @TEL1 = '" & TextBox5.Text & "', @TEL2 = '" & TextBox6.Text & "', @TEL3 = '" & TextBox7.Text & "', @CALLE = '" & TextBox8.Text & "', @NO_EXT = '" & TextBox9.Text & "', @NO_INT = '" & TextBox10.Text & "', @COLONIA = '" & DropDownList1.SelectedItem.Text & "', @DELMUN = '" & DropDownList2.SelectedItem.Text & "', @EDO = '" & DropDownList3.SelectedItem.Text & "', @CP = '" & TextBox3.Text & "', @REFERENCIAS = '" & TextBox11.Text & "', @EMAIL = '" & TextBox12.Text & "', @GENERO = 'No Proporciona', @FECHA_NAC = '01/01/1990', @ESTADO_CIVIL = 'Soltero', @TIP1 = " & tip1 & ", @TIP2 = " & tip2 & ", @TIP3 = " & tip3 & ", @TIP4 = " & tip4 & ", @TIP5 = " & tip5 & ", @TIP6 = " & tip6 & ", @COMENTARIOS = 'NA', @ID_CLIENTE = '" & Session("CustomerID") & "'"
        End If


        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQuery
        cmd.Connection = con

        con.Open()
        cmd.CommandTimeout = 1800
        cmd.ExecuteNonQuery()
        con.Close()

    End Sub

    Sub LoadPedidosActivos(Grid As Integer)

        'Dim strConnString As String = ConfigurationManager.ConnectionStrings("db").ConnectionString
        'Dim strQuery As String = "EXEC [CRM_VIPS].[dbo].[GET_Pedidos_Activos] @ID_Cliente = 1 "
        'Dim con As New SqlConnection(strConnString)
        'Dim cmd As New SqlCommand()

        'cmd.CommandType = CommandType.Text
        'cmd.CommandTimeout = 1800
        'cmd.CommandText = strQuery
        'cmd.Connection = con

        'con.Open()

        'If Grid = 1 Then

        '    GridView5.DataSource = cmd.ExecuteReader()
        '    GridView5.DataBind()
        'Else
        '    GridView6.DataSource = cmd.ExecuteReader()
        '    GridView6.DataBind()
        'End If
        'con.Close()
        'con.Dispose()



    End Sub

    Sub GetDetallesDrive(ID As String)

        Dim x As New Drive

        Dim y As New Funciones
        Dim Datos(2) As String
        Datos = y.GetToken(Session("Tienda"))


        Dim m As Drive = JsonConvert.DeserializeObject(Of Drive)(x.RequestStatus(Datos(0), Datos(1), ID, Datos(2)))

        Try

            TextBox36.Text = m.status.ToString
            TextBox37.Text = m.driver.ToString
            TextBox38.Text = m.fecha_captura.ToString
            TextBox39.Text = m.fecha_cancelacion
            TextBox40.Text = m.fecha_aceptado
            TextBox41.Text = m.fecha_1er_suc
            TextBox42.Text = m.fecha_sucursal
            TextBox43.Text = m.fecha_recoleccion
            TextBox44.Text = m.fecha_entrega
            TextBox45.Text = m.DLA

            Session("repartidor") = Mid(TextBox37.Text, 1, InStr(TextBox37.Text, "-") - 1)



            Dim n As GPSDriver = JsonConvert.DeserializeObject(Of GPSDriver)(x.GetGPS(Datos(0), Datos(1), Session("repartidor"), Datos(2)))

            If n Is Nothing Then


            Else
                Dim gps = Split(n.ubicacion, ",")
                If gps.Count = 1 Then

                    latitud.Value = ""
                    longitud.Value = ""
                Else

                    latitud.Value = gps(0)
                    longitud.Value = gps(1)

                    Dim script1 As String = "initMap(" & latitud.Value & "," & longitud.Value & ");"
                    ScriptManager.RegisterStartupScript(Me, GetType(Page), "modalQueja", script1, True)

                End If
            End If






        Catch ex As Exception


            'TextBox36.Text = Nothing
            'TextBox37.Text = Nothing
            'TextBox38.Text = Nothing
            'TextBox39.Text = Nothing
            'TextBox40.Text = Nothing
            'TextBox41.Text = Nothing
            'TextBox42.Text = Nothing
            'TextBox43.Text = Nothing
            'TextBox44.Text = Nothing
            'TextBox45.Text = Nothing

        End Try

    End Sub

    Sub Cancelar_Pedido()

        'Dim x As New Drive
        'x.CancelPedido("514", "iizieixsnkb", TextBox30.Text, 1)

    End Sub


    '***********************************************************EVENTOS***************************************************

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Session("RVT") = "" Then
        '    Response.Redirect("~/Login.aspx")
        'Else

        'End If


        'Dim script1 As String = "initMap(" & latitud.Value & "," & longitud.Value & ");"
        'ScriptManager.RegisterStartupScript(Me, GetType(Page), "modalQueja", script1, True)
        'Dim script2 As String = "initMap2(" & TextBox53.Text & "," & TextBox52.Text & ");"
        'ScriptManager.RegisterStartupScript(Me, GetType(Page), "initMap2", script2, True)

        If Not IsPostBack Then





            ComboEstados()
            ComboTip1()
            ComboTiendas()
            ComboTiendasBusqueda()
            ComboTiendasQuejas()
            'GetCustomer(Session("ANI"))


        End If

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes.Add("OnMouseOver", "On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Off(this);")
            e.Row.Attributes("OnClick") =
            Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex.ToString)

        End If

    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Session("CustomerID") = String.Format("{1}", e.CommandArgument, GridView1.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text)
        End If

        GetCustomerForID(Session("CustomerID"))

        GetUltimaQueja()
        GetUltimoPedido()
        UltimaInteraccion()

    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes.Add("OnMouseOver", "On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Off(this);")
            e.Row.Attributes("OnClick") =
            Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex.ToString)

        End If

    End Sub

    Private Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView2.RowCommand
        If e.CommandName = "Select" Then
            Session("CustomerID") = String.Format("{1}", e.CommandArgument, GridView2.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text)
            GetCustomerForID(Session("CustomerID"))
            UltimaInteraccion()
            GetUltimaQueja()
            GetUltimoPedido()
            nuevoCliente.Value = "0"
            Session("nuevoCliente") = "0"
        End If



    End Sub

    Protected Sub GridView5_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView5.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes.Add("OnMouseOver", "On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Off(this);")
            e.Row.Attributes("OnClick") =
            Page.ClientScript.GetPostBackClientHyperlink(GridView5, "Select$" + e.Row.RowIndex.ToString)

        End If

    End Sub

    Private Sub GridView5_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView5.RowCommand
        If e.CommandName = "Select" Then
            Session("Pedido_Drive") = String.Format("{1}", e.CommandArgument, GridView5.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text)
            Session("Pedido_OLO") = String.Format("{1}", e.CommandArgument, GridView5.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text)
            Session("hora_pedido") = String.Format("{1}", e.CommandArgument, GridView5.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text)
            Session("tienda") = String.Format("{1}", e.CommandArgument, GridView5.Rows(Convert.ToInt32(e.CommandArgument)).Cells(5).Text)
        End If

        TextBox30.Text = Session("Pedido_OLO")

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim conexion As New SqlConnection(strConnString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        Dim cmd As SqlCommand = New SqlCommand("EXEC [dbo].[GET_Detalle_Orden] @ID = '" & Session("Pedido_OLO") & "'", conexion)
        cmd.CommandType = CommandType.Text
        conexion.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()

        If ds.Tables(0).Rows.Count = 0 Then
            msgtipo(0) = 4
            msgmensaje(0) = "¡El número de pedido es incorrecto o no lo has guardado en VOLO!"
            Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
            Image2.Visible = False
            TextBox31.Text = Nothing
            TextBox32.Text = Nothing
            HiddenField5.Value = 0
        Else
            Image2.Visible = True
            TextBox31.Text = ds.Tables(0).Rows(0).Item(1)
            TextBox32.Text = ds.Tables(0).Rows(0).Item(2)
            HiddenField5.Value = 1

        End If



    End Sub

    Protected Sub GridView6_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView6.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes.Add("OnMouseOver", "On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Off(this);")
            e.Row.Attributes("OnClick") =
            Page.ClientScript.GetPostBackClientHyperlink(GridView6, "Select$" + e.Row.RowIndex.ToString)

        End If

    End Sub

    Private Sub GridView6_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView6.RowCommand
        If e.CommandName = "Select" Then
            Session("Pedido_Drive") = String.Format("{1}", e.CommandArgument, GridView6.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text)
            Session("Pedido_OLO") = String.Format("{1}", e.CommandArgument, GridView6.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text)
            Session("Tienda") = String.Format("{1}", e.CommandArgument, GridView6.Rows(Convert.ToInt32(e.CommandArgument)).Cells(5).Text)
        End If

        TextBox33.Text = Session("Pedido_OLO")

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim conexion As New SqlConnection(strConnString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        Dim cmd As SqlCommand = New SqlCommand("EXEC [dbo].[GET_Detalle_Orden] @ID = '" & Session("Pedido_OLO") & "'", conexion)
        cmd.CommandType = CommandType.Text
        conexion.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()

        If ds.Tables(0).Rows.Count = 0 Then
            msgtipo(0) = 4
            msgmensaje(0) = "¡El número de pedido es incorrecto o no lo has guardado en VOLO!"
            Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
            Image3.Visible = False
            TextBox34.Text = Nothing
            TextBox35.Text = Nothing
            HiddenField6.Value = 0
            TextBox36.Text = Nothing
            TextBox37.Text = Nothing
            TextBox38.Text = Nothing
            TextBox39.Text = Nothing
            TextBox40.Text = Nothing
            TextBox41.Text = Nothing
            TextBox42.Text = Nothing
            TextBox43.Text = Nothing
            TextBox44.Text = Nothing
            TextBox45.Text = Nothing
        Else
            Image3.Visible = True
            TextBox34.Text = ds.Tables(0).Rows(0).Item(1)
            TextBox35.Text = ds.Tables(0).Rows(0).Item(2)
            HiddenField6.Value = 1
            GetDetallesDrive(Session("Pedido_Drive"))
        End If



    End Sub

    Private Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        SearchColonia()
    End Sub

    Private Sub DropDownList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList2.SelectedIndexChanged
        DropDownList1.Items.Clear()
        ComboColonia()
    End Sub

    Protected Sub DropDownList3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList3.SelectedIndexChanged

        If IsPostBack Then

            DropDownList1.Items.Clear()
            DropDownList1.Items.Add(New ListItem("-", 0))
            DropDownList1.AppendDataBoundItems = True

        End If

        DropDownList2.Items.Clear()
        ComboDelMun()
    End Sub

    '******************************************************COMBOS TIPIFICACION******************************************************

    Private Sub DropDownList4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList4.SelectedIndexChanged

        x.LlenaTipificaciones(DropDownList4, DropDownList5, 2)

        HistoricoContainer.Visible = False
        nuevo_pedido.Visible = False
        MapContainer2.Visible=False

        If DropDownList4.SelectedItem.Text = "Queja" Then

            Label42.Visible = True
            DropDownList12.Visible = True
        End If

        If DropDownList4.SelectedItem.Text = "Otros" Then
            TextBox1.CssClass = "textbox"
            TextBox2.CssClass = "textbox"
            TextBox3.CssClass = "textbox"
            TextBox4.CssClass = "textbox"
            TextBox5.CssClass = "textbox validate[custom[integer],maxSize[10],minSize[10]]"
            TextBox6.CssClass = "textbox validate[custom[integer],maxSize[10],minSize[10]]"
            TextBox7.CssClass = "textbox validate[custom[integer],maxSize[10],minSize[10]]"
            TextBox8.CssClass = "textbox"
            TextBox9.CssClass = "textbox"
            DropDownList1.CssClass = "textbox"
            DropDownList2.CssClass = "textbox"
            DropDownList3.CssClass = "textbox"
        ElseIf DropDownList4.SelectedItem.Text = "Informacion" Then
            TextBox1.CssClass = "textbox"
            TextBox2.CssClass = "textbox"
            TextBox3.CssClass = "textbox"
            TextBox4.CssClass = "textbox"
            TextBox5.CssClass = "textbox validate[custom[integer],maxSize[10],minSize[10]]"
            TextBox6.CssClass = "textbox validate[custom[integer],maxSize[10],minSize[10]]"
            TextBox7.CssClass = "textbox validate[custom[integer],maxSize[10],minSize[10]]"
            TextBox8.CssClass = "textbox"
            TextBox9.CssClass = "textbox"
            DropDownList1.CssClass = "textbox"
            DropDownList2.CssClass = "textbox"
            DropDownList3.CssClass = "textbox"
        Else
            TextBox1.CssClass = "textbox validate[required]"
            TextBox1.CssClass = "textbox validate[required]"
            TextBox2.CssClass = "textbox validate[required]"
            TextBox3.CssClass = "textbox validate[required]"
            TextBox4.CssClass = "textbox validate[required]"
            TextBox5.CssClass = "textbox validate[required,custom[integer],maxSize[10],minSize[10]]"
            TextBox6.CssClass = "textbox validate[required,custom[integer],maxSize[10],minSize[10]]"
            TextBox7.CssClass = "textbox validate[required,custom[integer],maxSize[10],minSize[10]]"
            TextBox8.CssClass = "textbox validate[required]"
            TextBox9.CssClass = "textbox validate[required]"
            DropDownList1.CssClass = "textbox validate[required]"
            DropDownList2.CssClass = "textbox validate[required]"
            DropDownList3.CssClass = "textbox validate[required]"
        End If

        If x.GetNextLevel(DropDownList4, 1) = True Then
            Label8.Visible = True
            DropDownList5.Visible = True
            Label9.Visible = False
            DropDownList6.Visible = False
            Label37.Visible = False
            DropDownList10.Visible = False
            SeguimientoQuejas.Visible = False
            HistoricoContainer.Visible = False
            divQuejas.Visible = False
            nuevo_pedido.Visible = False
            MapContainer2.Visible = False
            Label41.Visible = False
            DropDownList11.Visible = False

            If DropDownList4.SelectedItem.Text <> "Queja" Then
                Label42.Visible = False
                DropDownList12.Visible = False
            End If

            cancelarPedido.Visible = False
            ConsultaPedidos.Visible = False
            mapContainer.Visible = False
        Else
            Label8.Visible = False
            DropDownList5.Visible = False
            Label9.Visible = False
            DropDownList6.Visible = False
            Label37.Visible = False
            DropDownList10.Visible = False
            SeguimientoQuejas.Visible = False
            HistoricoContainer.Visible = False
            divQuejas.Visible = False
            nuevo_pedido.Visible = False
            MapContainer2.Visible = False
            Label41.Visible = False
            DropDownList11.Visible = False
            Label42.Visible = False
            DropDownList12.Visible = False
            cancelarPedido.Visible = False
            ConsultaPedidos.Visible = False
            mapContainer.Visible = False
            DropDownList5.Items.Clear()
            DropDownList6.Items.Clear()
            DropDownList10.Items.Clear()
            DropDownList11.Items.Clear()

        End If

    End Sub

    Private Sub DropDownList5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList5.SelectedIndexChanged

        x.LlenaTipificaciones(DropDownList5, DropDownList6, 3)


        HistoricoContainer.Visible = False
        SeguimientoQuejas.Visible = False

        If x.GetNextLevel(DropDownList5, 2) = True Then
            Label9.Visible = True
            DropDownList6.Visible = True
            Label37.Visible = False
            DropDownList10.Visible = False
            SeguimientoQuejas.Visible = False
            HistoricoContainer.Visible = False
            divQuejas.Visible = False
            nuevo_pedido.Visible = False
            MapContainer2.Visible = False
            Label41.Visible = False
            DropDownList11.Visible = False
            If DropDownList4.SelectedItem.Text <> "Queja" Then
                Label42.Visible = False
                DropDownList12.Visible = False
            End If
            cancelarPedido.Visible = False
            ConsultaPedidos.Visible = False
            mapContainer.Visible = False
        Else
            Label9.Visible = False
            DropDownList6.Visible = False
            Label37.Visible = False
            DropDownList10.Visible = False
            divQuejas.Visible = False
            nuevo_pedido.Visible = False
            MapContainer2.Visible = False
            Label41.Visible = False
            DropDownList11.Visible = False
            If DropDownList4.SelectedItem.Text <> "Queja" Then
                Label42.Visible = False
                DropDownList12.Visible = False
            End If

            cancelarPedido.Visible = False
            ConsultaPedidos.Visible = False
            mapContainer.Visible = False
            DropDownList6.Items.Clear()
            DropDownList10.Items.Clear()
            DropDownList11.Items.Clear()

        End If



        If x.GetDisplayIndex(DropDownList5, 2) = 1 Then
            divQuejas.Visible = True
            divQuejas3.Visible = False
            SeguimientoQuejas.Visible = False
            HistoricoContainer.Visible = False
            nuevo_pedido.Visible = False
            MapContainer2.Visible = False
            Label41.Visible = False
            DropDownList11.Visible = False
            If DropDownList4.SelectedItem.Text <> "Queja" Then
                Label42.Visible = False
                DropDownList12.Visible = False
            End If
            cancelarPedido.Visible = False
            ConsultaPedidos.Visible = False
            mapContainer.Visible = False
        ElseIf x.GetDisplayIndex(DropDownList5, 2) = 2 Then
            SeguimientoQuejas.Visible = True
            divQuejas.Visible = False
            GetQuejasAbiertas()
            HistoricoContainer.Visible = False
            nuevo_pedido.Visible = False
            MapContainer2.Visible = False
            Label41.Visible = False
            DropDownList11.Visible = False
            If DropDownList4.SelectedItem.Text <> "Queja" Then
                Label42.Visible = False
                DropDownList12.Visible = False
            End If
            cancelarPedido.Visible = False
            ConsultaPedidos.Visible = False
            mapContainer.Visible = False
        ElseIf x.GetDisplayIndex(DropDownList5, 2) = 3 Then
            SeguimientoQuejas.Visible = False
            divQuejas.Visible = False
            HistoricoContainer.Visible = False
            nuevo_pedido.Visible = True
            MapContainer2.Visible = True
            Label41.Visible = False
            DropDownList11.Visible = False
            If DropDownList4.SelectedItem.Text <> "Queja" Then
                Label42.Visible = False
                DropDownList12.Visible = False
            End If
            cancelarPedido.Visible = False
            ConsultaPedidos.Visible = False
            mapContainer.Visible = False
        ElseIf x.GetDisplayIndex(DropDownList5, 2) = 4 Then
            SeguimientoQuejas.Visible = False
            divQuejas.Visible = False
            HistoricoContainer.Visible = False
            nuevo_pedido.Visible = False
            MapContainer2.Visible = False
            Label41.Visible = False
            DropDownList11.Visible = False
            If DropDownList4.SelectedItem.Text <> "Queja" Then
                Label42.Visible = False
                DropDownList12.Visible = False
            End If
            cancelarPedido.Visible = False
            ConsultaPedidos.Visible = True
            mapContainer.Visible = True
            LoadPedidosActivos(2)
        ElseIf x.GetDisplayIndex(DropDownList5, 2) = 5 Then
            SeguimientoQuejas.Visible = False
            divQuejas.Visible = False
            HistoricoContainer.Visible = False
            nuevo_pedido.Visible = False
            MapContainer2.Visible = False
            Label41.Visible = False
            DropDownList11.Visible = False
            If DropDownList4.SelectedItem.Text <> "Queja" Then
                Label42.Visible = False
                DropDownList12.Visible = False
            End If
            cancelarPedido.Visible = True
            ConsultaPedidos.Visible = False
            mapContainer.Visible = False
            LoadPedidosActivos(1)
        Else
            divQuejas.Visible = False
            SeguimientoQuejas.Visible = False
            HistoricoContainer.Visible = False
            nuevo_pedido.Visible = False
            MapContainer2.Visible = False
            Label41.Visible = False
            DropDownList11.Visible = False
            If DropDownList4.SelectedItem.Text <> "Queja" Then
                Label42.Visible = False
                DropDownList12.Visible = False
            End If
            cancelarPedido.Visible = False
            ConsultaPedidos.Visible = False
            mapContainer.Visible = False
        End If

        If DropDownList5.SelectedItem.Text = "No Venta" Then
            montonv.Visible = True
        Else
            montonv.Visible = False
        End If

    End Sub

    Private Sub DropDownList6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList6.SelectedIndexChanged

        'GetMailingIndex(3, DropDownList6)

        'MsgBox(Session("MailIndex"))

        x.LlenaTipificaciones(DropDownList6, DropDownList10, 4)

        If DropDownList5.SelectedItem.Text = "No Venta" Then
                Label37.Visible = True
                DropDownList10.Visible = True
                Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
            Dim strQuery As String = "SELECT id_tienda as ID,CONVERT(NVARCHAR(MAX),id_tienda) + ' - '+ [nombre_tienda] Tienda FROM [CRM_VIPS].[dbo].[SYS_Tiendas] WHERE status= 1 ORDER BY nombre_tienda"
            Dim con As New SqlConnection(strConnString)
                Dim cmd As New SqlCommand()

            DropDownList10.AppendDataBoundItems = True

                cmd.CommandType = CommandType.Text
                cmd.CommandText = strQuery
                cmd.Connection = con

                con.Open()

                DropDownList10.DataSource = cmd.ExecuteReader()
                DropDownList10.DataTextField = "Tienda"
                DropDownList10.DataValueField = "ID"
                DropDownList10.DataBind()

                con.Close()
                con.Dispose()

            Else
            If x.GetNextLevel(DropDownList6, 3) = True Then
                Label37.Visible = True
                DropDownList10.Visible = True

            Else
                Label37.Visible = False
                DropDownList10.Visible = False
                DropDownList10.Items.Clear()
                DropDownList11.Items.Clear()

            End If
        End If




        'If x.GetDisplayIndex(DropDownList6, 3) = 1 Then
        '    divQuejas.Visible = True
        '    divQuejas3.Visible = False
        '    SeguimientoQuejas.Visible = False
        '    HistoricoContainer.Visible = False
        '    nuevo_pedido.Visible = False
        '    MapContainer2.Visible = False
        '    Label41.Visible = False
        '    DropDownList11.Visible = False
        '    Label42.Visible = False
        '    DropDownList12.Visible = False
        '    cancelarPedido.Visible = False
        '    ConsultaPedidos.Visible = False
        '    mapContainer.Visible = False
        'ElseIf x.GetDisplayIndex(DropDownList6, 3) = 2 Then
        '    SeguimientoQuejas.Visible = True
        '    divQuejas.Visible = False
        '    GetQuejasAbiertas()
        '    HistoricoContainer.Visible = False
        '    nuevo_pedido.Visible = False
        '    MapContainer2.Visible = False
        '    Label41.Visible = False
        '    DropDownList11.Visible = False
        '    Label42.Visible = False
        '    DropDownList12.Visible = False
        '    cancelarPedido.Visible = False
        '    ConsultaPedidos.Visible = False
        '    mapContainer.Visible = False
        'ElseIf x.GetDisplayIndex(DropDownList6, 3) = 3 Then
        '    SeguimientoQuejas.Visible = False
        '    divQuejas.Visible = False
        '    HistoricoContainer.Visible = False
        '    nuevo_pedido.Visible = True
        '    MapContainer2.Visible = True
        '    Label41.Visible = False
        '    DropDownList11.Visible = False
        '    Label42.Visible = False
        '    DropDownList12.Visible = False
        '    cancelarPedido.Visible = False
        '    ConsultaPedidos.Visible = False
        '    mapContainer.Visible = False
        'ElseIf x.GetDisplayIndex(DropDownList6, 3) = 4 Then
        '    SeguimientoQuejas.Visible = False
        '    divQuejas.Visible = False
        '    HistoricoContainer.Visible = False
        '    nuevo_pedido.Visible = False
        '    MapContainer2.Visible = False
        '    Label41.Visible = False
        '    DropDownList11.Visible = False
        '    Label42.Visible = False
        '    DropDownList12.Visible = False
        '    cancelarPedido.Visible = False
        '    ConsultaPedidos.Visible = True
        '    mapContainer.Visible = True
        '    LoadPedidosActivos(2)
        'ElseIf x.GetDisplayIndex(DropDownList6, 3) = 5 Then
        '    SeguimientoQuejas.Visible = False
        '    divQuejas.Visible = False
        '    HistoricoContainer.Visible = False
        '    nuevo_pedido.Visible = False
        '    MapContainer2.Visible = False
        '    Label41.Visible = False
        '    DropDownList11.Visible = False
        '    Label42.Visible = False
        '    DropDownList12.Visible = False
        '    cancelarPedido.Visible = True
        '    ConsultaPedidos.Visible = False
        '    mapContainer.Visible = False
        '    LoadPedidosActivos(1)
        'Else
        '    divQuejas.Visible = False
        '    SeguimientoQuejas.Visible = False
        '    HistoricoContainer.Visible = False
        '    nuevo_pedido.Visible = False
        '    MapContainer2.Visible = False
        '    Label41.Visible = False
        '    DropDownList11.Visible = False
        '    Label42.Visible = False
        '    DropDownList12.Visible = False
        '    cancelarPedido.Visible = False
        '    ConsultaPedidos.Visible = False
        '    mapContainer.Visible = False
        'End If


    End Sub

    Private Sub DropDownList9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList9.SelectedIndexChanged

        If DropDownList9.SelectedItem.Value = 0 Then
            divQuejas3.Visible = True

        Else
            divQuejas3.Visible = False

        End If



    End Sub

    Private Sub DropDownList10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList10.SelectedIndexChanged


        x.LlenaTipificaciones(DropDownList10, DropDownList11, 5)

        If x.GetNextLevel(DropDownList10, 4) = True Then
            Label41.Visible = True
            DropDownList11.Visible = True
            Label42.Visible = True
            DropDownList12.Visible = True

        Else
            Label41.Visible = False
            DropDownList11.Visible = False
            If DropDownList4.SelectedItem.Text <> "Queja" Then
                Label42.Visible = False
                DropDownList12.Visible = False
            End If
            DropDownList11.Items.Clear()

        End If

    End Sub

    '*******************************************************************************************************************************

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim x As New Funciones
        Dim no_queja As String = x.GetFolio() - 1
        Dim FolioOK As String = "Q" & no_queja.PadLeft(8, "0")
        Label31.Text = FolioOK

        If DropDownList5.SelectedItem.Text = "Cancelacion" Or DropDownList5.SelectedItem.Text = "Retribucion" Then
            If HiddenField7.Value = 1 Then
                Dim Tipificacion As String
                Dim LD As String
                Dim MensajeQueja, MensajeNoVenta, MensajeCancelacion, MensajeRetribucion As String



                MensajeCancelacion = "Tienda: " & DropDownList10.SelectedItem.Value & " </br> Nombre Tienda: " & NombreTienda(DropDownList10.SelectedItem.Value) & "</br> Cliente: " & TextBox1.Text & " " & TextBox2.Text & " " & TextBox4.Text & " </br> Telefono: " & TextBox5.Text & " </br> Domicilio: " & TextBox8.Text & " " & TextBox9.Text & " " & TextBox10.Text & " </br> Fecha: " & Format(Today(), "dd/MM/yyyy") & " </br> Monto: $" & TextBox32.Text



                MensajeRetribucion = "Tienda: " & DropDownList10.SelectedItem.Value & " </br> Nombre Tienda: " & NombreTienda(DropDownList10.SelectedItem.Value) & "</br> Cliente: " & TextBox1.Text & " " & TextBox2.Text & " " & TextBox4.Text & " </br> Telefono: " & TextBox5.Text & " </br> Domicilio: " & TextBox8.Text & " " & TextBox9.Text & " " & TextBox10.Text & " </br> Fecha: " & Format(Today(), "dd/MM/yyyy") & " </br> Monto: $" & TextBox32.Text

                Try
                    If DropDownList11.Visible = True Then
                        Tipificacion = DropDownList5.SelectedItem.Text & " > " & DropDownList6.SelectedItem.Text & " > " & DropDownList10.SelectedItem.Text & " > " & DropDownList11.SelectedItem.Text
                    ElseIf DropDownList10.Visible = True Then
                        Tipificacion = DropDownList5.SelectedItem.Text & " > " & DropDownList6.SelectedItem.Text & " > " & DropDownList10.SelectedItem.Text
                    Else
                        Tipificacion = ""
                    End If


                    MensajeCancelacion = "Tienda: " & DropDownList10.SelectedItem.Value & " </br> Nombre Tienda: " & NombreTienda(DropDownList10.SelectedItem.Value) & "</br> Cliente: " & TextBox1.Text & " " & TextBox2.Text & " " & TextBox4.Text & " </br> Telefono: " & TextBox5.Text & " </br> Domicilio: " & TextBox8.Text & " " & TextBox9.Text & " " & TextBox10.Text & " </br> Fecha: " & Format(Today(), "dd/MM/yyyy") & " </br> Monto: $" & TextBox32.Text

                    MensajeRetribucion = "Tienda: " & DropDownList10.SelectedItem.Value & " </br> Nombre Tienda: " & NombreTienda(DropDownList10.SelectedItem.Value) & "</br> Cliente: " & TextBox1.Text & " " & TextBox2.Text & " " & TextBox4.Text & " </br> Telefono: " & TextBox5.Text & " </br> Domicilio: " & TextBox8.Text & " " & TextBox9.Text & " " & TextBox10.Text & " </br> Fecha: " & Format(Today(), "dd/MM/yyyy") & " </br> Monto: $" & TextBox32.Text

                Catch ex As Exception
                    Tipificacion = ""
                End Try



                If CheckBox1.Checked = True Then
                    Session("CustomerID") = Insert_Cliente()
                Else
                    Update_Cliente()
                End If

                Insert_Interaccion()
                UpdateInteracciones()

                If DropDownList5.Visible = True Then


                    If DropDownList5.SelectedItem.Text = "Nueva Queja" Then
                        GuardarQuejaNueva()

                        If GetMailingIndex(GetLastLevel(), GetLastLevelDD()) <> 0 Then
                            If DropDownList5.SelectedItem.Text = "Nueva Queja" Then
                                If DropDownList17.Visible = False Then
                                    LD = GetLD(GetMailingIndex(GetLastLevel(), GetLastLevelDD()), DropDownList10.SelectedItem.Value)
                                Else
                                    LD = GetLD(GetMailingIndex(GetLastLevel(), GetLastLevelDD()), DropDownList17.SelectedItem.Value)
                                End If
                                Alerta.EnviarMail(LD, "isaac.contreras@ccscontactcenter.com", "***QUEJA***", MensajeQueja)
                            Else
                                If DropDownList17.Visible = False Then
                                    LD = GetLD(GetMailingIndex(GetLastLevel(), GetLastLevelDD()), DropDownList10.SelectedItem.Value)
                                Else
                                    LD = GetLD(GetMailingIndex(GetLastLevel(), GetLastLevelDD()), DropDownList17.SelectedItem.Value)
                                End If
                                ' Alerta.EnviarMail(LD, "jorge.sanchez@ccscontactcenter.com", "***NO VENTA***", MensajeNoVenta)
                            End If
                        Else
                        End If


                        Dim script1 As String = "document.getElementById('miEnlace').click();"
                        ScriptManager.RegisterStartupScript(Me, GetType(Page), "modalQueja", script1, True)
                    ElseIf DropDownList5.SelectedItem.Text = "Nuevo Pedido" Then
                        EnviarPedido()
                        UpdatePedido()
                        msgtipo(0) = 1
                        msgmensaje(0) = "¡Pedido Guardado!"
                        Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
                    ElseIf DropDownList5.SelectedItem.Text = "Seguimiento Queja" Then
                        UpdateQueja()
                        msgtipo(0) = 1
                        msgmensaje(0) = "¡Queja Guardada!"
                        Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
                    ElseIf (DropDownList5.SelectedItem.Text = "Cancelacion" Or DropDownList5.SelectedItem.Text = "Retribucion") And HiddenField5.Value = 1 And HiddenField7.Value = 1 Then
                        Cancelar_Pedido()
                        If DropDownList5.SelectedItem.Text = "Cancelacion" Then
                            Alerta.EnviarMail2("vips" & DropDownList10.SelectedItem.Value & "@vips.com.mx", "enrique.escalante@alsea.com.mx,roni.cirilo@alsea.com.mx, raul.ayala@ccscontactcenter.com, nancy.souberbielle@ccscontactcenter.com, alejandra.lopez@ccscontactcenter.com, isai.hernandez@ccscontactcenter.com ", "***CANCELACION***", MensajeCancelacion)
                        ElseIf DropDownList5.SelectedItem.Text = "Retribucion" Then
                            Alerta.EnviarMail2("vips" & DropDownList10.SelectedItem.Value & "@vips.com.mx", "enrique.escalante@alsea.com.mx,roni.cirilo@alsea.com.mx, raul.ayala@ccscontactcenter.com, nancy.souberbielle@ccscontactcenter.com, alejandra.lopez@ccscontactcenter.com, isai.hernandez@ccscontactcenter.com ", "***RETRIBUCION***", MensajeRetribucion)
                        End If

                        msgtipo(0) = 1
                        msgmensaje(0) = "Correcto!"
                        Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
                    Else

                    End If

                End If

                If GetMailingIndex(GetLastLevel(), GetLastLevelDD()) <> 0 Then
                    If DropDownList5.SelectedItem.Text = "Nueva Queja" Then
                        If DropDownList17.Visible = False Then

                            LD = GetLD(GetMailingIndex(GetLastLevel(), GetLastLevelDD()), DropDownList10.SelectedItem.Value)
                        Else
                            LD = GetLD(GetMailingIndex(GetLastLevel(), GetLastLevelDD()), DropDownList17.SelectedItem.Value)
                        End If
                        Alerta.EnviarMail(LD, "jorge.sanchez@ccscontactcenter.com", "***QUEJA***", MensajeQueja)
                    Else
                        If DropDownList17.Visible = False Then
                            LD = GetLD(GetMailingIndex(GetLastLevel(), GetLastLevelDD()), DropDownList10.SelectedItem.Value)
                        Else
                            LD = GetLD(GetMailingIndex(GetLastLevel(), GetLastLevelDD()), DropDownList17.SelectedItem.Value)
                        End If
                        ' Alerta.EnviarMail(LD, "jorge.sanchez@ccscontactcenter.com", "***NO VENTA***", MensajeNoVenta)
                    End If
                Else
                End If


                Limpiar(Me.Controls)
                msgtipo(0) = 1
                msgmensaje(0) = "¡Interacción Guardada!"
                Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
                Session("nuevoCliente") = "1"
                Response.Redirect("Default.aspx")
            Else
                msgtipo(0) = 3
                msgmensaje(0) = "¡El Supervisor debe firmar la cancelacion/retribucion!"
                Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
            End If
        Else
            '############# FIN CANCELACION RETBUCION #######################
            Dim Tipificacion As String
            Dim LD As String
            Dim MensajeQueja, MensajeNoVenta, MensajeCancelacion, MensajeRetribucion As String


            ' MensajeQueja = "Tienda: " & DropDownList10.SelectedItem.Value & " </br> Nombre Tienda: " & NombreTienda(DropDownList10.SelectedItem.Value) & "</br> Cliente: " & TextBox1.Text & " " & TextBox2.Text & " " & TextBox4.Text & " </br> Telefono: " & TextBox5.Text & " </br> Domicilio: " & TextBox8.Text & " " & TextBox9.Text & " " & TextBox10.Text & " </br> Fecha: " & Format(Today(), "dd/MM/yyyy") & " </br> Monto: $" & TextBox32.Text


            Try
                If DropDownList11.Visible = True Then
                    Tipificacion = DropDownList5.SelectedItem.Text & " > " & DropDownList6.SelectedItem.Text & " > " & DropDownList10.SelectedItem.Text & " > " & DropDownList11.SelectedItem.Text
                ElseIf DropDownList10.Visible = True Then
                    Tipificacion = DropDownList5.SelectedItem.Text & " > " & DropDownList6.SelectedItem.Text & " > " & DropDownList10.SelectedItem.Text
                Else
                    Tipificacion = ""
                End If



                MensajeCancelacion = "Tienda: " & DropDownList10.SelectedItem.Value & " </br> Nombre Tienda: " & NombreTienda(DropDownList10.SelectedItem.Value) & "</br> Cliente: " & TextBox1.Text & " " & TextBox2.Text & " " & TextBox4.Text & " </br> Telefono: " & TextBox5.Text & " </br> Domicilio: " & TextBox8.Text & " " & TextBox9.Text & " " & TextBox10.Text & " </br> Fecha: " & Format(Today(), "dd/MM/yyyy") & " </br> Monto: $" & TextBox32.Text

                MensajeRetribucion = "Tienda: " & DropDownList10.SelectedItem.Value & " </br> Nombre Tienda: " & NombreTienda(DropDownList10.SelectedItem.Value) & "</br> Cliente: " & TextBox1.Text & " " & TextBox2.Text & " " & TextBox4.Text & " </br> Telefono: " & TextBox5.Text & " </br> Domicilio: " & TextBox8.Text & " " & TextBox9.Text & " " & TextBox10.Text & " </br> Fecha: " & Format(Today(), "dd/MM/yyyy") & " </br> Monto: $" & TextBox32.Text

            Catch ex As Exception
                Tipificacion = ""
            End Try



            If CheckBox1.Checked = True Then
                Session("CustomerID") = Insert_Cliente()
            Else
                Update_Cliente()
            End If

            Insert_Interaccion()
            UpdateInteracciones()

            Try



                MensajeNoVenta = "<html><head><style>table { font-family: arial, sans-serif; font-size: 14px; border-collapse: collapse; width: 50%;}td, th { border: 1px solid #dddddd; text-align: center; padding: 4px;}tr:nth-child(even) { background-color: #dddddd;}.negritas{font-weight: bold;}</style></head><body><table> <tr> <td>Fecha:</td> <td class='negritas'>" &
                        Format(Today(), "dd/MM/yyyy") &
                        "</td> </tr> <tr> <td>Hora:</td> <td class='negritas'>" &
                        Format(Now(), "HH:mm:ss am/pm") &
                        "</td> </tr> <tr> <td>Unidad:</td> <td class='negritas'>" &
                        DropDownList10.SelectedItem.Text &
                        "</td> </tr> <tr> <td>Tipo de Alerta</td> <td class='negritas'>" &
                        "NO VENTA" &
                        "</td> </tr> <tr> <td>Tipificación:</td> <td class='negritas'>" &
                        DropDownList6.SelectedItem.Text &
                        "</td> </tr> <tr> <td>Alertas Hoy:</td> <td class='negritas'>" &
                        x.GetNVDiaria(DropDownList10.SelectedItem.Value) &
                        "</td> </tr> <tr> <td>Alertas Semana:</td> <td class='negritas'>" &
                        x.GetNVSemana(DropDownList10.SelectedItem.Value) &
                        "</td> </tr> <tr> <td>Alertas Mes:</td> <td class='negritas'>" &
                        x.GetNVMes(DropDownList10.SelectedItem.Value) &
                        "</td> </tr></table></body></html>"

            Catch ex As Exception

            End Try


            If DropDownList5.Visible = True Then


                If DropDownList5.SelectedItem.Text = "Nueva Queja" Then
                    GuardarQuejaNueva()

                    MensajeQueja = "<html><head><style>table { font-family: arial, sans-serif; font-size: 14px; border-collapse: collapse; width: 50%;}td, th { border: 1px solid #dddddd; text-align: center; padding: 4px;}tr:nth-child(even) { background-color: #dddddd;}.negritas{font-weight: bold;}</style></head><body><table> <tr> <td>Fecha:</td> <td class='negritas'>" &
                            Format(Today(), "dd/MM/yyyy") &
                            "</td> </tr> <tr> <td>Hora:</td> <td class='negritas'>" &
                            Format(Now(), "HH:mm:ss am/pm") &
                            "</td> </tr> <tr> <td>Unidad:</td> <td class='negritas'>" &
                            DropDownList17.SelectedItem.Text &
                            "</td> </tr> <tr> <td>Tipo de Alerta</td> <td class='negritas'>" &
                            "QUEJA" &
                            "</td> </tr> <tr> <td>Cliente:</td> <td class='negritas'>" &
                            TextBox1.Text & " " & TextBox2.Text & " " & TextBox4.Text &
                            "</td> </tr> <tr> <td>Telefono:</td> <td class='negritas'>" &
                            TextBox5.Text &
                            "</td> </tr> <tr> <td>Tipificación:</td> <td class='negritas'>" &
                            DropDownList10.SelectedItem.Text &
                            "</td> </tr> <tr> <td>Descripcion:</td> <td class='negritas'>" &
                            TextBox18.Text &
                            "</td> </tr></table></body></html>"



                    If DropDownList6.SelectedItem.Text = "Inocuidad " Then
                        LD = GetCorreo(DropDownList17.SelectedItem.Value)
                        Alerta.EnviarMail(LD, "smirna-mirelle.beristain@alsea.com.mx, juan-carlos.cruz@alsea.com.mx, elizabeth.jimenez@alsea.com.mx, gerardo-antonio.cruz@alsea.com.mx , kathia.corona@starbucks.com.mx, jorge.sanchez@ccscontactcenter.com, oscar.almazan@ccscontactcenter.com, alejandra.lopez@ccscontactcenter.com", "***QUEJA INOCUIDAD***", MensajeQueja)
                    Else
                        LD = GetCorreo(DropDownList17.SelectedItem.Value)
                        Alerta.EnviarMail(LD, "jorge.sanchez@ccscontactcenter.com, oscar.almazan@ccscontactcenter.com, alejandra.lopez@ccscontactcenter.com", "***QUEJA***", MensajeQueja)
                    End If


                    Dim script1 As String = "document.getElementById('miEnlace').click();"
                    ScriptManager.RegisterStartupScript(Me, GetType(Page), "modalQueja", script1, True)
                ElseIf DropDownList5.SelectedItem.Text = "Nuevo Pedido" Then
                    EnviarPedido()
                    UpdatePedido()
                    msgtipo(0) = 1
                    msgmensaje(0) = "¡Pedido Guardado!"
                    Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
                ElseIf DropDownList5.SelectedItem.Text = "Seguimiento Queja" Then
                    UpdateQueja()
                    msgtipo(0) = 1
                    msgmensaje(0) = "¡Queja Guardada!"
                    Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
                ElseIf (DropDownList5.SelectedItem.Text = "Cancelacion" Or DropDownList5.SelectedItem.Text = "Retribucion") And HiddenField5.Value = 1 And HiddenField7.Value = 1 Then
                    Cancelar_Pedido()
                    If DropDownList5.SelectedItem.Text = "Cancelacion" Then
                        Alerta.EnviarMail2("vips" & DropDownList10.SelectedItem.Value & "@vips.com.mx", "enrique.escalante@alsea.com.mx,roni.cirilo@alsea.com.mx, raul.ayala@ccscontactcenter.com, nancy.souberbielle@ccscontactcenter.com, alejandra.lopez@ccscontactcenter.com, isai.hernandez@ccscontactcenter.com ", "***CANCELACION***", MensajeCancelacion)
                    ElseIf DropDownList5.SelectedItem.Text = "Retribucion" Then
                        Alerta.EnviarMail2("vips" & DropDownList10.SelectedItem.Value & "@vips.com.mx", "enrique.escalante@alsea.com.mx,roni.cirilo@alsea.com.mx, raul.ayala@ccscontactcenter.com, nancy.souberbielle@ccscontactcenter.com, alejandra.lopez@ccscontactcenter.com, isai.hernandez@ccscontactcenter.com ", "***RETRIBUCION***", MensajeRetribucion)
                    End If

                    msgtipo(0) = 1
                    msgmensaje(0) = "Correcto!"
                    Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
                Else

                End If

            End If

            If GetMailingIndex(GetLastLevel(), GetLastLevelDD()) <> 0 Then
                If DropDownList5.SelectedItem.Text = "Nueva Queja" Then
                    If DropDownList17.Visible = False Then

                        LD = GetLD(GetMailingIndex(GetLastLevel(), GetLastLevelDD()), DropDownList10.SelectedItem.Value)
                    Else
                        LD = GetLD(GetMailingIndex(GetLastLevel(), GetLastLevelDD()), DropDownList17.SelectedItem.Value)
                    End If
                    Alerta.EnviarMail(LD, "jorge.sanchez@ccscontactcenter.com", "***QUEJA***", MensajeQueja)
                Else
                    If DropDownList17.Visible = False Then
                        LD = GetLD(GetMailingIndex(GetLastLevel(), GetLastLevelDD()), DropDownList10.SelectedItem.Value)
                    Else
                        LD = GetLD(GetMailingIndex(GetLastLevel(), GetLastLevelDD()), DropDownList17.SelectedItem.Value)
                    End If
                    'Alerta.EnviarMail(LD, "jorge.sanchez@ccscontactcenter.com", "***NO VENTA***", MensajeNoVenta)
                End If
            Else
            End If


            Limpiar(Me.Controls)
            msgtipo(0) = 1
            msgmensaje(0) = "¡Interacción Guardada!"
            Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
            Session("nuevoCliente") = "1"
            Response.Redirect("Default.aspx")

        End If






    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        SearchCP()
    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged
        If TextBox17.Text = Nothing Then
            GridView2.Visible = False
        Else
            GridView2.Visible = True
            SearchCliente(TextBox17.Text)
        End If

    End Sub

    Private Sub TextBox51_TextChanged(sender As Object, e As EventArgs) Handles TextBox51.TextChanged
        If TextBox51.Text = Nothing Then
            GridView2.Visible = False
        Else
            GridView2.Visible = True
            SearchTelefono(TextBox51.Text)
        End If

    End Sub
    Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs) Handles TextBox21.TextChanged
        If TextBox22.Text = Nothing Then
            GetQuejas(TextBox21.Text)
        Else
            GetQuejas(TextBox21.Text, TextBox22.Text)
        End If
    End Sub

    Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs) Handles TextBox22.TextChanged
        If TextBox22.Text = Nothing Then
            GetQuejas(TextBox21.Text)
        Else
            GetQuejas(TextBox21.Text, TextBox22.Text)
        End If
    End Sub

    Private Sub TextBox46_TextChanged(sender As Object, e As EventArgs) Handles TextBox46.TextChanged

        Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        Dim conexion As New SqlConnection(strConnString)
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        Dim cmd As SqlCommand = New SqlCommand("EXEC [dbo].[GET_Detalle_Orden] @ID = '" & TextBox46.Text & "'", conexion)
        cmd.CommandType = CommandType.Text
        conexion.Open()
        da.SelectCommand = cmd
        da.Fill(ds)
        conexion.Close()

        If ds.Tables(0).Rows.Count = 0 Then
            'msgtipo(0) = 4
            'msgmensaje(0) = "¡El número de pedido es incorrecto o no lo has guardado en VOLO!"
            'Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
            Image3.Visible = False
            TextBox34.Text = Nothing
            TextBox35.Text = Nothing
            HiddenField6.Value = 0
        Else

            TextBox48.Text = ds.Tables(0).Rows(0).Item(4).ToString

        End If

    End Sub

    Protected Sub GridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes.Add("OnMouseOver", "On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Off(this);")
            e.Row.Attributes("OnClick") =
            Page.ClientScript.GetPostBackClientHyperlink(GridView3, "Select$" + e.Row.RowIndex.ToString)

        End If

    End Sub

    Private Sub GridView3_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView3.RowCommand
        If e.CommandName = "Select" Then
            Session("QuejaID") = String.Format("{1}", e.CommandArgument, GridView3.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text)
            LoadHistoricoQuejas()
            LoadGeneralQuejas()
            SeguimientoQuejas.Visible = False
            HistoricoContainer.Visible = True

        End If



    End Sub

    Protected Sub GridView4_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView4.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes.Add("OnMouseOver", "On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Off(this);")
            e.Row.Attributes("OnClick") =
            Page.ClientScript.GetPostBackClientHyperlink(GridView4, "Select$" + e.Row.RowIndex.ToString)

        End If

    End Sub

    Private Sub GridView4_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView4.RowCommand
        If e.CommandName = "Select" Then
            Session("QuejaID") = String.Format("{1}", e.CommandArgument, GridView4.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text)
            LoadHistoricoQuejas()
            LoadGeneralQuejas()
            GetCustomerForID(Session("ClienteQueja"))
            SeguimientoQuejas.Visible = False
            HistoricoContainer.Visible = True
        End If



    End Sub

    Private Sub TextBox26_TextChanged(sender As Object, e As EventArgs) Handles TextBox26.TextChanged

        'Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
        'Dim conexion As New SqlConnection(strConnString)
        'Dim da As New System.Data.SqlClient.SqlDataAdapter
        'Dim ds As New System.Data.DataSet

        'Dim cmd As SqlCommand = New SqlCommand("EXEC [dbo].[GET_Detalle_Orden] @ID = '" & TextBox26.Text & "'", conexion)
        'cmd.CommandType = CommandType.Text
        'conexion.Open()
        'da.SelectCommand = cmd
        'da.Fill(ds)
        'conexion.Close()

        'If ds.Tables(0).Rows.Count = 0 Then
        '    msgtipo(0) = 4
        '    msgmensaje(0) = "¡El número de pedido es incorrecto o no lo has guardado en VOLO!"
        '    Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
        '    Image1.Visible = False
        '    TextBox27.Text = Nothing
        '    TextBox29.Text = Nothing
        '    HiddenField4.Value = 0
        'Else
        '    Image1.Visible = True
        '    TextBox27.Text = ds.Tables(0).Rows(0).Item(1)
        '    TextBox29.Text = ds.Tables(0).Rows(0).Item(2)
        '    HiddenField4.Value = 1

        'End If

    End Sub

    'Private Sub TextBox30_TextChanged(sender As Object, e As EventArgs) Handles TextBox30.TextChanged

    '    Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
    '    Dim conexion As New SqlConnection(strConnString)
    '    Dim da As New System.Data.SqlClient.SqlDataAdapter
    '    Dim ds As New System.Data.DataSet

    '    Dim cmd As SqlCommand = New SqlCommand("EXEC [dbo].[GET_Detalle_Orden] @ID = '" & TextBox30.Text & "'", conexion)
    '    cmd.CommandType = CommandType.Text
    '    conexion.Open()
    '    da.SelectCommand = cmd
    '    da.Fill(ds)
    '    conexion.Close()

    '    If ds.Tables(0).Rows.Count = 0 Then
    '        msgtipo(0) = 4
    '        msgmensaje(0) = "¡El número de pedido es incorrecto o no lo has guardado en VOLO!"
    '        Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
    '        Image2.Visible = False
    '        TextBox31.Text = Nothing
    '        TextBox32.Text = Nothing
    '        HiddenField5.Value = 0
    '    Else
    '        Image2.Visible = True
    '        TextBox31.Text = ds.Tables(0).Rows(0).Item(1)
    '        TextBox32.Text = ds.Tables(0).Rows(0).Item(2)
    '        HiddenField5.Value = 1
    '        Session("tienda") = ds.Tables(0).Rows(0).Item(6)
    '    End If

    'End Sub

    'Private Sub TextBox33_TextChanged(sender As Object, e As EventArgs) Handles TextBox33.TextChanged
    '    Dim strConnString As String = ConfigurationManager.ConnectionStrings("VIPS").ConnectionString
    '    Dim conexion As New SqlConnection(strConnString)
    '    Dim da As New System.Data.SqlClient.SqlDataAdapter
    '    Dim ds As New System.Data.DataSet

    '    Dim cmd As SqlCommand = New SqlCommand("EXEC [dbo].[GET_Detalle_Orden] @ID = '" & TextBox33.Text & "'", conexion)
    '    cmd.CommandType = CommandType.Text
    '    conexion.Open()
    '    da.SelectCommand = cmd
    '    da.Fill(ds)
    '    conexion.Close()

    '    If ds.Tables(0).Rows.Count = 0 Then
    '        msgtipo(0) = 4
    '        msgmensaje(0) = "¡El número de pedido es incorrecto o no lo has guardado en VOLO!"
    '        Alerta.NewShowAlert(msgtipo, msgmensaje, Me)
    '        Image3.Visible = False
    '        TextBox34.Text = Nothing
    '        TextBox35.Text = Nothing
    '        HiddenField6.Value = 0
    '        TextBox36.Text = Nothing
    '        TextBox37.Text = Nothing
    '        TextBox38.Text = Nothing
    '        TextBox39.Text = Nothing
    '        TextBox40.Text = Nothing
    '        TextBox41.Text = Nothing
    '        TextBox42.Text = Nothing
    '        TextBox43.Text = Nothing
    '        TextBox44.Text = Nothing
    '        TextBox45.Text = Nothing
    '    Else
    '        Image3.Visible = True
    '        TextBox34.Text = ds.Tables(0).Rows(0).Item(1)
    '        TextBox35.Text = ds.Tables(0).Rows(0).Item(2)
    '        HiddenField6.Value = 1
    '        Session("Tienda") = ds.Tables(0).Rows(0).Item(3).ToString
    '        GetDetallesDrive(ds.Tables(0).Rows(0).Item(5).ToString)
    '        Dim script1 As String = "initMap(" & latitud.Value & "," & longitud.Value & ");"
    '        ScriptManager.RegisterStartupScript(Me, GetType(Page), "initMap", script1, True)


    '    End If
    'End Sub

    Public Sub Limpiar(ByVal controles As ControlCollection)
        For Each control As Control In controles
            If TypeOf control Is TextBox Then
                DirectCast(control, TextBox).Text = String.Empty
            ElseIf TypeOf control Is DropDownList Then
                DirectCast(control, DropDownList).ClearSelection()
            ElseIf TypeOf control Is RadioButtonList Then
                DirectCast(control, RadioButtonList).ClearSelection()
            ElseIf TypeOf control Is CheckBoxList Then
                DirectCast(control, CheckBoxList).ClearSelection()
            ElseIf TypeOf control Is RadioButton Then
                DirectCast(control, RadioButton).Checked = False
            ElseIf TypeOf control Is CheckBox Then
                DirectCast(control, CheckBox).Checked = False
            ElseIf control.HasControls() Then
                Limpiar(control.Controls)
            End If
        Next
    End Sub

    Private Sub TextBox52_TextChanged(sender As Object, e As EventArgs) Handles TextBox52.TextChanged
        Dim script1 As String = "initMap2(" & TextBox53.Text & "," & TextBox52.Text & ");"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "initMap2", script1, True)
    End Sub

    Private Sub TextBox53_TextChanged(sender As Object, e As EventArgs) Handles TextBox53.TextChanged
        Dim script1 As String = "initMap2(" & TextBox53.Text & "," & TextBox52.Text & ");"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "initMap2", script1, True)
    End Sub

    Private Sub DropDownList16_TextChanged(sender As Object, e As EventArgs) Handles DropDownList16.TextChanged
        StatusTienda()
    End Sub

    Private Sub DropDownList15_TextChanged(sender As Object, e As EventArgs) Handles DropDownList15.TextChanged
        If StatusDelivery(DropDownList15.SelectedItem.Value) = True Then
            DropDownList15.CssClass = "textboxGreen"
            Button1.Enabled = True
        ElseIf StatusDelivery(DropDownList15.SelectedItem.Value) = False Then
            DropDownList15.CssClass = "textboxRed"
            Button1.Enabled = False
        Else
            DropDownList15.CssClass = "textbox"
            Button1.Enabled = True
        End If

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox12.CssClass = "textbox validate[required,custom[email]]"
        Else
            TextBox12.CssClass = "textbox"
        End If
    End Sub

    Protected Sub TextBox50_TextChanged(sender As Object, e As EventArgs) Handles TextBox50.TextChanged
        If Autentificacion.AuthValidacion(TextBox47.Text, x.Passcrypt(TextBox50.Text)) = True Then
            Image4.Visible = True
            HiddenField7.Value = 1
        Else
            Image4.Visible = False
            HiddenField7.Value = 0
        End If
    End Sub
End Class

