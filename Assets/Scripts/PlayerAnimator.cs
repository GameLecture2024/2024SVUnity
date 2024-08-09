using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    //public Animator[] animators;
    // Start is called before the first frame update
    void Start()
    {
        //animators = GetComponentsInChildren<Animator>();  : 자식의 컴포넌트를 여럿 가져올 때 복수형(s)로 사용한다. <가지고 오고 싶은 컴포넌트 이름>
        //animator = GetComponentInParent<Animator>();      : 자기 자신과 부모를 검색해서 가져오는 방법
        //animator = GetComponentInChildren<Animator>();    : 자기 자신과 자식을 검색해서 가져오는 방법
        animator = GetComponent<Animator>();              //: 자기 자신에서 컴포넌트를 검색해서 가져오는 방법
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Mathf.abs : 왼쪽, 아래쪽을 입력받을 때 Input.GetAxis (음수 값을 반환합니다.) 음수도 양수로 반환하기 위한
        float moveInput = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));   // Clamp,  첫번째 인자로 받은 값의 최소 최대 값의 범위를 지정해주는 함수.

        if(moveInput == 0)
        {
            animator.SetBool("Run", false);
        }
        else if(moveInput != 0)
        {
            animator.SetBool("Run", true);
        }


        if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Victory");
        }

    }


   
}
