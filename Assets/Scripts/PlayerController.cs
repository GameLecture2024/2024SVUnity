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

    private void Update()
    {
        characterController.SimpleMove(Vector3.forward * speed);
    }
}
