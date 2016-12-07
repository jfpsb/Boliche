using UnityEngine;

public class ControleIndicadorForca : MonoBehaviour {

    private static bool vertical = true; //true é para cima, false é para baixo
    private static bool isForcaSet = false;
    public float forca = 5f;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("w") && ControleIndicadorDirecao.IsDirecaoSet() && !isForcaSet)
        {
            transform.Translate(0.0f, 0.0f, 0.0f);
            isForcaSet = true;
        }
    }

    void FixedUpdate()
    {
        if (ControleIndicadorDirecao.IsDirecaoSet() && !isForcaSet)
        {
            controleForca();
        }
    }

    private void controleForca()
    {
        if (transform.position.z <= 20.75f)
        {
            forca = 20;
            vertical = false;
        }
        else if (transform.position.z >= 24.65f)
        {
            forca = 10;
            vertical = true;
        }

        if (vertical)
        {
            transform.Translate(0.1f, 0.0f, 0.0f);
            forca += 0.25f;
        }
        else
        {
            transform.Translate(-0.1f, 0.0f, 0.0f);
            forca -= 0.25f;
        }
    }

    public static void ResetaForcaEVertical()
    {
        isForcaSet = false;
        vertical = true;
    }

    public static bool IsForcaSet()
    {
        return isForcaSet;
    }
}
