using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_UI_element : MonoBehaviour
{
    protected RectTransform UIRect;
    protected CanvasGroup canvasGroup;

     void Awake()
    {
        SetReference();
    }

    private void OnValidate()
    {
        SetReference();
    }

    protected virtual void SetReference()
    {
        this.SetRef(ref UIRect);
        this.SetRef(ref canvasGroup);
    }

    public void Show()
    {
        canvasGroup.alpha = 1;
    }

    public void Hide()
    {
        canvasGroup.alpha = 0;
    }

    public void Switch()
    {
        if (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha = 0;
        }
        else
        {
            canvasGroup.alpha = 1;
        }
    }



    //ë¶ç¿Ç…à íuÇ∆ëÂÇ´Ç≥ÇïœçX
    public void SetRectInstantly(Rect rect)
    {
        UIRect.sizeDelta = rect.size;
        UIRect.anchoredPosition = rect.center;
    }
    public void SetRectInstantly(Vector2 center, Vector2 size)
    {
        SetRectInstantly(RectEX.Rect_CS(center, size));
    }

    public Vector2 GetSize
    {
        get
        {
            return UIRect.sizeDelta;
        }
    }
    public Vector2 GetPos
    {
        get
        {
            return UIRect.anchoredPosition;
        }
    }

}
