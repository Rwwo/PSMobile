using MudBlazor;

namespace PSMobile.SharedUI.Components.Pages.ReceituarioOtico.Services;
public interface ISelectionStyleFormatFactory
{
    IStyleService GetStyle(string tb);
}

public class SelectionStyleFormatFactory : ISelectionStyleFormatFactory
{
    #region TextBoxes


    MudTextField<string> TBrecocu_lonodesf_tb4;
    MudTextField<string> TBrecocu_lonoeesf_tb8;

    MudTextField<string> TBrecocu_lonodcil_tb5;
    MudTextField<string> TBrecocu_lonoecil_tb9;

    MudTextField<string> TBrecocu_lonodeixo_tb6;
    MudTextField<string> TBrecocu_lonoeeixo_tb10;

    MudTextField<string> TBrecocu_lonoddnp_tb7;
    MudTextField<string> TBrecocu_lonoednp_tb11;


    MudTextField<string> TBrecocu_adicao_tb22;

    MudTextField<string> TBrecocu_perodesf_tb12;
    MudTextField<string> TBrecocu_peroeesf_tb16;

    MudTextField<string> TBrecocu_perodcil_tb13;
    MudTextField<string> TBrecocu_peroecil_tb17;
    MudTextField<string> TBrecocu_perodeixo_tb14;
    MudTextField<string> TBrecocu_peroeeixo_tb18;
    MudTextField<string> TBrecocu_peroddnp_tb14;
    MudTextField<string> TBrecocu_peroednp_tb19;

    MudTextField<string> TBrecocu_altura_tb21;
    MudTextField<string> TBrecocu_diagonal_tb33;
    MudTextField<string> TBrecocu_ponte_tb23;
    MudTextField<string> TBrecocu_vertical_tb31;
    MudTextField<string> TBrecocu_horizontal;

    #endregion

    #region Construtor
    public SelectionStyleFormatFactory(MudTextField<string> tBrecocu_lonodesf_tb4, MudTextField<string> tBrecocu_lonoeesf_tb8, MudTextField<string> tBrecocu_lonodcil_tb5, MudTextField<string> tBrecocu_lonoecil_tb9, MudTextField<string> tBrecocu_lonodeixo_tb6, MudTextField<string> tBrecocu_lonoeeixo_tb10, MudTextField<string> tBrecocu_lonoddnp_tb7, MudTextField<string> tBrecocu_lonoednp_tb11, MudTextField<string> tBrecocu_adicao_tb22, MudTextField<string> tBrecocu_perodesf_tb12, MudTextField<string> tBrecocu_peroeesf_tb16, MudTextField<string> tBrecocu_perodcil_tb13, MudTextField<string> tBrecocu_peroecil_tb17, MudTextField<string> tBrecocu_perodeixo_tb14, MudTextField<string> tBrecocu_peroeeixo_tb18, MudTextField<string> tBrecocu_peroddnp_tb14, MudTextField<string> tBrecocu_peroednp_tb19, MudTextField<string> tBrecocu_altura_tb21, MudTextField<string> tBrecocu_diagonal_tb33, MudTextField<string> tBrecocu_ponte_tb23, MudTextField<string> tBrecocu_vertical_tb31, MudTextField<string> tBrecocu_horizontal)
    {
        TBrecocu_lonodesf_tb4 = tBrecocu_lonodesf_tb4;
        TBrecocu_lonoeesf_tb8 = tBrecocu_lonoeesf_tb8;
        TBrecocu_lonodcil_tb5 = tBrecocu_lonodcil_tb5;
        TBrecocu_lonoecil_tb9 = tBrecocu_lonoecil_tb9;
        TBrecocu_lonodeixo_tb6 = tBrecocu_lonodeixo_tb6;
        TBrecocu_lonoeeixo_tb10 = tBrecocu_lonoeeixo_tb10;
        TBrecocu_lonoddnp_tb7 = tBrecocu_lonoddnp_tb7;
        TBrecocu_lonoednp_tb11 = tBrecocu_lonoednp_tb11;
        TBrecocu_adicao_tb22 = tBrecocu_adicao_tb22;
        TBrecocu_perodesf_tb12 = tBrecocu_perodesf_tb12;
        TBrecocu_peroeesf_tb16 = tBrecocu_peroeesf_tb16;
        TBrecocu_perodcil_tb13 = tBrecocu_perodcil_tb13;
        TBrecocu_peroecil_tb17 = tBrecocu_peroecil_tb17;
        TBrecocu_perodeixo_tb14 = tBrecocu_perodeixo_tb14;
        TBrecocu_peroeeixo_tb18 = tBrecocu_peroeeixo_tb18;
        TBrecocu_peroddnp_tb14 = tBrecocu_peroddnp_tb14;
        TBrecocu_peroednp_tb19 = tBrecocu_peroednp_tb19;

        TBrecocu_altura_tb21 = tBrecocu_altura_tb21;
        TBrecocu_diagonal_tb33 = tBrecocu_diagonal_tb33;
        TBrecocu_ponte_tb23 = tBrecocu_ponte_tb23;
        TBrecocu_vertical_tb31 = tBrecocu_vertical_tb31;
        TBrecocu_horizontal = tBrecocu_horizontal;

    }


    #endregion

    public IStyleService GetStyle(string tb)
    {
        IStyleService styleService = null;

        switch (tb.ToString())
        {
            case "TBrecocu_lonodcil_tb5":
                styleService = new CP_SemUnidade_SemSinalGrafico_DuasCasasDecimalService
                    (TBrecocu_lonodcil_tb5, TBrecocu_perodcil_tb13, TBrecocu_adicao_tb22);
                break;

            case "TBrecocu_lonoecil_tb9":
                styleService = new CP_SemUnidade_SemSinalGrafico_DuasCasasDecimalService
                    (TBrecocu_lonoecil_tb9, TBrecocu_peroecil_tb17, TBrecocu_adicao_tb22);
                break;

            case "TBrecocu_lonodeixo_tb6":
                styleService = new CP_ComUnidadeSemCasaDecimalService
                    (TBrecocu_lonodeixo_tb6, TBrecocu_perodeixo_tb14, TBrecocu_adicao_tb22);
                break;

            case "TBrecocu_lonoeeixo_tb10":
                styleService = new CP_ComUnidadeSemCasaDecimalService
                    (TBrecocu_lonoeeixo_tb10, TBrecocu_peroeeixo_tb18, TBrecocu_adicao_tb22);
                break;

            case "TBrecocu_lonoddnp_tb7":
                styleService = new CP_SemUnidade_SemSinalGrafico_UmaCasaDecimalService
                    (TBrecocu_lonoddnp_tb7, null, TBrecocu_adicao_tb22);
                break;

            case "TBrecocu_lonoednp_tb11":
                styleService = new CP_SemUnidade_SemSinalGrafico_UmaCasaDecimalService
                    (TBrecocu_lonoednp_tb11, null, TBrecocu_adicao_tb22);
                break;


            case "TBrecocu_perodcil_tb13":
                styleService = new CP_SemUnidade_SemSinalGrafico_DuasCasasDecimalService
                    (TBrecocu_perodcil_tb13, TBrecocu_lonodcil_tb5, TBrecocu_adicao_tb22);
                break;

            case "TBrecocu_peroecil_tb17":
                styleService = new CP_SemUnidade_SemSinalGrafico_DuasCasasDecimalService
                    (TBrecocu_peroecil_tb17, TBrecocu_lonoecil_tb9, TBrecocu_adicao_tb22);
                break;

            case "TBrecocu_perodeixo_tb14":
                styleService = new CP_ComUnidadeSemCasaDecimalService
                    (TBrecocu_perodeixo_tb14, TBrecocu_lonodeixo_tb6, TBrecocu_adicao_tb22);
                break;

            case "TBrecocu_peroeeixo_tb18":
                styleService = new CP_ComUnidadeSemCasaDecimalService
                    (TBrecocu_peroeeixo_tb18, TBrecocu_lonoeeixo_tb10, TBrecocu_adicao_tb22);
                break;

            case "TBrecocu_peroddnp_tb14":
                styleService = new CP_SemUnidade_SemSinalGrafico_UmaCasaDecimalService
                    (TBrecocu_peroddnp_tb14, null, TBrecocu_adicao_tb22);
                break;

            case "TBrecocu_peroednp_tb19":
                styleService = new CP_SemUnidade_SemSinalGrafico_UmaCasaDecimalService
                    (TBrecocu_peroednp_tb19, null, TBrecocu_adicao_tb22);
                break;


            case "TBrecocu_lonodesf_tb4":
                styleService = new CP_SemUnidade_ComCasaDecimalSomandoService
                    (TBrecocu_lonodesf_tb4, TBrecocu_perodesf_tb12, TBrecocu_adicao_tb22);
                break;

            case "TBrecocu_lonoeesf_tb8":
                styleService = new CP_SemUnidade_ComCasaDecimalSomandoService
                    (TBrecocu_lonoeesf_tb8, TBrecocu_peroeesf_tb16, TBrecocu_adicao_tb22);
                break;


            case "TBrecocu_perodesf_tb12":
                styleService = new CP_SemUnidade_ComCasaDecimalDiminuindoService
                    (TBrecocu_perodesf_tb12, TBrecocu_lonodesf_tb4, TBrecocu_adicao_tb22);
                break;

            case "TBrecocu_peroeesf_tb16":
                styleService = new CP_SemUnidade_ComCasaDecimalDiminuindoService
                    (TBrecocu_peroeesf_tb16, TBrecocu_lonoeesf_tb8, TBrecocu_adicao_tb22);
                break;


            case "TBrecocu_adicao_tb22":
                styleService = new CP_CalculaAdicaoLongePertoService(TBrecocu_lonodesf_tb4, TBrecocu_lonoeesf_tb8, TBrecocu_perodesf_tb12,
                    TBrecocu_peroeesf_tb16, TBrecocu_lonodcil_tb5, TBrecocu_lonoecil_tb9, TBrecocu_lonodeixo_tb6,
                    TBrecocu_lonoeeixo_tb10, TBrecocu_lonoddnp_tb7, TBrecocu_lonoednp_tb11, TBrecocu_adicao_tb22, TBrecocu_perodcil_tb13,
                    TBrecocu_peroecil_tb17, TBrecocu_perodeixo_tb14, TBrecocu_peroeeixo_tb18, TBrecocu_peroddnp_tb14, TBrecocu_peroednp_tb19, tb);
                break;

            default:
                break;
                //throw new InvalidOperationException();
        }

        return styleService;
    }

}