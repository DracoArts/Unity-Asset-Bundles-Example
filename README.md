
# Welcome to DracoArts
![Logo](https://dracoarts-logo.s3.eu-north-1.amazonaws.com/DracoArts.png)



# Unity Asset Bundles  Example

#  Asset Bundles in Unity:

Asset Bundles are a fundamental feature in Unity that empower developers to efficiently manage and distribute content separately from the main application build. They offer a range of benefits and functionalities that enhance the development process and improve the overall user experience. Here are the key aspects of Asset Bundles in Unity:

## Content-Code Separation:
 Asset Bundles allow developers to decouple content, such as 3D models, textures, audio files, and more, from the main codebase of their projects. This separation streamlines development workflows, making it easier to update, modify, or replace specific assets without impacting the entire application.
Reduced Initial Download Size: By utilizing Asset Bundles, developers can significantly reduce the initial download size of their applications. Only essential assets required for the core functionality of the game or app are included in the main build, while additional assets can be loaded dynamically at runtime as needed.
## Dynamic Asset Loading:
 One of the key features of Asset Bundles is the ability to load assets dynamically during runtime. This dynamic loading mechanism allows developers to manage memory efficiently by loading assets on-demand and unloading them when they are no longer needed, optimizing performance and resource usage.
## Downloadable Content (DLC) Support: 
Asset Bundles are commonly employed to support downloadable content (DLC) in games. Developers can create additional Asset Bundles containing new levels, characters, items, or other content that players can download separately after the initial installation. This enables developers to extend the lifespan of their games and provide ongoing updates and expansions.
## Efficient Content Updates: 
Asset Bundles facilitate efficient content updates without requiring a full application update through the app store or marketplace. Developers can push out updates to specific assets or content bundles independently, allowing for quicker iteration cycles, bug fixes, and new content releases.
By leveraging Asset Bundles in Unity, developers can create more flexible, scalable, and optimized applications that adapt to changing requirements and user needs. This feature is particularly valuable for game developers looking to deliver engaging experiences with rich and varied content while maintaining performance and minimizing download sizes.
# Key Features
## 1. Dynamic Loading
Asset Bundles enable loading assets during runtime rather than having everything in the initial build.

## 2. Platform-Specific Packaging
Unity automatically creates platform-appropriate bundles for each target (iOS, Android, Windows, etc.).

## 3. Dependency Management
The system tracks dependencies between assets to ensure everything needed is loaded.

## 4. Compression Options
Bundles support three compression types:

- No compression (fastest loading)

- LZMA (smallest size)

- LZ4 (balanced option)

## 5. Versioning Support
Allows for incremental updates to content.

## Common Use Cases
 - Mobile Games: Reduce initial app size by separating core assets from optional content

- Live Games: Push new content updates without app store submissions

- DLC/Expansions: Sell additional content after initial release

- Region-Specific Content: Load appropriate assets based on user location

- Memory Management: Load/unload assets as needed

# How They Work
- Creation: Assets are marked for bundling and built using Unity's build pipeline

- Distribution: Bundles are hosted on servers or included in app resources

- Loading: At runtime, your game downloads and loads bundles as needed

- Caching: Downloaded bundles are cached for future use
## Usage/Examples
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
## Images


- ## Part 1 
  ![](https://github.com/AzharKhemta/DemoClient/blob/main/assets%20bundle%20-.gif?raw=true)


- ## Parts 2
![](https://github.com/AzharKhemta/DemoClient/blob/main/assets%20bundle%20-2%20(1).gif?raw=true)


- ## Part 3 
![](https://github.com/AzharKhemta/DemoClient/blob/main/assets%20bundle%20-3.gif?raw=true
)
- ## Part 4
![](https://raw.githubusercontent.com/AzharKhemta/DemoClient/refs/heads/main/Asset%20bundle%20-1.gif)

## Authors

- [@MirHamzaHasan](https://github.com/MirHamzaHasan)
- [@WebSite](https://mirhamzahasan.com)


## 🔗 Links

[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/company/mir-hamza-hasan/posts/?feedView=all/)
## Tech Stack
**Client:** Unity,C#

**Package:** Asset Bundles




## Documentation

[Documentation](https://docs.unity3d.com/Manual/AssetBundlesIntro.html)

