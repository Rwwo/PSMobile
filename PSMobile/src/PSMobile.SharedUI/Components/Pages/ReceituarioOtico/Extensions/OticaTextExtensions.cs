using Microsoft.VisualBasic;

using MudBlazor;

using static Microsoft.VisualBasic.Information;
using static Microsoft.VisualBasic.Interaction;


namespace PSMobile.SharedUI.Components.Pages.ReceituarioOtico.Extensions;
public static class OticaTextExtensions
{
    public static string FormatarValorTextBox(this MudTextField<string> tb)
    {
        float VLR = Convert.ToSingle(IIf(IsNumeric(tb.Text), tb.Text, 0));

        if (VLR != 0)
        {
            tb.Text = Strings.FormatNumber(VLR, 2).ToString();
            if (VLR > 0)
                return tb.Text = ("+" + tb.Text).ToString();
        }

        return "";
    }

}
