using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GoblinAtack : StateMachineBehaviour
{
    Transform player;
    
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerHealth Player = player.gameObject.GetComponent<PlayerHealth>();
        animator.transform.LookAt(player);
        
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance > 3)
            animator.SetBool("IsAttacking",false);
        
    }
    public override void OnStateIK(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        PlayerHealth Player = player.gameObject.GetComponent<PlayerHealth>();

            Player.TakeDamage(5);
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
