using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinPatrol : StateMachineBehaviour
{
    float timer;
    private List<Transform> _points = new List<Transform>();
    private NavMeshAgent _agent;
    Transform player;
    float chaseRange = 20;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform pointsObject = GameObject.FindGameObjectWithTag("points").transform;
        foreach (Transform t in pointsObject)
        {
            _points.Add(t);
        }

        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.SetDestination(_points[Random.Range(0, _points.Count)].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     //   if (_agent.remainingDistance <= _agent.stoppingDistance)
        _agent.SetDestination(_points[Random.Range(0, _points.Count)].position);
        timer += Time.deltaTime;

        if (timer > 6)
            animator.SetBool("IsPatrolling", false);

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < chaseRange)
            animator.SetBool("IsChasing", true);
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }

    
}
