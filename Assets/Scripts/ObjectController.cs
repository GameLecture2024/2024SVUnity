using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float speed;

    // �ڵ����� Player�� �浹���� �� gameOverPanel Ȱ��ȭ �����ش�.
    // Start is called before the first frame update

    void Start() // ������ �� �ѹ� �����Ѵ�.
    {
        speed = 10;
        originPos = transform.position;

        MainUI.Instance.gameOverPanel.SetActive(false); // MainUI ����� UIâ�� ��Ȱ��ȭ�� �Ѵ�.
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
            MainUI.Instance.gameOverCamera.gameObject.SetActive(true);  // ���� ���� ī�޶� Ȱ��ȭ ȯ��.
            Destroy(collision.gameObject);                              // �÷��̾ �ı� ��Ų��.
            MainUI.Instance.gameOverPanel.SetActive(true);              // ���� ���� UI�� Ȱ��ȭ �Ѵ�.
        }
        if (collision.collider.CompareTag("Wall"))
        {
            transform.position = originPos;
        }
    }

    // OnTriggerEnter�� OnCollisionEnter�� ������ : Ʈ���Ŵ� ������ �浹�� �߻����� �ʴ´�. Collision ������ �浹�� �߻��ϰ� �̺�Ʈ�� �߻��Ѵ�.

}
