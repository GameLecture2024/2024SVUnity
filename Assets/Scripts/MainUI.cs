using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    [Header("Manager")]
    public static MainUI Instance; // ���� �ڵ� ����
    public GameObject gameOverPanel; // ���� ���� �� Ȱ��ȭ �Ǵ� UI
    public Camera gameOverCamera;    // ���� ���� �� Ȱ��ȭ �Ǵ� ī�޶�
    [Header("Clear")]
    public GameObject gameClearPanel; // ���� Ŭ���� �� Ȱ��ȭ �Ǵ� UI
    public Camera gameClearCamera;    // ���� Ŭ���� �� Ȱ��ȭ �Ǵ� ī�޶�

    private void Awake()       // Awake �Լ� :  ���� ���� �ѹ� ���۵Ǵ� �Լ�
                               // Start �Լ� : ������ �� �ѹ�
    {
        if (Instance == null)
            Instance = this;
    }                             // ���� �ڵ� ���� �̱��� ����

    private void Start()
    {
        gameClearPanel.SetActive(false);
        gameClearCamera.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);
        gameOverCamera.gameObject.SetActive(false);
    }

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

    public void GameNextLevel(int select) // 0�� : ���� �޴� 1�� ���� ��, 2�� ���� ������ �� ������ ������ �̵��ϱ�
    {
        SceneManager.LoadScene(select); // 1���� ��ϵ� Scene�� �ҷ��Ͷ�.
    }

    public void ReturnMainLobby() // �κ�� ���ư��� �Լ�
    {
        SceneManager.LoadScene(0);
    }
}
