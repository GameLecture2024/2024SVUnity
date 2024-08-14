using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    [Header("Manager")]
    public static MainUI Instance; // 현재 코드 부터
    public GameObject gameOverPanel; // 게임 종료 시 활성화 되는 UI
    public Camera gameOverCamera;    // 게임 종료 시 활성화 되는 카메라
    [Header("Clear")]
    public GameObject gameClearPanel; // 게임 클리어 시 활성화 되는 UI
    public Camera gameClearCamera;    // 게임 클리어 시 활성화 되는 카메라

    private void Awake()       // Awake 함수 :  보다 먼저 한번 시작되는 함수
                               // Start 함수 : 시작할 때 한번
    {
        if (Instance == null)
            Instance = this;
    }                             // 여기 코드 까지 싱글톤 패턴

    private void Start()
    {
        gameClearPanel.SetActive(false);
        gameClearCamera.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);
        gameOverCamera.gameObject.SetActive(false);
    }

    public void GameQuit() // 게임을 종료하는 함수
    {
        Application.Quit(); // 게임을 빌드 해야지만 적용이 됩니다.
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // 에디터에서 실행 버틀을 비활성 시키세요.
#endif
    }

    public void GameRetry() // 게임을 재도전하는 함수
    {
        SceneManager.LoadScene(1); // 1번에 등록된 Scene을 불러와라.
    }

    public void GameNextLevel(int select) // 0번 : 메인 메뉴 1번 현재 씬, 2번 새로 복사한 씬 선택한 레벨로 이동하기
    {
        SceneManager.LoadScene(select); // 1번에 등록된 Scene을 불러와라.
    }

    public void ReturnMainLobby() // 로비로 돌아가는 함수
    {
        SceneManager.LoadScene(0);
    }
}
