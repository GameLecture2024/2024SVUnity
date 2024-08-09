using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // animator 변수에 현재 게임 오브젝트의 컴포넌트 중에 Animator를 찾아서 넣어라
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetBool("IsOpen", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetBool("IsOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetBool("IsOpen", false);
        }
    }

}
