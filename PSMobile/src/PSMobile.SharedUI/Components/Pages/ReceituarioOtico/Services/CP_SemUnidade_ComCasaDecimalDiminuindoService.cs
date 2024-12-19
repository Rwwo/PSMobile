using MudBlazor;

using PSMobile.SharedUI.Components.Pages.ReceituarioOtico.Extensions;

namespace PSMobile.SharedUI.Components.Pages.ReceituarioOtico.Services
{
    public class CP_SemUnidade_ComCasaDecimalDiminuindoService : IStyleService
    {
        public MudTextField<string> From { get; set; }
        public MudTextField<string> To { get; set; }
        public MudTextField<string> TbAdicao { get; set; }

        public CP_SemUnidade_ComCasaDecimalDiminuindoService(MudTextField<string> from, MudTextField<string> to, MudTextField<string> tbAdicao)
        {
            From = from;
            To = to;
            TbAdicao = tbAdicao;
        }

        public void Process()
        {

            var VLR_Adicao = TbAdicao.FormatarValorTextBox();

            if (VLR_Adicao != "")
            {
                var VLR_From = From.FormatarValorTextBox();

                if (VLR_From != "")
                {
                    To.Text = ((Convert.ToSingle(VLR_From) - Convert.ToSingle(VLR_Adicao)).ToString());
                    To.FormatarValorTextBox();
                }

            }
            else
            {
                From.FormatarValorTextBox();
            }
        }
    }
}
