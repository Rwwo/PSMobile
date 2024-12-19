
using MudBlazor;

using PSMobile.SharedUI.Components.Pages.ReceituarioOtico.Extensions;

namespace PSMobile.SharedUI.Components.Pages.ReceituarioOtico.Services
{
    public class CP_CalculaAdicaoLongePertoService : IStyleService
    {

        public CP_CalculaAdicaoLongePertoService(MudTextField<string> tBrecocu_lonodesf_tb4, MudTextField<string> tBrecocu_lonoeesf_tb8, MudTextField<string> tBrecocu_perodesf_tb12, MudTextField<string> tBrecocu_peroeesf_tb16, MudTextField<string> tBrecocu_lonodcil_tb5, MudTextField<string> tBrecocu_lonoecil_tb9, MudTextField<string> tBrecocu_lonodeixo_tb6, MudTextField<string> tBrecocu_lonoeeixo_tb10, MudTextField<string> tBrecocu_lonoddnp_tb7, MudTextField<string> tBrecocu_lonoednp_tb11, MudTextField<string> tBrecocu_adicao_tb22, MudTextField<string> tBrecocu_perodcil_tb13, MudTextField<string> tBrecocu_peroecil_tb17, MudTextField<string> tBrecocu_perodeixo_tb14, MudTextField<string> tBrecocu_peroeeixo_tb18, MudTextField<string> tBrecocu_peroddnp_tb14, MudTextField<string> tBrecocu_peroednp_tb19, string tbSender)
        {
            TBrecocu_lonodesf_tb4 = tBrecocu_lonodesf_tb4;
            TBrecocu_lonoeesf_tb8 = tBrecocu_lonoeesf_tb8;
            TBrecocu_perodesf_tb12 = tBrecocu_perodesf_tb12;
            TBrecocu_peroeesf_tb16 = tBrecocu_peroeesf_tb16;
            TBrecocu_lonodcil_tb5 = tBrecocu_lonodcil_tb5;
            TBrecocu_lonoecil_tb9 = tBrecocu_lonoecil_tb9;
            TBrecocu_lonodeixo_tb6 = tBrecocu_lonodeixo_tb6;
            TBrecocu_lonoeeixo_tb10 = tBrecocu_lonoeeixo_tb10;
            TBrecocu_lonoddnp_tb7 = tBrecocu_lonoddnp_tb7;
            TBrecocu_lonoednp_tb11 = tBrecocu_lonoednp_tb11;
            TBrecocu_adicao_tb22 = tBrecocu_adicao_tb22;
            TBrecocu_perodcil_tb13 = tBrecocu_perodcil_tb13;
            TBrecocu_peroecil_tb17 = tBrecocu_peroecil_tb17;
            TBrecocu_perodeixo_tb14 = tBrecocu_perodeixo_tb14;
            TBrecocu_peroeeixo_tb18 = tBrecocu_peroeeixo_tb18;
            TBrecocu_peroddnp_tb14 = tBrecocu_peroddnp_tb14;
            TBrecocu_peroednp_tb19 = tBrecocu_peroednp_tb19;

            TbSender = tbSender;

        }

        public MudTextField<string> TBrecocu_lonodesf_tb4 { get; }
        public MudTextField<string> TBrecocu_lonoeesf_tb8 { get; }
        public MudTextField<string> TBrecocu_perodesf_tb12 { get; }
        public MudTextField<string> TBrecocu_peroeesf_tb16 { get; }

        MudTextField<string> TBrecocu_lonodcil_tb5;
        MudTextField<string> TBrecocu_lonoecil_tb9;

        MudTextField<string> TBrecocu_lonodeixo_tb6;
        MudTextField<string> TBrecocu_lonoeeixo_tb10;

        MudTextField<string> TBrecocu_lonoddnp_tb7;
        MudTextField<string> TBrecocu_lonoednp_tb11;

        MudTextField<string> TBrecocu_perodcil_tb13;
        MudTextField<string> TBrecocu_peroecil_tb17;
        MudTextField<string> TBrecocu_perodeixo_tb14;
        MudTextField<string> TBrecocu_peroeeixo_tb18;
        MudTextField<string> TBrecocu_peroddnp_tb14;
        MudTextField<string> TBrecocu_peroednp_tb19;

        public MudTextField<string> TBrecocu_adicao_tb22 { get; }
        public string TbSender { get; }

        public void Process()
        {

            var VLR_Adicao = TBrecocu_adicao_tb22.FormatarValorTextBox();

            if (VLR_Adicao != "")
            {
                if (TbSender.ToString() == "TBrecocu_adicao_tb22")
                {
                    if (!string.IsNullOrEmpty(TBrecocu_lonodesf_tb4.Text))
                    {
                        var VLR_LON_OD_ESF = TBrecocu_lonodesf_tb4.FormatarValorTextBox();
                        if (VLR_LON_OD_ESF != "")
                        {
                            TBrecocu_perodesf_tb12.Text = ((VLR_LON_OD_ESF + VLR_Adicao).ToString());
                            TBrecocu_perodesf_tb12.FormatarValorTextBox();
                        }
                    }

                    if (!string.IsNullOrEmpty(TBrecocu_lonoeesf_tb8.Text))
                    {
                        var VLR_LON_OE_ESF = TBrecocu_lonoeesf_tb8.FormatarValorTextBox();
                        if (VLR_LON_OE_ESF != "")
                        {
                            TBrecocu_peroeesf_tb16.Text = (VLR_LON_OE_ESF + VLR_Adicao).ToString();
                            TBrecocu_peroeesf_tb16.FormatarValorTextBox();
                        }
                    }

                    new CP_SemUnidade_SemSinalGrafico_DuasCasasDecimalService
                        (TBrecocu_lonodcil_tb5
                        , TBrecocu_perodcil_tb13
                        , TBrecocu_adicao_tb22)
                        .Process();

                    new CP_SemUnidade_SemSinalGrafico_DuasCasasDecimalService
                        (TBrecocu_lonoecil_tb9
                        , TBrecocu_peroecil_tb17
                        , TBrecocu_adicao_tb22)
                        .Process();

                    new CP_ComUnidadeSemCasaDecimalService
                        (TBrecocu_lonodeixo_tb6
                        , TBrecocu_perodeixo_tb14
                        , TBrecocu_adicao_tb22)
                        .Process();

                    new CP_ComUnidadeSemCasaDecimalService
                        (TBrecocu_lonoeeixo_tb10
                        , TBrecocu_peroeeixo_tb18
                        , TBrecocu_adicao_tb22)
                        .Process();

                    new CP_SemUnidade_SemSinalGrafico_UmaCasaDecimalService
                        (TBrecocu_lonoddnp_tb7
                        , TBrecocu_peroddnp_tb14
                        , TBrecocu_adicao_tb22)
                        .Process();

                    new CP_SemUnidade_SemSinalGrafico_UmaCasaDecimalService
                        (TBrecocu_lonoednp_tb11
                        , TBrecocu_peroednp_tb19
                        , TBrecocu_adicao_tb22)
                        .Process();

                }

            }
            else
            {
                TBrecocu_adicao_tb22.Text = "";
                TBrecocu_perodesf_tb12.Text = "";

                TBrecocu_peroeesf_tb16.Text = "";


                TBrecocu_perodcil_tb13.Text = "";
                TBrecocu_peroecil_tb17.Text = "";
                TBrecocu_perodeixo_tb14.Text = "";
                TBrecocu_peroeeixo_tb18.Text = "";
                TBrecocu_peroddnp_tb14.Text = "";
                TBrecocu_peroednp_tb19.Text = "";

            }


        }
    }
}
