using System;
using System.Threading;
using TMPro;
using UnityEngine;

public class MainBehaviour : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI logText;

    private async void Start()
    {
        try
        {
            logText.text = await GetStringAsync(5);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    private static async Awaitable<string> GetStringAsync(int delay, CancellationToken token = default)
    {
        token.ThrowIfCancellationRequested();

        await Awaitable.WaitForSecondsAsync(delay, token);
        return "Hello!";
    }
}