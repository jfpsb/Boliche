using UnityEngine;

public class ControleIndicadorDirecao : MonoBehaviour {

    private static bool horizontal = true; //true é direita, false é esquerda
    private static bool isDirecaoSet = false;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("w"))
        {
            isDirecaoSet = true;
            transform.Translate(0.0f, 0.0f, 0.0f);
        }

        if (!isDirecaoSet)
        {
            controleDirecao();
        }
	}

    private void controleDirecao()
    {
        if (transform.position.x <= -2.0f)
        {
            horizontal = false;
        }
        else if (transform.position.x >= 2.0f)
        {
            horizontal = true;
        }

        if (horizontal)
        {
            transform.Translate(-0.07f, 0.0f, 0.0f);
        }
        else
        {
            transform.Translate(0.07f, 0.0f, 0.0f);
        }
    }

    public static void ResetaDirecaoEHorizontal()
    {
        isDirecaoSet = false;
        horizontal = false;
    }

    public static bool IsDirecaoSet()
    {
        return isDirecaoSet;
    }
}
