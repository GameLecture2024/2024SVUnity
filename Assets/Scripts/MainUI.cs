using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
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

    public void ReturnMainLobby() // 로비로 돌아가는 함수
    {
        SceneManager.LoadScene(0);
    }
}
