SELECT Textvalue 
FROM Processcard.Data 
WHERE PartID = @partid AND TemplateID = (
	SELECT id 
	FROM Protocol.Template 
	WHERE FormTemplateID = @formtemplateid AND ProtocolDescriptionID = (
		SELECT id 
		FROM Protocol.Description 
		WHERE CodeText = 'DUBBELTAPERING') AND revision = (SELECT ProtocolTemplateRevision FROM [Order].MainData WHERE OrderID = @orderid))