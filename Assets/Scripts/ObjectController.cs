using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start() // ������ �� �ѹ� �����Ѵ�.
    {
        speed = 10;
    }


    // Update is called once per frame
    void Update()
    {
        // forward �Ķ��� z�� back �Ķ��� -z;, left x��
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
}
