using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlKing : MonoBehaviour
{
    public float displayTime;
    public GameObject kingDialogBox;
    public GameObject percyDialogBox;

    bool kingIsTalking;
    bool percyIsTalking;
    float timerDisplay;
    // Start is called before the first frame update
    void Start()
    {
        kingDialogBox.SetActive(false);
        percyDialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (kingIsTalking)
        {
            kingDialogBox.SetActive(true);
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                kingIsTalking = false;
                kingDialogBox.SetActive(false);
                DisplayPercyDialog();
            }
        }

        if (percyIsTalking)
        {
            percyDialogBox.SetActive(true);
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                percyIsTalking = false;
                percyDialogBox.SetActive(false);
            }
        }
    }

    public void DisplayKingDialog()
    {
        timerDisplay = displayTime;
        kingIsTalking = true;
    }

    public void DisplayPercyDialog()
    {
        timerDisplay = displayTime;
        percyIsTalking = true;
    }
}
