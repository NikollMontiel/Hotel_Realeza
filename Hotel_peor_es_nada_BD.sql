create database Hotel_Peor_Es_Nada

use Hotel_Peor_Es_Nada

create table Clientes(
ID_Cliente int identity(1,1) primary key not null,
PNC nvarchar(15) not null,
SNC nvarchar(15),
PAC nvarchar(15) not null,
SAC nvarchar(15),
TelC char(8) check(TelC like '[2|5|7|8][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
EstadoC bit default 1 not null
)

select * from Clientes

create table Tipo_Hab(
ID_TipoHab int identity(1,1) primary key not null,
Tipo_hab nvarchar(10) not null
)

create table Habitaciones(
ID_Hab int identity(1,1) primary key not null,
Numero_hab int not null,
Precio money not null,
ID_TipoHab int foreign key references Tipo_Hab(ID_TipoHab) not null,
EstadoH bit 
)

select * from Habitaciones

create table Forma_Pago(
ID_FPago int identity(1,1) primary key not null,
Forma_Pago nvarchar(20) not null
)
select * from Habitaciones
create table Reservaciones(
ID_reserva int identity(1,1) primary key not null,
fecha_reserva date not null,
ID_Hab int foreign key references Habitaciones(ID_Hab) not null,
ID_Cliente int foreign key references Clientes(ID_Cliente) not null,
tiempo_instancia int not null,
ID_FPago int foreign key references Forma_Pago(ID_FPago) not null,
Estado_salida bit default 1 not null
)

create table Refrigeradores(
ID_Refrigerador int identity(1,1) primary key not null,
Marca nvarchar(30) not null,
ID_Hab int foreign key references Habitaciones(ID_Hab) not null,
EstadoR bit default 1 not null
)

create table Productos(
ID_Producto int identity(1,1) primary key not null,
Nombre nvarchar(30) not null,
fecha_vencimiento date not null,
Existencia int not null,
Precio money not null,
EstadoP bit default 1 not null
)

create table Refrigerador_Productos(
ID int identity(1,1) primary key not null,
Cantidad int not null,
ID_Refrigerador int foreign key references Refrigeradores(ID_Refrigerador) not null,
ID_Producto int foreign key references Productos(ID_Producto) not null
)

create table Consumo_Cliente(
ID_consumo int identity(1,1) primary key not null,
ID_Cliente int foreign key references Clientes(ID_Cliente) not null,
ID_Refrigerador int foreign key references Refrigeradores(ID_Refrigerador) not null,
ID_Hab int foreign key references Habitaciones(ID_Hab) not null,
ID_Producto int foreign key references Productos(ID_Producto) not null,
Cantidad_Consumida int not null,
Total_pago money not null,
EstadoCC bit default 1 not null
)

create table Productos_baño_hab(
ID int identity(1,1) primary key not null,
Cantidad int not null,
ID_Producto int foreign key references Productos(ID_Producto) not null,
ID_Hab int foreign key references Habitaciones(ID_Hab) not null,
)

create table Telefonos_Hab(
ID_Tel int identity(1,1) primary key not null,
ID_Hab int foreign key references Habitaciones(ID_Hab) not null
)

create table Tipo_llamada(
ID_tipo_llamada int identity(1,1) primary key not null,
Tipo_llamada nvarchar(15) not null
)

create table llamadas_Cliente(
ID_llamada int identity(1,1) primary key not null,
Costo_llamada money not null,
ID_Tel int foreign key references Telefonos_Hab(ID_Tel) not null,
ID_tipo_llamada int foreign key references Tipo_llamada(ID_tipo_llamada) not null,
ID_Cliente int foreign key references Clientes(ID_Cliente) not null,
ID_Hab int foreign key references Habitaciones(ID_Hab) not null
)

create table Cuenta_Cliente(
ID_Cuenta int identity(1,1) primary key not null,
ID_Cliente int foreign key references Clientes(ID_Cliente) not null,
ID_Hab int foreign key references Habitaciones(ID_Hab) not null,
ID_Reserva int foreign key references Reservaciones(ID_Reserva) not null,
Forma_Pago nvarchar(10) not null,
Total_llamadas money not null,
Total_Refrigerador money not null,
Total_estancia money not null,
Total_a_pagar money not null
) 

create table Factura_O_Boleta(
ID_Fac int identity(1,1) primary key not null,
RUT nvarchar(9),
ID_Cliente int foreign key references Clientes(ID_Cliente) not null,
Total_Pago money not null
)




create table Tipo_Evento(
ID_tipo_evento int identity(1,1) primary key not null,
Tipo_Evento nvarchar(15) not null
)

insert into Tipo_Evento values('Fiesta'),('Conferencia'),('Despedida'),('Reunion')


create table Eventos(
ID_Evento int identity(1,1) primary key not null,
ID_Cliente int foreign key references Clientes(ID_Cliente) not null,
ID_tipo_evento int foreign key references Tipo_Evento(ID_tipo_evento) not null,
Costo_Evento money not null,
Fecha_Evento date not null
)

Create table Proveedor(
ID_Prov int identity(1,1) primary key not null,
PNP nvarchar(15) not null,
SNP nvarchar(15),
PAP nvarchar(15) not null,
SAP nvarchar(15),
TelP char(8) check(TelP like '[2|5|7|8][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
)

create table Compra_Producto(
ID_Compra int identity(1,1) primary key not null,
ID_Prov int foreign key references Proveedor(ID_Prov) not null,
ID_Producto int foreign key references Productos(ID_Producto) not null,
Cantidad int not null,
Fecha_Compra date not null,
Total_pago money not null
)

create table Devolucion_Producto(
ID_Dev int identity(1,1) primary key not null,
ID_Producto int foreign key references Productos(ID_Producto) not null,
ID_Prov int foreign key references Proveedor(ID_Prov) not null,
Cantidad int not null,
Fecha_Dev date not null,
Motivo_Dev nvarchar(100) not null,
Total_Dev money not null
)

create table Roles(
ID_Rol int identity(1,1) primary key not null,
Rol nvarchar(25) not null
)
select * from Roles
insert into Roles values('Recepcionista'),('Administrador'),('Contador'),('Limpieza')

create table Usuarios(
ID_U int identity(1,1) primary key not null,
Nombre_Usuario nvarchar(20) not null,
Contraseña nvarchar(20) not null,
ID_Rol int foreign key references  Roles(ID_Rol) not null,
intentos int not null,
Estado bit default 0 not null
)

insert into Usuarios values('Nikoll','123',2,0,0)
use Hotel_Peor_Es_Nada

select * from roles
select * from Usuarios

update Usuarios set intentos = 0 where ID_U = 1