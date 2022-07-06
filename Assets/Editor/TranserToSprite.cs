using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TranserToSprite : AssetPostprocessor
{
    void OnPostprocessTexture(Texture texture)
    {
        if (assetPath.StartsWith("Assets/Resources/Texture"))
        {
            TextureImporter importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;
            //读写设置
            importer.isReadable = false;
            //mipmap设置
            importer.mipmapEnabled = false;

            //平台压缩设置
            TextureImporterPlatformSettings platSetting = importer.GetPlatformTextureSettings("Android");
            platSetting.overridden = true;
            platSetting.format = TextureImporterFormat.ASTC_4x4;
            importer.SetPlatformTextureSettings(platSetting);

            platSetting = importer.GetPlatformTextureSettings("IOS");
            platSetting.overridden = true;
            platSetting.format = TextureImporterFormat.ASTC_4x4;
            importer.SetPlatformTextureSettings(platSetting);
        }
    }
}
