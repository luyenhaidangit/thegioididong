-- Table: ProductCategory
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'ProductCategories' AND type = 'U')
BEGIN
    DROP TABLE ProductCategories;
END

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
('Truyền hình', 0, NULL, 1, 0, 'product-categories/p-1.png', 1, 'television', 'flaticon-tv', NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
('Âm thanh & Rạp hát tại gia', 1, NULL, 1, 0, NULL, 0, 'home-audio-theaters', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
('TV & Videos', 1, NULL, 1, 1, NULL, 0, 'tv-videos', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
('Máy ảnh, Ảnh & Videos', 1, NULL, 1, 2, NULL, 0, 'camera-photos-videos', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
('Điện thoại & Phụ kiện', 1, NULL, 1, 3, NULL, 0, 'cellphones-accessories', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
('Tai nghe', 1, NULL, 1, 4, NULL, 0, 'headphones', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
('Trò chơi điện tử', 1, NULL, 1, 5, NULL, 0, 'video-games', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
('Loa không dây', 1, NULL, 1, 6, NULL, 0, 'wireless-speakers', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
('Đồ điện tử văn phòng', 1, NULL, 1, 7, NULL, 0, 'office-electronics', NULL, NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52'),
('Di động', 0, NULL, 1, 1, 'product-categories/p-2.png', 1, 'mobile', 'flaticon-responsive', NULL, '2024-04-26 02:47:52', '2024-04-26 02:47:52');
GO