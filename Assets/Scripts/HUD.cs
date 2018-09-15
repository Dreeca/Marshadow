﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    private float temps; // facilite pour afficher en secondes
    private float time; // calcul du temps actuel du niveau, considere qu'il commence a 20
    public bool timesup; // quand timesup, le timer de debut est fini et les phase de construction est terminee, les monstres apparaissent

	// Use this for initialization
	void Start () {
        ResetTimer();
	}
	
	// Update is called once per frame
	void Update () {
        TimerUpdate();
    }

    void TimerUpdate()
    {
        time -= Time.deltaTime;
        if (time > 0f)
        {
            GameManager.gameManager.timer.GetComponent<CanvasGroup>().alpha = 1;
            if (time < temps)
            {
                GameManager.gameManager.timer.text = temps.ToString();
                temps--;
            }
        }
        else
        {
            GameManager.gameManager.timer.text = "C'est parti !";
            
            timesup = true;
            if (GameManager.gameManager.isspawn)
            {
                GameManager.gameManager.isspawn = false;
            }
            if(time < -3f)
            {
                GameManager.gameManager.timer.GetComponent<CanvasGroup>().alpha = 0;
            }
        }
    }

    public void ResetTimer()
    {
        Debug.Log("phase défense");
        time = 5f;
        temps = 4f;
        timesup = false;
    }

    public void PrintLives(int vies)
    {
        GameManager.gameManager.pv.text = vies + " Vies";
    }

    public void PrintMoney(int argent)
    {
        GameManager.gameManager.pv.text = argent + " $";
    }
}
