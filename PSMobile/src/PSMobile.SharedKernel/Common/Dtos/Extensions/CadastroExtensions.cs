﻿using PSMobile.core.Entities;

namespace PSMobile.SharedKernel.Common.Dtos.Extensions;

public static class CadastroExtensions
{
    public static CadastroInputModel ToCadastrosInputModel(this Cadastros Cadastro)
    {
        var inputModel = new CadastroInputModel
        {
            Key = Cadastro.cad_key,
            Razao = Cadastro.cad_razao,
            Nome = Cadastro.cad_nome,
            Cnpj = Cadastro.cad_cnpj,
            Sexo = Cadastro.cad_sexo,
            Ie = Cadastro.cad_ie,
            Im = Cadastro.cad_im,
            Ist = Cadastro.cad_ist,
            Rg = Cadastro.cad_rg,
            Orgao = Cadastro.cad_orgao,
            DataNasFun = Cadastro.cad_datanasfun,
            Obs = Cadastro.cad_obs,

            CadCliDesconto = Cadastro.CadastroCliente.CadastroCredito.cad_cli_desconto,
            CliLimiteTotal = Cadastro.CadastroCliente.CadastroCredito.cad_cli_limitetotal,
            CliLimiteMensal = Cadastro.CadastroCliente.CadastroCredito.cad_cli_limitemensal,
            CliLimiteParcelas = Cadastro.CadastroCliente.CadastroCredito.cad_cli_limiteparcelas,
            CliRendaComprovada = Cadastro.CadastroCliente.CadastroCredito.cad_cli_rendacomprovada,
            CliComprovanteRenda = Cadastro.CadastroCliente.CadastroCredito.cad_cli_comprovanterenda,
            CliRenda = Cadastro.CadastroCliente.CadastroCredito.cad_cli_renda,

            Cep = Cadastro.CadastroEndereco.cad_cep,
            Endereco = Cadastro.CadastroEndereco.cad_endereco,
            Numero = Cadastro.CadastroEndereco.cad_numero,
            Complemento = Cadastro.CadastroEndereco.cad_complemento,
            Bairro = Cadastro.CadastroEndereco.cad_bairro,
            UfsCodigo = Cadastro.CadastroEndereco.cad_ufs_codigo,
            CidCodigo = Cadastro.CadastroEndereco.cad_cid_codigo,

            Contato = Cadastro.CadastroContato.cad_contato,
            FoneContato = Cadastro.CadastroContato.cad_fonecontato,
            Email = Cadastro.CadastroContato.cad_email,
            Fone1 = Cadastro.CadastroContato.cad_fone1,
            Fone2 = Cadastro.CadastroContato.cad_fone2,
            Fone3 = Cadastro.CadastroContato.cad_fone3,

        };

        return inputModel;
    }
}
