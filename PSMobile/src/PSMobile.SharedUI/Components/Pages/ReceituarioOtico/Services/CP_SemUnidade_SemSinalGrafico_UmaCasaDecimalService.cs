using System;

using Microsoft.VisualBasic;

using MudBlazor;

using static Microsoft.VisualBasic.Information;

namespace PSMobile.SharedUI.Components.Pages.ReceituarioOtico.Services
{
    public class CP_SemUnidade_SemSinalGrafico_UmaCasaDecimalService : IStyleService
    {
        public MudTextField<string> From { get; set; }
        public MudTextField<string> To { get; set; }
        public MudTextField<string> TbAdicao { get; set; }

        public CP_SemUnidade_SemSinalGrafico_UmaCasaDecimalService(MudTextField<string> from, MudTextField<string> to, MudTextField<string> tbAdicao)
        {
            From = from;
            To = to;
            TbAdicao = tbAdicao;
        }

        public void Process()
        {
            if (IsNumeric(From.Text))
            {
                float X1 = Convert.ToSingle(From.Text.Replace(".", ","));

                if (X1 != 0)
                {
                    int decimalPlaces = (X1 % 1 == 0) ? 0 : 1;
                    From.Text = Strings.FormatNumber(X1, decimalPlaces).ToString();
                }
            }
            else
            {
                From.Text = "";
            }
        }
    }
}
