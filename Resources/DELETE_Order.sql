 BEGIN TRANSACTION 
    DELETE FROM [Order].MainData                               WHERE OrderID = @id
    DELETE FROM [Order].Data                                   WHERE OrderID = @id


    DELETE FROM [Order].Compound                               WHERE OrderID = @id
    DELETE FROM [Order].Compound_Main                          WHERE OrderID = @id
    DELETE FROM Korprotokoll_Slipning_Produktion                    WHERE OrderID = @id
    DELETE FROM Korprotokoll_Slipning_Maskinparametrar              WHERE OrderID = @id                                                
    DELETE FROM Korprotokoll_Svetsning_Parametrar                   WHERE OrderID = @id
    DELETE FROM Korprotokoll_Svetsning_Maskinparametrar             WHERE OrderID = @id
                                                
    DELETE FROM [Order].ExtraComments                          WHERE OrderID = @id
    DELETE FROM [Order].PreFab                                        WHERE OrderID = @id
    DELETE FROM Measureprotocol.Data                                WHERE OrderID = @id
    DELETE FROM Measureprotocol.MainData                            WHERE OrderID = @id
    DELETE FROM MeasureInstruments.Mätdon                           WHERE OrderID = @id
    DELETE FROM Processcard.ProposedChanges                         WHERE OrderID = @id
    DELETE FROM [Order].Läcksökning                            WHERE OrderID = @id
    DELETE FROM Zumbach.Data                                        WHERE OrderID = @id
    DELETE FROM Zumbach.Measurements                                WHERE OrderID = @id
COMMIT TRANSACTION