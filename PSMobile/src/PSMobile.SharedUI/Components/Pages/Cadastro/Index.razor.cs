﻿using Microsoft.AspNetCore.Components;

using MudBlazor;

using PSMobile.core.Entities;
using PSMobile.SharedKernel.Common;
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedUI.Components.Pages.Cadastro;
public class IndexCadastroPage : MyBaseComponent
{
    [Inject] private ICadastroService CadService { get; set; } = null!;
    public string searchString = "";
    public List<Cadastros>? Cadastros { get; set; } = null;
    protected async override Task OnInitializedAsync()
    {
        IsLoading = true;
        await LoadDataAsync();
        IsLoading = false;
    }
    private async Task LoadDataAsync()
    {
        try
        {
            Cadastros = await CadService.GetAllAsync();
        }
        catch (Exception ex)
        {
            Snackbar.Add("Erro ao buscar os dados!", Severity.Warning, conf =>
            {
                conf.Action = "Detalhes";
                conf.ActionColor = Color.Info;
                conf.Onclick = snack =>
                {
                    Help(ex.Message);
                    return Task.CompletedTask;
                };
            });

        }
    }
    public void Help(string msg)
    {
        Snackbar.Add(msg, Severity.Warning);
    }
    public async Task DeleteAsync(Cadastros input)
    {
        try
        {
            var result = await DialogService.ShowMessageBox
            (
                "Atenção",
                $"Deseja excluir a Tag: {input.cad_nome}?",
                yesText: "SIM",
                cancelText: "NÃO"
            );

            if (result is true)
            {
                //await _uow.ITagsRepository.DeleteByIdAsync(input.Id);
                Snackbar.Add("Cadastro excluído com sucesso!", Severity.Success);

                await LoadDataAsync();
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    public void GoToUpdate(Cadastros input)
    {
        ServiceLocal.SetarCliente(input);
        Snackbar.Add(input.cad_nome, Severity.Success);
        //Navigation.NavigateTo($"/tags/editar");
    }

    public bool Search(Cadastros Cliente)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;

        if (Cliente.cad_nome is null)
            return false;

        if (Cliente.cad_nome.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }
}


