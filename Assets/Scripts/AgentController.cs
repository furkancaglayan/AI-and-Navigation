using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    [SerializeField] private string agentName;
    [SerializeField] private float agentSpeed=3f;
    [SerializeField] private AgentState.State startState;
    [SerializeField] private string _animatorDefaultParam="speed";
    [SerializeField] private Transform Points;

    private Agent agent;
    //TODO:Visualize Destination and Current Position.
    void Start()
    {
        agent = new Agent(agentName, Points, startState);
        agent._init_(gameObject, agentSpeed, _animatorDefaultParam);


    }

    void Update()
    {
        agent._update_();
    }
}
