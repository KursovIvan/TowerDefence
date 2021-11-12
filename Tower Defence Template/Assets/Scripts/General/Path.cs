using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<GameObject> pathWaypoints = new List<GameObject>();

    private void Awake()
    {
        createListOfWaypoints();
    }
    private void createListOfWaypoints()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            pathWaypoints.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }
}
