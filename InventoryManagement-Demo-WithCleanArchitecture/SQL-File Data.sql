/*
---------------------------------------------------------
Here I have created the Demo based on Clean Architecture
---------------------------------------------------------
STEP (1) => RUN BELOW COMMAND By SELECTING PROJECT "InventoryManagement.API" ON VISUAL STUDIO
			CMD ==> Update-Database

*/

---STEP (2) Execute the endpoint & verify the data by running below script on SSMS
SELECT *  FROM [InventoryManagement].[EquipmentInventory]
SELECT *  FROM [InventoryManagement].[ItemGroup]


/*
--------------------------------------------
Demo Data for insert data on Swagger UI
--------------------------------------------

{
  "itemCode": "84186930",
  "itemName": "Vending machine",
  "make": "HBN",
  "itemModel": "Estcvgr",
  "trackingMethod": "Estcvgr",
  "itemGroupId": 1,
  "isVoid": false
}

{
  "itemCode": "SBGA551",
  "itemName": "EDM Machine- GF",
  "make": "HBN",
  "itemModel": "Estcvgr",
  "trackingMethod": "EDM Machine- GF",
  "itemGroupId": 2,
  "isVoid": false
}
*/

/*
--------------
Table Schema
--------------
Note:- These table automatically created while run above [STEP (1)] migration command.

CREATE TABLE [InventoryMgmt].[EquipmentInventory](
             [Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
			 [ItemCode] [nvarchar](10) NOT NULL,
             [ItemName] [nvarchar](50) NOT NULL,
			 [Make] [nvarchar](50) NOT NULL,
			 [ItemModel] [nvarchar](50) NULL,
             [TrackingMethod] [nvarchar](250) NULL,
			 [ItemGroupId] INT NOT NULL FOREIGN KEY REFERENCES [InventoryMgmt].[ItemGroup](Id),
             [IsVoid] [bit] NOT NULL,
             
)
GO

CREATE TABLE [InventoryMgmt].[ItemGroup](
             [Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
             [ItemGroupName] [nvarchar](50) NOT NULL,
			 [IsVoid] [bit] NOT NULL             
)
GO

INSERT INTO [InventoryManagement].[ItemGroup](ItemGroupName,IsVoid) VALUES
('Cylindrical Grinding- HMT',1),
('EDM Machine- GF',1)
GO

*/