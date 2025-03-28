using UnityEngine;
using UnityEditor;

public class TextureImportSettings : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        TextureImporter importer = (TextureImporter)assetImporter;
        importer.textureCompression = TextureImporterCompression.Uncompressed;
    }
}
