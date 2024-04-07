SET IDENTITY_INSERT [dbo].[BaseMaterial] ON
INSERT INTO [dbo].[BaseMaterial] (
	[MaterialId], 
	[MaterialName], 
	[MaterialCode], 
	[ActivityDescription], 
	[VATRate], 
	[Quantity],
	[Measure],
	[LedgerAccountNumber], 
	[Rounding], 
	[ITJ_SZTJ], 
	[MaterialGroupId], 
	[Note],
	[Kilojule],
	[Protein],
	[Fat],
	[Carbohydrate],
	[Cholesterol],
	[Sugar],
	[Salt],
	[SaturatedFat],
	[TransFat],
	[Fiber],
	[Kalcium],
	[Kalium],
	[CostPrice], 
	[RetailPrice], 
	[SupplierCode])
	VALUES
	(1, N'BL55 liszt', N'BL55_LL', N'sth sth', 27, 1000, N'Kg', 1, 2, N'idkn', 11, N'nootee', 15400, 12, 1, 76, 0, 0, 0, 0, 0, 4,  13, 140, 200, 250, N'123NOK'),
	(2, N'Kristálycukor', N'CUK_12NOK', 'Cuukor', 27, 1000, N'Kg', 2, 2, N'idkn', 10, N'notee', 17000, 0, 0, 1000, 0, 1000, 0, 0, 0, 0, 0, 150, 190, 220, N'124NOK')
SET IDENTITY_INSERT [dbo].[BaseMaterial] OFF


	