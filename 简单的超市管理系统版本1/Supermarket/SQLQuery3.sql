USE Supermarket;
SELECT * FROM Users;
SELECT CommodityName,CommoditySort.SortName,CommodityPrice,IsDiscount,ReducedPrice from Commodity,CommoditySort where 
Commodity.SortID = CommoditySort.SortID and CommodityName like '%��%'
SELECT UserName,Password From Users WHERE UserName = 'admin' and Password = 'admin'
INSERT INTO Commodity(CommodityName,SortID,CommodityPrice,IsDiscount,ReducedPrice,CreateUserId) VALUES('��','1','12.22','false','12.2','1')
SELECT * FROM Commodity;
select SortID from CommoditySort where SortName = '����';
SELECT Username,Password FROM Users;
SELECT SortName FROM CommoditySort
SELECT SortID,SortName FROM CommoditySort