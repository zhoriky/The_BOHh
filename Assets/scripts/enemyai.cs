using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class enemyai : MonoBehaviour
{
    public List<Transform> patrolPoints;

    public FirstPersonMovement player;
    public float viewAngle;
    public float damage = 30;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;

    //public Animator animator;


    private void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //animator.SetBool("IsAttack", false);
        NoticePlayerUpdate();
        ChaseUpdate();
        AttackUpdate();
        PotrolUpdate();
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
           
                //animator.SetBool("IsAttack", true);
            }
        }
    }



    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if ((Vector3.Angle(transform.forward, direction) < viewAngle) || (Vector3.Distance(transform.position, player.transform.position) < 5))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }

    }

    private void PotrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
}
