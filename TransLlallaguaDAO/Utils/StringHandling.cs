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
        public string StringWithoutSpaces(string cadena)
        {
            return cadena.Replace(" ", "");
        }
        public bool ValidationEmail(string cadena)
        {
            Regex regex = new Regex(@"^[^@\s]+@[^@\s]+.[^@\s]+$");
            return regex.IsMatch(cadena); 
        }
        public string GetPasswordStrength(string password)
        {
            if (password.Length < 8)
                return "Débil";

            Regex uppercase = new Regex(@"[A-Z]+");
            Regex lowercase = new Regex(@"[a-z]+");
            Regex digit = new Regex(@"[0-9]+");
            Regex specialChar = new Regex(@"[!@#$%^&*()+}{:;'?/>.<,]");

            int criteriaMet = 0;
            if (uppercase.IsMatch(password))
                criteriaMet++;
            if (lowercase.IsMatch(password))
                criteriaMet++;
            if (digit.IsMatch(password))
                criteriaMet++;
            if (specialChar.IsMatch(password))
                criteriaMet++;

            if (password.Length >= 8 && criteriaMet >= 4)
                return "Fuerte";
            else if (password.Length >= 8 && criteriaMet >= 2)
                return "Media";
            else
                return "Débil";
        }
    }
}
