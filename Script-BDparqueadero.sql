USE [master]
GO
/****** Object:  Database [BDparqueadero]    Script Date: 27/04/2023 11:14:22 p. m. ******/
CREATE DATABASE [BDparqueadero]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDparqueadero', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDparqueadero.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDparqueadero_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDparqueadero_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BDparqueadero] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDparqueadero].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDparqueadero] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDparqueadero] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDparqueadero] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDparqueadero] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDparqueadero] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDparqueadero] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDparqueadero] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDparqueadero] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDparqueadero] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDparqueadero] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDparqueadero] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDparqueadero] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDparqueadero] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDparqueadero] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDparqueadero] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BDparqueadero] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDparqueadero] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDparqueadero] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDparqueadero] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDparqueadero] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDparqueadero] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDparqueadero] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDparqueadero] SET RECOVERY FULL 
GO
ALTER DATABASE [BDparqueadero] SET  MULTI_USER 
GO
ALTER DATABASE [BDparqueadero] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDparqueadero] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDparqueadero] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDparqueadero] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDparqueadero] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDparqueadero] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BDparqueadero', N'ON'
GO
ALTER DATABASE [BDparqueadero] SET QUERY_STORE = OFF
GO
USE [BDparqueadero]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 27/04/2023 11:14:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingresoVehiculo]    Script Date: 27/04/2023 11:14:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingresoVehiculo](
	[idVehiculo] [int] IDENTITY(1,1) NOT NULL,
	[tipoVehiculo] [varchar](150) NOT NULL,
	[placa] [varchar](150) NOT NULL,
	[horaIngreso] [datetime] NOT NULL,
	[EstadoPago] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[idVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModeloSPs]    Script Date: 27/04/2023 11:14:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModeloSPs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[tipoVehiculo] [nvarchar](max) NULL,
	[placa] [nvarchar](max) NULL,
	[horaIngreso] [datetime] NOT NULL,
	[horaSalida] [datetime] NOT NULL,
	[numeroFactura] [nvarchar](max) NULL,
	[valorPagado] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ModeloSPs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salidaVehiculo]    Script Date: 27/04/2023 11:14:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salidaVehiculo](
	[idSalidaVEhiculo] [int] IDENTITY(1,1) NOT NULL,
	[horaSalida] [datetime] NOT NULL,
	[numeroFactura] [varchar](150) NOT NULL,
	[valorPagado] [varchar](150) NOT NULL,
	[idIngresoVehiculo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idSalidaVEhiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[salidaVehiculo]  WITH CHECK ADD FOREIGN KEY([idIngresoVehiculo])
REFERENCES [dbo].[ingresoVehiculo] ([idVehiculo])
GO
/****** Object:  StoredProcedure [dbo].[sp_getVehiculosByRangoHorario]    Script Date: 27/04/2023 11:14:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getVehiculosByRangoHorario]
    @horaInicio DATETIME,
    @horaFin DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    SELECT iv.idVehiculo, iv.tipoVehiculo, iv.placa, iv.horaIngreso, sv.horaSalida, sv.numeroFactura, sv.valorPagado
    FROM ingresoVehiculo iv
    JOIN salidaVehiculo sv ON iv.idVehiculo = sv.idIngresoVehiculo
    WHERE iv.horaIngreso BETWEEN @horaInicio AND @horaFin
        OR sv.horaSalida BETWEEN @horaInicio AND @horaFin
END
GO
USE [master]
GO
ALTER DATABASE [BDparqueadero] SET  READ_WRITE 
GO
