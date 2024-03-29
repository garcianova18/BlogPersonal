USE [blogPersonal]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 10/07/2023 23:05:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comentario]    Script Date: 10/07/2023 23:05:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[FechaPublicado] [datetime] NOT NULL,
	[idPost] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Comentario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 10/07/2023 23:05:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](200) NOT NULL,
	[FechaPublicado] [datetime] NOT NULL,
	[Descripcion] [varchar](max) NULL,
	[Imagen] [varchar](max) NULL,
	[Status] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 10/07/2023 23:05:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/07/2023 23:05:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IdRol] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (1, N'Developer')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (2, N'DBA')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (3, N'Desarrollo Web')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Comentario] ON 

INSERT [dbo].[Comentario] ([Id], [Descripcion], [FechaPublicado], [idPost], [Status], [Nombre]) VALUES (2, N'muy bueno ete articulo', CAST(N'2023-05-18T00:00:00.000' AS DateTime), 1011, 1, N'pepe')
INSERT [dbo].[Comentario] ([Id], [Descripcion], [FechaPublicado], [idPost], [Status], [Nombre]) VALUES (3, N'me encanta', CAST(N'2023-05-17T00:00:00.000' AS DateTime), 1011, 1, N'maria')
INSERT [dbo].[Comentario] ([Id], [Descripcion], [FechaPublicado], [idPost], [Status], [Nombre]) VALUES (1002, N'probando', CAST(N'2023-05-19T00:48:35.273' AS DateTime), 1011, 1, N'juan')
INSERT [dbo].[Comentario] ([Id], [Descripcion], [FechaPublicado], [idPost], [Status], [Nombre]) VALUES (2002, N'eso ta durisimo', CAST(N'2023-05-19T14:31:45.143' AS DateTime), 1011, 1, N'jose')
INSERT [dbo].[Comentario] ([Id], [Descripcion], [FechaPublicado], [idPost], [Status], [Nombre]) VALUES (2003, N'klk', CAST(N'2023-05-19T14:32:09.513' AS DateTime), 1011, 1, N'fela')
INSERT [dbo].[Comentario] ([Id], [Descripcion], [FechaPublicado], [idPost], [Status], [Nombre]) VALUES (2004, N'klk', CAST(N'2023-05-19T14:32:18.300' AS DateTime), 1011, 1, N'felipe')
INSERT [dbo].[Comentario] ([Id], [Descripcion], [FechaPublicado], [idPost], [Status], [Nombre]) VALUES (2005, N'probando 5', CAST(N'2023-05-19T14:33:03.400' AS DateTime), 1011, 1, N'ramona')
INSERT [dbo].[Comentario] ([Id], [Descripcion], [FechaPublicado], [idPost], [Status], [Nombre]) VALUES (3003, N'mi primer comentario', CAST(N'2023-05-20T02:41:47.260' AS DateTime), 2008, 1, N'ramon')
INSERT [dbo].[Comentario] ([Id], [Descripcion], [FechaPublicado], [idPost], [Status], [Nombre]) VALUES (3010, N'klk sy la queen', CAST(N'2023-07-09T23:17:37.223' AS DateTime), 1011, 1, N'queen')
SET IDENTITY_INSERT [dbo].[Comentario] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([Id], [Titulo], [FechaPublicado], [Descripcion], [Imagen], [Status], [IdCategoria], [IdUser]) VALUES (1011, N'el crepusculo lindo atardecer', CAST(N'2023-05-17T01:28:53.903' AS DateTime), N'<p style="text-align: left; margin-right: 0px; margin-bottom: 15px; margin-left: 0px; padding: 0px; font-family: &quot;Open Sans&quot;, Arial, sans-serif; font-size: 14px;"><b>Lorem ipsum</b> dolor sit amet, consectetur adipiscing elit. Etiam ut tincidunt nisi. Proin nibh ante, scelerisque ut pellentesque a, facilisis sed leo. Duis dictum augue a laoreet lacinia. Donec metus ex, interdum vel lacinia nec, egestas eu diam. Praesent gravida ac sapien sed rhoncus. Integer justo eros, molestie in facilisis vitae, aliquet sed eros. Morbi enim lacus, consequat ac vehicula eu, fermentum ut lectus.</p><p style="text-align: left; margin-right: 0px; margin-bottom: 15px; margin-left: 0px; padding: 0px; font-family: &quot;Open Sans&quot;, Arial, sans-serif; font-size: 14px;"><b>Vestibulum nisl sem</b>, rhoncus sit amet felis quis, volutpat suscipit velit. Nunc ultrices luctus purus. Aenean at luctus dolor. Nunc dignissim erat eget tortor dignissim, in elementum nibh ultricies. Vivamus rutrum sollicitudin enim, quis cursus nulla eleifend eget. Nullam sapien sem, condimentum vitae mollis in, tempus vitae ex. Maecenas facilisis facilisis nibh volutpat tincidunt. Quisque vel arcu vitae lacus commodo ultricies. Fusce molestie nisi a placerat gravida. Donec eu enim ornare lectus vulputate porttitor vitae eu felis. Maecenas vehicula efficitur enim, ut cursus arcu ultricies ultrices. In tincidunt scelerisque tellus, eu volutpat elit. Sed et egestas tellus. Quisque et nisl quis enim consectetur hendrerit eu sagittis lorem. Aenean pulvinar lobortis dictum.</p>', N'rio_25291a4d-74a0-4e60-8893-013a13f3df55.jpg', 1, 1, 1)
INSERT [dbo].[Post] ([Id], [Titulo], [FechaPublicado], [Descripcion], [Imagen], [Status], [IdCategoria], [IdUser]) VALUES (2008, N'Rayo de Luz en la carretera', CAST(N'2023-05-13T23:51:28.270' AS DateTime), N'<p>una hermasa carretera c dwedwdw</p>', N'caretera_4ea6aa32-db5b-47c0-9217-37a21725ad50.jpg', 1, 3, 1)
INSERT [dbo].[Post] ([Id], [Titulo], [FechaPublicado], [Descripcion], [Imagen], [Status], [IdCategoria], [IdUser]) VALUES (3008, N'Lindo Pasaje callendo el atardecer', CAST(N'2023-05-14T12:18:54.203' AS DateTime), N'<p style="margin-right: 0px; margin-bottom: 15px; margin-left: 0px; padding: 0px; text-align: justify; font-family: &quot;Open Sans&quot;, Arial, sans-serif; font-size: 14px;">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse pharetra urna vel magna malesuada consequat. Suspendisse blandit pretium elit, luctus elementum tortor venenatis sit amet. Pellentesque ornare lacus et augue venenatis ullamcorper. Nunc dignissim, sapien sed cursus commodo, tortor felis varius felis, eget sodales leo orci sed mauris.</p><p style="margin-right: 0px; margin-bottom: 15px; margin-left: 0px; padding: 0px; text-align: justify; font-family: &quot;Open Sans&quot;, Arial, sans-serif; font-size: 14px;"><img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGAAAABgBAMAAAAQtmoLAAAALVBMVEUAAAAAAAAIQVIgc5RiYmKDMRjNUkHNzc3mQRDugynutFru3nv2pBD/1RD////8tlCXAAAAAXRSTlMAQObYZgAABLNJREFUWMPtmD1r5EYYx2eOyGypWfAkcsDYc9hwZdYfIl3QBiROgYBl0ARdwGCISRd8nQq72IAG5q5y4SJKHwj7Ba7Z3oVVGPLS+TPkeWak3dXbxttdcVN4kff56fk/r6tdQj6dj/NcbWk/uhpth4yyLNvOxdbA6EO2ZRg32XbE6Pp+cYWqgmeZBxB1WX4AwCn8Z9ij1WhR3htAPgMIAchuSoybpvkpcYJgs58oJ6ObmzLDuD2tgkjrfJgIfEcDsFg8ZNcAcG2POh3Sr/NIJ2RUQggL1ITGQRBq1R+ME+HtTMwPWQlRA8DGQohQ617C2ANAbhZliQCJZmB+cjI5flec9gmaMW4AcAE+EBijPRLFXY+DX+F2HAFI68P9lQVenhgiVd0MabAXhxA0ya7LB9NMS+DkWHUFoQMhvBwnorxvA7pdDCcVS4CMvn9NyFoMqKkdtXNmgcO8qvezAePbsQrWgFd5u+kqQLyyQGJkAlClqRN1KNYBEkofsWHAkUIcfWuA3AKJTxwlloBopQmBMDZQbq+B4EamAYRoRY0hIADdI13rQibhMEBRkYzFkY6Bq1zEUqwBzTTRMwRcEUGYR5KZVomtIhuEEM2oKwAa9gW8hRki1LMOaqAZNQJc7kbwT3hLYhE8UDepNJlXG9taDDxQWrvkhThku1hlBZ1XAQcUXo7dZt0OUxi3GSEvmAeTBEFDzibm1icTQsY9AM7nzKXM7AlmgJfgDf4egIQ24Jx5ZqKnLLWbhWHIk8mxZGMEwEULiO0KyqWsdhHHBB1gOYTfAxCvWlpSWhcaF4YghEs5TvqBN7/l6RqAnYriJRwfg2gCVKtCXaIUOeWWmbExvgMusC4dIJQ6fjKrkdBdQ0R6ZipeuRi3JPFEf/UPRg0LPgFaK3Nh+1ZCP45b25KGSZCqKUx/mMg6VRo/GxzU5JNx3J7RFGXLJEAJNaDzqQGgj/hpe5HBid+a268yBcrcShN3u6tbfZFxAMKlfeDVQEJ2enY9yzIey2QpSCVOCGKsJtpVNCPgIQZRlT0ky6c14HccROAcAHcnTOfzP60HmVBQb4B2jjylzwF4G7rEm89XBK+BpAVQLZlLX+/nPv1xviQsAEGrDkAoI0HydzAj9L0B5sbFboSATlMp3e5nnIxxprm1Ny6mWBvIh1J9QBhKxnwbQuUCP9klTkqvB2Zb4Mv5ygVPPC2ndq66AGQwgPq8XwNmF6lCobpXErQpYWQFoKZE5zw29m96gOk+lDNqADpMphdo3ymcJaAN9AowebrMGdrL26HHJa1WADYtk9isvYrMSXX+ewPQEreALAaAHZixogb+qHocHQwpAkB/V7u4s0AMAzjkwAKF8VEUS+BdcTv4iIhzX1TnLrUdu1cMOrCTvVcBt0uAkU2AjGtAVgDb8JiLbSb3aiA1bcc2PRebrRTvVQAQsrft1obIzO/UEIEp2UAbNQAfBra4C4pnANWWwwcBKMct/3+Aylo0PNYH5krONj7d80aUeJWmm6L+7OIyXNOALpTaBHzz9U8/NwHYSZsA9u/+BXObIZ1vAiij64Wl/Ifwl/PHLb6isafHp78utvlSt+9+/si2AahL3U+/GHyM5z/tOd8zbwTGEwAAAABJRU5ErkJggg==" style="width: 96px;" data-filename="Charizard.png"><br></p><p style="margin-right: 0px; margin-bottom: 15px; margin-left: 0px; padding: 0px; text-align: justify; font-family: &quot;Open Sans&quot;, Arial, sans-serif; font-size: 14px;"> Ut eget nulla quam. Pellentesque vulputate at lacus euismod iaculis. Quisque nec ultrices orci. Etiam commodo tempus turpis. Aliquam bibendum, libero a interdum cursus, quam turpis sagittis eros, eget consequat nunc orci et tortor. Quisque at leo tristique sem efficitur rhoncus ut vitae metus.</p><p style="margin-right: 0px; margin-bottom: 15px; margin-left: 0px; padding: 0px; text-align: justify; font-family: &quot;Open Sans&quot;, Arial, sans-serif; font-size: 14px;">Nam et porta nibh. Nunc non iaculis odio, id lacinia neque. Pellentesque pretium ante sapien, at luctus lectus malesuada aliquam. Nunc vel porttitor mauris. Vestibulum odio enim, mattis at fringilla id, interdum id risus. </p><p style="margin-right: 0px; margin-bottom: 15px; margin-left: 0px; padding: 0px; text-align: justify; font-family: &quot;Open Sans&quot;, Arial, sans-serif; font-size: 14px;">Pellentesque vestibulum nisl quam, non semper quam fringilla id. Aenean porttitor mattis est interdum rutrum. Pellentesque ultricies finibus vulputate. Fusce condimentum enim et dapibus fermentum.</p>', N'paisaje_3f879710-8a16-41fb-9408-e3a4a3a87f38.jpg', 1, 2, 1)
INSERT [dbo].[Post] ([Id], [Titulo], [FechaPublicado], [Descripcion], [Imagen], [Status], [IdCategoria], [IdUser]) VALUES (6010, N'para eliminar', CAST(N'2023-05-19T01:50:20.300' AS DateTime), N'<p>para elmiminar</p>', NULL, 1, 3, 1)
INSERT [dbo].[Post] ([Id], [Titulo], [FechaPublicado], [Descripcion], [Imagen], [Status], [IdCategoria], [IdUser]) VALUES (6011, N'zzzz', CAST(N'2023-05-19T01:50:46.493' AS DateTime), N'<p>zzzz</p>', NULL, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([Id], [Nombre]) VALUES (1, N'Admin')
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [Nombre], [Apellido], [UserName], [Password], [IdRol]) VALUES (1, N'Wilson', N'Garcia Nova', N'wgarcia', N'123456', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_Post] FOREIGN KEY([idPost])
REFERENCES [dbo].[Post] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comentario] CHECK CONSTRAINT [FK_Comentario_Post]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Categoria]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Rol]
GO
