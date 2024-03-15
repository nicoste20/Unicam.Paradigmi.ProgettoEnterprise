/****** Object:  Table [dbo].[Calendari]    Script Date: 15/03/2024 10:29:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calendari](
	[IdCalendario] [int] NOT NULL,
	[IdCorso] [int] NOT NULL,
	[DataOraInizio] [datetime] NOT NULL,
	[DataOraFine] [datetime] NOT NULL,
	[Luogo] [varchar](100) NOT NULL,
	[Modalita] [tinyint] NOT NULL,
 CONSTRAINT [PK_Calendari] PRIMARY KEY CLUSTERED 
(
	[IdCalendario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Corsi]    Script Date: 15/03/2024 10:29:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corsi](
	[IdCorso] [int] NOT NULL,
	[NomeCorso] [varchar](100) NOT NULL,
	[IdDocente] [varchar](255) NOT NULL,
	[NOre] [tinyint] NOT NULL,
	[IdCalendario] [int] NOT NULL,
 CONSTRAINT [PK_Corsi] PRIMARY KEY CLUSTERED 
(
	[IdCorso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CorsiDocenti]    Script Date: 15/03/2024 10:29:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CorsiDocenti](
	[IdUtente] [varchar](255) NOT NULL,
	[IdCorso] [int] NOT NULL,
 CONSTRAINT [PK_CorsiDocenti] PRIMARY KEY CLUSTERED 
(
	[IdUtente] ASC,
	[IdCorso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presenze]    Script Date: 15/03/2024 10:29:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presenze](
	[IdPresenza] [int] NOT NULL,
	[IdAlunno] [varchar](255) NOT NULL,
	[DataOraInizio] [datetime] NOT NULL,
	[DataOraFine] [datetime] NOT NULL,
 CONSTRAINT [PK_Presenze] PRIMARY KEY CLUSTERED 
(
	[IdPresenza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 15/03/2024 10:29:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[Email] [varchar](255) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Cognome] [varchar](100) NOT NULL,
	[Password] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Utenti] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Calendari]  WITH CHECK ADD  CONSTRAINT [FK_Calendari_Corsi] FOREIGN KEY([IdCorso])
REFERENCES [dbo].[Corsi] ([IdCorso])
GO
ALTER TABLE [dbo].[Calendari] CHECK CONSTRAINT [FK_Calendari_Corsi]
GO
ALTER TABLE [dbo].[Corsi]  WITH CHECK ADD  CONSTRAINT [FK_Corsi_Calendari] FOREIGN KEY([IdCalendario])
REFERENCES [dbo].[Calendari] ([IdCalendario])
GO
ALTER TABLE [dbo].[Corsi] CHECK CONSTRAINT [FK_Corsi_Calendari]
GO
ALTER TABLE [dbo].[Corsi]  WITH CHECK ADD  CONSTRAINT [FK_Corsi_Utenti] FOREIGN KEY([IdDocente])
REFERENCES [dbo].[Utenti] ([Email])
GO
ALTER TABLE [dbo].[Corsi] CHECK CONSTRAINT [FK_Corsi_Utenti]
GO
ALTER TABLE [dbo].[CorsiDocenti]  WITH CHECK ADD  CONSTRAINT [FK_CorsiDocenti_Corsi] FOREIGN KEY([IdCorso])
REFERENCES [dbo].[Corsi] ([IdCorso])
GO
ALTER TABLE [dbo].[CorsiDocenti] CHECK CONSTRAINT [FK_CorsiDocenti_Corsi]
GO
ALTER TABLE [dbo].[CorsiDocenti]  WITH CHECK ADD  CONSTRAINT [FK_CorsiDocenti_Utenti] FOREIGN KEY([IdUtente])
REFERENCES [dbo].[Utenti] ([Email])
GO
ALTER TABLE [dbo].[CorsiDocenti] CHECK CONSTRAINT [FK_CorsiDocenti_Utenti]
GO
ALTER TABLE [dbo].[Presenze]  WITH CHECK ADD  CONSTRAINT [FK_Presenze_Utenti] FOREIGN KEY([IdAlunno])
REFERENCES [dbo].[Utenti] ([Email])
GO
ALTER TABLE [dbo].[Presenze] CHECK CONSTRAINT [FK_Presenze_Utenti]
GO
USE [master]
GO
ALTER DATABASE [Paradigmi_Progetto] SET  READ_WRITE 
GO
