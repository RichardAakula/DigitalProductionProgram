SELECT TOP(1) OrderNr, PartNr, RevNr, ProdType, Amount, Unit, Customer, Description, Date_Start, Date_Stop, Name_Start, LC_Rengjort_Extrudern_Ja, LC_Rengjort_Extrudern_Nej_Samma_Mtrl, LC_Rengjort_Extrudern_Mjukt_Hårt, LC_Rengjort_Extrudern_Ljus_Mörk, LC_Name, LC_Date, Rum_Temp, Rum_Fukt, Comments, LC_Comments, Version                               
FROM [Order].MainData AS main
WHERE main.OrderID = @id
