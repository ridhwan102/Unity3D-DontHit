using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject DestroyedVersion;

    private float deltaX, deltaZ;

    [HideInInspector]
    public bool GameIsRun = true;
    [HideInInspector]
    public bool hidup = true;

    private Rigidbody rg;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Gerak(GameIsRun, hidup);
    }

    void Gerak(bool GameIsRun, bool hidup)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.444f, 0.444f), transform.position.y, Mathf.Clamp(transform.position.z, -4.4f, -2f));
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToViewportPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaZ = touchPos.y - transform.position.z;
                    break;

                case TouchPhase.Moved:
                    rg.MovePosition(new Vector3(touchPos.x - deltaX, 0.07309f, touchPos.y - deltaZ));
                    break;

                case TouchPhase.Ended:
                    rg.velocity = Vector3.zero;
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Rintangan"))
        {
            GameObject objek = Instantiate(DestroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
            hidup = false;
            Debug.Log("Mati");
            Destroy(objek, 3);
        }
    }
}
