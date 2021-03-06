
/****** Object:  StoredProcedure [dbo].[MiProcedimientoAlmacenado]    Script Date: 05/02/2021 10:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MiProcedimientoAlmacenado]
	@xml_usuarios XML
	,@xml_compras XML
	,@xml_itemsIva XML
AS
BEGIN
	
SET NOCOUNT ON;


DECLARE @handleUsuarios INT,   @handleCompras INT,   @handleitemsIva INT 
DECLARE @PrepareXmlStatus INT  

EXEC @PrepareXmlStatus= sp_xml_preparedocument @handleUsuarios OUTPUT, @xml_usuarios  
EXEC @PrepareXmlStatus= sp_xml_preparedocument @handleCompras OUTPUT, @xml_compras  
EXEC @PrepareXmlStatus= sp_xml_preparedocument @handleitemsIva OUTPUT, @xml_itemsIva  

;WITH UsuariosCTE (Id,Nombre)
AS
(
SELECT  * 
FROM    OPENXML(@handleUsuarios, '/Data/Usuario', 2)  
    WITH (
    Id INT,
    Nombre Nvarchar(50)
    )  
)

,ComprasCTE (Usuario, Producto, Valor)  
AS    
(
SELECT  * 
FROM    OPENXML(@handleCompras, '/Data/Item', 2)  
    WITH (
    Usuario INT,
    Producto INT,
	Valor numeric(19,2)
    )  
)

,ItemsIvaCTE (IdProducto,Porcentaje)
AS
(
SELECT  * 
FROM    OPENXML(@handleitemsIva, '/Data/Producto', 2)  
    WITH (
    IdProducto INT,
	Porcentaje numeric(19,2)
    )  
)

SELECT 
A.Id,A.Nombre
,ISNULL(SUM(B.Valor),0) AS Valor
,ISNULL(SUM(C.Porcentaje*B.Valor),0) AS Iva  
FROM  UsuariosCTE A
	LEFT JOIN ComprasCTE B ON A.Id = B.Usuario
	LEFT JOIN ItemsIvaCTE C ON B.Producto = C.IdProducto
GROUP BY A.Id,A.Nombre
ORDER BY 1

EXEC sp_xml_removedocument @handleUsuarios 
EXEC sp_xml_removedocument @handleCompras 
EXEC sp_xml_removedocument @handleitemsIva 



END
