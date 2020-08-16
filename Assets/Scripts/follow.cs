using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject ObjectToFollow;
    Transform target;
    Vector3 offset;

    void Start()
    {
        target = ObjectToFollow.transform;
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position - offset;
    }
}
