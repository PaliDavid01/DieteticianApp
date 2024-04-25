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
	(1, N'BL55 liszt', N'BL55_LL', N'sth sth', 27, 1000, N'g', 1, 2, N'idkn', 11, N'nootee', 3370, 12, 1, 76, 0, 0, 0, 0, 0, 4,  13, 140, 200, 250, N'123NOK'),
	(2, N'Kristálycukor', N'CUK_12NOK', 'Cuukor', 27, 1000, N'g', 2, 2, N'idkn', 10, N'notee', 4000, 0, 0, 1000, 0, 1000, 0, 0, 0, 0, 0, 150, 190, 220, N'124NOK'),
	(3, N'Kakaópor', N'KAK_12NOK', 'Kakaópor', 27, 1000, N'g', 3, 2, N'idkn', 10, N'notee', 3680, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'125NOK'),
	(4, N'Kakaóvaj', N'KAKV_12NOK', 'Kakaóvaj', 27, 1000, N'Kg', 4, 2, N'idkn', 10, N'notee', 8840, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'126NOK'),
	(5, N'Közepes Tojás (~53g)', N'TOJ_12NOK', 'Tojás', 27, 1, N'db', 5, 2, N'idkn', 10, N'notee', 317, 0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'127NOK'),
	(6, N'Só', N'SO_12NOK', 'Só', 27, 1000, N'g', 6, 2, N'idkn', 10, N'notee', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'128NOK'),
	(7, N'Élesztő', N'EL_12NOK', 'Élesztő', 27, 100, N'g', 7, 2, N'idkn', 10, N'notee', 320, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'129NOK'),
	(8, N'Vaj', N'VAJ_12NOK', 'Vaj', 27, 1, N'Kg', 8, 2, N'idkn', 10, N'notee', 7420, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'130NOK'),
	(9, N'Napraforgóolaj', N'NAP_12NOK', 'Napraforgóolaj', 27, 1, N'l', 9, 2, N'idkn', 10, N'notee', 8133, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'131NOK'),
	(10, N'Tej 1,5%', N'TEJ_12NOK', 'Tej', 27, 1, N'l', 10, 2, N'idkn', 10, N'notee', 440, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'132NOK')
	
SET IDENTITY_INSERT [dbo].[BaseMaterial] OFF

	