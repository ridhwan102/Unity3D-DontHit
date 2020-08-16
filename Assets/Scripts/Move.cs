using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;
    private Rigidbody rg;

    [HideInInspector]
    public bool GameIsRun = true;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameIsRun)
        {
            transform.Translate(0f, 0f, Speed / 10 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
            if (transform.parent != null)
            { Destroy(transform.parent.gameObject); }
        }
    }
}
