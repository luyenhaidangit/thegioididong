-- Table: ProductCategory
BEGIN
IF OBJECT_ID('ProductCategories', 'U') IS NOT NULL
    DROP TABLE ProductCategories;

CREATE TABLE ProductCategories
(
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    Name        NVARCHAR(255) NOT NULL,
    ParentId    INT,
    Description NVARCHAR(512),
    Status      INT NOT NULL,
    [Order]     INT NOT NULL,
    Image       NVARCHAR(255),
    IsFeatured  BIT NOT NULL,
    Slug        NVARCHAR(255) NOT NULL,
    Icon        NVARCHAR(255),
    IconImage   NVARCHAR(255),
    CreatedAt   DATETIME2,
    UpdatedAt   DATETIME2
);

INSERT INTO ProductCategories
(Name, ParentId, Description, Status, [Order], Image, IsFeatured, Slug, Icon, IconImage, CreatedAt, UpdatedAt)
VALUES
(N'Truyền hình', NULL, NULL, 1, 0, 'product-categories/p-1.png', 1, 'television', 'flaticon-tv', NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
(N'Âm thanh & Rạp hát tại gia', 1, NULL, 1, 0, NULL, 0, 'home-audio-theaters', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
(N'TV & Videos', 1, NULL, 1, 1, NULL, 0, 'tv-videos', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
(N'Máy ảnh, Ảnh & Videos', 1, NULL, 1, 2, NULL, 0, 'camera-photos-videos', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
(N'Điện thoại & Phụ kiện', 1, NULL, 1, 3, NULL, 0, 'cellphones-accessories', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
(N'Tai nghe', 1, NULL, 1, 4, NULL, 0, 'headphones', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
(N'Trò chơi điện tử', 1, NULL, 1, 5, NULL, 0, 'video-games', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
(N'Loa không dây', 1, NULL, 1, 6, NULL, 0, 'wireless-speakers', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
(N'Đồ điện tử văn phòng', 1, NULL, 1, 7, NULL, 0, 'office-electronics', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
(N'Di động', NULL, NULL, 1, 1, 'product-categories/p-2.png', 1, 'mobile', 'flaticon-responsive', NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52');
END;

-- Table: Brands
BEGIN
    IF OBJECT_ID('Brands', 'U') IS NOT NULL
        DROP TABLE Brands;

    CREATE TABLE Brands
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(191) NOT NULL,
        Description NVARCHAR(MAX),
        Website NVARCHAR(191) NULL,
        Logo NVARCHAR(191) NULL,
        Status INT NOT NULL,
        [Order] TINYINT NOT NULL DEFAULT 0,
        IsFeatured BIT NOT NULL DEFAULT 0,
        CreatedAt DATETIME2 NULL,
        UpdatedAt DATETIME2 NULL
    );

    INSERT INTO Brands (Name, Description, Website, Logo, Status, [Order], IsFeatured, CreatedAt, UpdatedAt)
    VALUES
    (N'Fashion live', NULL, NULL, N'brands/1.png', 1, 0, 1, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
    (N'Hand crafted', NULL, NULL, N'brands/2.png', 1, 1, 1, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
    (N'Mestonix', NULL, NULL, N'brands/3.png', 1, 2, 1, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
    (N'Sunshine', NULL, NULL, N'brands/4.png', 1, 3, 1, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
    (N'Pure', NULL, NULL, N'brands/5.png', 1, 4, 1, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
    (N'Anfold', NULL, NULL, N'brands/6.png', 1, 5, 1, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
    (N'Automotive', NULL, NULL, N'brands/7.png', 1, 6, 1, '2024-04-26 02:47:52', '2024-04-26 02:47:52');
END;

-- Table: MediaFiles
BEGIN
IF OBJECT_ID('MediaFiles', 'U') IS NOT NULL
    DROP TABLE MediaFiles;

CREATE TABLE MediaFiles
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Name NVARCHAR(191) NOT NULL,
    AltText NVARCHAR(191) NULL,
    FolderId INT NOT NULL,
    MimeType NVARCHAR(120) NOT NULL,
    Size INT NOT NULL,
    URL NVARCHAR(191) NOT NULL,
    Options NVARCHAR(MAX),
    CreatedAt DATETIME2 NULL,
    UpdatedAt DATETIME2 NULL,
    DeletedAt DATETIME2 NULL
);

INSERT INTO MediaFiles (UserId, Name, AltText, FolderId, MimeType, Size, URL, Options, CreatedAt, UpdatedAt, DeletedAt)
VALUES
(1, N'1', N'1', 1, N'image/png', 1, N'brands/1.png', N'[]', '2024-04-26T02:47:51', '2024-04-26T02:47:51', NULL),
(1, N'2', N'2', 1, N'image/png', 1, N'brands/2.png', N'[]', '2024-04-26T02:47:51', '2024-04-26T02:47:51', NULL),
(1, N'3', N'3', 1, N'image/png', 1, N'brands/3.png', N'[]', '2024-04-26T02:47:51', '2024-04-26T02:47:51', NULL),
(1, N'4', N'4', 1, N'image/png', 1, N'brands/4.png', N'[]', '2024-04-26T02:47:51', '2024-04-26T02:47:51', NULL),
(1, N'5', N'5', 1, N'image/png', 1, N'brands/5.png', N'[]', '2024-04-26T02:47:51', '2024-04-26T02:47:51', NULL),
(1, N'6', N'6', 1, N'image/png', 1, N'brands/6.png', N'[]', '2024-04-26T02:47:51', '2024-04-26T02:47:51', NULL),
(1, N'7', N'7', 1, N'image/png', 1, N'brands/7.png', N'[]', '2024-04-26T02:47:51', '2024-04-26T02:47:51', NULL),
(1, N'p-1', N'p-1', 2, N'image/png', 1, N'product-categories/p-1.png', N'[]', '2024-04-26T02:47:52', '2024-04-26T02:47:52', NULL),
(1, N'p-7', N'p-7', 2, N'image/png', 1, N'product-categories/p-7.png', N'[]', '2024-04-26T02:47:52', '2024-04-26T02:47:52', NULL);
END;

-- Table: MediaFolders
BEGIN
IF OBJECT_ID('MediaFolders', 'U') IS NOT NULL
    DROP TABLE MediaFolders;

CREATE TABLE MediaFolders
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Name NVARCHAR(191) NULL,
    Color NVARCHAR(191) NULL,
    Slug NVARCHAR(191) NULL,
    ParentId INT,
    CreatedAt DATETIME2 NULL,
    UpdatedAt DATETIME2 NULL,
    DeletedAt DATETIME2 NULL
);

INSERT INTO MediaFolders (UserId, Name, Color, Slug, ParentId, CreatedAt, UpdatedAt, DeletedAt)
VALUES
(1, N'brands', NULL, N'brands', NULL, '2024-04-26T02:47:51', '2024-04-26T02:47:51', NULL),
(1, N'product-categories', NULL, N'product-categories', NULL, '2024-04-26T02:47:52', '2024-04-26T02:47:52', NULL),
(1, N'customers', NULL, N'customers', NULL, '2024-04-26T02:47:52', '2024-04-26T02:47:52', NULL),
(1, N'products', NULL, N'products', NULL, '2024-04-26T02:47:56', '2024-04-26T02:47:56', NULL),
(1, N'news', NULL, N'news', NULL, '2024-04-26T02:48:02', '2024-04-26T02:48:02', NULL),
(1, N'testimonials', NULL, N'testimonials', NULL, '2024-04-26T02:48:03', '2024-04-26T02:48:03', NULL),
(1, N'sliders', NULL, N'sliders', NULL, '2024-04-26T02:48:03', '2024-04-26T02:48:03', NULL),
(1, N'general', NULL, N'general', NULL, '2024-04-26T02:48:04', '2024-04-26T02:48:04', NULL),
(1, N'promotion', NULL, N'promotion', NULL, '2024-04-26T02:48:05', '2024-04-26T02:48:05', NULL);
END;

-- Table: MediaSettings
BEGIN
    IF OBJECT_ID('MediaSettings', 'U') IS NOT NULL
        DROP TABLE MediaSettings;

    CREATE TABLE MediaSettings
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        [Key] NVARCHAR(120) NOT NULL,
        [Value] NVARCHAR(MAX),
        MediaId INT NULL,
        UserId INT NULL,
        CreatedAt DATETIME2 NULL,
        UpdatedAt DATETIME2 NULL
    );
END;