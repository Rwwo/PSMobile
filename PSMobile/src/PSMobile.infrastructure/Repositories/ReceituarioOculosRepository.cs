using Microsoft.EntityFrameworkCore;

using PSMobile.core.Entities;
using PSMobile.core.InputModel;
using PSMobile.core.Interfaces;
using PSMobile.core.ReturnFunctions;
using PSMobile.infrastructure.Context;

namespace PSMobile.infrastructure.Repositories;

public class ReceituarioOculosRepository : ReadRepository<ReceituarioOculos>, IReceituarioOculosRepository
{
    private readonly AppDbContext _context;
    public ReceituarioOculosRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<ReceituarioOculosGravarRetornoFuncao> GravarAsync(ReceituarioOculosInputModel model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model));
        try
        {
            var builder = new ReceituarioOculosBuilder();

            builder.ComId(
                model.recocu_key
                );

            builder.ComDadosCabecalho((DateTime)model.recocu_data_abert,
                                      (DateTime)model.recocu_data_prev,
                                      (DateTime)model.recocu_data_renov,
                                      model.recocu_data_fech,
                                      model.recocu_emp_key,
                                      model.recocu_fun_key,
                                      model.recocu_mov_num,
                                      model.recocu_clioti_key,
                                      model.recocu_cad_key,
                                      model.recocu_pre_key
                                      );

            builder.ComDadosLente(model.recocu_lente,
                                  model.recocu_cor,
                                  model.recocu_cr39,
                                  model.recocu_poli,
                                  model.recocu_trivex,
                                  model.recocu_cristal,
                                  model.recocu_valorlente);

            builder.ComDadosArmacao(model.recocu_vta,
                                    model.recocu_vtanodia,
                                    model.recocu_vta_data,
                                    model.recocu_armacao,
                                    model.recocu_referencia,
                                    model.recocu_pro_codigo,
                                    model.recocu_tipmat_key,
                                    model.recocu_valorarmacao,
                                    model.recocu_vta_entregue);

            builder.ComDadosDiopmetria(
                model.recocu_lonodesf,
                model.recocu_lonodcil,
                model.recocu_lonodeixo,
                model.recocu_lonoddnp,
                model.recocu_lonoeesf,
                model.recocu_lonoecil,
                model.recocu_lonoeeixo,
                model.recocu_lonoednp,
                model.recocu_perodesf,
                model.recocu_perodcil,
                model.recocu_perodeixo,
                model.recocu_peroddnp,
                model.recocu_peroeesf,
                model.recocu_peroecil,
                model.recocu_peroeeixo,
                model.recocu_peroednp,
                model.recocu_altura,
                model.recocu_vertical,
                model.recocu_diagonal,
                model.recocu_adicao,
                model.recocu_ponte,
                model.recocu_horizontal,
                model.recocu_observacao
                );

            var receituario = builder.Build();

            if (receituario.recocu_key == 0)
            {
                _context.ReceituarioOculos.Add(receituario);
            }
            else
            {
                _context.ReceituarioOculos.Update(receituario);
            }
            
            await _context.SaveChangesAsync();

            return new ReceituarioOculosGravarRetornoFuncao(receituario.recocu_key);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Erro ao gravar: {ex.Message}", ex);
        }
    }

}