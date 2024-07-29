using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 주석.
    // 초심자가 실수하기 쉬운 가장 많은 녀석 첫번째, 대소문자 오탈자
    public CharacterController characterController; // 초록색 이름 타입 - 흰색 이름 변수
    public float speed = 10f;                       // 초기 속도를 10으로 설정한다.

    private void Start()
    {
        
    }

    private void Update() // 움직임은 계속 변화하는 것이기 때문에 Update 작성해야겠다.
    {
        PlayerMove();
        PlayerCameraMove();
    }

    private void PlayerMove()
    {
        // 플레이어의 입력을 받고 싶다.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Debug.Log($"horizontalInput : {horizontalInput}, verticlaInput : {verticalInput}");

        Vector3 moveVector = new Vector3(horizontalInput, 0, verticalInput);

        // Time.deltaTime연산이 내부적으로 처리되어 있기 때문에 추가안해줘도 된다.
        characterController.SimpleMove(moveVector * speed); // 방향과 속도 speed Vector
    }

    // 시점을 움직이고 싶다.
    private void PlayerCameraMove()
    {
        // 플레이어의 입력. Mouse 입력을받아야겠죠
        float MouseX = Input.GetAxis("Mouse X");

        Debug.Log($"MouseX {MouseX}");
        float MouseY = Input.GetAxis("Mouse Y");

        // transform 각도. Y축을 MouseX값만큼 변경해주면 된다.

        transform.rotation = Quaternion.Euler(MouseX, MouseY, 0);

    }


}
