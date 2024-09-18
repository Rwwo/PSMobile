using PSMobile.core.Entities;

namespace PSMobile.SharedKernel.Common.Dtos.Extensions;
public static class CadastroInputModelExtensions
{
    public static Cadastros ToCadastros(this CadastroInputModel inputModel)
    {
        var cadastro = new Cadastros
        {
            cad_key = inputModel.Key,
            cad_razao = inputModel.Razao,
            cad_nome = inputModel.Nome,
            cad_cnpj = inputModel.Cnpj,
            cad_sexo = inputModel.Sexo,
            cad_ie = inputModel.Ie,
            cad_im = inputModel.Im,
            cad_ist = inputModel.Ist,
            cad_rg = inputModel.Rg,
            cad_orgao = inputModel.Orgao,
            cad_datanasfun = inputModel.DataNasFun,
            cad_obs = inputModel.Obs,
            CadastroCliente = new CadastroCliente
            {
                cad_cli_datacad = inputModel.CliDataCad,
                //cad_cli_usu = inputModel.CliUsu,
                //cad_cli_comput = inputModel.CliComput,
                cad_cli_liberado = (short)inputModel.CadCliLiberado,
                cad_cli_diastolerancia = inputModel.CadCliDiasTolerancia,
                cad_cli_datamud = DateTime.Now,  // Atualiza data de modificação
                //cad_cli_naturalidade = inputModel.CliNaturalidade,
                CadastroCredito = new CadastroCredito
                {
                    //cad_cli_usu = inputModel.CliUsu,
                    cad_cli_desconto = inputModel.CadCliDesconto,
                    cad_cli_limitetotal = inputModel.CliLimiteTotal ?? 0,
                    cad_cli_limitemensal = inputModel.CliLimiteMensal ?? 0,
                    cad_cli_limiteparcelas = inputModel.CliLimiteParcelas ?? 0,
                    cad_cli_rendacomprovada = inputModel.CliRendaComprovada ?? null,
                    cad_cli_comprovanterenda = inputModel.CliComprovanteRenda ?? null,
                    cad_cli_renda = inputModel.CliRenda ?? null,
                    //cad_cli_juros = inputModel.CadCliJuros
                }
            },
            CadastroEndereco = new CadastroEndereco
            {
                cad_cep = inputModel.Cep,
                cad_endereco = inputModel.Endereco,
                cad_numero = inputModel.Numero,
                cad_complemento = inputModel.Complemento,
                cad_bairro = inputModel.Bairro,
                cad_ufs_codigo = inputModel.UfsCodigo,
                cad_cid_codigo = inputModel.CidCodigo
            },
            CadastroEnderecoEntrega = new CadastroEndereco
            {
                cad_cep = inputModel.EntCep,
                cad_endereco = inputModel.EntEndereco,
                cad_numero = inputModel.EntNumero,
                cad_complemento = inputModel.EntComplemento,
                cad_bairro = inputModel.EntBairro,
                cad_ufs_codigo = inputModel.EntUfsCodigo,
                cad_cid_codigo = inputModel.EntCidCodigo
            },
            CadastroEnderecoCorrespondencia = new CadastroEndereco
            {
                cad_cep = inputModel.CorCep,
                cad_endereco = inputModel.CorEndereco,
                cad_numero = inputModel.CorNumero,
                cad_complemento = inputModel.CorComplemento,
                cad_bairro = inputModel.CorBairro,
                cad_ufs_codigo = inputModel.CorUfsCodigo,
                cad_cid_codigo = inputModel.CorCidCodigo
            },
            CadastroContato = new CadastroContato
            {
                cad_contato = inputModel.Contato,
                cad_fonecontato = inputModel.FoneContato,
                cad_email = inputModel.Email,
                cad_fone1 = inputModel.Fone1,
                cad_fone2 = inputModel.Fone2,
                cad_fone3 = inputModel.Fone3,
            }
        };

        return cadastro;
    }
}
