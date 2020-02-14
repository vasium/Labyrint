using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public Vector3 floatingTextOffset = new Vector3(0, 3, 0);
    public float destroyTime = 1f;


    void Start()
    {
        Destroy(gameObject, destroyTime);
        transform.localPosition += floatingTextOffset;
    }
}
