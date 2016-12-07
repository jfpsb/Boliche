using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleBola : MonoBehaviour {

    private Rigidbody rb;
    public float power;
    public int derrubados;
    private Vector3 offset;

    private bool compensaEsq = true;
    private bool compensaDir = true;

    public GameObject indicadorDirecao;
    public GameObject indicadorForca;
    public Text placar;
    public Button sair;
    public Text fim;

    ControleIndicadorForca controleForca;

    // Use this for initialization
    void Start () {
        offset = transform.position - indicadorDirecao.transform.position;
        rb = GetComponent<Rigidbody>();
        controleForca = indicadorForca.GetComponent<ControleIndicadorForca>();

        placar = GameObject.Find("Placar").GetComponent<Text>();

        sair.gameObject.SetActive(false);

        ControleGame.InicializaGame();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("w") && !ControleGame.play && ControleIndicadorForca.IsForcaSet())
        {
            float efeito = new System.Random().Next(-300, 300);
            rb.AddForce(new Vector3(efeito, 0.0f, -Mathf.Abs(power)));
            rb.velocity = new Vector3(0.0f, 0.0f, -controleForca.forca);
            ControleGame.inicio = DateTime.Now;
            ControleGame.play = true;
        }

        // Se começar a compensar para um lado, não é possível compensar para o outro.
        if(Input.GetKey("d") && compensaDir)
        {
            compensaEsq = false;
            rb.AddForce(new Vector3(-3.0f, 0.0f, -2.0f));
        }

        if (Input.GetKey("a") && compensaEsq)
        {
            compensaDir = false;
            rb.AddForce(new Vector3(3.0f, 0.0f, -2.0f));
        }

        if (Input.GetKey(KeyCode.Space) && ControleGame.play && ControleGame.gameover)
        {
            ControleGame.InicializaGame();
            SceneManager.LoadScene(0);
        }

        if(Input.GetKeyDown("escape"))
        {
            if(sair.gameObject.activeSelf)
                sair.gameObject.SetActive(false);
            else
                sair.gameObject.SetActive(true);
        }
    }

    void LateUpdate()
    {
        if (!ControleGame.play)
        {
            transform.position = indicadorDirecao.transform.position + offset;
        }
        else
        {
            EscrevePlacar(derrubados, placar);

            if (!ControleGame.gameover)
            {
                ControleGame.horaAtual = DateTime.Now;

                if ((ControleGame.horaAtual - ControleGame.inicio).Seconds >= 10 || transform.position.y < 0.0f || derrubados == 10)
                    ControleGame.gameover = true;
            }
            else
            {
                fim.text = "Aperte espaço para começar nova rodada";
                placar.rectTransform.anchoredPosition = new Vector2(0, Screen.height/2);
                placar.fontSize = 70;
            }
        }
    }

    private static void EscrevePlacar(int derrubados, Text placar)
    {
        placar.text = "Placar: " + derrubados;

        if (derrubados == 10)
        {
            placar.text += "\nStrike!";
        }
    }
}