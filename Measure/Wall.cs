using DigitalProductionProgram.Övrigt;

namespace DigitalProductionProgram.Measure
{
    internal class Wall
    {
        public double? LCL { get; set; }
        public double? UCL { get; set; }
        public double? LSL { get; set; }
        public double? USL { get; set; }
        public double? RunOut_USL { get; set; }
        public double? RunOut_UCL { get; set; }

        public double? MainWall;
        public double? MainRunOut;

        public double? Wall_Layer1, Wall_Layer2, Wall_Layer3;
        public double? RunOut_Layer1, RunOut_Layer2, RunOut_Layer3;

        public bool IsNeutral
        {
            get
            {
                if (MainWall == 0 && MainRunOut == 0)
                    return true;
                return false;
            }
        }
        public bool IsWarning
        {
            get
            {
                if (UCL > 0 && MainWall > UCL && MainWall <= USL)
                    return true;
                if (LCL > 0 && MainWall < LCL && MainWall >= LSL)
                    return true;
                if (MainRunOut > RunOut_UCL && MainRunOut <= RunOut_USL)
                    return true;
                return false;
            }
        }
        public bool IsBad
        {
            get
            {
                if (USL > 0 && MainWall > USL)
                    return true;
                if (MainWall < LSL)
                    return true;
                if (MainRunOut > RunOut_USL && RunOut_USL > 0)
                    return true;
                return false;
            }
            
        }
        public bool IsOk
        {
            get
            {
                if (UCL > 0 && MainWall > UCL || LCL > 0 && MainWall < LCL)
                    return false;
                if (MainRunOut > RunOut_UCL)
                    return false;
                return true;
            }
        }

        public int Img_Nr_Wall1
        {
            get
            {
                if (Calculate.Measurement_1.Wall1 <= 0)
                    return 0;
                if (IsWall_Ok(Calculate.Measurement_1.Wall1))
                    return 1;
                if (IsWall_Warning(Calculate.Measurement_1.Wall1))
                    return 2;
                if (IsWall_Bad(Calculate.Measurement_1.Wall1))
                    return 3;
                return 0;
            }
        }
        public int Img_Nr_Wall2
        {
            get
            {
                if (Calculate.Measurement_1.Wall4 <= 0)
                    return 0;
                if (IsWall_Ok(Calculate.Measurement_1.Wall4))
                    return 1;
                if (IsWall_Warning(Calculate.Measurement_1.Wall4))
                    return 2;
                if (IsWall_Bad(Calculate.Measurement_1.Wall4))
                    return 3;
                return 0;
            }
        }
        public int Img_Nr_Wall3
        {
            get
            {
                if (Calculate.Measurement_1.Wall2 <= 0)
                    return 0;
                if (IsWall_Ok(Calculate.Measurement_1.Wall2))
                    return 1;
                if (IsWall_Warning(Calculate.Measurement_1.Wall2))
                    return 2;
                if (IsWall_Bad(Calculate.Measurement_1.Wall2))
                    return 3;
                return 0;
            }
        }
        public int Img_Nr_Wall4
        {
            get
            {
                if (Calculate.Measurement_1.Wall3 <= 0)
                    return 0;
                if (IsWall_Ok(Calculate.Measurement_1.Wall3))
                    return 1;
                if (IsWall_Warning(Calculate.Measurement_1.Wall3))
                    return 2;
                if (IsWall_Bad(Calculate.Measurement_1.Wall3))
                    return 3;
                return 0;
            }
        }
        public bool IsWall_Ok(double? Wall)
        {
            Wall /= 1000;
            if (LCL == 0 && UCL == 0)
                return true;
            var IsWallOk = Wall > LCL && Wall < UCL;
            return IsWallOk;
        }
        public bool IsWall_Warning(double? Wall)
        {
            Wall /= 1000;
            if (UCL == 0 && USL == 0 && LCL == 0 && LSL == 0)
                return true;
            var IsWallWarning = Wall >= UCL && Wall <= USL || Wall <= LCL && Wall >= LSL;
            return IsWallWarning;
        }
        public bool IsWall_Bad(double? Wall)
        {
            Wall /= 1000;
            if (USL == 0 && LSL == 0)
                return true;
            return Wall > USL || Wall < LSL;
            
        }

        public bool IsNeutral_2Layer
        {
            get
            {
                if (MainWall == 0 && MainRunOut == 0 && Wall_Layer1 == 0 && Wall_Layer2 == 0 && RunOut_Layer1 == 0 && RunOut_Layer2 == 0)
                    return true;
                return false;
            }
        }
        public bool IsNeutral_3Layer
        {
            get
            {
                if (MainWall == 0 && MainRunOut == 0 && Wall_Layer1 == 0 && Wall_Layer2 == 0 && Wall_Layer3 == 0 && RunOut_Layer1 == 0 && RunOut_Layer2 == 0 && RunOut_Layer3 == 0)
                    return true;
                return false;
            }
        }

        public bool Layer1Is_Ok
        {
            get
            {
                if (Wall_Layer1 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer1, "UCL") || Wall_Layer1 < MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer1, "LCL"))
                    return false;
                if (RunOut_Layer1 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RunoutLayer1, "UCL"))
                    return false;

                return true;
            }
        }
        public bool Layer1Is_Warning
        {
            get
            {
                if (Wall_Layer1 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer1, "UCL") && Wall_Layer1 <= MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer1, "USL"))
                    return true;
                if (Wall_Layer1 < MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer1, "LCL") && Wall_Layer1 >= MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer1, "LSL"))
                    return true;
                if (RunOut_Layer1 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RunoutLayer1, "UCL") && RunOut_Layer1 <= MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RunoutLayer1, "USL"))
                    return true;

                return false;
            }
        }
        public bool Layer1Is_Bad
        {
            get
            {
                if (Wall_Layer1 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer1, "USL") || Wall_Layer1 < MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer1, "LSL"))
                    return true;
                if (RunOut_Layer1 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RunoutLayer1, "USL"))
                    return true;

                return false;
            }
        }
        public bool Layer2Is_Ok
        {
            get
            {
                if (Wall_Layer2 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer2, "UCL") || Wall_Layer2 < MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer2, "LCL"))
                    return false;
                if (RunOut_Layer2 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RunoutLayer2, "UCL"))
                    return false;

                return true;
            }
        }
        public bool Layer2Is_Warning
        {
            get
            {
                if (Wall_Layer2 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer2, "UCL") && Wall_Layer2 <= MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer2, "USL"))
                    return true;
                if (Wall_Layer2 < MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer2, "LCL") && Wall_Layer2 >= MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer2, "LSL"))
                    return true;
                if (RunOut_Layer2 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RunoutLayer2, "UCL") && RunOut_Layer2 <= MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RunoutLayer2, "USL"))
                    return true;

                return false;
            }
        }
        public bool Layer2Is_Bad
        {
            get
            {
                if (Wall_Layer2 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer2, "USL") || Wall_Layer2 < MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer2, "LSL"))
                    return true;
                if (RunOut_Layer2 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RunoutLayer2, "USL"))
                    return true;

                return false;
            }
        }
        public bool Layer3Is_Ok
        {
            get
            {
                if (Wall_Layer3 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer3, "UCL") || Wall_Layer3 < MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer3, "LCL"))
                    return false;
                if (RunOut_Layer3 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RunoutLayer3, "UCL"))
                    return false;

                return true;
            }
        }
        public bool Layer3Is_Warning
        {
            get
            {
                if (Wall_Layer3 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer3, "UCL") && Wall_Layer3 <= MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer3, "USL"))
                    return true;
                if (Wall_Layer3 < MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer3, "LCL") && Wall_Layer3 >= MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer3, "LSL"))
                    return true;
                if (RunOut_Layer3 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RunoutLayer3, "UCL") && RunOut_Layer3 <= MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RunoutLayer3, "USL"))
                    return true;

                return false;
            }
        }
        public bool Layer3Is_Bad
        {
            get
            {
                if (Wall_Layer3 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer3, "USL") || Wall_Layer3 < MeasurePoints.Value(MeasurePoints.CodeTextMonitor.WallLayer3, "LSL"))
                    return true;
                if (RunOut_Layer3 > MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RunoutLayer3, "USL"))
                    return true;

                return false;
            }
        }
    
}
}
