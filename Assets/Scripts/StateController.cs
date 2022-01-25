using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public GameObject[] snakes;
    public static int totalSnakes;
    public static int currentSnakes;

    public GameObject youWinUI;
    
    // Start is called before the first frame update
    void Start()
    {
        totalSnakes = snakes.Length;
        currentSnakes = snakes.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSnakes == 0)
        {
            Time.timeScale = 0;
            youWinUI.SetActive(true);
        }
    }
}
