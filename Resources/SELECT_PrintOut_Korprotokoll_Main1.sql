SELECT TOP(1) Matarhjul_Hastighet_nom, Matarhjul_Vinkel_min, Matarhjul_Vinkel_nom, Matarhjul_Vinkel_max, Helix_Vinkel_nom, Bladh�jd_min, Bladh�jd_nom, Bladh�jd_max, Arbetsblad_min, 
		Arbetsblad_nom, Arbetsblad_max, Chimsh�jd_nom, Dragprov_enhet, main.Extra_Info, main.Validerade_Loter, main.Godk�ntDatum, main.QA_sign, main.Uppr�ttatAv_Sign_AnstNr, 
		main.RevInfo, main.Rev�ndratDatum, main.Historiska_Data, main.Validerat, main.Framtagning_Processf�nster, main.Aktiv
                    
FROM Processkort_Slipning as slipning
	JOIN Processcard.MainData as main
		ON slipning.PartID = main.PartID
WHERE slipning.PartID = @partID
