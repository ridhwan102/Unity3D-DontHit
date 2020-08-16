using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[HideInInspector]
    public bool GameIsRun = true;

    public float JedaSpawn;
    public List<GameObject> Gedung = new List<GameObject>();
    public List<GameObject> Rintangan = new List<GameObject>();

    private Transform lokasi;
    private int rand, rand2;
    private float timer;
        
    void Update()
    {
        Spawn(GameIsRun);        
    }

    void Spawn(bool GameIsRun)
    {
        if(GameIsRun) timer += Time.deltaTime;
        if (timer >= JedaSpawn && GameIsRun)
        {
            timer = 0;
            rand = Random.Range(0, Gedung.Count);
            rand2 = Random.Range(0, Rintangan.Count);
            Instantiate(Rintangan[rand2], new Vector3(transform.position.x, Rintangan[rand2].transform.position.y, transform.position.z), transform.rotation);
            if (Rintangan.Count > 1 && rand2 != 0)
                Instantiate(Gedung[rand], transform.position, transform.rotation);
            else if (Rintangan.Count == 1)
                Instantiate(Gedung[rand], transform.position, transform.rotation);
            //Instantiate(Gedung[rand], new Vector3(transform.position.x, Gedung[rand].transform.position.y, transform.position.z), transform.rotation);

        }
    }
}
