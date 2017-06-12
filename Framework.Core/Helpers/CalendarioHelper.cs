using System;

namespace Framework.Core.Helpers
{
    public static class CalendarioHelper
    {
        public static string ObterDataAtual()
        {
            return DateTime.Now.ToShortDateString();
        }

        public static string ObterDiaFuturo(double dia)
        {
            return DateTime.Now.AddDays(dia).ToShortDateString();
        }

        public static string ObterMesFuturo(int mes)
        {
            return DateTime.Now.AddMonths(mes).ToShortDateString();
        }

        public static string ObterSemanasFuturas(double dias)
        {
            return DateTime.Now.AddDays(dias).ToShortDateString();
        }
    }
}
