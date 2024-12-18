# Web-Awaitable-testbed

[![Deploy](https://github.com/drumath2237/Web-Awaitable-testbed/actions/workflows/deploy.yaml/badge.svg)](https://github.com/drumath2237/Web-Awaitable-testbed/actions/workflows/deploy.yaml)

## Environment

- Windows 10 Home
- Unity 6000.0.31f1
- Chrome for Windows 131.0.6778.140

## Code Example

Awaitable!

```cs
public static class AsyncFunctions
{
    public static async Awaitable<string> GetStringAwaitableAsync(string str, CancellationToken token)
    {
        await Awaitable.WaitForSecondsAsync(3f, token);
        return str;
    }
}

// ...

var str = await AsyncFunctions.GetStringAwaitableAsync("Awaitable!", destroyCancellationToken);
```
