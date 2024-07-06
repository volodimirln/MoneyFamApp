USE [MoneyFamBilling]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 06.07.2024 20:52:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](70) NOT NULL,
	[UserId] [int] NULL,
	[DateRegistration] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Families]    Script Date: 06.07.2024 20:52:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Families](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Title] [varchar](max) NOT NULL,
	[DateRegistration] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[SecretKey] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Families] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamilyMembers]    Script Date: 06.07.2024 20:52:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyMembers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FamilyId] [int] NOT NULL,
 CONSTRAINT [PK_FamilyMembers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Goals]    Script Date: 06.07.2024 20:52:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Title] [varchar](70) NOT NULL,
	[Description] [varchar](350) NOT NULL,
	[IsFamily] [bit] NOT NULL,
	[Type] [varchar](70) NOT NULL,
	[DateRegistration] [date] NOT NULL,
	[Amount] [int] NULL,
 CONSTRAINT [PK_Goals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operations]    Script Date: 06.07.2024 20:52:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Note] [varchar](max) NOT NULL,
	[DateCompletion] [datetime] NOT NULL,
 CONSTRAINT [PK_Operations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 06.07.2024 20:52:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GoalId] [int] NOT NULL,
	[DateExecution] [datetime] NULL,
	[PeriodInHours] [int] NULL,
	[IsDone] [bit] NOT NULL,
	[Amount] [int] NOT NULL,
	[DatePayment] [datetime] NULL,
	[IsYield] [int] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06.07.2024 20:52:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [varchar](70) NOT NULL,
	[Name] [varchar](70) NOT NULL,
	[Patronymic] [varchar](70) NOT NULL,
	[Login] [varchar](70) NOT NULL,
	[Password] [varchar](70) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Title], [UserId], [DateRegistration], [Active]) VALUES (1, N'Квартплата', NULL, CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Title], [UserId], [DateRegistration], [Active]) VALUES (2, N'Мобильная связь', NULL, CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Title], [UserId], [DateRegistration], [Active]) VALUES (3, N'Интернет', NULL, CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Title], [UserId], [DateRegistration], [Active]) VALUES (4, N'Продукты', 1, CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Title], [UserId], [DateRegistration], [Active]) VALUES (5, N'Транспорт', NULL, CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Title], [UserId], [DateRegistration], [Active]) VALUES (6, N'Одежда', NULL, CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Title], [UserId], [DateRegistration], [Active]) VALUES (7, N'Развлечения', 1, CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Title], [UserId], [DateRegistration], [Active]) VALUES (8, N'Здоровье', NULL, CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Title], [UserId], [DateRegistration], [Active]) VALUES (9, N'Образование', NULL, CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Title], [UserId], [DateRegistration], [Active]) VALUES (10, N'Сбережения', 1, CAST(N'2024-01-05T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[Categories] ([Id], [Title], [UserId], [DateRegistration], [Active]) VALUES (11, N'Ремонт', 1, CAST(N'2024-05-01T23:08:48.013' AS DateTime), 0)
GO
INSERT [dbo].[Categories] ([Id], [Title], [UserId], [DateRegistration], [Active]) VALUES (12, N'Авто', 1, CAST(N'2024-05-01T23:33:40.147' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Families] ON 
GO
INSERT [dbo].[Families] ([Id], [UserId], [Title], [DateRegistration], [IsActive], [SecretKey]) VALUES (1, 1, N'Семья Исаевых', CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1, N'b8c7f913ea5a4d76bfe312e8a49d8a21')
GO
INSERT [dbo].[Families] ([Id], [UserId], [Title], [DateRegistration], [IsActive], [SecretKey]) VALUES (2, 2, N'Семья Петровых', CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1, N'a8d6b08d5b4c40718b9f3159b4a5e792')
GO
INSERT [dbo].[Families] ([Id], [UserId], [Title], [DateRegistration], [IsActive], [SecretKey]) VALUES (3, 3, N'Семья Поповых', CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1, N'c45a9b6d307d4a53a00bba0be155053e')
GO
INSERT [dbo].[Families] ([Id], [UserId], [Title], [DateRegistration], [IsActive], [SecretKey]) VALUES (4, 4, N'Семья Зубковых', CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1, N'e19a9b891b9b4628b65a630a69e3c8af')
GO
INSERT [dbo].[Families] ([Id], [UserId], [Title], [DateRegistration], [IsActive], [SecretKey]) VALUES (5, 5, N'Семья Давыдовых', CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1, N'd56aa5dcbb5c4f5f8960c2f02c885a28')
GO
INSERT [dbo].[Families] ([Id], [UserId], [Title], [DateRegistration], [IsActive], [SecretKey]) VALUES (6, 6, N'Семья Даниловых', CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1, N'975e6616e6bf4f34ae0c3d007d38bb25')
GO
INSERT [dbo].[Families] ([Id], [UserId], [Title], [DateRegistration], [IsActive], [SecretKey]) VALUES (7, 7, N'Семья Наумовых', CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1, N'2dd161cbbac3406fa9d40c0e3a7c2c8a')
GO
INSERT [dbo].[Families] ([Id], [UserId], [Title], [DateRegistration], [IsActive], [SecretKey]) VALUES (8, 8, N'Семья Астафьевых', CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1, N'7c0f21f5deec4d0982b7d91f3c45e729')
GO
INSERT [dbo].[Families] ([Id], [UserId], [Title], [DateRegistration], [IsActive], [SecretKey]) VALUES (9, 9, N'Семья Ивановых', CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1, N'b56422c9d19c480f9f44c03a1d4dd89e')
GO
INSERT [dbo].[Families] ([Id], [UserId], [Title], [DateRegistration], [IsActive], [SecretKey]) VALUES (10, 10, N'Семья Галкиных', CAST(N'2024-01-05T00:00:00.000' AS DateTime), 1, N'0a607e926d2a4a9abdd6812a6a381ec9')
GO
SET IDENTITY_INSERT [dbo].[Families] OFF
GO
SET IDENTITY_INSERT [dbo].[FamilyMembers] ON 
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (2, 11, 1)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (3, 12, 1)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (4, 13, 2)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (5, 14, 2)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (6, 15, 3)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (7, 16, 3)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (8, 17, 4)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (9, 18, 4)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (10, 19, 5)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (11, 20, 5)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (12, 21, 6)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (13, 22, 6)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (14, 23, 7)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (15, 24, 7)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (16, 25, 8)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (17, 26, 8)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (18, 27, 9)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (19, 28, 9)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (20, 29, 10)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (21, 30, 10)
GO
INSERT [dbo].[FamilyMembers] ([Id], [UserId], [FamilyId]) VALUES (22, 32, 1)
GO
SET IDENTITY_INSERT [dbo].[FamilyMembers] OFF
GO
SET IDENTITY_INSERT [dbo].[Goals] ON 
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (4, 2, N'Покупка новой квартиры', N'Найти и приобрести квартиру в центре города', 0, N'Личная', CAST(N'2024-05-01' AS Date), 28000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (5, 3, N'Покупка автомобиля', N'Приобрести новый автомобиль для удобства перемещения по городу', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (6, 3, N'Совместный отпуск', N'Планируем отправиться в путешествие вместе с семьей', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (7, 4, N'Открытие собственного бизнеса', N'Стартовать свой стартап в области IT', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (8, 4, N'Ремонт в доме', N'Провести капитальный ремонт внутренних помещений', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (9, 5, N'Сбережения на образование детей', N'Начать откладывать средства для будущего образования детей', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (10, 5, N'Покупка акций', N'Инвестировать в ценные бумаги для долгосрочных инвестиций', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (11, 6, N'Подготовка к марафону', N'Начать тренировки и принять участие в местном марафоне', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (12, 6, N'Семейный выходной в парке', N'Организовать семейный пикник и активные игры в парке', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (13, 7, N'Покупка новой мебели', N'Обновить мебель в гостиной и спальне', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (14, 7, N'Отдых на море с друзьями', N'Организовать незабываемый отдых с друзьями на побережье', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (15, 8, N'Отпраздновать свадьбу', N'Организовать свадебное торжество и запланировать медовый месяц', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (16, 8, N'Путешествие за границу', N'Совершить путешествие за границу для отдыха и знакомства с новыми культурами', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (17, 9, N'Покупка новой техники', N'Приобрести новый ноутбук и смарт-гаджеты', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (18, 9, N'Семейное посещение театра', N'Провести вечер в театре с семьей', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (19, 10, N'Участие в марафоне благотворительности', N'Принять участие в благотворительном марафоне и собрать средства для нуждающихся', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (20, 10, N'Подарок для родителей на юбилей', N'Выбрать подарок и организовать торжественное мероприятие на 50-летие родителей', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (21, 11, N'Покупка нового спортивного инвентаря', N'Приобрести новые велосипеды и спортивные аксессуары', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (22, 11, N'Семейный отдых на природе', N'Отправиться на выходные на природу с семьей', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (23, 12, N'Покупка нового автомобиля', N'Приобрести семейный автомобиль', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (24, 12, N'Отпуск на курорте', N'Отправиться на отдых на популярный курорт', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (25, 13, N'Приобретение новой кухонной техники', N'Обновить кухонные приборы и улучшить функционал кухни', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (26, 13, N'Семейное посещение музея', N'Провести выходные с семьей в музейной экскурсии', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (27, 14, N'Покупка нового ноутбука', N'Обновить компьютерное оборудование для работы и учебы', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (28, 14, N'Семейный ужин в ресторане', N'Провести вечер в ресторане в кругу семьи', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (29, 15, N'Путешествие по Европе', N'Организовать путешествие по самым популярным городам Европы', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (30, 15, N'Приобретение новой мебели для детской комнаты', N'Обновить интерьер детской комнаты для ребенка', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (31, 16, N'Участие в спортивном мероприятии', N'Принять участие в местном спортивном соревновании', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (32, 16, N'Семейный пикник на природе', N'Организовать выезд на природу и провести время с семьей', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (33, 17, N'Ремонт в доме', N'Провести косметический ремонт внутренних помещений', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (34, 17, N'Путешествие в горы', N'Отправиться на активный отдых в горы', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (35, 18, N'Покупка нового снаряжения для путешествий', N'Приобрести новый рюкзак и палатку для путешествий', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (36, 18, N'Семейный вечер с фильмами', N'Организовать вечер с семьей и посмотреть любимые фильмы', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (37, 19, N'Приобретение нового домашнего питомца', N'Взять домашнего питомца из приюта', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (38, 19, N'Семейный выходной на природе', N'Провести выходные на природе с семьей', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (39, 20, N'Подготовка к экзаменам', N'Начать подготовку к важным экзаменам', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (40, 20, N'Семейное посещение зоопарка', N'Провести время в зоопарке вместе с семьей', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (41, 21, N'Покупка подарков на Новый год', N'Подготовить подарки для друзей и близких на Новый год', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (42, 21, N'Празднование Нового года в кругу семьи', N'Отпраздновать Новый год в домашнем уюте с семьей', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (43, 22, N'Сбор средств на ремонт дороги во дворе', N'Организовать сбор средств с соседями на ремонт дорожного покрытия', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (44, 22, N'Улучшение условий в доме', N'Провести ремонт и улучшение условий проживания в квартире', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (45, 23, N'Подарок себе на день рождения', N'Сделать себе приятный подарок на день рождения', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (46, 23, N'Семейный выезд на выходные', N'Отправиться с семьей на выходные в загородный дом', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (47, 24, N'Покупка новой кухонной техники', N'Обновить кухонную технику и приобрести новые приборы', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (48, 24, N'Посещение семейной фотосессии', N'Сделать семейные фотографии с близкими', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (49, 25, N'Участие в благотворительном марафоне', N'Принять участие в благотворительном забеге для сбора средств', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (50, 25, N'Семейное посещение парка аттракционов', N'Провести день в парке аттракционов вместе с семьей', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (51, 26, N'Покупка нового телевизора', N'Обновить технику в гостиной и приобрести новый телевизор', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (52, 26, N'Семейный ужин в любимом ресторане', N'Организовать семейный ужин в ресторане на особый случай', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (53, 27, N'Подготовка к путешествию', N'Начать подготовку к путешествию и выбрать направление', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (54, 27, N'Семейный отдых на море', N'Отправиться на отдых на морское побережье с семьей', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (55, 28, N'Посещение концерта любимого исполнителя', N'Купить билеты на концерт и насладиться выступлением', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (56, 28, N'Семейное путешествие на каникулах', N'Провести каникулы с семьей, отправившись в путешествие', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (57, 29, N'Покупка подарков на праздники', N'Выбрать подарки для близких на предстоящие праздники', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (58, 29, N'Празднование дня рождения в кругу друзей', N'Организовать вечеринку по случаю дня рождения', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (59, 30, N'Участие в мастер-классе по рисованию', N'Принять участие в мастер-классе и освоить новый вид искусства', 0, N'Личная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (60, 30, N'Семейный ужин на природе', N'Провести время на природе, организовав семейный ужин', 1, N'Семейная', CAST(N'2024-05-01' AS Date), 30000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (62, 1, N'Семейный отдых на море', N'Отправиться на отдых на морское побережье с семьей', 1, N'asd', CAST(N'2024-05-08' AS Date), 100)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (66, 1, N'Посещение концерта любимого исполнителя', N'Купить билеты на концерт и насладиться выступлением', 0, N'asc', CAST(N'2024-05-08' AS Date), 100)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (67, 1, N'Семейное путешествие на каникулах', N'Провести каникулы с семьей, отправившись в путешествие', 1, N'test', CAST(N'2024-05-08' AS Date), 1000)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (68, 1, N'Покупка подарков на праздники', N'Выбрать подарки для близких на предстоящие праздники', 1, N'test', CAST(N'2024-05-08' AS Date), 100)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (69, 1, N'Празднование дня рождения в кругу друзей', N'Организовать вечеринку по случаю дня рождения', 1, N'test', CAST(N'2024-05-08' AS Date), 100)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (70, 1, N'Участие в мастер-классе по рисованию', N'Принять участие в мастер-классе и освоить новый вид искусства', 0, N'test', CAST(N'2024-05-08' AS Date), 100)
GO
INSERT [dbo].[Goals] ([Id], [UserId], [Title], [Description], [IsFamily], [Type], [DateRegistration], [Amount]) VALUES (72, 1, N'Улучшение условий в доме', N'Провести ремонт и улучшение условий проживания в квартире', 1, N'2KMB85', CAST(N'2024-05-08' AS Date), 100)
GO
SET IDENTITY_INSERT [dbo].[Goals] OFF
GO
SET IDENTITY_INSERT [dbo].[Operations] ON 
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (27, 50, 1, 1, N'Оплата коммунальных услуг', CAST(N'2024-01-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (36, 90, 2, 1, N'Оплата за интернет', CAST(N'2024-01-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (44, 150, 3, 1, N'Подключение домашнего инетренета', CAST(N'2024-01-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (45, 200, 4, 1, N'Покупки в гипермарките', CAST(N'2024-01-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (46, 50, 5, 22, N'Поздка в парк', CAST(N'2024-01-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (47, 100, 6, 23, N'Покупка кроссовок', CAST(N'2024-01-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (48, 300, 7, 24, N'Покупка билета в кино', CAST(N'2024-01-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (49, 80, 8, 25, N'Покупка лекарств в аптеке', CAST(N'2024-01-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (50, 120, 9, 26, N'Оплата курсов', CAST(N'2024-01-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (51, 250, 10, 27, N'Пополнение накопительного счета', CAST(N'2024-01-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (52, 70, 11, 28, N'Покупка обоев', CAST(N'2024-01-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (53, 180, 12, 29, N'Замена масла', CAST(N'2024-01-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (54, 180, 1, 30, N'Оплата капремонта', CAST(N'2024-01-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (55, 100, 2, 1, N'Оплата за мобильный интернет', CAST(N'2024-05-08T22:46:21.293' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (56, 1000, 3, 1, N'Оплата за домашний интернет', CAST(N'2024-05-08T22:46:28.370' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (57, 1000, 4, 1, N'Покупки в гипермарките', CAST(N'2024-05-08T22:46:34.787' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (58, 12000, 9, 1, N'test1', CAST(N'2024-07-05T20:15:36.720' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (59, 123, 9, 1, N'axsasx', CAST(N'2024-07-05T23:47:04.450' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (60, 123, 9, 1, N'1213', CAST(N'2024-07-05T23:47:15.257' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (61, 123, 9, 1, N'123', CAST(N'2024-07-05T23:47:23.550' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (62, 123, 9, 1, N'123', CAST(N'2024-07-05T23:47:29.483' AS DateTime))
GO
INSERT [dbo].[Operations] ([Id], [Amount], [CategoryId], [UserId], [Note], [DateCompletion]) VALUES (63, 123, 9, 1, N'123', CAST(N'2024-07-05T23:47:35.163' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Operations] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (6, 62, CAST(N'2024-07-02T22:44:49.993' AS DateTime), NULL, 1, 1000, CAST(N'2024-05-06T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (7, 66, CAST(N'2024-06-25T06:23:05.877' AS DateTime), NULL, 1, 100, CAST(N'2024-05-14T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (8, 70, CAST(N'2024-07-02T22:45:31.363' AS DateTime), NULL, 1, 100, CAST(N'2024-05-16T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (9, 69, CAST(N'2024-07-02T22:45:23.247' AS DateTime), NULL, 1, 1000, CAST(N'2024-05-09T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (10, 69, CAST(N'2024-06-03T22:20:45.817' AS DateTime), NULL, 1, 100, CAST(N'2024-05-08T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (11, 70, CAST(N'2024-07-02T22:45:38.887' AS DateTime), NULL, 1, 100, CAST(N'2024-05-22T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (12, 69, NULL, NULL, 1, 1000, CAST(N'2024-06-11T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (13, 69, NULL, NULL, 1, 100, CAST(N'2024-06-11T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (14, 72, NULL, NULL, 1, 1000, CAST(N'2024-06-26T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (15, 72, CAST(N'2024-06-24T20:34:17.363' AS DateTime), NULL, 1, 10000, CAST(N'2024-06-25T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (16, 72, NULL, NULL, 1, 123, CAST(N'2024-06-19T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (17, 69, CAST(N'2024-07-02T22:33:37.500' AS DateTime), NULL, 1, 1000, CAST(N'2024-07-03T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (18, 69, CAST(N'2024-07-05T23:22:22.510' AS DateTime), NULL, 1, 567, CAST(N'2024-07-09T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (19, 69, CAST(N'2024-07-02T22:49:28.053' AS DateTime), NULL, 1, 678, CAST(N'2024-07-02T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (20, 68, NULL, NULL, 0, 1300, CAST(N'2024-07-10T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Payments] ([Id], [GoalId], [DateExecution], [PeriodInHours], [IsDone], [Amount], [DatePayment], [IsYield]) VALUES (21, 68, NULL, NULL, 0, 1400, CAST(N'2024-07-03T00:00:00.000' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (1, N'Исаев', N'Николай', N'Сергеевич', N'isaev', N'2KMB85')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (2, N'Петрова', N'Виктория', N'Тимуровна', N'petrova', N'r1gVps')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (3, N'Попов', N'Егор', N'Михайлович', N'popov', N'NkKWEf')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (4, N'Зубкова', N'Варвара', N'Данииловна', N'zubkova', N'muipPh')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (5, N'Давыдов', N'Марк', N'Петрович', N'davydov', N'g38CyT')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (6, N'Данилов', N'Михаил', N'Иванович', N'danilov', N'65sbzS')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (7, N'Наумов', N'Владимир', N'Игоревич', N'naumov', N'fyexRl')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (8, N'Астафьев', N'Артём', N'Владимирович', N'astafyev', N'1REBxc')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (9, N'Иванова', N'Ксения', N'Михайловна', N'ivanova', N'kfKl7Y')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (10, N'Галкина', N'Агния', N'Михайловна', N'galkina', N'aP7O45')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (11, N'Исаева', N'Дарья', N'Никитична', N'bogomolova', N'CvHbmC')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (12, N'Исаев', N'Максим', N'Артёмович', N'markelov', N'TQSCXJ')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (13, N'Петрова', N'Амина', N'Алексеевна', N'khokhlova', N'3nJeLR')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (14, N'Петрова', N'Мария', N'Артёмовна', N'tikhonova', N'6sroAq')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (15, N'Попов', N'Роберт', N'Даниилович', N'kozlov', N'LZb8s2')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (16, N'Попов', N'Илья', N'Иванович', N'borisov', N'ok9sqS')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (17, N'Зубкова', N'Адель', N'Кирилловна', N'zhukova', N'zBXhDF')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (18, N'Зубкова', N'Полина', N'Филипповна', N'stepanova', N'fbBBZx')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (19, N'Давыдов', N'Михаил', N'Макарович', N'mescheryakov', N'duwtYz')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (20, N'Давыдова', N'Виктория', N'Никитична', N'savelieva', N'lnmvK5')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (21, N'Данилова', N'Василиса', N'Владиславовна', N'vorobyeva', N'9ieUqg')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (22, N'Данилов', N'Александр', N'Максимович', N'makarov', N'V1Rejd')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (23, N'Наумова', N'Полина', N'Артёмовна', N'alexeeva', N'b5fvGX')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (24, N'Наумова', N'Марина', N'Николаевна', N'ovchinnikova', N'9JacPV')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (25, N'Астафьев', N'Артём', N'Викторович', N'novikov', N'3tmPck')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (26, N'Астафьев', N'Даниэль', N'Андреевич', N'kalachev', N'8Jc5ok')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (27, N'Иванова', N'Ксения', N'Денисовна', N'kuznetsova', N'cahhjP')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (28, N'Иванова', N'Максим', N'Даниилович', N'kulikov', N'lK1muL')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (29, N'Галкин', N'Анастасия', N'Романовна', N'tumanova', N'wt87iI')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (30, N'Галкин', N'Руслан', N'Маркович', N'kopylov', N'YT4993')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (31, N'test', N'test', N'test', N'test', N'test')
GO
INSERT [dbo].[Users] ([Id], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (32, N'test', N'test', N'test', N'test123@qw', N'test123')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Users]
GO
ALTER TABLE [dbo].[FamilyMembers]  WITH CHECK ADD  CONSTRAINT [FK_FamilyMembers_Families] FOREIGN KEY([FamilyId])
REFERENCES [dbo].[Families] ([Id])
GO
ALTER TABLE [dbo].[FamilyMembers] CHECK CONSTRAINT [FK_FamilyMembers_Families]
GO
ALTER TABLE [dbo].[FamilyMembers]  WITH CHECK ADD  CONSTRAINT [FK_FamilyMembers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[FamilyMembers] CHECK CONSTRAINT [FK_FamilyMembers_Users]
GO
ALTER TABLE [dbo].[Goals]  WITH CHECK ADD  CONSTRAINT [FK_Goals_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Goals] CHECK CONSTRAINT [FK_Goals_Users]
GO
ALTER TABLE [dbo].[Operations]  WITH CHECK ADD  CONSTRAINT [FK_Operations_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Operations] CHECK CONSTRAINT [FK_Operations_Categories]
GO
ALTER TABLE [dbo].[Operations]  WITH CHECK ADD  CONSTRAINT [FK_Operations_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Operations] CHECK CONSTRAINT [FK_Operations_Users]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Goals] FOREIGN KEY([GoalId])
REFERENCES [dbo].[Goals] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Goals]
GO
