<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpages/Content.Master" CodeBehind="Tiendas.aspx.vb" Inherits="VIPS.Tiendas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <link href="../CSS/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery.validationEngine-en.js" charset="utf-8"></script>
    <script src="../JS/jquery.validationEngine.js" charset="utf-8"></script>
    <script id="grid" type="text/javascript">



        function pageLoad() {
            jQuery("#form1").validationEngine();
        }





        function DateFormat(field, rules, i, options) {
            var regex = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
            if (!regex.test(field.val())) {
                return "La fecha debe estar en formato DD/MM/AAAA"
            }
        }



        function On(GridView) {
            if (GridView != null) {
                GridView.originalBgColor = GridView.style.backgroundColor;
                GridView.style.backgroundColor = "#EEEEEE";
                GridView.style.Color = "#FFFFFF";
            }
        }

        function Off(GridView) {
            if (GridView != null) {
                GridView.style.backgroundColor = GridView.originalBgColor;
            }
        }



    </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="0" EnablePageMethods="True"></asp:ToolkitScriptManager>


    <div id="site_content">

        <div class="content">

            <h1>
                <asp:Label ID="Label75" runat="server" Text="Administrar Tiendas" Font-Size="100%" ForeColor="#063E4C"></asp:Label></h1>


            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div runat="server" id="tiendasMod">
                        <asp:Panel ID="Panel1" runat="server">
                        </asp:Panel>
                    </div>


                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="Button" Width="70px" Height="20px" />


        </div>


    </div>

</asp:Content>
