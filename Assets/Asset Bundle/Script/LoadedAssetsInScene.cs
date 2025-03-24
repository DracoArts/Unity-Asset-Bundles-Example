using System.Collections;

using UnityEngine;

public class LoadEnvoirnment : MonoBehaviour
{

    public string[] assetName;
    private string SplitsAssetName;
    private void Start()
    {
        string path = Application.persistentDataPath + "/" + "newbundle";
        Debug.Log(path);    
        string[] splits = path.Split('/');
        SplitsAssetName = splits[splits.Length - 1];
        Debug.Log(SplitsAssetName);
        StartCoroutine(LoadAndInstantiateAsset(path));
    }

    IEnumerator LoadAndInstantiateAsset(string localFilePath)
    {
        Debug.Log(localFilePath);
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(localFilePath);
        if (localAssetBundle != null)
        {
            foreach (var AssetName in assetName)
            {
                if (AssetName == SplitsAssetName)
                {
                    Debug.Log(" ******************  111111111 ");
            
                  
                        Debug.Log(" ************:   " +SplitsAssetName    );
                        Instantiate(localAssetBundle.LoadAsset(SplitsAssetName));
                        // Unload the local AssetBundle
                        localAssetBundle.Unload(false);
                    
                    
                }
            }
        }
        else
        {
            Debug.LogError("Failed to load AssetBundle: " + localFilePath);
        }

        yield return null;
    }
}
