using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadePanelSystem : MonoBehaviour
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }
    public void MakeFadeIn()
    {
        _image.DOColor(new Color(_image.color.r, _image.color.g, _image.color.b, 1), 0.5f);
    }
    public void MakeFadeOut()
    {
        _image.DOColor(new Color(_image.color.r, _image.color.g, _image.color.b, 0), 0f);
    }
}
