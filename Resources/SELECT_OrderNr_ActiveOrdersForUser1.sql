SELECT DISTINCT TOP(5) OrderNr, Operation, workoperation.Name, Back_Red, Back_Green, Back_Blue, Fore_Red, Fore_Green, Fore_Blue 
FROM Measureprotocol.MainData AS mp
	JOIN [Order].MainData as main
		ON mp.OrderID = main.OrderID 
	JOIN [Settings].QuickStart_Color as color
		ON main.WorkoperationID = color.WorkoperationID	
	JOIN Workoperation.Names as workoperation
		ON main.WorkoperationID = workoperation.ID
WHERE AnstNr = @employeenumber AND main.IsOrderDone = 'False'

UNION 

SELECT DISTINCT TOP(5) OrderNr, Operation, workoperation.Name, Back_Red, Back_Green, Back_Blue, Fore_Red, Fore_Green, Fore_Blue FROM Korprotokoll_Slipning_Produktion as slipning
	JOIN [Order].MainData as main
		ON slipning.OrderID = main.OrderID
	JOIN [Settings].QuickStart_Color as color
		ON main.WorkoperationID = color.WorkoperationID	
	JOIN Workoperation.Names as workoperation
		ON main.WorkoperationID = workoperation.ID
WHERE AnstNr = @employeenumber AND main.IsOrderDone = 'False'

UNION 

SELECT DISTINCT TOP(5) OrderNr, Operation, workoperation.Name, Back_Red, Back_Green, Back_Blue, Fore_Red, Fore_Green, Fore_Blue FROM Korprotokoll_Svetsning_Parametrar as svetsning
	JOIN [Order].MainData as main
		ON svetsning.OrderID = main.OrderID
	JOIN [Settings].QuickStart_Color as color
		ON main.WorkoperationID = color.WorkoperationID	
	JOIN Workoperation.Names as workoperation
		ON main.WorkoperationID = workoperation.ID
WHERE AnstNr = @employeenumber AND main.IsOrderDone = 'False'



