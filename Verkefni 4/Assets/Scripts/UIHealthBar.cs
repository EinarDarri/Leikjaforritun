using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    // breitur
    public static UIHealthBar instance { get; private set; }

    public Image mask;
    float originalSize;


    void Awake()
    {
        // vista sjálfan sig
        instance = this;
    }

    void Start()
    {
        // fá upprunulegu stærð
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        // færa mastið til?
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}