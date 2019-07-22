using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent
{
    private AgentState agentState;


    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private GameObject agentGameObject;




    private string agentName;
    private string _animatorDefaultParam;
    private float _agentSpeed = 0f;




    public Agent(string agentName,Transform WayPoints,AgentState.State startState)
    {
        this.agentName = agentName;
        agentState = new AgentState(WayPoints, startState);
    }
    public void _init_(GameObject self, float _agentSpeed, string _animatorDefaultParam)
    {
        navMeshAgent = self.GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
            navMeshAgent = self.AddComponent<NavMeshAgent>();

        animator = self.GetComponent<Animator>();
        if (animator == null)
            animator = self.AddComponent<Animator>();

        //initialize navmeshagent and animator settings
        navMeshAgent.stoppingDistance = .5f;
        navMeshAgent.acceleration = 60;
        navMeshAgent.angularSpeed = 360f;
        navMeshAgent.height = 1.8f;
        navMeshAgent.autoRepath = true;
        navMeshAgent.autoBraking = false;
        navMeshAgent.radius = .25f;

        this._agentSpeed = _agentSpeed;

        animator.applyRootMotion = false;
        this._animatorDefaultParam = _animatorDefaultParam;

        agentGameObject = self;
        if (agentName != null)
        {
            if (agentName != "")
            {

                agentGameObject.name = agentName;
                return;
            }
        }

        agentGameObject.name = "_Agent_";

    }

    public void _update_()
    {
        float speedVal = Mathf.Clamp(navMeshAgent.speed,0f,1f);
        animator.SetFloat(_animatorDefaultParam,speedVal);

        //Distance between agent and current destination
        float dist = Vector3.Distance(navMeshAgent.transform.position, navMeshAgent.destination);


        //Check if arrived at destination so it can stop
        if (dist < navMeshAgent.stoppingDistance)
            _stop_();


        

    }

    private void _stop_()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0f;


        if (agentState.GetCurrentStateInt() == 1)
        {
            Vector3 nextPoint = agentState.GetNextPatrolPoint();
            _move_(nextPoint);
            agentState.currentDestIndex++;
        }

        

    }

    private void _move_(Vector3 dest)
    {
        navMeshAgent.destination = dest;
        navMeshAgent.speed = _agentSpeed;
        navMeshAgent.isStopped = false;
    }


}
