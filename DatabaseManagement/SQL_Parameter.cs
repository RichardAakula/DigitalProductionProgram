using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.Settings;
using Microsoft.Data.SqlClient;

namespace DigitalProductionProgram.DatabaseManagement
{
    [DebuggerStepThrough]
    internal class SQL_Parameter
    {
        
        public static SqlParameter Boolean(SqlParameterCollection collection, string param, object? text, bool isNullEqFalse = false)
        {
            var IsTrue = false;
            if (isNullEqFalse && text is null)
                return collection.AddWithValue(param, false);
            if (ControlValidator.IsStringNA(text.ToString()))
                return collection.AddWithValue(param, DBNull.Value);
            if (text.ToString() == "Ja" || text.ToString() == "Yes" || text.ToString() == "True" || text.ToString() == "1")
                IsTrue = true;
            
            return collection.AddWithValue(param, IsTrue);
        }
        public static object Bool(string value)
        {
            return bool.TryParse(value, out var result) ? result : (object)DBNull.Value;
        }

        public static SqlParameter Double(SqlParameterCollection collection, string param, object? text)
        {
            if (text is null)
                return collection.AddWithValue(param, DBNull.Value);
            if (!double.TryParse(text.ToString(), out var value)) 
                return collection.AddWithValue(param, DBNull.Value);
            return !double.IsNaN(value) ? collection.AddWithValue(param, value) : collection.AddWithValue(param, DBNull.Value);
        }
        public static SqlParameter Int(SqlParameterCollection collection, string param, object? text)
        {
            if (text is null)
                return collection.AddWithValue(param, DBNull.Value);
            if (int.TryParse(text.ToString(), out var value))
                return collection.AddWithValue(param, value);
            return collection.AddWithValue(param, DBNull.Value);
        }
        public static SqlParameter Byte_ZeroEqNULL(SqlParameterCollection collection, string param, byte value)
        {
            return value == 0 ? collection.AddWithValue(param, DBNull.Value) : collection.AddWithValue(param, value);
        }
        public static SqlParameter NullableINT(SqlParameterCollection collection, string param, int? value)
        {
            return value is null ? collection.AddWithValue(param, DBNull.Value) : collection.AddWithValue(param, value);
        }
        [DebuggerStepThrough]
        public static SqlParameter String(SqlParameterCollection collection, string param, string? value, bool IsNA_Ok = false)
        {
            if (string.IsNullOrEmpty(value) || (ControlValidator.IsStringNA(value) && IsNA_Ok == false))
                return collection.AddWithValue(param, DBNull.Value);
            return collection.AddWithValue(param, value);
            
        }
        public static SqlParameter Date(SqlParameterCollection collection, string param, string date)
        { 
            if (!DateTime.TryParse(date, out var dateTime))
                return collection.AddWithValue(param, DBNull.Value);

            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            var formattedDate = dateTime.ToString(dateTimeFormat.ShortDatePattern);

            return collection.AddWithValue(param, formattedDate);
        }
        public static SqlParameter Date_Time(SqlParameterCollection collection, string param, string? value)
        {
            if (!DateTime.TryParse(value, out var date)) 
                return collection.AddWithValue(param, DBNull.Value);

            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
            return collection.AddWithValue(param, formattedDate);
        }

        public static SqlParameter tlp(SqlParameterCollection collection, string param, TableLayoutPanel tlp, int row, int col, TypeCode valueTyp = TypeCode.String)
        {
            var tb = (TextBox)tlp.GetControlFromPosition(col, row);
            if (tb is null)
            {
                return collection.AddWithValue(param, DBNull.Value);
            }
            var text = tb.Text;
            if (valueTyp == TypeCode.Int32)
            {
                if (int.TryParse(text, out var value))
                    return collection.AddWithValue(param, value);
                return collection.AddWithValue(param, DBNull.Value);
            }

            if (valueTyp == TypeCode.Double)
            {
                if (double.TryParse(text, out var value))
                    return collection.AddWithValue(param, value);
                return collection.AddWithValue(param, DBNull.Value);
            }

            if (valueTyp == TypeCode.Boolean)
            {
                bool flag;
                if (tb.Text == "Ja")
                    flag = true;
                else if (tb.Text == "Nej")
                    flag = false;
                else
                    return collection.AddWithValue(param, DBNull.Value);
                return collection.AddWithValue(param, flag);
            }

            if (string.IsNullOrEmpty(text))
                return collection.AddWithValue(param, DBNull.Value);
            return collection.AddWithValue(param, text);
        }
        public static SqlParameter Verktyg_Landlängd(SqlParameterCollection collection, string param, string value)
        {
            if (value.Contains('|'))
            {
                value = value.Remove(0, value.IndexOf('|'));
                if (value.Contains('|'))
                    value = value.Remove(0, 1);
                if (value.StartsWith(" "))
                    value = value.TrimStart();

                return collection.AddWithValue(param, value);
            }

            return collection.AddWithValue(param, DBNull.Value);
        }
    }
}
