<%@ Page Title="" Language="C#" MasterPageFile="~/App/Site1.Master" AutoEventWireup="true" CodeBehind="UsuarioWF.aspx.cs" Inherits="Web.App.UsuarioWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Content page-->
	<section>
		<!-- NavBar -->
		
		<!-- Content page -->
		<div class="container-fluid">
			<div class="page-header">
			  <h1 class="text-titles"><i class="zmdi zmdi-face zmdi-hc-fw"></i> Usuarios <small>datos</small></h1>
			</div>
		</div>
		<div class="container-fluid">
			<div class="row">
				<div class="col-xs-12">
					<ul class="nav nav-tabs" style="margin-bottom: 15px;">
					  	<li class="active"><a href="#new" data-toggle="tab">New</a></li>
					  	<li><a href="#list" data-toggle="tab">List</a></li>
					</ul>
					<div id="myTabContent" class="tab-content">
						<div class="tab-pane fade active in" id="new">
							<div class="container-fluid">
								<div class="row">
									<div class="col-xs-12 col-md-10 col-md-offset-1">
									    <form action="" runat="server">
                                          
                                          
                                            <section  class = "row center">
                                                <div class="col-lg-1 p-0">
                                                        <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                                                        <span class="fas fa-search"></span>Buscar
                                                        </asp:LinkButton>
                                                          
                                                      </div>
                                            </section>
                                                
                                             
									    	<div class="form-group label-floating">
											  <asp:Label ID="Label1" runat="server" class="control-label" Text="Id"></asp:Label>
											   <asp:TextBox ID="UsuarioId" runat="server" class="form-control"  ></asp:TextBox>
											</div>
                                   
                                            <div class="form-group label-floating">
											  <asp:Label ID="Label2" runat="server" class="control-label" Text="Nombres"></asp:Label>
											   <asp:TextBox ID="NombresTextBox" runat="server" class="form-control"  ></asp:TextBox>
											</div>

                                            <div class="form-group label-floating">
											  <asp:Label ID="Label3" runat="server" class="control-label" Text="Email"></asp:Label>
											   <asp:TextBox ID="EmailTextBox" runat="server" class="form-control"  ></asp:TextBox>
											</div>
                                                                                      <div class="form-group">                                            <label class="control-label">Nivel de Usuario</label>                                            <asp:DropDownList ID="DropDownList" runat="server" Width="904px">
                                            <asp:ListItem>Administrador</asp:ListItem>
                                            <asp:ListItem>Venta</asp:ListItem>
                                            <asp:ListItem>Contabilidad</asp:ListItem>                                            </asp:DropDownList>                                            </div>                                            <div class="form-group label-floating">
											  <asp:Label ID="Label4" runat="server" class="control-label" Text="Usuario"></asp:Label>
											   <asp:TextBox ID="UsuarioTextBox" runat="server" class="form-control"  ></asp:TextBox>
											</div>

                                            <div class="form-group label-floating">
											  <asp:Label ID="Label5" runat="server" class="control-label" Text="Clave"></asp:Label>
											   <asp:TextBox ID="ClaveTextBox" runat="server" class="form-control"  ></asp:TextBox>
											</div>

                                            <div class="form-group label-floating">
											  <asp:Label ID="Label6" runat="server" class="control-label" Text="Confirmar"></asp:Label>
											   <asp:TextBox ID="ConfirmarTextBox" runat="server" class="form-control"  ></asp:TextBox>
											</div>
										    <p class="text-center">
                                                <asp:Button ID="Guardar" runat="server"  Text="Gurdar" class="btn btn-info btn-raised btn-sm" OnClick="Guardar_Click"/>
                                                 <asp:Button ID="Eliminar" runat="server"  Text="Eliminar" class="btn btn-success btn-raised btn-sm" OnClick="Eliminar_Click" />
                                            </p>
									    </form>
									</div>
								</div>
							</div>
						</div>
					  	<div class="tab-pane fade" id="list">
							<div class="table-responsive">
								<table class="table table-hover text-center">
									<thead>
										<tr>
											<th class="text-center">#</th>
											<th class="text-center">Nombres</th>
											<th class="text-center">Email</th>
											<th class="text-center">Uuario</th>
											<th class="text-center">Clave</th>
											<th class="text-center">Fecha</th>
										</tr>
									</thead>
									<tbody>
										<tr>
											<td>1</td>
											<td>Carlos</td>
											<td>carlos@gmail.com</td>
											<td>wal</td>
											<td>123456</td>
											<td>07/03/1997</td>
										</tr>
										
									</tbody>
								</table>
								<ul class="pagination pagination-sm">
								  	<li class="disabled"><a href="#!">«</a></li>
								  	<li class="active"><a href="#!">1</a></li>
								  	<li><a href="#!">2</a></li>
								  	<li><a href="#!">3</a></li>
								  	<li><a href="#!">4</a></li>
								  	<li><a href="#!">5</a></li>
								  	<li><a href="#!">»</a></li>
								</ul>
							</div>
					  	</div>
					</div>
				</div>
			</div>
		</div>
	</section>
</asp:Content>
