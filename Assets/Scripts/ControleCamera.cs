using UnityEngine;

public class ControleCamera : MonoBehaviour {

    public GameObject bola;
    private float offset;
    private bool play = false;

    // Use this for initialization
    void Start ()
    {
        offset = transform.position.z - bola.transform.position.z;
    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
            play = true;
    }

    void LateUpdate()
    {
        if (play && transform.position.z > -18)
            transform.position = new Vector3(transform.position.x, transform.position.y, bola.transform.position.z + offset);
    }
}
