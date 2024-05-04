using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Puntaje : MonoBehaviour
{
    private static readonly Puntaje instance = new Puntaje(); // singletone

    private int score;
    private Puntaje()
    {
        score = 100;
    }
    public static Puntaje Instance
    {
        get
        {
            return instance;
        }
    }

    public int GetScore()
    {
        return score;
    }


    public void ReducirPuntaje(int points) // para reducir un x puntaje 
    {
        score -= points;
    }

    public void falla() // si se equivoca de carta -6
    {
        ReducirPuntaje(5);
    }
}
