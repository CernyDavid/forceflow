using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FitToScreen : MonoBehaviour
{
    public Image image;

    void Start()
    {
        AdjustImage();
    }

    void AdjustImage()
    {
        RectTransform canvasRect = image.canvas.GetComponent<RectTransform>();
        RectTransform imageRect = image.GetComponent<RectTransform>();

        float canvasAspect = canvasRect.rect.width / canvasRect.rect.height;
        float imageAspect = (float)image.mainTexture.width / image.mainTexture.height;

        if (canvasAspect > imageAspect)
        {
            imageRect.sizeDelta = new Vector2(canvasRect.rect.height * imageAspect, canvasRect.rect.height);
        }
        else
        {
            imageRect.sizeDelta = new Vector2(canvasRect.rect.width, canvasRect.rect.width / imageAspect);
        }

        imageRect.anchoredPosition = Vector2.zero;
    }
}
