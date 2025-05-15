using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.Protocols.Template_Management
{
    public partial class FormulaBuilder : Form
    {
        public string Formula { get; set; }
        public FormulaBuilder(string parameterName, DataTable dataTable_Parameters)
        {
            InitializeComponent();

            label_Parameter.Text = $"Fyll i formel nedan för ({parameterName})";

            foreach (DataRow row in dataTable_Parameters.Rows)
            {
                var parameterMonitor = row["ParameterMonitor"];
                if (!string.IsNullOrEmpty(parameterMonitor.ToString()))
                    dgv_MeasureValues.Rows.Add( parameterMonitor);
            }

            dgv_MeasureValues.Rows.Add("Wall1");
            dgv_MeasureValues.Rows.Add("Wall2");
            dgv_MeasureValues.Rows.Add("Wall3");
            dgv_MeasureValues.Rows.Add("Wall4");
            dgv_MeasureValues.Rows.Add("RecWall1");
            dgv_MeasureValues.Rows.Add("RecWall2");
            dgv_MeasureValues.Rows.Add("RecWall3");
            dgv_MeasureValues.Rows.Add("RecWall4");

            string[] functions = {
                "Floor()","Ceiling()","Round()", "Min()", "Max()", "Abs()", "Acos()", "Asin()", "Atan()",  "Cos()", "Exp()",
                 "Log10()", "Pow()", "Sign()", "Sin()", "Sqrt()", "Tan( )",  "if(x > y, Ja, Nej)"
            };

            foreach (var func in functions)
                dgv_Functions.Rows.Add(func);
        }

        private void Parameters_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var parameterMonitor = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(tb_Formula.Text))
                tb_Formula.Text += "=";
            tb_Formula.Text += $"{parameterMonitor}";
            tb_Formula.Focus();
            tb_Formula.Select(tb_Formula.Text.Length, 0);
            if (dgv == dgv_MeasureValues)
                AddParameter_TestFormula(parameterMonitor);
        }
        private void AddParameter_TestFormula(string parameter)
        {
            foreach (DataGridViewRow row in dgv_Variables.Rows)
                if (row.Cells[0].Value.ToString() == parameter)
                    return;
            var rnd = new Random();
            var value = rnd.Next(1, 10);
            dgv_Variables.Rows.Add(parameter, value);
        }

        private void Formula_TextChanged(object sender, EventArgs e)
        {
            _ = IsFormulaOk;
        }
        private void Variables_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _ = IsFormulaOk;
        }
        private bool IsFormulaOk
        {
            get
            {
                var formula = tb_Formula.Text;
                formula = Regex.Replace(formula, @"^=+", "");

                if (string.IsNullOrWhiteSpace(formula))
                    return true;

                var parameters = new Dictionary<string, object>();

                foreach (DataGridViewRow row in dgv_Variables.Rows)
                {
                    if (double.TryParse(row.Cells[1].Value.ToString(), out var value))
                        parameters[row.Cells[0].Value.ToString()] = value;
                }

                var expression = new NCalc.Expression(formula);
                foreach (var param in parameters)
                    expression.Parameters[param.Key] = param.Value;


                try
                {
                    var result = expression.Evaluate();
                    label_FormulaResult.Text = double.TryParse(result.ToString(), out var numericResult)
                        ? Math.Round(numericResult, 3).ToString(CultureInfo.CurrentCulture)
                        : "N/A";
                    label_FormulaResult.BackColor = CustomColors.Ok_Back;
                    label_FormulaResult.ForeColor = CustomColors.Ok_Front;
                    return true;
                }
                catch (Exception exception)
                {
                    label_FormulaResult.Text = exception.Message;
                    label_FormulaResult.BackColor = CustomColors.Bad_Back;
                    label_FormulaResult.ForeColor = CustomColors.Bad_Front;
                    return false;
                }
            }
        }

        private void SaveFormula_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
       

        private void FormulaBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsFormulaOk == false)
                e.Cancel = true;
            Formula = tb_Formula.Text;
        }

        
    }
}
