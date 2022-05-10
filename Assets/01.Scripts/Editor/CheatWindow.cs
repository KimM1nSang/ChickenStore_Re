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
        GUILayout.Label("���̵� ����", EditorStyles.boldLabel);
        GUILayout.Label($"���̵� : {GameManager.Instance.Difficulty}", EditorStyles.boldLabel);


        if (GUILayout.Button("���̵� ����", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
        {
            if (Application.isPlaying)
            {
                GameManager.Instance.AddDifficulty();
            }
        }
        GUILayout.Space(10.0f);
        if (GUILayout.Button("���̵� ����", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
        {
            if (Application.isPlaying)
            {
                GameManager.Instance.SubDifficulty();
            }
        }

        difficulty = EditorGUILayout.TextField("���̵�", difficulty);
        if (GUILayout.Button("���̵� å��", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
        {
            if (Application.isPlaying)
            {
                GameManager.Instance.SetDifficulty(int.Parse(difficulty));
            }
        }
    }
}
