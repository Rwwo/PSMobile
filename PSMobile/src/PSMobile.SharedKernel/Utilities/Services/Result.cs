﻿namespace PSMobile.SharedKernel.Utilities.Services;

public class Result<T>
{
    public T Data { get; set; }
    public bool IsSuccess { get; set; }
    public List<string> Errors { get; set; }

    public static Result<T> Success(T data)
    {
        return new Result<T> { IsSuccess = true, Data = data, Errors = new List<string>() };
    }

    public static Result<T> Failure(List<string> errors)
    {
        return new Result<T> { IsSuccess = false, Errors = errors };
    }
}



