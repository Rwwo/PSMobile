using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PSMobile.core.Entities;

namespace PSMobile.infrastructure.Context.Configurations;
public class CadastrosConfiguration : IEntityTypeConfiguration<Cadastros>
{
    public void Configure(EntityTypeBuilder<Cadastros> builder)
    {
        // Definindo a tabela
        builder.ToTable("cadastros");

        // Chave Primária
        builder.HasKey(c => c.cad_key);

        builder.HasOne(t => t.ClientesOtica)
            .WithOne(o => o.Cadastros)
            .HasForeignKey<ClientesOtica>(t=>t.clioti_cad_key);

        builder.Property(c => c.cad_tipocli).HasColumnName("cad_tipocli");
        builder.Property(f => f.cad_tipofor).HasColumnName("cad_tipofor");
        builder.Property(t => t.cad_tipotra).HasColumnName("cad_tipotra");
        builder.Property(c => c.cad_cnpj).HasColumnName("cad_cnpj");
        builder.Property(c => c.cad_sexo).HasColumnName("cad_sexo");
        builder.Property(c => c.cad_nome).HasColumnName("cad_nome");
        builder.Property(f => f.cad_ie).HasColumnName("cad_ie");
        builder.Property(f => f.cad_im).HasColumnName("cad_im");
        builder.Property(f => f.cad_ist).HasColumnName("cad_ist");
        builder.Property(c => c.cad_rg).HasColumnName("cad_rg");
        builder.Property(c => c.cad_orgao).HasColumnName("cad_orgao");
        builder.Property(c => c.cad_datanasfun).HasColumnName("cad_datanasfun");
        builder.Property(c => c.cad_razao).HasColumnName("cad_razao");

        builder.OwnsOne(c => c.CadastroCliente, cliente =>
        {
            cliente.Property(c => c.cad_cli_naturalidade).HasColumnName("cad_cli_naturalidade");
            cliente.Property(c => c.cad_cli_exc).HasColumnName("cad_cli_exc");
            cliente.Property(c => c.cad_cli_mensagem).HasColumnName("cad_cli_mensagem");
            cliente.Property(c => c.cad_cli_dataexc).HasColumnName("cad_cli_dataexc");
            cliente.Property(c => c.cad_cli_usu).HasColumnName("cad_cli_usu");
            cliente.Property(c => c.cad_cli_comput).HasColumnName("cad_cli_comput");
            cliente.Property(c => c.cad_cli_datamud).HasColumnName("cad_cli_datamud");
            cliente.Property(c => c.cad_cli_datacad).HasColumnName("cad_cli_datacad");
            cliente.Property(c => c.cad_cli_liberado).HasColumnName("cad_cli_liberado");
            cliente.Property(c => c.cad_cli_diastolerancia).HasColumnName("cad_cli_diastolerancia");

            cliente.OwnsOne(c => c.CadastroCredito, credito =>
            {
                credito.Property(cr => cr.cad_cli_usu).HasColumnName("cad_cli_usu");
                credito.Property(cr => cr.cad_cli_desconto).HasColumnName("cad_cli_desconto");
                credito.Property(cr => cr.cad_cli_catcli_key).HasColumnName("cad_cli_catcli_key");
                credito.Property(cr => cr.cad_cli_limitetotal).HasColumnName("cad_cli_limitetotal");
                credito.Property(cr => cr.cad_cli_limitemensal).HasColumnName("cad_cli_limitemensal");
                credito.Property(cr => cr.cad_cli_limiteparcelas).HasColumnName("cad_cli_limiteparcelas");
                credito.Property(cr => cr.cad_cli_rendacomprovada).HasColumnName("cad_cli_rendacomprovada");
                credito.Property(cr => cr.cad_cli_comprovanterenda).HasColumnName("cad_cli_comprovanterenda");
                credito.Property(cr => cr.cad_cli_renda).HasColumnName("cad_cli_renda");
                credito.Property(cr => cr.cad_cli_juros).HasColumnName("cad_cli_juros");
                credito.Property(cr => cr.cad_cli_liberado).HasColumnName("cad_cli_liberado");
            });

        });


        // Mapeia CadastroFornecedor
        builder.OwnsOne(c => c.CadastroFornecedor, fornecedor =>
        {

            fornecedor.Property(f => f.cad_for_suframa).HasColumnName("cad_for_suframa");
            fornecedor.Property(f => f.cad_for_grufor_key).HasColumnName("cad_for_grufor_key");
            fornecedor.Property(f => f.cad_for_creditoicms).HasColumnName("cad_for_creditoicms");
            fornecedor.Property(f => f.cad_for_exc).HasColumnName("cad_for_exc");
            fornecedor.Property(f => f.cad_for_dataexc).HasColumnName("cad_for_dataexc");
            fornecedor.Property(f => f.cad_for_usu).HasColumnName("cad_for_usu");
            fornecedor.Property(f => f.cad_for_comput).HasColumnName("cad_for_comput");
            fornecedor.Property(f => f.cad_for_datamud).HasColumnName("cad_for_datamud");
            fornecedor.Property(f => f.cad_for_datacad).HasColumnName("cad_for_datacad");
            fornecedor.Property(f => f.cad_for_liberado).HasColumnName("cad_for_liberado");
            fornecedor.Property(f => f.cad_for_fornecedor).HasColumnName("cad_for_fornecedor");
            fornecedor.Property(f => f.cad_for_contacontabil).HasColumnName("cad_for_contacontabil");
            fornecedor.Property(f => f.cad_for_prestador).HasColumnName("cad_for_prestador");

        });

        // Mapeia CadastroTransportadora
        builder.OwnsOne(c => c.CadastroTransportadora, transportadora =>
        {
            transportadora.Property(t => t.cad_tra_exc).HasColumnName("cad_tra_exc");
            transportadora.Property(t => t.cad_tra_dataexc).HasColumnName("cad_tra_dataexc");
            transportadora.Property(t => t.cad_tra_usu).HasColumnName("cad_tra_usu");
            transportadora.Property(t => t.cad_tra_comput).HasColumnName("cad_tra_comput");
            transportadora.Property(t => t.cad_tra_datamud).HasColumnName("cad_tra_datamud");
            transportadora.Property(t => t.cad_tra_datacad).HasColumnName("cad_tra_datacad");
            transportadora.Property(t => t.cad_rntrc).HasColumnName("cad_rntrc");
            transportadora.Property(t => t.cad_rntrctipoproprietario).HasColumnName("cad_rntrctipoproprietario");
            transportadora.Property(t => t.cad_tra_liberado).HasColumnName("cad_tra_liberado");

        });

        // Mapeia CadastroContato
        builder.OwnsOne(c => c.CadastroContato, contato =>
        {
            contato.Property(ct => ct.cad_contato).HasColumnName("cad_contato");
            contato.Property(ct => ct.cad_fonecontato).HasColumnName("cad_fonecontato");
            contato.Property(ct => ct.cad_email).HasColumnName("cad_email");
            contato.Property(ct => ct.cad_site).HasColumnName("cad_site");
            contato.Property(ct => ct.cad_whats1).HasColumnName("cad_whats1");
            contato.Property(ct => ct.cad_whats2).HasColumnName("cad_whats2");
            contato.Property(ct => ct.cad_whats3).HasColumnName("cad_whats3");

            contato.Property(ct => ct.cad_fone1).HasColumnName("cad_fone1");
            contato.Property(ct => ct.cad_fone2).HasColumnName("cad_fone2");
            contato.Property(ct => ct.cad_fone3).HasColumnName("cad_fone3");

            contato.Property(r => r.cad_cli_ref1fone).HasColumnName("cad_cli_ref1fone");
            contato.Property(r => r.cad_cli_ref2fone).HasColumnName("cad_cli_ref2fone");
            contato.Property(r => r.cad_cli_ref3fone).HasColumnName("cad_cli_ref3fone");
            contato.Property(r => r.cad_cli_ref1relacao).HasColumnName("cad_cli_ref1relacao");
            contato.Property(r => r.cad_cli_ref2relacao).HasColumnName("cad_cli_ref2relacao");
            contato.Property(r => r.cad_cli_ref3relacao).HasColumnName("cad_cli_ref3relacao");
        });

        // Mapeia CadastroEndereco diretamente da entidade Cadastros
        builder.OwnsOne(c => c.CadastroEndereco, endereco =>
        {
            endereco.Property(e => e.cad_pai_codigo).HasColumnName("cad_pai_codigo");
            endereco.Property(e => e.cad_cep).HasColumnName("cad_cep");
            endereco.Property(e => e.cad_numero).HasColumnName("cad_numero");
            endereco.Property(e => e.cad_complemento).HasColumnName("cad_complemento");
            endereco.Property(e => e.cad_endereco).HasColumnName("cad_endereco");
            endereco.Property(e => e.cad_bairro).HasColumnName("cad_bairro");
            endereco.Property(e => e.cad_ufs_codigo).HasColumnName("cad_ufs_codigo");
            endereco.Property(e => e.cad_cid_codigo).HasColumnName("cad_cid_codigo");
        });

        builder.OwnsOne(c => c.CadastroEnderecoEntrega, endereco =>
        {

            endereco.Property(e => e.cad_pai_codigo).HasColumnName("cad_entpai_codigo");
            endereco.Property(e => e.cad_cep).HasColumnName("cad_entcep");
            endereco.Property(e => e.cad_numero).HasColumnName("cad_entnumero");
            endereco.Property(e => e.cad_complemento).HasColumnName("cad_entcomplemento");
            endereco.Property(e => e.cad_endereco).HasColumnName("cad_entendereco");
            endereco.Property(e => e.cad_bairro).HasColumnName("cad_entbairro");
            endereco.Property(e => e.cad_ufs_codigo).HasColumnName("cad_entufs_codigo");
            endereco.Property(e => e.cad_cid_codigo).HasColumnName("cad_entcid_codigo");
        });

        builder.OwnsOne(c => c.CadastroEnderecoCorrespondencia, endereco =>
        {
            endereco.Property(e => e.cad_pai_codigo).HasColumnName("cad_corpai_codigo");
            endereco.Property(e => e.cad_cep).HasColumnName("cad_corcep");
            endereco.Property(e => e.cad_numero).HasColumnName("cad_cornumero");
            endereco.Property(e => e.cad_complemento).HasColumnName("cad_corcomplemento");
            endereco.Property(e => e.cad_endereco).HasColumnName("cad_corendereco");
            endereco.Property(e => e.cad_bairro).HasColumnName("cad_corbairro");
            endereco.Property(e => e.cad_ufs_codigo).HasColumnName("cad_corufs_codigo");
            endereco.Property(e => e.cad_cid_codigo).HasColumnName("cad_corcid_codigo");
        });


    }
}
