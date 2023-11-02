using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private PlayerController player;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Pin[] pins;

    private bool isGamePlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGamePlaying = true;

        // Get the first throw
        player.StartThrow();

    }

    //private void Update()
    //{
    //    if(Input.GetKeyUp(KeyCode.Escape))
    //    {
    //        ResetAllPins();
    //    }
    //}

    public void SetNextThrow()
    {
        Invoke("NextThrow", 3.0f);
    }

    void NextThrow()
    {
        if (scoreManager.currentFrame == 0)
        {
            Debug.Log($"Game Over. Your Total Score is {scoreManager.CalculateTotalScore()}");
        }
        else
        {
            Debug.Log($"Frame {scoreManager.currentFrame} - Throw {scoreManager.currentThrow}");
            scoreManager.SetFrameScore(CalculateFallenPins());
            Debug.Log($"Current Score : {scoreManager.CalculateTotalScore()}");

            player.StartThrow();
        }
    }

    public void ResetAllPins()
    {
        foreach (Pin p in pins) 
        {
            p.ResetPin();
        }
    }

    public int CalculateFallenPins()
    {
        int count = 0;

        foreach(Pin pin in pins)
        {
            if (pin.isFallen && pin.gameObject.activeSelf)
            {
                count++;
                pin.gameObject.SetActive(false);
            }
        }

        Debug.Log($"Total Fallen Pins = {count}");
        return count;

    }

}
