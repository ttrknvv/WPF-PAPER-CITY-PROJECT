using EXAMPLE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMPLE
{
    public enum ThemeOfApplicationEnum
    {
        Dark,
        Light
    }
    public enum LanguageOfApplicationEnum
    {
        Russian,
        English
    }

    public enum CountryOfAppEnum
    {
        Belarus,
        Russia,
        Ukraine,
        America
    }
    public class SettingOfApp
    {

        static public ThemeOfApplicationEnum ThemeOfApplication = ThemeOfApplicationEnum.Dark;
        static public LanguageOfApplicationEnum LanguageOfApplication = LanguageOfApplicationEnum.Russian;
        static public CountryOfAppEnum CountryOfApp = CountryOfAppEnum.Belarus;
        static public User LocalUser;
        static public int busket;
    }
}
