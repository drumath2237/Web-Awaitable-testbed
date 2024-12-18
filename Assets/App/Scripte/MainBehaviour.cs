using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MainBehaviour : MonoBehaviour
{
    [SerializeField]
    private LogText logText;

    [SerializeField]
    private Button buttonAwaitable;

    [SerializeField]
    private Button buttonTask;

    [SerializeField]
    private Button buttonJsAwaitable;

    private CancellationTokenSource _tokenSource;

    private void Start()
    {
        _tokenSource = new CancellationTokenSource();

        buttonAwaitable.onClick.AddListener(OnClick_Awaitable);
        buttonTask.onClick.AddListener(OnClick_Task);
        buttonJsAwaitable.onClick.AddListener(OnClick_JS);
    }

    private void OnDestroy()
    {
        _tokenSource?.Dispose();
        _tokenSource = null;

        buttonAwaitable.onClick.RemoveListener(OnClick_Awaitable);
        buttonTask.onClick.RemoveListener(OnClick_Task);
        buttonJsAwaitable.onClick.RemoveListener(OnClick_JS);
    }

    private async void OnClick_Awaitable()
    {
        logText.Log("Click");
        var str = await AsyncFunctions.GetStringAwaitableAsync("Awaitable!", _tokenSource.Token);
        logText.Log(str);
    }

    private async void OnClick_Task()
    {
        logText.Log("Click");
        var str = await AsyncFunctions.GetStringTaskAsync("Task!", _tokenSource.Token);
        logText.Log(str);
    }

    private async void OnClick_JS()
    {
        logText.Log("Click");
        var str = await AsyncFunctions.GetStringAwaitableJSAsync("JS Awaitable!", _tokenSource.Token);
        logText.Log(str);
    }
}