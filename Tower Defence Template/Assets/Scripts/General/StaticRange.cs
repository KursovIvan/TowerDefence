using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRange : MonoBehaviour
{
    float ratio = 4.75f;

    public void ScaleRadius(float radius)
    {
        gameObject.transform.localScale = new Vector3(radius * ratio, radius * ratio, radius * ratio);
    }
}
