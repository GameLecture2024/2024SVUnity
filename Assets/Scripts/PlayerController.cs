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

    private void Update() // �������� ��� ��ȭ�ϴ� ���̱� ������ Update �ۼ��ؾ߰ڴ�.
    {
        PlayerMove();
        PlayerCameraMove();
    }

    private void PlayerMove()
    {
        // �÷��̾��� �Է��� �ް� �ʹ�.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Debug.Log($"horizontalInput : {horizontalInput}, verticlaInput : {verticalInput}");

        Vector3 moveVector = new Vector3(horizontalInput, 0, verticalInput);

        // Time.deltaTime������ ���������� ó���Ǿ� �ֱ� ������ �߰������൵ �ȴ�.
        characterController.SimpleMove(moveVector * speed); // ����� �ӵ� speed Vector
    }

    // ������ �����̰� �ʹ�.
    private void PlayerCameraMove()
    {
        // �÷��̾��� �Է�. Mouse �Է����޾ƾ߰���
        float MouseX = Input.GetAxis("Mouse X");

        Debug.Log($"MouseX {MouseX}");
        float MouseY = Input.GetAxis("Mouse Y");

        // transform ����. Y���� MouseX����ŭ �������ָ� �ȴ�.

        transform.rotation = Quaternion.Euler(MouseX, MouseY, 0);

    }


}
