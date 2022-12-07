USE Goods
GO

-- Chèn giá trị vào bảng User
INSERT INTO dbo.user_Entities
VALUES ('Duc Thang', '123456','Admin', 'Nguyen', 'Thang', 012345678, 'Nghe An', 'abcd', '2022-11-13', '2022-12-01' );
INSERT INTO dbo.user_Entities
VALUES ('Duc Nam', '12345678','Test', 'Vu', 'Nam', '012347778', 'Ha Noi');

-- Chèn giá trị vào bảng Items
INSERT INTO dbo.items_Entities
VALUES ('Ip14', 0, 3000000, 100);
INSERT INTO dbo.items_Entities
VALUES ('Ip13', 0, 2500000, 100);
INSERT INTO dbo.items_Entities
VALUES ('Ip12', 0, 2000000, 100);

-- Chèn giá trị vào bảng Items
INSERT INTO dbo.orders_Entities
VALUES ('2021-11-12', 'Van chuyen nhanh', 'Ha Noi', 0987654312, 'Dang Giao', 0);

-- Hiển thi thông tin các bảng
Select * from dbo.user_Entities
Select * from dbo.items_Entities
Select * from dbo.carts_Entities
Select * from dbo.reviews_Entities
Select * from dbo.orders_Entities
Select * from dbo.orderDetails_Entities