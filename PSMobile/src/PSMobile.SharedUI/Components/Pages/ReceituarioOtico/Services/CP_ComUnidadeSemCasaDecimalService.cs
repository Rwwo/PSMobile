
using Microsoft.VisualBasic;

using MudBlazor;

using static Microsoft.VisualBasic.Information;
using static Microsoft.VisualBasic.Interaction;

namespace PSMobile.SharedUI.Components.Pages.ReceituarioOtico.Services
{
    public class CP_ComUnidadeSemCasaDecimalService : IStyleService
    {
        public MudTextField<string> From { get; set; }
        public MudTextField<string> To { get; set; }
        public MudTextField<string> TbAdicao { get; set; }

        public CP_ComUnidadeSemCasaDecimalService(MudTextField<string> from, MudTextField<string> to, MudTextField<string> tbAdicao)
        {
            From = from;
            To = to;
            TbAdicao = tbAdicao;
        }

        public void Process()
        {


            if (IsNumeric(From.Text.Replace("º", "")))
            {
                float X1 = Convert.ToSingle(From.Text.Replace("º", "").Replace(".", ","));

                if (X1 != 0)
                {
                    From.SetText(Strings.FormatNumber(X1, 0).ToString());
                    if (X1 > 0)
                        From.Text = From.Text + "º";
                }
            }
            else
            {
                From.SetText("");
            }

            if (!string.IsNullOrEmpty(TbAdicao.Text))
                To.Text = From.Text;



        }


    }
}
