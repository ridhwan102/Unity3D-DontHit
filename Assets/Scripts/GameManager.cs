using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Spawner;
    public GameObject[] ActiveWhenPause;
    public GameObject[] ActiveWhenDie;
    public GameObject[] DeactiveWhenDie;

    Spawner spawner;
    ScoreManager score;

    Player player;

    [HideInInspector]
    public GameObject[] kumpulanMove;
    Move moveScript;

    [HideInInspector]
    public GameObject[] kumpulanRintangan;
    MoveNyamping rintanganScript;

    private float timer1;
    private float max1 = 3;

    void Start()
    {
        foreach (GameObject AWP in ActiveWhenPause)
        {
            AWP.gameObject.SetActive(false);
        }

        foreach (GameObject AWD in ActiveWhenDie)
        {
            AWD.gameObject.SetActive(false);
        }

        foreach (GameObject DWD in DeactiveWhenDie)
        {
            DWD.gameObject.SetActive(true);
        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spawner = Spawner.GetComponent<Spawner>();
        score = this.GetComponent<ScoreManager>();
    }
    
    void Update()
    {
        kumpulanMove = GameObject.FindGameObjectsWithTag("Move");
        kumpulanRintangan = GameObject.FindGameObjectsWithTag("Rintangan");

        // player mati
        if (player.hidup == false)
        {
            //Handheld.Vibrate();
            score.GameIsRun = false;
            timer1 += Time.deltaTime;
            if (timer1 > max1)
            {
                foreach (GameObject AWD in ActiveWhenDie)
                {
                    AWD.gameObject.SetActive(true);
                }
                foreach (GameObject DWD in DeactiveWhenDie)
                {
                    DWD.gameObject.SetActive(false);
                }
            }
        }
    }

    public void Pause()
    {
        foreach (GameObject AWP in ActiveWhenPause)
        {
            AWP.gameObject.SetActive(true);
        }
        Debug.Log("You have clicked the PAUSE button!");
        player.GameIsRun = false;
        foreach (GameObject move in kumpulanMove)
        {
            if (move != null)
            {
                moveScript = move.GetComponent<Move>();
                moveScript.GameIsRun = false;
            }
        }

        foreach (GameObject rint in kumpulanRintangan)
        {
            if (rint != null)
            {
                rintanganScript = rint.GetComponent<MoveNyamping>();
                rintanganScript.GameIsRun = false;
            }
        }

        spawner.GameIsRun = false;
        score.GameIsRun = false;
    }

    public void UnPause()
    {
        foreach (GameObject AWP in ActiveWhenPause)
        {
            AWP.gameObject.SetActive(false);
        }
        Debug.Log("You have clicked the UnPAUSE button!");
        player.GameIsRun = true;
        foreach (GameObject move in kumpulanMove)
        {
            moveScript = move.GetComponent<Move>();
            moveScript.GameIsRun = true;
        }

        foreach (GameObject rint in kumpulanRintangan)
        {
            rintanganScript = rint.GetComponent<MoveNyamping>();
            rintanganScript.GameIsRun = true;
        }

        spawner.GameIsRun = true;
        score.GameIsRun = true;
    }

    public void ChangeScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
