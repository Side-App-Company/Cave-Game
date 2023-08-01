 
using UnityEngine;
using UnityEditor;
using System.IO;

#if UNITY_EDITOR
    public class ExportSlicedTexture : EditorWindow
    {
        private Texture2D texture;
    
        [MenuItem("Window/Export Sliced Texture")]
        public static void ShowWindow()
        {
            GetWindow<ExportSlicedTexture>("Export Sliced Texture");
        }
    
        private void OnGUI()
        {
            texture = (Texture2D)EditorGUILayout.ObjectField(texture, typeof(Texture2D), allowSceneObjects: false);
            if (GUILayout.Button("Generate Sliced Image") && texture != null)
            {
                SaveTextureAsPNG(texture);
            }
        }
    
        public static void SaveTextureAsPNG(Texture2D texture)
        {
            byte[] _bytes = texture.EncodeToPNG();
    
            var assetPath = AssetDatabase.GetAssetPath(texture);
            var assetFileInfo = new FileInfo(assetPath);
            var assetDirectory = assetFileInfo.Directory.FullName;
            var fileName = assetFileInfo.Name;
    
            var filePath = Path.Combine(assetDirectory, fileName + "_sliced.png");
    
            File.WriteAllBytes(filePath, _bytes);
            Debug.Log(_bytes.Length / 1024 + "Kb was saved as: " + filePath);
        }
    }
 #endif