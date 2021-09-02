using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int JumpHash;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        JumpHash = Animator.StringToHash("Jump");
        time = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimationController(); 
    }

    public void AnimationController() 
    {
        bool isrunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey(KeyCode.LeftControl);
        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
        if (!isrunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
        if (!forwardPressed)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    public void Jump() 
    {
        bool Jump = animator.GetBool(JumpHash);
        Debug.Log("test");
        animator.SetBool(JumpHash, true);
        Invoke("test", time);
        
    }

    public void test() 
    {
        animator.SetBool(JumpHash, false);
    }
}
