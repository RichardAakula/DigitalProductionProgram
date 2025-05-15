SELECT TOP(1) Matarhjul_Hastighet_nom, Matarhjul_Vinkel_min, Matarhjul_Vinkel_nom, Matarhjul_Vinkel_max, Helix_Vinkel_nom, Bladhöjd_min, Bladhöjd_nom, Bladhöjd_max, Arbetsblad_min, 
		Arbetsblad_nom, Arbetsblad_max, Chimshöjd_nom, Dragprov_enhet, main.Extra_Info, main.Validerade_Loter, main.GodkäntDatum, main.QA_sign, main.UpprättatAv_Sign_AnstNr, 
		main.RevInfo, main.RevÄndratDatum, main.Historiska_Data, main.Validerat, main.Framtagning_Processfönster, main.Aktiv
                    
FROM Processkort_Slipning as slipning
	JOIN Processcard.MainData as main
		ON slipning.PartID = main.PartID
WHERE slipning.PartID = @partID
