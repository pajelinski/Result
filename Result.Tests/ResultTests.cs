﻿using System;
using NUnit.Framework;

namespace Result.Test
{
    [TestFixture]
    public class ResultTests
    {
        class Sucess
        {
            [Test]
            public void GivenVoidFunction_WhenFunctionReturnsEmptySuccess_IsSuccessReturnsTrue()
            {
                Assert.That(ReturnSuccessWithNothing().IsSuccess(), Is.True);
            }

            [Test]
            public void GivenVoidFunction_WhenFunctionReturnsEmptySuccess__GetValueReturnsNothing()
            {
                Assert.That(ReturnSuccessWithNothing().GetValue(), Is.TypeOf<Nothing>());
            }

            [Test]
            public void WhenFunctionReturnsSuccess_IsSuccessReturns_True()
            {
                Assert.That(ReturnSuccessWithString(string.Empty).IsSuccess(), Is.True);
            }

            [Test]
            public void WhenFunctionReturnsSuccess_GetValueReturns_test()
            {
                const string expected = "test";
                var result = ReturnSuccessWithString(expected).GetValue();
                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenFunctionReturnsSuccess_GetErrorThrowsInvalidCastException()
            {
                Assert.That(() => ReturnSuccessWithString(string.Empty).GetError(), Throws.InstanceOf<InvalidCastException>());
            }
        }

        class Error
        {
            [Test]
            public void GivenVoidFunction_WhenFunctionReturnsEmptyError_IsSuccessReturnsFalse()
            {
                Assert.That(ReturnErrorWithNothing(string.Empty).IsSuccess(), Is.False);
            }

            [Test]
            public void WhenFunctionReturnsError_IsSuccessReturnsFalse()
            {
                Assert.That(ReturnErrorWithString(string.Empty).IsSuccess(), Is.False);
            }

            [Test]
            public void WhenFunctionReturnsError_GetErrorReturns_test()
            {
                const string expected = "test";
                var result = ReturnErrorWithString(expected).GetError();
                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenFunctionReturnsError_GetValueThrowsInvalidCastException()
            {
                Assert.That(() => ReturnErrorWithString("").GetValue(), Throws.InstanceOf<InvalidCastException>());
            }
        }

        class ContinueWith
        {
            [Test]
            public void WhenContinautionFunctionReturnsSuccess_IsSuccessReturnsTrue()
            {
                var result = ReturnSuccessWithNothing().ContinueWith(() => ReturnSuccessWithNothing());
                Assert.That(result.IsSuccess(), Is.True);
            }

            [Test]
            public void WhenContinautionFunctionReturnsError_IsSuccessReturnsFalse()
            {
                var result = ReturnSuccessWithNothing().ContinueWith(() => ReturnErrorWithNothing(string.Empty));
                Assert.That(result.IsSuccess(), Is.False);
            }

            [Test]
            public void WhenContinautionFunctionReturnsSuccess_GetValueReturns_test2()
            {
                var result = ReturnSuccessWithString("test1").ContinueWith(() => ReturnSuccessWithString("test2"));
                Assert.That(result.GetValue, Is.EqualTo("test2"));
            }

            [Test]
            public void WhenContinuationFunctionPassPreviousResult_GetValueReturns_test()
            {
                var result = ReturnSuccessWithString("test1").ContinueWith(r => PassValue(r));
                Assert.That(result.GetValue, Is.EqualTo("test1"));
            }

            [Test]
            public void GivenThatFirsResultIsError_WhenContinuationFunctionPassPreviousResult_GetValueReturns_error()
            {
                var result = ReturnErrorWithString("error").ContinueWith(r => PassValue(r));
                Assert.That(result.GetError, Is.EqualTo("error"));
            }
        }

        private static Result<T> PassValue<T>(Result<T> result) => ResultFactory.CreateSuccess(result.GetValue());

        private static Result<Nothing> ReturnSuccessWithNothing() => ResultFactory.CreateSuccess();

        private static Result<Nothing> ReturnErrorWithNothing(string errorMessage) => ResultFactory.CreateError(errorMessage);

        private static Result<string> ReturnSuccessWithString(string value) => ResultFactory.CreateSuccess(value);

        private static Result<string> ReturnErrorWithString(string errorMessage) => ResultFactory.CreateError<string>(errorMessage);
    }
}