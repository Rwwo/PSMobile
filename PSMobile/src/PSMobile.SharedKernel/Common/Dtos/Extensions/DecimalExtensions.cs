using System.Globalization;

namespace PSMobile.SharedKernel.Common.Dtos.Extensions;
public static class DecimalExtensions
{
    public static string ToMonetaryString(this decimal value)
    {
        // Formata o valor decimal como moeda, utilizando a cultura atual
        return value.ToString("C", CultureInfo.CurrentCulture);
    }
}
