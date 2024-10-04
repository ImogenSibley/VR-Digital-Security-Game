using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script created following Justin P Barnett's Youtube Tutorial for Hand Animations https://www.youtube.com/watch?v=DxKWq7z4Xao
[RequireComponent(typeof(Animator))]

public class Hand : MonoBehaviour
{
    public float speed;
    Animator animator;
    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //animate hand 
        AnimateHand();
    }

    internal void SetGrip(float v)
    {
        gripTarget = v; 
    }
   
    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    void AnimateHand()
    {
        if (gripCurrent != gripTarget) //if grip is different animate hand
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }
        if (triggerCurrent != triggerTarget) //if grip is different animate hand
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }

    }

}
