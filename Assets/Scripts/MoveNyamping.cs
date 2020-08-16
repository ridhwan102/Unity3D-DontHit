using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNyamping : MonoBehaviour
{
    public float Speed, Jeda;

    [HideInInspector]
    public bool GameIsRun = true;

    private Rigidbody rg;
    private float timer;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jalan(GameIsRun);
    }

    void Jalan (bool GameIsRun)
    {
        timer += Time.deltaTime;
        if (timer >= Jeda && GameIsRun)
        {
            transform.Translate(Speed / 10 * Time.deltaTime, 0f, 0f);
        }
    }
}
