using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{

    public static UIHealthBar instance {get; private set;}
    
    public Image healthBar;
    float originalSize;

    void Awake() 
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        originalSize = healthBar.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        healthBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,originalSize * value);
    }
}
