using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �ּ�.
    // �ʽ��ڰ� �Ǽ��ϱ� ���� ���� ���� �༮ ù��°, ��ҹ��� ��Ż��
    public CharacterController characterController; // �ʷϻ� �̸� Ÿ�� - ��� �̸� ����
    public float speed = 10f;                       // �ʱ� �ӵ��� 10���� �����Ѵ�.

    private void Start()
    {
        
    }

    private void Update()
    {
        characterController.SimpleMove(Vector3.forward * speed);
    }
}
