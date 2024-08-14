using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float speed;

    // 자동차가 Player랑 충돌했을 때 gameOverPanel 활성화 시켜준다.
    // Start is called before the first frame update

    void Start() // 시작할 때 한번 실행한다.
    {
        speed = 10;
        originPos = transform.position;

        MainUI.Instance.gameOverPanel.SetActive(false); // MainUI 등록한 UI창을 비활성화를 한다.
    }


    // Update is called once per frame
    void Update()
    {
        // forward 파란색 z축 back 파란색 -z;, left x축
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }

    //private void OnTriggerEnter(Collider other) // Collider가 Trigger인 True 녀석이 충돌했을 때 작동하는 이벤트
    //{
    //    Debug.Log($"충돌한 대상 이름 :{other.name}");
    //
    //    // 플레이어가 오브젝트에 충돌했을 때 게임오버
    //}

    private Vector3 originPos;

    private void OnCollisionEnter(Collision collision) // Collider가 Trigger가 false 일때 작동하는 이벤트 
    {
        if (collision.collider.CompareTag("Player")) 
        {
            // 자기 자신을 파괴하라
            //Destroy(gameObject);

            // 충돌한 대상을 파괴한다.
            MainUI.Instance.gameOverCamera.gameObject.SetActive(true);  // 게임 종료 카메라를 활성화 환다.
            Destroy(collision.gameObject);                              // 플레이어를 파괴 시킨다.
            MainUI.Instance.gameOverPanel.SetActive(true);              // 게임 종료 UI를 활성화 한다.
        }
        if (collision.collider.CompareTag("Wall"))
        {
            transform.position = originPos;
        }
    }

    // OnTriggerEnter와 OnCollisionEnter의 차이점 : 트리거는 물리적 충돌이 발생하지 않는다. Collision 물리적 충돌이 발생하고 이벤트도 발생한다.

}
