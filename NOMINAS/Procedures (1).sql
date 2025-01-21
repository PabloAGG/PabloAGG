CREATE PROCEDURE InsertarPeriodo
    @mes INT,
    @año INT
AS
BEGIN
    INSERT INTO periodos (mes, año)
    VALUES (@mes, @año);
END;
-- PROCEDURE PARA INSERTAR EMPLEADO -----------------------------------------------------------------------------------------------
drop procedure InsertarEmpleado;
CREATE PROCEDURE InsertarEmpleado
    @id_empleado INT,
    @nombre_empleado NVARCHAR(150),
    @apellido_paterno NVARCHAR(150),
    @apellido_materno NVARCHAR(150),
    @fecha_nacimiento DATE,
    @curp NVARCHAR(18),
    @rfc NVARCHAR(13),
    @nss NVARCHAR(11),
    @direccion NVARCHAR(100),
    @banco NVARCHAR(100),
    @numero_cuenta NVARCHAR(20),
    @email NVARCHAR(100),
    @telefono NVARCHAR(20),
    @fecha_ingreso_empresa DATE,
    @sueldo DECIMAL(10, 2),
    @tipo_empleado INT,
    @id_puesto INT,
    @id_departamento INT
AS
BEGIN
    -- Declaración de variables para los cálculos
    DECLARE @sd DECIMAL(10, 2); -- Salario Diario
    DECLARE @bonoa DECIMAL(10, 2); -- Bono de Asistencia
    DECLARE @des DECIMAL(10, 2); -- Despensa
    DECLARE @isr DECIMAL(10, 2); -- ISR
    DECLARE @imss DECIMAL(10, 2); -- IMSS
    DECLARE @info DECIMAL(10, 2); -- INFONAVIT
    DECLARE @aho DECIMAL(10, 2); -- Fondo de Ahorro
    DECLARE @punt DECIMAL(10, 2); -- Puntualidad
    DECLARE @smi DECIMAL(10, 2); -- Salario Mensual Integrado

    -- Cálculos
    SET @sd = @sueldo / 30.41;
    SET @bonoa = @sueldo * 0.07;
    SET @des = @sueldo * 0.15;
    SET @isr = @sueldo * 0.02;
    SET @imss = @sueldo * 0.05;
    SET @info = @sueldo * 0.11;
    SET @aho = @sueldo * 0.05;
    SET @punt = @sueldo * 0.05;
    SET @smi = @sueldo - (@isr + @imss + @info + @aho) + (@bonoa + @des + @punt);

    -- Insertar en la tabla Empleado
    INSERT INTO Empleado (
        id_empleado,
        nombre_empleado,
        apellido_paterno,
        apellido_materno,
        fecha_nacimiento,
        curp,
        rfc,
        nss,
        direccion,
        banco,
        numero_cuenta,
        email,
        telefono,
        fecha_ingreso_empresa,
        sueldo,
        tipo_empleado,
        id_puesto,
        id_departamento
    )
    VALUES (
        @id_empleado,
        @nombre_empleado,
        @apellido_paterno,
        @apellido_materno,
        @fecha_nacimiento,
        @curp,
        @rfc,
        @nss,
        @direccion,
        @banco,
        @numero_cuenta,
        @email,
        @telefono,
        @fecha_ingreso_empresa,
        @sueldo,
        @tipo_empleado,
        @id_puesto,
        @id_departamento
    );

    -- Insertar en la tabla CONCEPTO
    INSERT INTO CONCEPTO (
        id_empleado,
        Sueldo,
        SalarioDiario,
        BonoAsistencia,
        Despensa,
        ISR,
        IMSS,
        PrestamoINF,
        FondoAhorro,
        Puntualidad,
        SMI
    )
    VALUES (
        @id_empleado,
        @sueldo,
        @sd,
        @bonoa,
        @des,
        @isr,
        @imss,
        @info,
        @aho,
        @punt,
        @smi
    );
END;

drop procedure InsertarEmpleado;

-- PROCEDURE PARA ELIMINAR EMPLEADO -----------------------------------------------------------------------------------------------
CREATE PROCEDURE EliminarEmpleado
  @id_empleado INT
AS
BEGIN
  DELETE FROM Empleado WHERE id_empleado = @id_empleado;
END;

-- PROCEDURE PARA ACTUALIZAR EMPLEADO ---------------------------------------------------------------------------------------------
CREATE PROCEDURE ActualizarEmpleado
    @id_empleado INT,
    @nombre_empleado VARCHAR(150),
    @apellido_paterno VARCHAR(150),
    @apellido_materno VARCHAR(150),
    @fecha_nacimiento DATE,
    @curp VARCHAR(18),
    @rfc VARCHAR(13),
    @nss VARCHAR(11),
    @direccion VARCHAR(100),
    @banco VARCHAR(100),
    @numero_cuenta VARCHAR(20),
    @email VARCHAR(100),
    @telefono VARCHAR(20),
    @fecha_ingreso_empresa DATE,
    @sueldo DECIMAL(10, 2),
    @tipo_empleado INT,
    @id_puesto INT,
    @id_departamento INT -- Nuevo parámetro
AS
BEGIN
    UPDATE Empleado
    SET 
        nombre_empleado = @nombre_empleado,
        apellido_paterno = @apellido_paterno,
        apellido_materno = @apellido_materno,
        fecha_nacimiento = @fecha_nacimiento,
        curp = @curp,
        rfc = @rfc,
        nss = @nss,
        direccion = @direccion,
        banco = @banco,
        numero_cuenta = @numero_cuenta,
        email = @email,
        telefono = @telefono,
        fecha_ingreso_empresa = @fecha_ingreso_empresa,
        sueldo = @sueldo,
        tipo_empleado = @tipo_empleado,
        id_puesto = @id_puesto,
        id_departamento = @id_departamento -- Nueva columna
    WHERE id_empleado = @id_empleado;

	UPDATE Concepto
    SET 
        Sueldo = @sueldo,
        SalarioDiario = @sueldo / 30.41,
        BonoAsistencia = @sueldo * 0.07,
        Despensa = @sueldo * 0.15,
        ISR = @sueldo * 0.02,
        IMSS = @sueldo * 0.05,
        PrestamoINF = @sueldo * 0.11,
        FondoAhorro = @sueldo * 0.05,
        Puntualidad = @sueldo * 0.05,
        SMI = @sueldo + (@sueldo * (0.07 + 0.15 + 0.05))-(@sueldo * (0.02 + 0.05 + 0.11+0.05)) -- Ejemplo de cálculo combinado
    WHERE id_empleado = @id_empleado;
END;

--DROP PROCEDURE ActualizarEmpleado;

-- PROCEDURE PARA INSERTAR DEPARTAMENTO -------------------------------------------------------------------------------------------
CREATE PROCEDURE InsertarDepartamento(
    @nombre_departamento VARCHAR(100),
    @id_empresa INT
)
AS
BEGIN
    INSERT INTO Departamento (nombre_departamento, id_empresa)
    VALUES (@nombre_departamento, @id_empresa);
END;

--DROP PROCEDURE InsertarDepartamento;

-- PROCEDURE PARA ELIMINAR DEPARTAMENTO -------------------------------------------------------------------------------------------
CREATE PROCEDURE EliminarDepartamento(
    @id_departamento INT
)
AS
BEGIN
	UPDATE Puesto SET id_departamento = NULL WHERE id_departamento = @id_departamento;

    DELETE FROM Departamento WHERE id_departamento = @id_departamento;
END;

-- PROCEDURE PARA ACTUALIZAR DEPARTAMENTO -----------------------------------------------------------------------------------------
CREATE PROCEDURE ActualizarDepartamento
    @id_departamento INT,
    @nombre_departamento VARCHAR(100),
    @id_empresa INT

AS
BEGIN
 
        -- Actualizar el departamento con los datos proporcionados
        UPDATE Departamento
        SET nombre_departamento = @nombre_departamento,
            id_empresa = @id_empresa
        
        WHERE id_departamento = @id_departamento;
END;

--DROP PROCEDURE ActualizarDepartamento;

-- PROCEDURE PARA INSERTAR PUESTO -------------------------------------------------------------------------------------------------
CREATE PROCEDURE InsertarPuesto(
    @nombre_puesto VARCHAR(100),
    @id_departamento INT
)
AS
BEGIN
    INSERT INTO Puesto (nombre_puesto,id_departamento)
    VALUES (@nombre_puesto, @id_departamento);
END;
drop procedure InsertarPuesto;
-- PROCEDURE PARA ELIMINAR PUESTO -------------------------------------------------------------------------------------------------
CREATE PROCEDURE EliminarPuesto(
	@puesto_id INT)
AS
BEGIN
    -- Actualizar los empleados para quitar la referencia al puesto
    UPDATE Empleado SET id_puesto = 0 WHERE id_puesto = @puesto_id;

    -- Ahora eliminar el puesto
    DELETE FROM Puesto WHERE id_puesto = @puesto_id;
END;

-- PROCEDURE PARA ACTUALIZAR PUESTO -----------------------------------------------------------------------------------------------
CREATE PROCEDURE ActualizarPuesto(
    @id_puesto INT,
    @nombre_puesto VARCHAR(100),
    @id_departamento INT
)
AS
BEGIN
    UPDATE Puesto
    SET 
        nombre_puesto = @nombre_puesto,
        id_departamento = @id_departamento
    WHERE id_puesto = @id_puesto;
END;

-- PROCEDURE PARA INSERTAR NOMINA -------------------------------------------------------------------------------------------------
CREATE PROCEDURE InsertarNomina
    @id_empleado INT,

    @Mes INT,
    @Fecha_pago DATE,
    @Año INT,
    @sueldo_neto INT,
    @sueldo_bruto INT
AS
BEGIN
    INSERT INTO Nomina (id_empleado, Mes, Fecha_pago, Año, sueldo_neto, sueldo_bruto)
    VALUES (@id_empleado, @Mes, @Fecha_pago, @Año, @sueldo_neto, @sueldo_bruto);
END;

----------INCIDENCIAS-----------------------------
CREATE PROCEDURE AgregarIncidencias
    @id_empleado INT,
    @id_periodo INT,
    @vacaciones DECIMAL(10, 2) = 0,
    @aguinaldo DECIMAL(10, 2) = 0,
    @horas_extras DECIMAL(10, 2) = 0,
    @faltas DECIMAL(10, 2) = 0
AS
BEGIN
    -- Declarar variables para cálculos
    DECLARE @salario_diario DECIMAL(10, 2);
    DECLARE @dias_trabajados DECIMAL(5, 2);
    DECLARE @bono_asistencia DECIMAL(10, 2);
    DECLARE @bono_puntualidad DECIMAL(10, 2);
    DECLARE @sueldo_final DECIMAL(10, 2);
    DECLARE @sueldo_mes DECIMAL(10, 2);

    -- Recuperar datos de la tabla CONCEPTO
    SELECT 
        @salario_diario = SalarioDiario,
        @bono_asistencia = BonoAsistencia,
        @bono_puntualidad = Puntualidad,
        @sueldo_mes = SMI
    FROM CONCEPTO
    WHERE id_empleado = @id_empleado;

    -- Calcular días trabajados considerando faltas
    SET @dias_trabajados = 30.41 - @faltas;

    -- Calcular el sueldo final:
    -- 1. Sueldo base por días trabajados
    SET @sueldo_final = @sueldo_mes -(@salario_diario*@faltas);

    -- 2. Sumar Vacaciones, Aguinaldo y Horas Extras
    SET @sueldo_final = @sueldo_final + @vacaciones + @aguinaldo + @horas_extras;

    -- 3. Si hay faltas, eliminar bonos
    IF @faltas > 0
    BEGIN
        SET @sueldo_final = @sueldo_final - (@bono_asistencia + @bono_puntualidad);
    END

    -- Insertar los datos en la tabla incidencias
    INSERT INTO incidencias (
        id_empleado,
        id_periodo,
        sueldodia,
        Vacaciones,
        Aguinaldo,
        HorasExtras,
        faltas,
        sueldofinal
    )
    VALUES (
        @id_empleado,
        @id_periodo,
        @salario_diario,
        @vacaciones,
        @aguinaldo,
        @horas_extras,
        @faltas,
        @sueldo_final
    );

END;

-- PROCEDURE PARA ACTUALIZAR NOMINA -----------------------------------------------------------------------------------------------
CREATE PROCEDURE ActualizarNomina
    @id_nomina INT,
    @id_empleado INT,

    @Mes INT,
    @Fecha_pago DATE,
    @Año INT,
    @sueldo_neto INT,
    @sueldo_bruto INT
AS
BEGIN
    UPDATE Nomina
    SET id_empleado = @id_empleado,

        Mes = @Mes,
        Fecha_pago = @Fecha_pago,
        Año = @Año,
        sueldo_neto = @sueldo_neto,
        sueldo_bruto = @sueldo_bruto
    WHERE id_nomina = @id_nomina;
END;

--DROP PROCEDURE ActualizarNomina;

-- PROCEDURE PARA ELIMINAR NOMINA -------------------------------------------------------------------------------------------------
CREATE PROCEDURE EliminarNomina
    @id_nomina INT
AS
BEGIN
    DELETE FROM Nomina WHERE id_nomina = @id_nomina;
END;

---- PROCEDURE PARA INSERTAR PERCEPCCIÓN Y DEDUCCIÓN --------------------------------------------------------------------------------
--CREATE PROCEDURE InsertarPD
--    @nombre_pd VARCHAR(100),
--	@mes_pd INT,
--	@año_pd INT, 
--	@cantidad DECIMAL (10, 2),
--    @EsPercepcion BIT,
--	@EsPorcentaje BIT
--AS
--BEGIN
--    INSERT INTO PD (nombre_pd, mes_pd, año_pd, cantidad, EsPercepcion, EsPorcentaje)
--    VALUES (@nombre_pd, @mes_pd, @año_pd, @cantidad, @EsPercepcion, @EsPorcentaje);
--END;

--EXEC InsertarPD 
--    @nombre_pd = 'Aguinaldo', 
--    @mes_pd = 11, 
--    @año_pd = 2024, 
--    @cantidad = 1.5, 
--    @EsPercepcion = 1,
--	@EsPorcentaje = 1;

--DROP PROCEDURE InsertarPD;

---- PROCEDURE PARA ACTUALIZAR PERCEPCCIÓN Y DEDUCCIÓN ------------------------------------------------------------------------------
--CREATE PROCEDURE ActualizarPD
--    @id_pd INT,
--    @nombre_pd VARCHAR(100),
--	@mes_pd INT,
--	@año_pd INT, 
--    @cantidad DECIMAL(10, 2),
--    @EsPercepcion BIT,
--	@EsPorcentaje BIT
--AS
--BEGIN
--    UPDATE PD
--    SET 
--        nombre_pd = @nombre_pd,
--		mes_pd = @mes_pd,
--		año_pd = @año_pd,
--        cantidad = @cantidad,
--        EsPercepcion = @EsPercepcion,
--		EsPorcentaje = @EsPorcentaje
--    WHERE id_pd = @id_pd;
--END;

---- PROCEDURE PARA ELIMINAR PERCEPCCIÓN Y DEDUCCIÓN --------------------------------------------------------------------------------
--CREATE PROCEDURE EliminarPD
--    @id_pd INT
--AS
--BEGIN
--    DELETE FROM PD
--    WHERE id_pd = @id_pd;
--END;


-- Reporte de cálculo de nómina ---------------------------------------------------------------------------------------------------
SELECT 
    E.id_empleado,
    CONCAT(E.nombre_empleado, ' ', E.apellido_paterno, ' ', E.apellido_materno) AS nombre_completo,
    N.Fecha_pago,
    N.sueldo_neto,
    E.banco,
    E.numero_cuenta
FROM 
    Nomina N
JOIN 
    Empleado E ON N.id_empleado = E.id_empleado;

-- Reporte General de nómina ------------------------------------------------------------------------------------------------------
SELECT 
    d.nombre_departamento AS Departamento,
    p.nombre_puesto AS Puesto,
    CONCAT(e.apellido_paterno, ' ', e.apellido_materno, ' ', e.nombre_empleado) AS NombreEmpleado,
    e.fecha_ingreso_empresa AS FechaIngreso,
    DATEDIFF(YEAR, e.fecha_nacimiento, GETDATE()) AS Edad,
    e.sueldo AS Salario
FROM 
    Empleado e
    INNER JOIN Puesto p ON e.id_puesto = p.id_puesto
    INNER JOIN Departamento d ON p.id_departamento = d.id_departamento
WHERE 
    YEAR(e.fecha_ingreso_empresa) = NULL AND
    MONTH(e.fecha_ingreso_empresa) = NULL
ORDER BY 
    d.nombre_departamento,
    p.nombre_puesto,
    e.apellido_paterno, 
    e.apellido_materno, 
    e.nombre_empleado;


-- Reporte Headcounter ------------------------------------------------------------------------------------------------------------
SELECT 
    d.nombre_departamento AS Departamento,
    p.nombre_puesto AS Puesto,
    COUNT(e.id_empleado) AS Cantidad_Empleados
FROM 
    Empleado e
    INNER JOIN Puesto p ON e.id_puesto = p.id_puesto
    INNER JOIN Departamento d ON p.id_departamento = d.id_departamento
WHERE 
    (NULL IS NULL OR d.id_departamento = NULL) AND
    YEAR(e.fecha_ingreso_empresa) = 2024 AND
    MONTH(e.fecha_ingreso_empresa) = 11
GROUP BY 
    d.nombre_departamento, p.nombre_puesto
ORDER BY 
    d.nombre_departamento, p.nombre_puesto;


-- Reporte Headcounter Parte 2 ----------------------------------------------------------------------------------------------------
SELECT 
    d.nombre_departamento AS Departamento,
    COUNT(e.id_empleado) AS Cantidad_Empleados
FROM 
    Empleado e
    INNER JOIN Puesto p ON e.id_puesto = p.id_puesto
    INNER JOIN Departamento d ON p.id_departamento = d.id_departamento
WHERE 
    (NULL IS NULL OR d.id_departamento = NULL) AND
    YEAR(e.fecha_ingreso_empresa) = 2024 AND
    MONTH(e.fecha_ingreso_empresa) = 11
GROUP BY 
    d.nombre_departamento
ORDER BY 
    d.nombre_departamento;


CREATE PROCEDURE InsertarPeriodo
    @mes INT,
    @año INT
AS
BEGIN
  IF EXISTS (
        SELECT 1
        FROM periodos
        WHERE mes = @mes AND año = @año
    )
    BEGIN
        -- Lanzar un error personalizado
        RAISERROR ('Ya existe periodo registrado para este mes y este año.', 16, 1);
        RETURN;
    END
    INSERT INTO periodos (mes, año)
    VALUES (@mes, @año);
END;

-----
CREATE FUNCTION ObtenerNominasPorMesYAño (
    @mes INT,
    @año INT
)
RETURNS TABLE
AS
RETURN
(
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
    INNER JOIN periodos p ON i.id_periodo = p.id_periodo -- Relación con periodos
    WHERE p.mes = @mes AND p.año = @año
);
drop procedure AgregarIncidencias;
------------------------------------
CREATE PROCEDURE AgregarIncidencias
    @id_empleado INT,
    @id_periodo INT,
    @vacaciones DECIMAL(10, 2) = 0,
    @aguinaldo DECIMAL(10, 2) = 0,
    @horas_extras DECIMAL(10, 2) = 0,
    @faltas DECIMAL(10, 2) = 0
AS
BEGIN

  IF EXISTS (
        SELECT 1
        FROM incidencias
        WHERE id_empleado = @id_empleado AND id_periodo = @id_periodo
    )
    BEGIN
        -- Lanzar un error personalizado
        RAISERROR ('Ya existen incidencias registradas para este empleado y este periodo.', 16, 1);
        RETURN;
    END
    -- Declarar variables para cálculos
    DECLARE @salario_diario DECIMAL(10, 2);
    DECLARE @dias_trabajados DECIMAL(5, 2);
    DECLARE @bono_asistencia DECIMAL(10, 2);
    DECLARE @bono_puntualidad DECIMAL(10, 2);
    DECLARE @sueldo_final DECIMAL(10, 2);
    DECLARE @sueldo_mes DECIMAL(10, 2);

    -- Recuperar datos de la tabla CONCEPTO
    SELECT 
        @salario_diario = SalarioDiario,
        @bono_asistencia = BonoAsistencia,
        @bono_puntualidad = Puntualidad,
        @sueldo_mes = SMI
    FROM CONCEPTO
    WHERE id_empleado = @id_empleado;

    -- Calcular días trabajados considerando faltas
    SET @dias_trabajados = 30.41 - @faltas;

    -- Calcular el sueldo final:
    -- 1. Sueldo base por días trabajados
    SET @sueldo_final = @sueldo_mes -(@salario_diario*@faltas);

    -- 2. Sumar Vacaciones, Aguinaldo y Horas Extras
    SET @sueldo_final = @sueldo_final + @vacaciones + @aguinaldo + @horas_extras;

    -- 3. Si hay faltas, eliminar bonos
    IF @faltas > 0
    BEGIN
        SET @sueldo_final = @sueldo_final - (@bono_asistencia + @bono_puntualidad);
    END

    -- Insertar los datos en la tabla incidencias
    INSERT INTO incidencias (
        id_empleado,
        id_periodo,
        sueldodia,
        Vacaciones,
        Aguinaldo,
        HorasExtras,
        faltas,
        sueldofinal
    )
    VALUES (
        @id_empleado,
        @id_periodo,
        @salario_diario,
        @vacaciones,
        @aguinaldo,
        @horas_extras,
        @faltas,
        @sueldo_final
    );

END;

CREATE FUNCTION ObtenerUltimoPeriodo()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 1 *
    FROM periodos
    ORDER BY año DESC, mes DESC
);
select*from periodos;
select*from incidencias;
-----------------------------------
use NominaBD;
drop function ObtenerNominasPorMesYAño;

CREATE FUNCTION ObtenerNominasPorMesYAño (
    @mes INT,
    @año INT
)
RETURNS TABLE
AS
RETURN
(
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
        -- Incidencias relacionadas con el periodo seleccionado
        ISNULL(i.Vacaciones, 0) AS Vacaciones,
        ISNULL(i.Aguinaldo, 0) AS Aguinaldo,
        ISNULL(i.HorasExtras, 0) AS HorasExtras,
        ISNULL(i.faltas, 0) AS Faltas,
        ISNULL(i.sueldofinal, c.SMI) AS Sueldo_Final -- Si no hay incidencias, usa el sueldo bruto
    FROM Empleado e
    INNER JOIN CONCEPTO c ON e.id_empleado = c.id_empleado
    LEFT JOIN incidencias i ON e.id_empleado = i.id_empleado
        AND EXISTS (
            SELECT 1 
            FROM periodos p 
            WHERE i.id_periodo = p.id_periodo 
            AND p.mes = @mes AND p.año = @año
        )
    -- Asegurar que los empleados tengan fecha de ingreso coherente con el periodo
    WHERE YEAR(e.fecha_ingreso_empresa) < @año
        OR (YEAR(e.fecha_ingreso_empresa) = @año AND MONTH(e.fecha_ingreso_empresa) <= @mes)
);
truncate table periodos;