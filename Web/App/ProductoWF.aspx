﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App/Site1.Master" AutoEventWireup="true" CodeBehind="ProductoWF.aspx.cs" Inherits="Web.App.ProductoWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
		<!-- NavBar -->
		
		<!-- Content page -->
		<div class="container-fluid">
			<div class="page-header">
			  <h1 class="text-titles"><i class="zmdi zmdi-face zmdi-hc-fw"></i> Productos <small>datos</small></h1>
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
											  <asp:Label ID="Label1" runat="server" class="control-label" Text="ProductoId"></asp:Label>
											   <asp:TextBox ID="ProductoId" runat="server" class="form-control"  ></asp:TextBox>
											</div>

                                            <div class="form-group label-floating">
											  <asp:Label ID="Label2" runat="server" class="control-label" Text="ProveedorId"></asp:Label>
											   <asp:TextBox ID="ProveedorId" runat="server" class="form-control"  ></asp:TextBox>
											</div>

                                            <div class="form-group label-floating">
											  <asp:Label ID="Label3" runat="server" class="control-label" Text="Descripcion"></asp:Label>
											   <asp:TextBox ID="DescripcionTextBox" runat="server" class="form-control"  ></asp:TextBox>
										                                            <div class="form-group label-floating">
											  <asp:Label ID="Label4" runat="server" class="control-label" Text="Cantidad"></asp:Label>
											   <asp:TextBox ID="CantidadTextBox" runat="server" class="form-control"  ></asp:TextBox>
											</div>

                                            <div class="form-group label-floating">
											  <asp:Label ID="Label5" runat="server" class="control-label" Text="Costo"></asp:Label>
											   <asp:TextBox ID="CostoTextBox" runat="server" class="form-control"  ></asp:TextBox>
											</div>

                                            <div class="form-group label-floating">
											  <asp:Label ID="Label6" runat="server" class="control-label" Text="Precio"></asp:Label>
											   <asp:TextBox ID="PrecioTextBox" runat="server" class="form-control"  ></asp:TextBox>
											</div>

                                            <div class="form-group label-floating">
											<asp:Label ID="Label7" runat="server" class="control-label" Text="Ganancia"></asp:Label>
											<asp:TextBox ID="GananciaTextBox" runat="server" class="form-control"  ></asp:TextBox>
											</div>

                                            <div class="form-group label-floating">
											<asp:Label ID="Label8" runat="server" class="control-label" Text="Descuento"></asp:Label>
											<asp:TextBox ID="DescuentoTextBox" runat="server" class="form-control"  ></asp:TextBox>
											</div>

										    <p class="text-center">
                                                <asp:Button ID="Guardar" runat="server"  Text="Gurdar" class="btn btn-info btn-raised btn-sm" OnClick="Guardar_Click"/>
                                                 <asp:Button ID="Eliminar" runat="server"  Text="Eliminar" class="btn btn-success btn-raised btn-xs" OnClick="Eliminar_Click" />
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
