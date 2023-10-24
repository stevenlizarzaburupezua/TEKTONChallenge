CREATE DATABASE TEKTONPRODUCT
GO

USE TEKTONPRODUCT
GO

CREATE TABLE PRODUCTO (
   ID int identity,
   NOMBRE VARCHAR(50),
   FOTO image,
   DESCRIPCION VARCHAR(200),
   ID_CATEGORIA int,
   STOCK int,
   PRECIO MONEY,
   FLG_ACTIVE BIT,
   ID_ESTADO int,
   FEC_REGISTRO DATETIME,
)

GO

INSERT INTO PRODUCTO (NOMBRE, FOTO, DESCRIPCION, ID_CATEGORIA, STOCK, PRECIO, FLG_ACTIVE, ID_ESTADO, FEC_REGISTRO) 
VALUES ('Teléfono Inteligente', NULL, 'Teléfono inteligente de última generación', 1, 100, 599.99, 1, 1, GETDATE()),
       ('Laptop Ultradelgada', NULL, 'Laptop ultradelgada y potente', 1, 50, 899.99, 1,1, GETDATE()),
       ('Camiseta de Algodón', NULL, 'Camiseta de algodón de alta calidad', 2, 200, 1,19.99, 1, GETDATE()),
       ('Sofá de Cuero', NULL, 'Sofá de cuero para sala de estar', 3, 10, 699.99, 1,3, GETDATE());
GO

CREATE TABLE CATEGORIA (
   ID int identity,
   NOMBRE VARCHAR(50),
   DESCRIPCION VARCHAR(200),
   FLG_ACTIVE int,
   FEC_REGISTRO DATETIME,
)

GO

INSERT INTO CATEGORIA (NOMBRE, DESCRIPCION, FLG_ACTIVE, FEC_REGISTRO) VALUES ('Electrónicos', 'Productos electrónicos', 1, GETDATE()),
                                                                             ('Ropa', 'Ropa y accesorios', 1, GETDATE()),
																			 ('Hogar', 'Productos para el hogar', 1, GETDATE());

CREATE TABLE ESTADO (
   ID int identity,
   NOMBRE VARCHAR(50),
   DESCRIPCION VARCHAR(200),
   FEC_REGISTRO DATETIME,
)

GO

INSERT INTO ESTADO (NOMBRE, DESCRIPCION, FEC_REGISTRO)
VALUES ('Disponible', 'Producto disponible para la venta', GETDATE()),
       ('Agotado', 'Producto agotado temporalmente', GETDATE()),
       ('En Reparación', 'Producto en proceso de reparación', GETDATE());
GO

CREATE PROCEDURE USP_OBTENER_PRODUCTO 

@P_IDPRODUCTO INT
AS
        BEGIN
            SELECT P.ID AS IDPRODUCTO, 
                   P.NOMBRE AS NOMBREPRODUCTO, 
                   P.FOTO AS FOTOPRODUCTO,
				   P.DESCRIPCION AS DESCRIPCIONPRODUCTO,
				   C.ID AS IDCATEGORIA,
				   C.NOMBRE AS NOMBRECATEGORIA,
				   E.ID AS IDESTADO,
				   E.NOMBRE AS NOMBRESTADO                   
            FROM   PRODUCTO P
                 INNER JOIN CATEGORIA C  ON P.ID_CATEGORIA = C.ID
				 INNER JOIN ESTADO E ON P.ID_ESTADO = E.ID
            WHERE P.ID = @P_IDPRODUCTO 
        END;
GO

CREATE PROCEDURE USP_OBTENER_PRODUCTOS 

AS
        BEGIN
            SELECT P.ID AS IDPRODUCTO, 
                   P.NOMBRE AS NOMBREPRODUCTO, 
                   P.FOTO AS FOTOPRODUCTO,
				   P.DESCRIPCION AS DESCRIPCIONPRODUCTO,
				   C.ID AS IDCATEGORIA,
				   C.NOMBRE AS NOMBRECATEGORIA,
				   E.ID AS IDESTADO,
				   E.NOMBRE AS NOMBRESTADO                   
            FROM   PRODUCTO P
                 INNER JOIN CATEGORIA C  ON P.ID_CATEGORIA = C.ID
				 INNER JOIN ESTADO E ON P.ID_ESTADO = E.ID
       
        END;
GO
