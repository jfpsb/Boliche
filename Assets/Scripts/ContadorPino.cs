using UnityEngine;
using System.Collections;

public class ContadorPino : MonoBehaviour {

    private bool caido = false;
    public GameObject bola;

    ControleBola scriptBola;

	// Use this for initialization
	public void Start () {
        scriptBola = bola.GetComponent<ControleBola>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.up.y < 0.5f && !caido)
        {
            caido = true;
            scriptBola.derrubados++;
        }
    }
}
