using UnityEngine;
using System;
using UnityEngine.UI;

public class ControleGame {

    public static bool play = false;
    public static bool gameover = false;
    public static DateTime inicio;
    public static DateTime horaAtual;

    public static void InicializaGame()
    {
        play = false;
        gameover = false;

        ControleIndicadorDirecao.ResetaDirecaoEHorizontal();
        ControleIndicadorForca.ResetaForcaEVertical();
    }
}
