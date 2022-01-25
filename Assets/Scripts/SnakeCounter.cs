using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeCounter : MonoBehaviour
{
    int totalSnakes;

    public Text counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = "Snakes Remaining: " + StateController.currentSnakes + "/" + StateController.totalSnakes;
    }
}
