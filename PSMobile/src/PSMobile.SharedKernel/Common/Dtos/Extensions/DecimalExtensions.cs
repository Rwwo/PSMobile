using System.Globalization;

namespace PSMobile.SharedKernel.Common.Dtos.Extensions;
public static class DecimalExtensions
{
    public static string ToMonetaryString(this decimal value)
    {        
        return value.ToString("C", CultureInfo.CurrentCulture);
    }
}
