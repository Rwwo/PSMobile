using PSMobile.core.Entities;

namespace PSMobile.core.Extensions;

public static class CadastrosExtensions
{
    public static void UpdateCadastro(this Cadastros cadastro, Cadastros updatedData)
    {
        cadastro.cad_razao = updatedData.cad_razao;
        cadastro.cad_tipocli = updatedData.cad_tipocli;
        cadastro.cad_tipofor = updatedData.cad_tipofor;
        cadastro.cad_tipotra = updatedData.cad_tipotra;
        cadastro.cad_ie = updatedData.cad_ie;
        cadastro.cad_im = updatedData.cad_im;
        cadastro.cad_ist = updatedData.cad_ist;
        cadastro.cad_cnpj = updatedData.cad_cnpj;
        cadastro.cad_sexo = updatedData.cad_sexo;
        cadastro.cad_nome = updatedData.cad_nome;
        cadastro.cad_rg = updatedData.cad_rg;
        cadastro.cad_orgao = updatedData.cad_orgao;
        cadastro.cad_datanasfun = updatedData.cad_datanasfun;

        // Atualizar os objetos relacionados
        cadastro.CadastroCliente?.UpdateCadastroCliente(updatedData.CadastroCliente);
        cadastro.CadastroFornecedor?.UpdateCadastroFornecedor(updatedData.CadastroFornecedor);
        cadastro.CadastroTransportadora?.UpdateCadastroTransportadora(updatedData.CadastroTransportadora);
        cadastro.CadastroContato?.UpdateCadastroContato(updatedData.CadastroContato);
        cadastro.CadastroEndereco?.UpdateCadastroEndereco(updatedData.CadastroEndereco);
        cadastro.CadastroEnderecoEntrega?.UpdateCadastroEndereco(updatedData.CadastroEnderecoEntrega);
        cadastro.CadastroEnderecoCorrespondencia?.UpdateCadastroEndereco(updatedData.CadastroEnderecoCorrespondencia);
    }

    public static void UpdateCadastroCliente(this CadastroCliente cliente, CadastroCliente updatedData)
    {
        if (cliente == null || updatedData == null)
            return;

        cliente.cad_cli_naturalidade = updatedData.cad_cli_naturalidade;
        cliente.cad_cli_exc = updatedData.cad_cli_exc;
        cliente.cad_cli_dataexc = updatedData.cad_cli_dataexc;
        cliente.cad_cli_usu = updatedData.cad_cli_usu;
        cliente.cad_cli_comput = updatedData.cad_cli_comput;
        cliente.cad_cli_datamud = updatedData.cad_cli_datamud;
        cliente.cad_cli_datacad = updatedData.cad_cli_datacad;
        cliente.cad_cli_liberado = updatedData.cad_cli_liberado;
        cliente.cad_cli_diastolerancia = updatedData.cad_cli_diastolerancia;

        cliente.CadastroCredito?.UpdateCadastroCredito(updatedData.CadastroCredito);
    }

    public static void UpdateCadastroFornecedor(this CadastroFornecedor fornecedor, CadastroFornecedor updatedData)
    {
        if (fornecedor == null || updatedData == null)
            return;

        fornecedor.cad_for_suframa = updatedData.cad_for_suframa;
        fornecedor.cad_for_grufor_key = updatedData.cad_for_grufor_key;
        fornecedor.cad_for_creditoicms = updatedData.cad_for_creditoicms;
        fornecedor.cad_for_exc = updatedData.cad_for_exc;
        fornecedor.cad_for_dataexc = updatedData.cad_for_dataexc;
        fornecedor.cad_for_usu = updatedData.cad_for_usu;
        fornecedor.cad_for_comput = updatedData.cad_for_comput;
        fornecedor.cad_for_datamud = updatedData.cad_for_datamud;
        fornecedor.cad_for_datacad = updatedData.cad_for_datacad;
        fornecedor.cad_for_liberado = updatedData.cad_for_liberado;
        fornecedor.cad_for_fornecedor = updatedData.cad_for_fornecedor;
        fornecedor.cad_for_contacontabil = updatedData.cad_for_contacontabil;
        fornecedor.cad_for_prestador = updatedData.cad_for_prestador;
    }

    public static void UpdateCadastroTransportadora(this CadastroTransportadora transportadora, CadastroTransportadora updatedData)
    {
        if (transportadora == null || updatedData == null)
            return;

        transportadora.cad_tra_exc = updatedData.cad_tra_exc;
        transportadora.cad_tra_dataexc = updatedData.cad_tra_dataexc;
        transportadora.cad_tra_usu = updatedData.cad_tra_usu;
        transportadora.cad_tra_comput = updatedData.cad_tra_comput;
        transportadora.cad_tra_datamud = updatedData.cad_tra_datamud;
        transportadora.cad_tra_datacad = updatedData.cad_tra_datacad;
        transportadora.cad_rntrc = updatedData.cad_rntrc;
        transportadora.cad_rntrctipoproprietario = updatedData.cad_rntrctipoproprietario;
        transportadora.cad_tra_liberado = updatedData.cad_tra_liberado;
    }

    public static void UpdateCadastroEndereco(this CadastroEndereco endereco, CadastroEndereco updatedData)
    {
        if (endereco == null || updatedData == null)
            return;

        endereco.cad_pai_codigo = updatedData.cad_pai_codigo;
        endereco.cad_cep = updatedData.cad_cep;
        endereco.cad_numero = updatedData.cad_numero;
        endereco.cad_complemento = updatedData.cad_complemento;
        endereco.cad_endereco = updatedData.cad_endereco;
        endereco.cad_bairro = updatedData.cad_bairro;
        endereco.cad_ufs_codigo = updatedData.cad_ufs_codigo;
        endereco.cad_cid_codigo = updatedData.cad_cid_codigo;
    }

    public static void UpdateCadastroContato(this CadastroContato contato, CadastroContato updatedData)
    {
        if (contato == null || updatedData == null)
            return;

        contato.cad_contato = updatedData.cad_contato;
        contato.cad_fonecontato = updatedData.cad_fonecontato;
        contato.cad_email = updatedData.cad_email;
        contato.cad_site = updatedData.cad_site;
        contato.cad_whats1 = updatedData.cad_whats1;
        contato.cad_whats2 = updatedData.cad_whats2;
        contato.cad_whats3 = updatedData.cad_whats3;
        contato.cad_cli_ref1fone = updatedData.cad_cli_ref1fone;
        contato.cad_cli_ref2fone = updatedData.cad_cli_ref2fone;
        contato.cad_cli_ref3fone = updatedData.cad_cli_ref3fone;
        contato.cad_cli_ref1relacao = updatedData.cad_cli_ref1relacao;
        contato.cad_cli_ref2relacao = updatedData.cad_cli_ref2relacao;
        contato.cad_cli_ref3relacao = updatedData.cad_cli_ref3relacao;
    }

    public static void UpdateCadastroCredito(this CadastroCredito credito, CadastroCredito updatedData)
    {
        if (credito == null || updatedData == null)
            return;

        credito.cad_cli_usu = updatedData.cad_cli_usu;
        credito.cad_cli_desconto = updatedData.cad_cli_desconto;
        credito.cad_cli_catcli_key = updatedData.cad_cli_catcli_key;
        credito.cad_cli_limitetotal = updatedData.cad_cli_limitetotal;
        credito.cad_cli_limitemensal = updatedData.cad_cli_limitemensal;
        credito.cad_cli_limiteparcelas = updatedData.cad_cli_limiteparcelas;
        credito.cad_cli_rendacomprovada = updatedData.cad_cli_rendacomprovada;
        credito.cad_cli_comprovanterenda = updatedData.cad_cli_comprovanterenda;
        credito.cad_cli_renda = updatedData.cad_cli_renda;
        credito.cad_cli_juros = updatedData.cad_cli_juros;
        credito.cad_cli_liberado = updatedData.cad_cli_liberado;
    }
}
