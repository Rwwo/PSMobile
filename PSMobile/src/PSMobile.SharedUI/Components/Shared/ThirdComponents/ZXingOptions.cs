using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ZXingBlazor.Components;

public class ZXingOptions
{
    public bool Pdf417 { get; set; }
    public bool Decodeonce { get; set; } = true;
    public int TimeBetweenDecodingAttempts { get; set; } = 10;
    public bool DecodeAllFormats { get; set; }
    public bool ShowSelectFile { get; set; }
    public bool Screenshot { get; set; }
    public bool StreamFromZxing { get; set; }

    [DisplayName("Debug")]
    public bool Debug { get; set; }

    [DisplayName("Quality")]
    public double Quality { get; set; } = 0.9d;

    [DisplayName("Width")]
    public int? Width { get; set; }

    [DisplayName("Height")]
    public int? Height { get; set; }

    [DisplayName("DeviceId")]
    public string? DeviceID { get; set; }
    public List<BarcodeFormat> formats { get; set; } = new List<BarcodeFormat>() {
        BarcodeFormat.AZTEC ,
        BarcodeFormat.CODABAR,
        BarcodeFormat.CODE_39,
        BarcodeFormat.CODE_93,
        BarcodeFormat.CODE_128,
        BarcodeFormat.DATA_MATRIX,
        BarcodeFormat.EAN_8,
        BarcodeFormat.EAN_13,
        BarcodeFormat.ITF,
        BarcodeFormat.MAXICODE,
        BarcodeFormat.PDF_417,
        BarcodeFormat.QR_CODE,
        BarcodeFormat.RSS_14,
        BarcodeFormat.RSS_EXPANDED,
        BarcodeFormat.UPC_A,
        BarcodeFormat.UPC_E,
        BarcodeFormat.UPC_EAN_EXTENSION,
    };

    //[JsonPropertyName("ALSO_INVERTED")]
    //public bool ALSO_INVERTED { get; set; }

    [JsonPropertyName("ALLOWED_EAN_EXTENSIONS")]
    public int[]? ALLOWED_EAN_EXTENSIONS { get; set; } //= new int[] { 2 };
    [JsonPropertyName("ALLOWED_LENGTHS")]
    public int[]? ALLOWED_LENGTHS { get; set; }
    [JsonPropertyName("ASSUME_CODE_39_CHECK_DIGIT")]
    public bool? ASSUME_CODE_39_CHECK_DIGIT { get; set; }
    [JsonPropertyName("ASSUME_GS1")]
    public bool? ASSUME_GS1 { get; set; }
    [JsonPropertyName("CHARACTER_SET")]
    public string? CHARACTER_SET { get; set; }

    //public object NEED_RESULT_POINT_CALLBACK { get; set; }

    [JsonPropertyName("OTHER")]
    public object? OTHER { get; set; }

    [JsonPropertyName("PURE_BARCODE")]
    public bool? PURE_BARCODE { get; set; }

    [JsonPropertyName("RETURN_CODABAR_START_END")]
    public bool? RETURN_CODABAR_START_END { get; set; }

    [JsonPropertyName("TRY_HARDER")]
    public bool? TRY_HARDER { get; set; }
    public bool? TryInvertColors { get; set; }

}


/**
 * Enumerates barcode formats known to this package. Please keep alphabetized.
 *
 * @author Sean Owen
 */
public enum BarcodeFormat
{

    /** Aztec 2D barcode format. */
    AZTEC,

    /** CODABAR 1D format. */
    CODABAR,

    /** Code 39 1D format. */
    CODE_39,

    /** Code 93 1D format. */
    CODE_93,

    /** Code 128 1D format. */
    CODE_128,

    /** Data Matrix 2D barcode format. */
    DATA_MATRIX,

    /** EAN-8 1D format. */
    EAN_8,

    /** EAN-13 1D format. */
    EAN_13,

    /** ITF (Interleaved Two of Five) 1D format. */
    ITF,

    /** MaxiCode 2D barcode format. */
    MAXICODE,

    /** PDF417 format. */
    PDF_417,

    /** QR Code 2D barcode format. */
    QR_CODE,

    /** RSS 14 */
    RSS_14,

    /** RSS EXPANDED */
    RSS_EXPANDED,

    /** UPC-A 1D format. */
    UPC_A,

    /** UPC-E 1D format. */
    UPC_E,

    /** UPC/EAN extension format. Not a stand-alone format. */
    UPC_EAN_EXTENSION

}
