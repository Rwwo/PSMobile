﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PSMobile.core.Entities;

[Table("gerais")]
public class Gerais : Entity
{

    // public short ger_zerames_exigirfechamentomes { get; set; }
    // public short ger_produtos_grade_ou_familia { get; set; }
    // public short ger_produtos_mascara { get; set; }
    // public short ger_produtos_balancas { get; set; }
    // public short ger_pesquisar_exibircolunacusto { get; set; }
    // public short ger_pesquisar_exibircolunadesconto { get; set; }
    // public short ger_pdv_logotipoimagem { get; set; }
    // public string? ger_pdv_logotexto { get; set; }
    // public short ger_pdv_imagemfundoindex { get; set; }
    // public string? ger_pdv_msgcf { get; set; }
    // public byte[]? ger_pdv_logoimagem { get; set; }
    // public byte[]? ger_pdv_imagemfundo { get; set; }
    // public string? ger_pdv_msg2via { get; set; }
    // public short ger_pdv_horarioverao { get; set; }
    // public DateTime? ger_pdv_horarioveraodata { get; set; }
    // public short ger_pdv_balancasdigitosprodutos { get; set; }
    // public short ger_pdv_balancasmodopreco { get; set; }
    // public short ger_pdv_balancasdigitosposicao { get; set; }
    // public string? ger_pdv_permissoessupervisor { get; set; }
    // public short ger_pdv_sincronizar { get; set; }
    // public short ger_pdv_maximizado { get; set; }
    // public decimal? ger_ali_pis { get; set; }
    // public decimal? ger_ali_cofins { get; set; }
    // public int? ger_versao { get; set; }
    public short ger_modofilial { get; set; }

    // public string? ger_hostmatriz { get; set; }
    // public DateTime? ger_dataultsin { get; set; }
    public int ger_emp_key { get; set; }

    // public string? ger_pastaxmlsaidas { get; set; }
    // public string? ger_pastaxmlentradaslancadas { get; set; }
    // public short ger_pdv_exigircpf { get; set; }
    // public decimal? ger_pdv_exigircpfvalor { get; set; }
    // public decimal? ger_pdv_valoraviso { get; set; }
    // public short ger_pdv_diacotepe { get; set; }
    // public short ger_pdv_gerarcotepe { get; set; }
    // public short ger_pdv_gerarcotepediario { get; set; }
    // public short ger_mesmosprecosfiliais { get; set; }
    // public decimal? ger_ali_piscumulativo { get; set; }
    // public decimal? ger_ali_cofinscumulativo { get; set; }
    // public decimal? ger_multa { get; set; }
    // public decimal? ger_juros { get; set; }
    // public int? ger_diastolerancia { get; set; }
    // public int? ger_subversao { get; set; }
    // public decimal? ger_curvavalor_a { get; set; }
    // public decimal? ger_curvavalor_b { get; set; }
    // public decimal? ger_curvavalor_c { get; set; }
    // public decimal? ger_curvaqtd_a { get; set; }
    // public decimal? ger_curvaqtd_b { get; set; }
    // public decimal? ger_curvaqtd_c { get; set; }
    // public short ger_exigirvendedor { get; set; }
    // public int? ger_pro_codigo_inicial { get; set; }
    // public int? ger_pro_codigo_final { get; set; }
    // public int? ger_pro_codigo_bloquear { get; set; }

    public short ger_produtos_alfanumericos { get; set; }


    // public short ger_pdv_exibirlimite { get; set; }
    // public short ger_pdv_vendarapida { get; set; }
    // public short ger_pdv_fechamentodetalhado { get; set; }
    // public short ger_pdv_imagemproduto { get; set; }
    // public short ger_conferirestoque { get; set; }
    // public short ger_produtos_sequencial_digitos { get; set; }
    // public int? ger_produtos_sequencial_inicial { get; set; }
    // public string? ger_pdv_mensagemacrescimofinal { get; set; }
    // public short ger_pdv_sugeriracrescimofinal { get; set; }
    // public decimal? ger_pdv_acrescimofinal { get; set; }
    // public short ger_pdv_naoreducaozfechamento { get; set; }
    // public short ger_bloqueardataentrada { get; set; }
    // public short ger_fechamentodiaunificado { get; set; }
    // public short ger_casasdecimaiscustos { get; set; }
    // public short ger_permitiralterarvalorvenda { get; set; }
    // public DateTime? ger_datacaixafechado { get; set; }
    // public string? ger_senhacaixafechado { get; set; }
    // public int? ger_rest_mesas { get; set; }
    // public int? ger_validadecartaopresente { get; set; }
    // public short ger_utilizaracumuladorcartaopresente { get; set; }
    // public string? ger_nomeacumuladorcartaopresente { get; set; }
    // public int? ger_cartaopresente_forpag_codigo { get; set; }
    // public short ger_regimepiscofins { get; set; }
    // public short ger_customediosemcreditoicms { get; set; }
    // public string? ger_pcsincronizacao { get; set; }
    // public decimal? ger_produtos_margemlucro_descontoaproximado { get; set; }
    // public decimal? ger_produtos_margemlucro_comissao { get; set; }
    // public decimal? ger_produtos_margemlucro_impostos { get; set; }
    // public decimal? ger_produtos_margemlucro_outros { get; set; }
    // public string? ger_dctf_pis { get; set; }
    // public string? ger_dctf_cofins { get; set; }
    // public short ger_permitircnpjdiferente { get; set; }
    // public short ger_fracionarporvalor { get; set; }
    // public short ger_pdv_fracionarporvalor { get; set; }
    // public short ger_modonotaservico { get; set; }
    // public short ger_sincronizar { get; set; }
    // public short ger_baixarestoqueordemservico { get; set; }
    // public decimal? ger_aliquotainterna { get; set; }
    // public string? ger_pro_codigoservico { get; set; }
    // public string? ger_pastafotos { get; set; }
    // public int? ger_rest_tempoatraso { get; set; }
    // public int? ger_rest_tempourgencia { get; set; }
    // public short ger_pdv_descontofinal { get; set; }
    // public string? ger_mensagemos { get; set; }
    // public int? ger_con_key_creditoretiradas { get; set; }
    // public string? ger_niveis_creditoretiradas { get; set; }
    // public short ger_sempreacrescimofinal { get; set; }
    // public short ger_pedirobscomandasitens { get; set; }
    // public string? ger_modosistema { get; set; }
    // public decimal? ger_descontomaximo { get; set; }
    // public short ger_permitiralterarvalorvendanfe { get; set; }
    // public short ger_naoexibirdescontos { get; set; }
    // public short ger_devolucaoclientesregistrarestoque { get; set; }
    // public short ger_sinc_contasreceber { get; set; }
    // public short ger_solicitargarcommesa { get; set; }
    // public short ger_exigirsupervisorexclusaocomandas { get; set; }
    // public short ger_exigirjustificativas { get; set; }
    // public short ger_cobrancabancariaintegrada { get; set; }
    // public short ger_valetrocaaposdocumentofiscal { get; set; }
    // public short ger_exigirsupervisorconfiguracoesmesas { get; set; }
    // public short ger_inverterimpressaocomposicao { get; set; }
    // public short ger_modocomandasnumeradas { get; set; }
    // public short ger_questionarimpressaonfce { get; set; }
    // public short ger_contasreceberapenasemcaixa { get; set; }
    // public short ger_verificarcaixaaberto { get; set; }
    // public short ger_mesmaspromocoesfiliais { get; set; }
    // public short ger_liberarcreditoclienteszero { get; set; }
    // public short ger_contasrecebercaixafechado { get; set; }
    // public short ger_aviso_itemdiferentevendaemnfe { get; set; }
    // public short ger_permitirdescontoscomandas { get; set; }
    // public short ger_ordenaritensparacomandacodigo { get; set; }
    // public short ger_solicitartelecomanda { get; set; }
    // public short ger_vinculartributosncms { get; set; }
    // public short ger_destacarprodutosvencendo { get; set; }
    // public int? ger_destacarprodutosvencendo_dias { get; set; }
    // public short ger_controlarlotes { get; set; }
    // public int? ger_viasretiradadeposito { get; set; }
    // public int? ger_viasreciboprestacoes { get; set; }
    // public int? ger_viaspromissoria { get; set; }
    // public int? ger_viascontravale { get; set; }
    // public int? ger_viasprepago { get; set; }
    // public short ger_registrarcheques { get; set; }
    // public short ger_sinc_excluirprodutoss { get; set; }
    // public short ger_ativarprodutos { get; set; }
    // public short ger_exigirjustificativasajusteestoque { get; set; }
    // public short ger_integrarsngpc { get; set; }
    // public short ger_sped_entradaspordataemissao { get; set; }
    // public byte[]? ger_rest_iconelivre { get; set; }
    // public byte[]? ger_rest_iconeocupado { get; set; }
    // public short ger_exigirdadosvale { get; set; }
    // public short ger_finalizarvenda_desconto { get; set; }
    // public short ger_finalizarvenda_acrescimo { get; set; }
    // public int? ger_exibirreferencia { get; set; }
    // public string? ger_pastafuncional { get; set; }
    // public short ger_registrardatacompraajustes { get; set; }
    // public string? ger_pastaportal { get; set; }
    // public short ger_produtos_sequencial_digitosformatacao { get; set; }
    // public string? ger_gia52_codigo { get; set; }
    // public short ger_rest_pschef { get; set; }
    // public short ger_vendasemcaixa { get; set; }
    // public short ger_bloquearmultiploscaixas { get; set; }
    // public short ger_bloquearimpressaocaixaaberto { get; set; }
    // public string? ger_mensagemorcamento { get; set; }
    // public int? ger_comandofixo { get; set; }
    // public int? ger_comandofixo_key { get; set; }
    // public short ger_exibircustoproduto { get; set; }
    // public short ger_freteporconta { get; set; }
    // public short ger_modopdv { get; set; }
    // public short ger_bloquearpreconotaentrada { get; set; }
    // public short ger_bloquearalteracaodescricao { get; set; }
    // public short ger_os2 { get; set; }
    // public string? ger_os2nome { get; set; }
    // public short ger_exigirplanodecontasnotaentrada { get; set; }
    // public string? ger_sistemasincronizacao { get; set; }
    // public short ger_imprimirdescontoitensnfce { get; set; }
    // public short ger_imprimirrecibonfe { get; set; }
    // public string? ger_mensagemossaida { get; set; }
    // public short ger_osmultipla { get; set; }
    // public short ger_limitediascheque { get; set; }
    // public short ger_exibirsomatorioos { get; set; }
    // public short ger_informacoescomplementaresnfse { get; set; }
    public string? ger_msg1 { get; set; }
    public string? ger_msg2 { get; set; }
    public string? ger_msg3 { get; set; }
    public string? ger_msg4 { get; set; }
    public string? ger_msg5 { get; set; }
    public string? ger_msg6 { get; set; }
    // public DateTime? ger_dataultimoreenviosinc { get; set; }
    // public short ger_exigirenter { get; set; }
    // public short ger_exibirsomatoriopedidos { get; set; }
    // public short ger_nfsmultiempresa { get; set; }
    // public short ger_chequecomolimite { get; set; }
    // public short ger_desativarf5caixa { get; set; }
    // public short ger_naocancelarnfe { get; set; }
    // public short ger_lancarretornocaixa { get; set; }
    // public short ger_exibirsomatoriotelaos { get; set; }
    // public short ger_pedirnumerocopias { get; set; }
    // public short ger_lancarretornocaixadiautil { get; set; }
    // public short ger_somatoriocorridocaixa { get; set; }
    // public short ger_exibirdescontomaximo { get; set; }
    // public string? ger_usuariomatriz { get; set; }
    // public string? ger_senhamatriz { get; set; }
    // public int? ger_portamatriz { get; set; }
    // public short ger_fechamentocaixacego { get; set; }
    // public string? ger_bdmatriz { get; set; }
    // public short ger_novosclientesbloqueados { get; set; }
    // public string? ger_rest_pcmobile { get; set; }
    // public short ger_questionarnfceporemail { get; set; }
    // public short ger_desconsiderarcontroledescontoquandoalterarvalor { get; set; }
    // public short ger_ocultarpercentualdescontomaximo { get; set; }
    // public short ger_recibotroca { get; set; }
    // public string? ger_recibotrocamsg { get; set; }
    // public string? ger_msgmobile { get; set; }
    // public short ger_baixarestoqueordemservicoarquivar { get; set; }
    // public short ger_verificarstretidoanteriormente { get; set; }
    // public short ger_ospedirvalorquandozerado { get; set; }
    // public short ger_verificargia52produtos { get; set; }
    // public short ger_impedirexclusaoorcamento { get; set; }
    // public short ger_5411_cst { get; set; }
    // public short ger_5411_010por000 { get; set; }
    // public string? ger_cfopadjudicacao { get; set; }
    // public string? ger_pro_codigocouvert { get; set; }
    // public string? ger_mobile_ip { get; set; }
    // public int? ger_mobile_porta { get; set; }
    // public short ger_exigirclientepedidos { get; set; }
    // public short ger_alertacontasapagar { get; set; }
    // public int? ger_alertacontasapagar_dias { get; set; }
    // public short ger_imprimirosf10 { get; set; }
    // public short ger_osf10justificativa { get; set; }
    // public short ger_perguntarcpffinal { get; set; }
    // public short ger_transferenciainternaprecovenda { get; set; }
    // public short ger_viasosf10 { get; set; }
    // public short ger_baixarretornobancario { get; set; }
    // public short ger_mesmoscustosfiliais { get; set; }
    // public short ger_enviarnfeemail { get; set; }
    // public short ger_enviarnfecopia { get; set; }
    // public string? ger_enviarnfecopiaemail { get; set; }
    // public DateTime? ger_dataliquidez { get; set; }
    // public short ger_impedirexclusaoos { get; set; }
    // public short ger_impedirexclusaoosaposimpressao { get; set; }
    // public short ger_contasreceberdata { get; set; }
    // public short ger_notasentrada_pausarestoque { get; set; }
    // public short ger_exibirestoqueproduto { get; set; }
    // public short ger_bloquearboletonfce { get; set; }
    // public short ger_exibirparcelasclienteos { get; set; }
    // public short ger_exibirparcelasclienteorcamento { get; set; }
    // public short ger_exibirparcelasclientepedido { get; set; }
    // public string? ger_ssl { get; set; }
    // public short ger_portaftp { get; set; }
    // public short ger_exibirpedidosusuariologado { get; set; }
    // public int? ger_rest_temporetirada { get; set; }
    // public int? ger_rest_tempotele { get; set; }
    // public short ger_digitoverificadorprodutos { get; set; }
    // public short ger_caixasomarvaletroca { get; set; }
    // public short ger_viasospssys { get; set; }
    // public short ger_osequipamentos { get; set; }
    // public string? ger_msgemail { get; set; }
    // public string? ger_msgemail_orcamentos { get; set; }
    // public string? ger_msgemail_os { get; set; }
    // public string? ger_msgemail_pedidos { get; set; }
    // public short ger_exibirlocalizacao { get; set; }
    // public short ger_diasvalidadeos { get; set; }
    // public int? ger_staordser_key_padrao { get; set; }
    // public string? ger_msgfinalos { get; set; }
    // public decimal? ger_ali_irrf { get; set; }
    // public decimal? ger_ali_csll { get; set; }
    // public decimal? ger_ali_previdenciasocial { get; set; }
    // public decimal? ger_ali_irrfservicos { get; set; }
    // public decimal? ger_ali_csllservicos { get; set; }
    // public decimal? ger_ali_previdenciasocialservicos { get; set; }
    // public short ger_regimepiscofins_servicos { get; set; }
    // public short ger_preverjuros { get; set; }
    // public short ger_exibirsomentevendaliquidaporvendedor { get; set; }
    // public short ger_reservaestoque { get; set; }
    // public short ger_pontos { get; set; }
    // public DateTime? ger_datapon { get; set; }
    // public decimal? ger_pontosindice { get; set; }
    // public int? ger_pontosdias { get; set; }
    // public short ger_imprimircolunafretenfe { get; set; }
    // public short ger_exigirplanodecontas { get; set; }
    // public short ger_alertaestoqueminimo { get; set; }
    // public decimal? ger_descontocrediarioemdia { get; set; }
    // public short ger_exigirvendedororcamento { get; set; }
    // public short ger_invertercolunasfantasiarazao { get; set; }
    // public decimal? ger_descontoemdia { get; set; }
    // public short ger_hospedagem { get; set; }
    // public DateTime? ger_datatimerxml { get; set; }
    // public string? ger_computtimerxml { get; set; }
    // public DateTime? ger_datatimerinserirdados { get; set; }
    // public string? ger_computtimerinserirdados { get; set; }
    // public short ger_exigircadastrocompletocliente { get; set; }
    // public DateTime? ger_datainiajustest { get; set; }
    // public short ger_colunaservicosorcamentos { get; set; }
    // public short ger_exibirvaloratacado { get; set; }
    // public short ger_pdv_cupomsorteio { get; set; }
    // public decimal? ger_pdv_cupomsorteiovalor { get; set; }
    // public string? ger_pdv_cupomsorteiotexto { get; set; }
    // public short ger_a2fvendaprodutos { get; set; }
    // public short ger_mobile_exibircusto { get; set; }
    // public short ger_baixarestoquelotesproducao { get; set; }
    // public short ger_pdv_semoperador { get; set; }
    // public string? ger_rest_pccaixa { get; set; }
    // public string? ger_rest_pccopa { get; set; }
    // public int? ger_fonteorcamentos { get; set; }
    // public int? ger_fonteos { get; set; }
    // public int? ger_fontepedidos { get; set; }
    // public short ger_pontosclientesparticipantes { get; set; }
    // public string? ger_niveis_vendas { get; set; }
    // public string? ger_niveis_devolucoes { get; set; }
    // public string? ger_niveis_os { get; set; }
    // public decimal? ger_jurosrsdia { get; set; }
    // public short ger_excluiricmsbasepiscofins { get; set; }
    // public short ger_exigircadastroreferenciaendereco { get; set; }
    // public short ger_impressaorelacaoosassinatura { get; set; }
    // public string? ger_impressaorelacaoosdescricaocolunavalor { get; set; }
    // public decimal? ger_ali_irrfglp { get; set; }
    // public decimal? ger_ali_csllglp { get; set; }
    // public decimal? ger_ali_previdenciasocialglp { get; set; }
    // public short ger_fechamentocaixaresumovendas { get; set; }
    // public short ger_modulolocacoesimpressoras { get; set; }
    // public short ger_controlarestoqueuso { get; set; }
    // public short ger_criarprodutodeos { get; set; }
    // public short ger_usarcustomediorecalculotabela { get; set; }
    // public short ger_osmodocusto { get; set; }
    // public short ger_imprimirfaturamentopedidos { get; set; }
    // public short ger_resumoprodutosfechamentocaixa { get; set; }
    // public short ger_osdigitada { get; set; }
    // public short ger_dataoriginalrecebimentoparcial { get; set; }
    // public short ger_fechamentocego_transferir { get; set; }
    // public int? ger_fechamentocego_con_key { get; set; }
    // public string? ger_fechamentocego_nivel { get; set; }
    // public short ger_fechamentocego_colunaoperador { get; set; }
    // public short ger_produtosexigirfornecedor { get; set; }
    // public short ger_nuncalancarestoquenfe { get; set; }
    // public short ger_modorepasse { get; set; }
    // public decimal? ger_custorepasse { get; set; }
    // public short ger_exigircredenciadora { get; set; }
    // public short ger_pedidosdatafinalizacao { get; set; }
    // public short ger_sincfornecedorprodutos { get; set; }
    // public short ger_orcamentos_ocultarvaloresitens { get; set; }
    // public short ger_exibirfornecedor { get; set; }
    // public short ger_relvendaspssysvendas { get; set; }
    // public short ger_forcarcaixaloja { get; set; }
    // public short ger_fecharcaixadataabertura { get; set; }
    // public short ger_exibirestoqueconsignadoproduto { get; set; }
    // public short ger_migrouoculos { get; set; }
    // public short ger_produtosconcatenardescricao { get; set; }
    // public short ger_alertacontasareceber { get; set; }
    // public int? ger_alertacontasareceber_dias { get; set; }
    // public short ger_destinopedidosconsignados { get; set; }
    // public decimal? ger_percentualminimodevolucaoconsignados { get; set; }
    // public short ger_tabelapedidosconsignados { get; set; }
    // public short ger_relestoquedata_exibirestoquesemicms { get; set; }
    // public short ger_adicionarcomplemento { get; set; }
    // public string? ger_niveis_vendasaprazo { get; set; }
    // public int? ger_rest_tamanhosenha { get; set; }
    // public short ger_parcelasemnfse { get; set; }
    // public short ger_estoquesentrefiliais { get; set; }
    // public int? ger_bloqueiodias { get; set; }
    // public short ger_impressaocompactaantiga { get; set; }
    // public short ger_sinc_qtdmin { get; set; }
    // public short ger_replicarprodutoautomaticamente { get; set; }
    // public short ger_exigircadastrotelefone { get; set; }
    // public short ger_estoqueminimomaisum { get; set; }
    // public short ger_recebimentolancarsomenteemdinheiro { get; set; }
    // public short ger_maiusculas { get; set; }
    // public short ger_pesquisarprodutosemdigito { get; set; }
    // public short ger_pesquisamargemlucro { get; set; }
    // public short ger_pssysvendassomentenfe { get; set; }
    // public short ger_permitirfaturarsomenteservicos { get; set; }
    // public short ger_vendarapidanaoadicionar { get; set; }
    // public short ger_cliforambos { get; set; }
    // public short ger_exigircategoria { get; set; }
    // public short ger_exibirdataalteracaovalores { get; set; }
    // public int? ger_compensacao_forpag_codigo { get; set; }

    public Empresas Empresa { get; set; }

}
