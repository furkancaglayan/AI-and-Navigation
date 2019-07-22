using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointVisualizer : MonoBehaviour
{
    public Color Color;
    private List<Transform> Points;
    private void OnDrawGizmosSelected()
    {
        Color.a = 1;
        Gizmos.color = Color;
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
            Gizmos.DrawWireSphere(transform.GetChild(i).position,.5f);
    }
    private void Start()
    {
        Points = new List<Transform>();
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
            Points.Add(transform.GetChild(i));
    }
    private void Update()
    {
        foreach (var VARIABLE in Points)
            VARIABLE.Rotate(new Vector3(20,20,20)*Time.deltaTime);
    }


}
