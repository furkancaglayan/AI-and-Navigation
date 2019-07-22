using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentState 
{
    /// <summary>
    /// This class will be controlling agent's behaviour's by
    /// changing its states.
    /// </summary>
    public enum State
    {
        DEFAULT=0,
        PATROLLING=1
    }
    private State currentState = State.DEFAULT;
    private List<Vector3> _patrolPoints;
    public int currentDestIndex = 0;

    public AgentState(Transform WayPointParent, State startState)
    {
        _patrolPoints = new List<Vector3>();
        SetPatrolPoints(WayPointParent);
        currentState = startState;
    }
    public void ChangeState(int state)
    {
        currentState = (State)state;
    }
    public State GetCurrentState()
    {
        return currentState;
    }

    public int GetCurrentStateInt()
    {
        return (int) currentState;
    }

    public void SetPatrolPoints(Transform Points)
    {
        _patrolPoints.Clear();
        int count = Points.childCount;
        for (int i = 0; i < count; i++)
            _patrolPoints.Add(Points.GetChild(i).position);
        currentDestIndex = 0;
    }

    public Vector3 GetNextPatrolPoint()
    {
        int count = _patrolPoints.Count;
        return _patrolPoints[(currentDestIndex+1) % count];
    }

}
