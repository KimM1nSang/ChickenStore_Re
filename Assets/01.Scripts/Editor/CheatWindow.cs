using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class CheatWindow : EditorWindow
{
    [MenuItem("Window/Cheat Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CheatWindow));
    }

    private string difficulty;

    private void OnGUI()
    {
        GUILayout.Label("난이도 조절", EditorStyles.boldLabel);
        GUILayout.Label($"난이도 : {GameManager.Instance.Difficulty}", EditorStyles.boldLabel);


        if (GUILayout.Button("난이도 증가", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
        {
            if (Application.isPlaying)
            {
                GameManager.Instance.AddDifficulty();
            }
        }
        GUILayout.Space(10.0f);
        if (GUILayout.Button("난이도 감소", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
        {
            if (Application.isPlaying)
            {
                GameManager.Instance.SubDifficulty();
            }
        }

        difficulty = EditorGUILayout.TextField("난이도", difficulty);
        if (GUILayout.Button("난이도 책정", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
        {
            if (Application.isPlaying)
            {
                GameManager.Instance.SetDifficulty(int.Parse(difficulty));
            }
        }
    }
}
