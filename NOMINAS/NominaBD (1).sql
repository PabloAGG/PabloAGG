CREATE DATABASE NominaBD;
USE NominaBD;

Create table Usuario(
idUs int primary key identity(1,1),
nombre nvarchar(50),
contraseña nvarchar(20)
);
insert into Usuario(nombre, contraseña)
values ('Pablo228','123'),
('Jorge117','111');
drop table Usuario
-- Crear la tabla Empresa ---------------------------------------------------------------------------------------------------------
CREATE TABLE Empresa (
    id_empresa INT PRIMARY KEY IDENTITY(1,1),
	rfc_empresa NVARCHAR(13),	 
	nombre_empresa NVARCHAR (100) NOT NULL,
    razon_social NVARCHAR(100),
	registro_patronal NVARCHAR(50),
	fecha_inicio_operaciones DATE,
    dominio_fiscal NVARCHAR(150),
    datos_contacto NVARCHAR(150)	    
);

--CREATE TABLE PD (
--    id_pd INT PRIMARY KEY IDENTITY(1,1),         
--    nombre_pd VARCHAR(100) NOT NULL,                         
--	cantidad DECIMAL (10, 2),
--	EsPercepcion BIT,
--	 EsPorcentaje BIT default 0
--);
-- Crear la tabla Departamento ----------------------------------------------------------------------------------------------------
CREATE TABLE Departamento (
    id_departamento INT PRIMARY KEY IDENTITY(1,1),
	nombre_departamento NVARCHAR(100) NOT NULL,
	id_empresa INT,
	FOREIGN KEY (id_empresa) REFERENCES Empresa(id_empresa)

);

-- Crear la tabla Puesto ----------------------------------------------------------------------------------------------------------
CREATE TABLE Puesto (
    id_puesto INT PRIMARY KEY IDENTITY(1,1),         
    nombre_puesto VARCHAR(100) NOT NULL,                                                                        
    id_departamento INT,                                 
    FOREIGN KEY (id_departamento) REFERENCES Departamento(id_departamento) 
);
select * from PD
-- Crear la tabla Empleado --------------------------------------------------------------------------------------------------------
CREATE TABLE Empleado (
    id_empleado INT PRIMARY key ,
	nombre_empleado NVARCHAR(150),
	apellido_paterno NVARCHAR (150),
	apellido_materno NVARCHAR (150),
	fecha_nacimiento DATE,
	curp NVARCHAR(18),
	rfc NVARCHAR(13),
	nss NVARCHAR (11),
	direccion NVARCHAR (100),
	banco NVARCHAR(100),
	numero_cuenta NVARCHAR(20),
	email NVARCHAR(100),
	telefono NVARCHAR(20),
	fecha_ingreso_empresa DATE,
	sueldo DECIMAL(10, 2),
	tipo_empleado INT,
	id_puesto INT,
	id_departamento INT,
	FOREIGN KEY (id_departamento) REFERENCES Departamento(id_departamento),
	FOREIGN KEY (id_puesto) REFERENCES Puesto(id_puesto)
);


--UPDATE Empleado
--SET sueldo = P.sueldo_especifico_diario
--FROM Empleado E
--INNER JOIN Puesto P
--ON E.id_puesto = P.id_puesto;
 

-- Crear la tabla Nomina --------------------------------------------------------------------------------------------------------
	CREATE TABLE Nomina (
		id_nomina INT PRIMARY KEY IDENTITY(1,1),  
		id_empleado int,
		Mes INT,                           
		Fecha_pago DATE, 
		Año int,
	sueldo_neto DECIMAL(10, 2),
sueldo_bruto DECIMAL(10, 2),

		FOREIGN KEY (id_empleado) REFERENCES Empleado(id_empleado),

	);

-------------------------------------------------------------------
CREATE TABLE periodos (
    id_periodo INT PRIMARY KEY IDENTITY(1,1),
    mes int,
    año int,
);
-------------------------------------------------------------------
DROP TABLE CONCEPTO;
ALTER TABLE CONCEPTO
ALTER COLUMN DiasTrabajados Decimal (5,2)

CREATE TABLE CONCEPTO (
    id_concepto INT IDENTITY(1,1) PRIMARY KEY,  -- Identificador único de la nómina
	id_empleado int,
    Sueldo DECIMAL(10, 2),  -- Sueldo del empleado
	SalarioDiario DECIMAL(10, 2),
    DiasTrabajados Decimal(5,2) default 30.41,  -- Días trabajados en el mes 30
    BonoAsistencia DECIMAL(10, 2),  -- Bono de asistencia (constante) 0.07
    Despensa DECIMAL(10, 2),  -- Bono de despensa (constante) 0.15
    ISR DECIMAL(10, 2),  -- Impuesto sobre la renta 0.02
    IMSS DECIMAL(10, 2)  ,  -- Porcentaje de IMSS (constante) 0.05
    PrestamoINF DECIMAL(10, 2) ,  -- Préstamo INFONAVIT (constante)0.11
    FondoAhorro DECIMAL(10, 2),  -- Fondo de ahorro 0.05
    Puntualidad DECIMAL(10, 2) , -- Bono de puntualidad (constante)0.05
	SMI DECIMAL(10, 2),  -- Salario Diario Integrado
	FOREIGN KEY (id_empleado) REFERENCES Empleado(id_empleado)
);
create table incidencias(
id_inc int primary key identity(1,1),
id_empleado int,
id_periodo int,
sueldodia decimal(10,2),
 Vacaciones DECIMAL(10, 2) DEFAULT 0,  -- Vacaciones
 Aguinaldo DECIMAL(10, 2) DEFAULT 0,  -- Aguinaldo
 HorasExtras DECIMAL(10, 2)DEFAULT 0,  -- Horas extras
 faltas DECIMAL(10, 2) DEFAULT 0,  -- Deducción por retardos
 sueldofinal decimal(10,2) DEFAULT 0,
    FOREIGN KEY (id_periodo) REFERENCES periodos(id_periodo),
	FOREIGN KEY (id_empleado) REFERENCES Empleado(id_empleado)
);
-- Inserción de valores en las tablas ---------------------------------------------------------------------------------------------
INSERT INTO Nomina (id_empleado, Mes, Fecha_pago, Año, sueldo_neto, sueldo_bruto)
    VALUES (1, 03, '2003-04-03', 2003, 300, 500);


INSERT INTO Empresa (rfc_empresa, nombre_empresa, razon_social, registro_patronal, fecha_inicio_operaciones, dominio_fiscal, datos_contacto) 
    VALUES ('ABC1234567890', 'LMAD S.A. de C.V.', 'LMAD Servicios y Soluciones', 'RP12345678', '2022-05-15', 'Av. Revolución 123, Ciudad de México, CDMX', 'contacto@tecnologiaavanzada.com | 55-1234-5678');

INSERT INTO Departamento (nombre_departamento, id_empresa)
    VALUES ('Contablidad', 1);




SELECT * FROM Nomina;
select * from Puesto;

select * from Departamento;


----EXEC InsertarEmpleado
--    --@nombre_empleado = 'Juan',
--    --@apellido_paterno = 'Pérez',
--   -- @apellido_materno = 'Gómez',
--   -- @fecha_nacimiento = '1995-08-15',
--  --
--   -- @curp = 'PEGJ950815HDFRMS04',
--   -- @rfc = 'PEGJ950815RT3',
--    @nss = '12345678901',
--    @direccion = 'Av. Siempre Viva 742',
--    @banco = 'Banco Ejemplo',
--    @numero_cuenta = '1234567890123456',
--    @email = 'juan.perez@example.com',
--    @telefono = '5512345678',
--    @fecha_ingreso_empresa = '2024-01-10',
--    @fecha_contrato = '2024-01-15',
--    @sueldo = 25000.50,
--    @tipo_empleado = 1,
--    @id_puesto = 3,
--    @id_departamento = 2;
--	select *from Nomina;

---------------------------------------------------------------

UPDATE CONCEPTO
SET PensionAlimenticia = 0
WHERE PensionAlimenticia IS NULL;
sp_help 'CONCEPTO';

SELECT 
    COLUMN_NAME AS NombreColumna, 
    DATA_TYPE AS TipoDato, 
    CHARACTER_MAXIMUM_LENGTH AS LongitudMaxima,
    IS_NULLABLE AS PermiteNulo,
    ORDINAL_POSITION AS OrdenColumna
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'CONCEPTO'
ORDER BY ORDINAL_POSITION;



SELECT  * FROM CONCEPTO;

--ESTO DA EL INDICE DE CADA ATRIBUTO EN FORMA DE TABLA 
SELECT COLUMN_NAME, ORDINAL_POSITION 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'CONCEPTO';


-------------------------------------------------------------------
WITH CTE AS (
    SELECT 
        id,
        ROW_NUMBER() OVER (PARTITION BY id_empleado, YEAR(fecha_periodo), MONTH(fecha_periodo) ORDER BY FeEXP DESC) AS fila
    FROM Nomina
)
DELETE FROM Nomina
WHERE id IN (
    SELECT id FROM CTE WHERE fila > 1
);




----lo de las nominas generales-------
SELECT 
    e.id_empleado AS ID_Empleado,
    e.nombre_empleado + ' ' + e.apellido_paterno + ' ' + e.apellido_materno AS Nombre_Empleado,
    c.Sueldo AS Sueldo_Bruto,
    c.SalarioDiario,
    c.BonoAsistencia,
    c.Despensa,
    c.ISR,
    c.IMSS,
    c.PrestamoINF,
    c.FondoAhorro,
    c.Puntualidad,
    ISNULL(i.Vacaciones, 0) AS Vacaciones,
    ISNULL(i.Aguinaldo, 0) AS Aguinaldo,
    ISNULL(i.HorasExtras, 0) AS HorasExtras,
    ISNULL(i.faltas, 0) AS Faltas,
    ISNULL(i.sueldofinal, c.SMI) AS Sueldo_Final -- Si no hay incidencias, usa el sueldo bruto
FROM Empleado e
INNER JOIN CONCEPTO c ON e.id_empleado = c.id_empleado
LEFT JOIN incidencias i ON e.id_empleado = i.id_empleado


select * from incidencias;
EXEC InsertarEmpleado 
    @id_empleado = 2,
    @nombre_empleado = 'Juan',
    @apellido_paterno = 'PaGod',
    @apellido_materno = 'López',
    @fecha_nacimiento = '1990-01-01',
    @curp = 'CURP1234567890AB',
    @rfc = 'RFC123456A12',
    @nss = '12345678901',
    @direccion = 'Calle Ejemplo #123',
    @banco = 'Banco Ejemplo',
    @numero_cuenta = '1234567890',
    @email = 'juan.perez@example.com',
    @telefono = '1234567890',
    @fecha_ingreso_empresa = '2023-01-15',
    @sueldo = 1000,
    @tipo_empleado = 1,
    @id_puesto = 1,
    @id_departamento = 1;

	EXEC InsertarDepartamento 
    @nombre_departamento = 'Recursos Humanos',
    @id_empresa = 1;

EXEC InsertarPuesto 
    @nombre_puesto = 'Gerente',
    @id_departamento = 1;

	EXEC InsertarPeriodo 
    @mes = 12,
    @año = 2023;


	EXEC AgregarIncidencias 
    @id_empleado = 2,
    @id_periodo = 1, -- Ejemplo: periodo de diciembre 2023
    @vacaciones = 1000.00,
    @aguinaldo = 1000.00,
    @horas_extras = 1000.00,
    @faltas =0.00;

	select *from Empleado;
		select *from Departamento;
			select *from CONCEPTO;