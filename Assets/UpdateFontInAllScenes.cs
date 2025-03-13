using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using System.IO;

public class UpdateFontInAllScenes : EditorWindow
{
    private TMP_FontAsset newFont;

    [MenuItem("Tools/Update Font In All Scenes")]
    public static void ShowWindow()
    {
        GetWindow<UpdateFontInAllScenes>("Update Font");
    }

    void OnGUI()
    {
        GUILayout.Label("Update Font In All Scenes", EditorStyles.boldLabel);
        newFont = (TMP_FontAsset)EditorGUILayout.ObjectField("New Font:", newFont, typeof(TMP_FontAsset), false);

        if (GUILayout.Button("Apply Font to All Scenes"))
        {
            ApplyFontToAllScenes();
        }
    }

    static void ApplyFontToAllScenes()
    {
        string[] scenePaths = Directory.GetFiles("Assets", "*.unity", SearchOption.AllDirectories);
        
        foreach (string scenePath in scenePaths)
        {
            EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
            TMP_Text[] textComponents = FindObjectsOfType<TMP_Text>(true);

            foreach (TMP_Text text in textComponents)
            {
                if (text.font != null) // Ensure it's a valid TextMeshPro component
                {
                    text.font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Fonts & Materials/WheelPetFont.asset"); // Adjust path if needed
                }
            }

            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        }

        Debug.Log("All scenes updated with the new font.");
    }
}
