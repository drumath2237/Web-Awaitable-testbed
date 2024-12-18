using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AOT;
using JetBrains.Annotations;
using UnityEngine;

public static class AsyncFunctions
{
    public static async Awaitable<string> GetStringAwaitableAsync(string str, CancellationToken token)
    {
        await Awaitable.WaitForSecondsAsync(5f, token);
        return str;
    }

    public static async Task<string> GetStringTaskAsync(string str, CancellationToken token)
    {
        await Task.Delay(5000, token);
        return str;
    }

    [DllImport("__Internal")]
    private static extern void getStringJSAsync(Action callback);

    [MonoPInvokeCallback(typeof(Action))]
    private static void OnCallback_GetStringJS()
    {
        _awaitableSource?.TrySetResult();
    }

    [CanBeNull]
    private static AwaitableCompletionSource _awaitableSource;

    // ReSharper disable once InconsistentNaming
    public static async Awaitable<string> GetStringAwaitableJSAsync(string str, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        _awaitableSource?.TrySetCanceled();

        _awaitableSource = new AwaitableCompletionSource();
        getStringJSAsync(OnCallback_GetStringJS);
        await _awaitableSource.Awaitable;
        _awaitableSource = null;

        return str;
    }
}