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
            GUILayout.Label("���̵� ����", EditorStyles.boldLabel);
            GUILayout.Label($"���̵� : {GameManager.Instance.Difficulty}", EditorStyles.boldLabel);


            if (GUILayout.Button("���̵� ����", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
            {
                GameManager.Instance.AddDifficulty();
            }
            GUILayout.Space(10.0f);
            if (GUILayout.Button("���̵� ����", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
            {
                GameManager.Instance.SubDifficulty();
            }

            difficulty = EditorGUILayout.TextField("���̵�", difficulty);
            if (GUILayout.Button("���̵� å��", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
            {
                GameManager.Instance.SetDifficulty(int.Parse(difficulty));
            }
            if (GUILayout.Button("�մ� �ѱ��", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
            {
                GuestManager.Instance.Complete();
            }
        }
        else
        {
            GUILayout.Label("���̵� ������ �÷��� ���߿��� ��밡��", EditorStyles.boldLabel);
        }

        if (Application.isPlaying)
        {
            GUILayout.Label("�ð� ����", EditorStyles.boldLabel);
            GUILayout.Label($"�ð� : {DayManager.Instance.CurTime}", EditorStyles.boldLabel);


            if (GUILayout.Button("Day ����", GUILayout.Width(100.0f), GUILayout.Height(30.0f)))
            {
                DayManager.Instance.AddDay();
                Debug.Log(DayManager.Instance.CurTime);
            }
        }
        else
        {
            GUILayout.Label("��¥ ������ �÷��� ���߿��� ��밡��", EditorStyles.boldLabel);
        }
    }
}
