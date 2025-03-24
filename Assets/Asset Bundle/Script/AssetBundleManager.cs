using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class AssetBundleManager : MonoBehaviour
{
  
    public Slider slider;

    public string baseUrl = "http://localhost/assetbundles/newbundle";

    private void Start()
    {
        
    
    }
    public async void StartDownload()
    {
        await DownloadAssetBundle();
    }

    private async Task DownloadAssetBundle()
    {
        string assetBundleUrl = baseUrl;
        string assetBundleLocalPath = Application.persistentDataPath+ "/newbundle";;
        Debug.Log(assetBundleLocalPath);

        if (File.Exists(assetBundleLocalPath))
        {
            LoadNextScene();
        }
        else
        {
            UnityWebRequest web = UnityWebRequest.Get(assetBundleUrl);
            var operation = web.SendWebRequest();

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 2f);
                slider.value = progress;
        
                await Task.Yield();
            }

            if (web.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to download AssetBundle: " + web.error);
                return;
            }

            await WriteBytesAsync(assetBundleLocalPath, web.downloadHandler.data);

            LoadNextScene();
        }
    }

    private async Task WriteBytesAsync(string path, byte[] bytes)
    {
        using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
        await fileStream.WriteAsync(bytes, 0, bytes.Length);
    }

    void LoadNextScene()
    {
        SceneManager.LoadSceneAsync("GamePlay");
    }
}
