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
        // vista sj�lfan sig
        instance = this;
    }

    void Start()
    {
        // f� upprunulegu st�r�
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        // f�ra masti� til?
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}