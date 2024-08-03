using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update

    void Start() // 시작할 때 한번 실행한다.
    {
        speed = 10;
        originPos = transform.position;
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
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("Wall"))
        {
            transform.position = originPos;
        }
    }

    // OnTriggerEnter와 OnCollisionEnter의 차이점 : 트리거는 물리적 충돌이 발생하지 않는다. Collision 물리적 충돌이 발생하고 이벤트도 발생한다.

}
