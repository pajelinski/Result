[![NuGet](https://img.shields.io/nuget/v/ResultType.svg)](https://www.nuget.org/packages/ResultType/) [![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md) 

| Build server | Build status |
|--------------|--------------|
| Travis | [![Build Status](https://travis-ci.org/pajelinski/Result.svg?branch=master)](https://travis-ci.org/pajelinski/Result) |     


**Result** is an implementation of Result type for C#.

This library offers an elegant and efficient way of handling errors known as railway programming.
Result object holds the desired value or error message. Thanks to that, Result allows you to deal with errors without resorting to using exceptions.
It's really easy to use and can be used alongside exceptions in order to build a system where known errors are handled using Result type and unknown errors are thrown as exceptions.

## How it works?

The library contains two types that implement Result<T> - Success and Error.

## Getting started

The basic feature of Result is holding value or error.
Let's look at an examples:

```cs
var result = ResultFactory.CreateSuccess(value);
```

Example of an error:

```cs
var result = ResultFactory.CreateError("error message");
```

It's possible to create Success without value:
  
```cs
var result = ResultFactory.CreateSuccess(value);
```
In this case value of type Nothing is stored.
To unpack value you have to call GetValue() method:
  
```cs
var unpackedValue = result.GetValue();
```

Unpacking error is simillar:

```cs
var upackedValue = result.GetError();
```

If you call GetValue() method on Error or GetError on Success, InvalidOperationException will be thrown. 

It is really easy to check if result is success:

```cs
var isSucces = result.IsSuccess();
```
or error:

```cs
var isSucces = result.IsError();
```

You can chain functions that returns Result type using cotinuations:

```cs
public Result<Nothing> SomeFunction(Result<Nothing> result)
{
    return result.Continue(() => ResultFactory.CreateSuccess());
}
```

When you call Continue() method, it checks if the result is Success or Error. If it is Success then provided lambda expresion is executed. In other case error message is propagated.

It's possible to pass value from previous expresion as argument.

```cs
public Result<string> SomeFunction(Result<Nothing> result)
{
    return result.Continue(s => ResultFactory.CreateSuccess(s));
}
```
Tasks thar returns Result can also be chained using Continue method.

```cs
public async Task<Result<string>> SomeFunction(Result<Nothing> result)
{
    return await result.Continue(s => ResultFactory.CreateSuccess(s));
}
```

```cs
public async Task<Result<string>> SomeFunction(Result<Nothing> result)
{
    return await result.Continue(async s => await SomeAsyncFunction(s));
}
```
