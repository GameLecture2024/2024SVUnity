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
        originPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        // forward �Ķ��� z�� back �Ķ��� -z;, left x��
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }

    //private void OnTriggerEnter(Collider other) // Collider�� Trigger�� True �༮�� �浹���� �� �۵��ϴ� �̺�Ʈ
    //{
    //    Debug.Log($"�浹�� ��� �̸� :{other.name}");
    //
    //    // �÷��̾ ������Ʈ�� �浹���� �� ���ӿ���
    //}

    private Vector3 originPos;

    private void OnCollisionEnter(Collision collision) // Collider�� Trigger�� false �϶� �۵��ϴ� �̺�Ʈ 
    {
        if (collision.collider.CompareTag("Player")) 
        {
            // �ڱ� �ڽ��� �ı��϶�
            //Destroy(gameObject);

            // �浹�� ����� �ı��Ѵ�.
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("Wall"))
        {
            transform.position = originPos;
        }
    }

    // OnTriggerEnter�� OnCollisionEnter�� ������ : Ʈ���Ŵ� ������ �浹�� �߻����� �ʴ´�. Collision ������ �浹�� �߻��ϰ� �̺�Ʈ�� �߻��Ѵ�.

}
