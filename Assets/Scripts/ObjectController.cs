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
    }


    // Update is called once per frame
    void Update()
    {
        // forward 파란색 z축 back 파란색 -z;, left x축
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
}
