using System;
using System.Collections.Generic;

namespace SouthernBug.App.Repository
{
    public static class Tables
    {
        public static class Names
        {
            public const string OperInfoHydro = "OPER_INFO_HYDRO";
            public const string OperInfoMeteo = "OPER_INFO_METEO";
            public const string BazaInfoMeteo = "BAZA_INFO_METEO";
            public const string BazaInfoHydro = "BAZA_INFO_HYDRO";
            public const string BazaInfoCoeffs = "Coeffs";
            public const string OrdinKtgr = "ORDIN_KTGR";
            public const string Posts = "Posts";
            public const string ConsultSp = "Consult_SP";

            public static readonly string[] BasicTables =
            {
                BazaInfoHydro, BazaInfoMeteo,
                BazaInfoCoeffs, OrdinKtgr, ConsultSp
            };

            public static readonly string[] OperTables =
            {
                OperInfoHydro, OperInfoMeteo
            };

            public static readonly Dictionary<string, string> PostTablesDic 
                = new Dictionary<string, string>()
            {
                {"Південний Буг- с.Тростянчик", "187"},
                {"Південний Буг- с.Підгір`я", "188"},
                {"Рів- с.Демидівка", "193"},
                {"Кодима- с.Катеринка", "197"},
                {"Синюха- с.Синюхін Брід", "198"},
                {"Велика Вись- с.Ямпіль", "200"},
                {"Ятрань – с.Покотилово", "201"},
                {"Чорний Ташлик- с.Тарасівка", "203"},
                {"р.Інгул-м.Кропивницький", "207"},
                {"р.Інгул-с.Новогорожене", "209"},
                {"Мертвовiд-с.Крива Пустош", "204"},
                {"Чичиклiя-с.Василiвка", "205"},
                {"Гнилий Єланець-с.Женево- Кривор", "206"},
                {"Громоклія-с.Михайлiвка", "210"},
                {"Тилiгул-с.Новоукраїнка", "211"},
                {"Тилiгул-с.Березiвка", "212"},
                {"Великий Куяльник-Северинівка", "139"},
                {"Ботна-м.Каушани", "213"},
                {"Когильник-м.Котовськ", "214"},
                {"Ялпуг-зал.ст.Комрат", "215"},
                {"Муса-зал.ст.Комрат", "216"},
                {"Тараклiя-смтТараклiя", "217"},
            };
        }

        public static class OperTables
        {
            public const string Year = "_Year";
        }

        public static class OperInfoHydro
        {
            public const string Index = "Index";
            public const string OI_Hydro = "OI_Hydro";
            public const string Hydro = "Hydro";
            public const string OBL = "OBL";
            public const string Q12 = "Q12";
            public const string Q01 = "Q01";
            public const string Q02 = "Q02";
            public const string Q03 = "Q03";
            public const string QPB = "QPB";
            public const string MQP = "MQP";
            public const string DB = "DB";
            public const string DQm = "DQm";
            public const string Qm = "Qm";
            public const string Hm = "Hm";
            public const string Ym = "Ym";
            public const string dS = "dS";
        }

        public static class OperInfoMeteo
        {
            public const string Index = "Index";
            public const string OI_Meteo = "OI_Meteo";
            public const string Meteo = "Meteo";
            public const string S05_01 = "S05_01";
            public const string S10_01 = "S10_01";
            public const string S15_01 = "S15_01";
            public const string S20_01 = "S20_01";
            public const string S25_01 = "S25_01";
            public const string S31_01 = "S31_01";
            public const string S05_02 = "S05_02";
            public const string S10_02 = "S10_02";
            public const string S15_02 = "S15_02";
            public const string S20_02 = "S20_02";
            public const string S25_02 = "S25_02";
            public const string S28_02 = "S28_02";
            public const string S05_03 = "S05_03";
            public const string S10_03 = "S10_03";
            public const string S15_03 = "S15_03";
            public const string S20_03 = "S20_03";
            public const string S25_03 = "S25_03";
            public const string S31_03 = "S31_03";
            public const string S05_04 = "S05_04";
            public const string S10_04 = "S10_04";
            public const string Sm = "Sm";
            public const string DSm = "DSm";
            public const string L31_12 = "L31_12";
            public const string L10_01 = "L10_01";
            public const string L20_01 = "L20_01";
            public const string L31_01 = "L31_01";
            public const string L10_02 = "L10_02";
            public const string L20_02 = "L20_02";
            public const string L28_02 = "L28_02";
            public const string L10_03 = "L10_03";
            public const string L20_03 = "L20_03";
            public const string L31_03 = "L31_03";
            public const string L10_04 = "L10_04";
            public const string Lm = "Lm";
            public const string T11 = "T11";
            public const string T12 = "T12";
            public const string T13 = "T13";
            public const string T21 = "T21";
            public const string T22 = "T22";
            public const string T23 = "T23";
            public const string T31 = "T31";
            public const string T32 = "T32";
            public const string T33 = "T33";
            public const string T41 = "T41";
            public const string T42 = "T42";
            public const string T43 = "T43";
            public const string W100_OS = "W100_OS";
            public const string dW = "dW";
            public const string W100_B = "W100_B";
        }

        public static class BazaInfoMeteo
        {
            public const string Index = "Index";
            public const string OI_Meteo = "OI_Meteo";
            public const string Meteo = "Meteo";
            public const string H = "H";
            public const string Hr1 = "Hr1";
            public const string T10 = "T10";
            public const string T20 = "T20";
            public const string T30 = "T30";
            public const string WHB = "WHB";
        }

        public static class BazaInfoHydro
        {
            public const string Index = "Index";
            public const string Hr = "Hr";
            public const string OI_Hydro = "OI_Hydro";
            public const string Hydro = "Hydro";
            public const string OBL = "OBL";
            public const string F = "F";
            public const string fb = "fb";
            public const string fl = "fl";
            public const string Hr_G = "Hr_G";
            public const string Dl_G = "Dl_G";
            public const string Hr_D = "Hr_D";
            public const string Dl_D = "Dl_D";
            public const string S0 = "S0";
            public const string X10 = "X10";
            public const string X20 = "X20";
            public const string L0 = "L0";
            public const string Y0 = "Y0";
            public const string CvY = "CvY";
            public const string SigmY = "SigmY";
            public const string Q0 = "BigQ_0";
            public const string q0 = "SmallQ_0";
            public const string CvQm = "CvQm";
            public const string SigmQm = "SigmQm";
            public const string Hm0 = "Hm0";
            public const string DOPHm = "DOPHm";
            public const string Q12SR = "Q12SR";
            public const string Q01SR = "Q01SR";
            public const string Q02SR = "Q02SR";
            public const string Q03SR = "Q03SR";
            public const string HZp = "HZp";
            public const string HNB = "HNB";
            public const string HSNB = "HSNB";
            public const string Hmm = "Hmm";
            public const string OI_METEO = "OI_METEO";
            public const string OI_METEO_T = "OI_METEO_T";
            public const string Nazva_Meteo_T = "Nazva_Meteo_T";
            public const string T10 = "T10";
            public const string T20 = "T20";
            public const string T30 = "T30";
            public const string OI_RnDFY = "OI_RnDFY";
            public const string OI_RnDFQm = "OI_RnDFQm";
            public const string OI_RnY = "OI_RnY";
            public const string OI_RnQm = "OI_RnQm";
        }
    }
}