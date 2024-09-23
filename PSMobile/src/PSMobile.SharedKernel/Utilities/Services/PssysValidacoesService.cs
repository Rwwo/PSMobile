using System.ComponentModel;
using System.Text.RegularExpressions;

using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class PssysValidacoesService : IPssysValidacoesService
{
    public string PSFormatarFone(string Texto)
    {
        if (Texto == "")
            return "";
        else
        {
            string St = "";
            int I;
            for (I = 0; I <= Texto.Length - 1; I++)
            {
                if (char.IsDigit(Texto, I))
                    St += Texto.Substring(I, 1);
            }
            if (St.Length == 10)
                return "(" + St.Substring(0, 2) + ")" + St.Substring(2, 4) + "-" + St.Substring(6, 4);
            else if (St.Length == 11)
                return "(" + St.Substring(0, 2) + ")" + St.Substring(2, 5) + "-" + St.Substring(7, 4);
            else if (St.Length == 8)
                return St.Substring(0, 4) + "-" + St.Substring(4, 4);
            else if (St.Length == 9)
                return St.Substring(0, 5) + "-" + St.Substring(5, 4);
            else
                return Texto;
        }
    }

    public string PSFormatarCNPJ(string _CPFouCNPJ)
    {
        TipoCPFouCNPJ tipoCPFouCNPJ = 0;

        string CPFouCNPJ = _CPFouCNPJ.Replace(".", "").Replace("-", "").Replace("/", "");
        if (tipoCPFouCNPJ == TipoCPFouCNPJ.CNPJ)
        {
            if (IsCnpj(CPFouCNPJ))
            {
                return CPFouCNPJ.Substring(0, 2) + "." + CPFouCNPJ.Substring(2, 3) + "." + CPFouCNPJ.Substring(5, 3) + "/" + CPFouCNPJ.Substring(8, 4) + "-" + CPFouCNPJ.Substring(12, 2);
            }
            else
            {
                return "";
            }
        }
        else if (tipoCPFouCNPJ == TipoCPFouCNPJ.CPF)
        {
            if (IsCpf(CPFouCNPJ))
            {
                return CPFouCNPJ.Substring(0, 3) + "." + CPFouCNPJ.Substring(3, 3) + "." + CPFouCNPJ.Substring(6, 3) + "-" + CPFouCNPJ.Substring(9, 2);
            }
            else
            {
                return "";
            }
        }
        else
        {
            if (IsCnpj(CPFouCNPJ))
            {
                return CPFouCNPJ.Substring(0, 2) + "." + CPFouCNPJ.Substring(2, 3) + "." + CPFouCNPJ.Substring(5, 3) + "/" + CPFouCNPJ.Substring(8, 4) + "-" + CPFouCNPJ.Substring(12, 2);
            }
            else if (IsCpf(CPFouCNPJ))
            {
                return CPFouCNPJ.Substring(0, 3) + "." + CPFouCNPJ.Substring(3, 3) + "." + CPFouCNPJ.Substring(6, 3) + "-" + CPFouCNPJ.Substring(9, 2);
            }
            else
            {
                return "";
            }
        }
    }


    public enum TipoCPFouCNPJ
    {
        [Description("0 - Ambos")]
        Ambos = 0,
        [Description("1 - CPF")]
        CPF = 1,
        [Description("2 - CNPJ")]
        CNPJ = 2
    }

    public bool IsCpf(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;

        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");

        try
        {
            Regex regexObj = new Regex(@"[^\d]");
            cpf = regexObj.Replace(cpf, "");
        }
        catch
        {
            return false;
        }

        if (cpf.Length != 11)
            return false;

        tempCpf = cpf.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();

        tempCpf = tempCpf + digito;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cpf.EndsWith(digito);
    }

    public bool IsCnpj(string cnpj)
    {
        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma;
        int resto;
        string digito;
        string tempCnpj;

        cnpj = cnpj.Trim();
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

        try
        {
            Regex regexObj = new Regex(@"[^\d]");
            cnpj = regexObj.Replace(cnpj, "");
        }
        catch
        {
            return false;
        }

        if (cnpj.Length != 14)
            return false;

        tempCnpj = cnpj.Substring(0, 12);

        soma = 0;
        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();

        tempCnpj = tempCnpj + digito;
        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cnpj.EndsWith(digito);
    }
}


