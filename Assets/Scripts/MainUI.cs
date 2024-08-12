using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public void GameQuit() // ������ �����ϴ� �Լ�
    {
        Application.Quit(); // ������ ���� �ؾ����� ������ �˴ϴ�.
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // �����Ϳ��� ���� ��Ʋ�� ��Ȱ�� ��Ű����.
#endif
    }

    public void GameRetry() // ������ �絵���ϴ� �Լ�
    {
        SceneManager.LoadScene(1); // 1���� ��ϵ� Scene�� �ҷ��Ͷ�.
    }

    public void ReturnMainLobby() // �κ�� ���ư��� �Լ�
    {
        SceneManager.LoadScene(0);
    }
}
