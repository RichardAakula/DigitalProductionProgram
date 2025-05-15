SELECT Rum_Temp, Rum_Fukt, FORMAT(LC_Date, 'yyyy-MM-dd HH:mm') AS LC_Date, LC_Name,  
FORMAT(LC_Approved_Date, 'yyyy-MM-dd HH:mm') AS LC_Approved_Date, LC_Approved_Name, LC_Rengjort_Extrudern_Ja, LC_Rengjort_Extrudern_Nej_Samma_Mtrl, LC_Rengjort_Extrudern_Mjukt_Hårt, LC_Rengjort_Extrudern_Ljus_Mörk, LC_Comments
FROM [Order].MainData
WHERE OrderID = @orderid
