using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDashBar : MonoBehaviour
{

    public static UIDashBar instance {get; private set;}

    public Image dashBar;
    float originalSize;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalSize = dashBar.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        dashBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,originalSize * value);
    }
}
