using System.ComponentModel.DataAnnotations;

namespace PSMobile.core.Entities;

public class ProdutosImagens : Entity
{
    [Key]
    public int proima_key { get; set; }
    public int proima_pro_key { get; set; }
    public byte[] proima_imagem { get; set; }
    public DateTime proima_datamud { get; set; }
    public string proima_sinc { get; set; }
    public string proima_pro_codigo { get; set; }
    public short proima_indice { get; set; }
    public short proima_sincenviar { get; set; }

    public Produtos? Produtos { get; set; }
}