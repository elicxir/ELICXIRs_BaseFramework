using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class System_Window : MonoBehaviour
{
    RectTransform WindowRect;
    CanvasGroup canvasGroup;
    Image window;

    [SerializeField] Sprite sp;

    private void OnValidate()
    {
        if (WindowRect == null)
        {
            WindowRect = GetComponent<RectTransform>();
        }
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        if (window == null)
        {
            window = GetComponent<Image>();
        }
    }

    public void SetSprite(Sprite sprite)
    {
        window.sprite = sprite;

        print(window.sprite.border);
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



    //即座に位置と大きさを変更
    public void SetRectInstantly(Rect rect)
    {
        print(rect);
        print(rect.center);

        WindowRect.sizeDelta = rect.size;
        WindowRect.anchoredPosition = rect.center;

    }
    public void SetRectInstantly(Vector2 center,Vector2 size)
    {

        SetRectInstantly(RectExtensions.Rect_CS(center, size));
    }



    public Vector2 GetMinSize
    {
        get
        {
            return new Vector2(window.sprite.border.x + window.sprite.border.z, window.sprite.border.y + window.sprite.border.w);
        }
    }
    public Vector2 GetPos
    {
        get
        {
            return WindowRect.anchoredPosition;
        }
    }

    //時間をかけて位置と大きさを変更
    public IEnumerator SetRect(Rect rect, float time)
    {
        Vector2 c_b = WindowRect.anchoredPosition;
        Vector2 c_a = rect.center;

        Vector2 s_b = WindowRect.sizeDelta;
        Vector2 s_a = rect.size;

        float timer = 0;

        while (timer < time)
        {
            WindowRect.sizeDelta = Vector2.Lerp(s_b, s_a, timer / time);
            WindowRect.anchoredPosition = Vector2.Lerp(c_b, c_a, timer / time);

            yield return null;
        }
    }

    public IEnumerator SetRect(Vector2 center, Vector2 size, float time)
    {
        return SetRect(RectExtensions.Rect_CS(center, size),time);

    }

}
