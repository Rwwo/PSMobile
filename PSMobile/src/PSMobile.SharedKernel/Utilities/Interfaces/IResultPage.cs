namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface IResultPage<TResult>
{
    event EventHandler<TResult> OnResult;
}