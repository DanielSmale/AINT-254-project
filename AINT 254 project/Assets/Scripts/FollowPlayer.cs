using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface surface;

    [SerializeField]
    private Transform goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;

    }

    private void Update()
    {
        

    }

    public void UpdateWalkableArea()
    {
        surface.BuildNavMesh();
    }




}


