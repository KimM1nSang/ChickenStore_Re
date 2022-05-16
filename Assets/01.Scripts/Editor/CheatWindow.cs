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
    private string day;

    private void OnGUI()
    {
        if (Application.isPlaying)
        {
            GUILayout.Label("난이도 조절", EditorStyles.boldLabel);
            GUILayout.Label($"난이도 : {GameManager.Instance.Difficulty}", EditorStyles.boldLabel);


            if (GUILayout.Button("난이도 증가", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
            {
                GameManager.Instance.AddDifficulty();
            }
            GUILayout.Space(10.0f);
            if (GUILayout.Button("난이도 감소", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
            {
                GameManager.Instance.SubDifficulty();
            }

            difficulty = EditorGUILayout.TextField("난이도", difficulty);
            if (GUILayout.Button("난이도 책정", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
            {
                GameManager.Instance.SetDifficulty(int.Parse(difficulty));
            }
            if (GUILayout.Button("손님 넘기기", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
            {
                GuestManager.Instance.Complete();
            }
        }
        else
        {
            GUILayout.Label("난이도 조절은 플레이 도중에만 사용가능", EditorStyles.boldLabel);
        }

        if (Application.isPlaying)
        {
            GUILayout.Label("시간 조절", EditorStyles.boldLabel);
            GUILayout.Label($"시간 : {DayManager.Instance.CurTime}", EditorStyles.boldLabel);


            if (GUILayout.Button("Day 증가", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
            {
                DayManager.Instance.AddDay();
                Debug.Log(DayManager.Instance.CurTime);
            }
        }
        else
        {
            GUILayout.Label("날짜 조절은 플레이 도중에만 사용가능", EditorStyles.boldLabel);
        }
    }
}
