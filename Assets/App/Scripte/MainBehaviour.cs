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

    [SerializeField]
    private Button buttonClear;


    private void Start()
    {
        buttonAwaitable.onClick.AddListener(OnClick_Awaitable);
        buttonTask.onClick.AddListener(OnClick_Task);
        buttonJsAwaitable.onClick.AddListener(OnClick_JS);
        buttonClear.onClick.AddListener(OnClick_Clear);
    }

    private void OnDestroy()
    {
        buttonAwaitable.onClick.RemoveListener(OnClick_Awaitable);
        buttonTask.onClick.RemoveListener(OnClick_Task);
        buttonJsAwaitable.onClick.RemoveListener(OnClick_JS);
        buttonClear.onClick.RemoveListener(OnClick_Clear);
    }

    private async void OnClick_Awaitable()
    {
        logText.Log("Click");
        var str = await AsyncFunctions.GetStringAwaitableAsync("Awaitable!", destroyCancellationToken);
        logText.Log(str);
    }

    private async void OnClick_Task()
    {
        logText.Log("Click");
        var str = await AsyncFunctions.GetStringTaskAsync("Task!", destroyCancellationToken);
        logText.Log(str);
    }

    private async void OnClick_JS()
    {
        logText.Log("Click");
        var str = await AsyncFunctions.GetStringAwaitableJSAsync("JS Awaitable!", destroyCancellationToken);
        logText.Log(str);
    }

    private void OnClick_Clear()
    {
        logText.ClearLog();
    }
}