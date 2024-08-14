using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �ּ�.
    // �ʽ��ڰ� �Ǽ��ϱ� ���� ���� ���� �༮ ù��°, ��ҹ��� ��Ż��
    public CharacterController characterController; // �ʷϻ� �̸� Ÿ�� - ��� �̸� ����
    public float speed = 10f;                       // �ʱ� �ӵ��� 10���� �����Ѵ�.
    public float itemAddSpeed = 5f;
    public Camera cam;                             // �÷��̾ �ڽ����� ������ �ִ� ī�޶� ����Ѵ�.
    public float jumpPower = 7.5f;                        // �÷��̾ �����ϴ� ũ��
    public float gravityModifier;                  // ���ڰ� ũ�� Ŭ���� �÷��̾ �޴� �߷��� ũ�Ⱑ Ŀ����.
    public float groundCheck;                      // ���� �˻��ϴ� ���� ����
    public bool isGround = true;                   // ���� �÷��̾ ���� ��� ������ true, �ƴϸ� false
    public LayerMask groundLayer;                  // ���� �ش��ϴ� Layer�� �����ϴ� ����
    private void Start() // �����ϰ� �ѹ��� ����ȴ�.
    {
        cam = GetComponentInChildren<Camera>();   // PlayerController.cs ���ԵǾ� �ִ� ������Ʈ���� �ڽĿ��� Camera ������Ʈ�� ã�� cam ������ �ִ´�.
    }

    private void Update() // �������� ��� ��ȭ�ϴ� ���̱� ������ Update �ۼ��ؾ߰ڴ�.
    {
        PlayerMove();
        GroundCheck();
        //PlayerCameraMove(); - 
    }

    private void GroundCheck()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, groundCheck, groundLayer);
    }

    private void PlayerMove()
    {
        // �÷��̾��� �Է��� �ް� �ʹ�.
        float horizontalInput = Input.GetAxis("Horizontal");   // Ű���� a,d ȭ��ǥ <- -> �����ؼ� ���� ��ȯ
        float verticalInput = Input.GetAxis("Vertical");       // Ű���� w,s ȭ��ǥ �� �� �����ؼ� ���� ��ȯ

        Vector3 moveVector = new Vector3(horizontalInput, 0, verticalInput); // Vector3( -1, 0 , 0)���̸� ��ȯ�ϴ� ����

        Vector3 moveDirection = cam.transform.forward * moveVector.z + cam.transform.right * moveVector.x; // ī�޶� �ٷκ��� �ִ� �������� �Է� ���� ��ȯ�� ��

        if(isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // �����̽��ٸ� ������ �� �ѹ�
            {
                moveDirection.y = jumpPower;
            }
        }
        

        moveDirection = moveDirection + Physics.gravity * gravityModifier * Time.deltaTime;

        // Time.deltaTime������ ���������� ó���Ǿ� �ֱ� ������ �߰������൵ �ȴ�.
        characterController.Move(moveDirection * speed * Time.deltaTime); // ����� �ӵ� speed Vector
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheck);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Goal"))
        {
            MainUI.Instance.gameClearPanel.SetActive(true);
            MainUI.Instance.gameClearCamera.gameObject.SetActive(true);
            Destroy(gameObject);
        }

        if(other.CompareTag("Item"))
        {
            speed = speed + itemAddSpeed;
            Destroy(other.gameObject);
        }
    }

}
