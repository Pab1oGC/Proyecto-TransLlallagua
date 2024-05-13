using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Utils
{
    public class StringHandling
    {
        public bool IsSpecialCharacter(char c)
        {
            Regex regex = new Regex(@"[^\w\d]");
            return regex.IsMatch(c.ToString());
        }
        public bool IsSpecialCharacterNotHyphen(char c)
        {
            Regex regex = new Regex(@"[^\w\d-]");
            return regex.IsMatch(c.ToString());
        }
        public string DeleteExtraSpaces(string cadena)
        {
            string cadenaSinEspaciosExtras = Regex.Replace(cadena, @"\s+", " ");
            return cadenaSinEspaciosExtras;
        }
        public bool IsSpecialCharacterNotPoint(char c)
        {
            Regex regex = new Regex(@"^[0-9.]$"); 
            return regex.IsMatch(c.ToString());
        }
        public bool IsSpecialCharacterOrNumber(char c)
        {
            Regex regex = new Regex(@"^[0-9\W&&[^-]]$");
            return regex.IsMatch(c.ToString());
        }
    }
}
