using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class System_Window : MonoBehaviour
{
    RectTransform WindowRect;
    CanvasGroup canvasGroup;
    Image window;

    [SerializeField] AnimationCurve curve_X;
    [SerializeField] AnimationCurve curve_Y;

    private void Awake()
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
    public void SetRectInstantly(Vector2 center, Vector2 size)
    {

        SetRectInstantly(RectEX.Rect_CS(center, size));
    }



    public Vector2 GetMinSize
    {
        get
        {
            return new Vector2(Mathf.RoundToInt(window.sprite.border.x + window.sprite.border.z), Mathf.RoundToInt(window.sprite.border.y + window.sprite.border.w));
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
    public IEnumerator SetRect(Rect rect, float time, bool reverse = false)
    {
        float c_b_x = WindowRect.anchoredPosition.x;
        float c_b_y = WindowRect.anchoredPosition.y;

        float c_a_x = rect.center.x;
        float c_a_y = rect.center.y;

        float s_b_x = WindowRect.sizeDelta.x;
        float s_b_y = WindowRect.sizeDelta.y;

        float s_a_x = rect.size.x;
        float s_a_y = rect.size.y;

        float timer = 0;

        float L(float v1, float v2, float t, AnimationCurve c)
        {
            if (reverse)
            {
                return Mathf.Lerp(v1, v2, 1-c.Evaluate(1 - t / time));

            }
            else
            {
                return Mathf.Lerp(v1, v2, c.Evaluate(t / time));
            }

        }

        while (timer < time)
        {


            WindowRect.sizeDelta = new Vector2(L(s_b_x, s_a_x, timer, curve_X), L(s_b_y, s_a_y, timer, curve_Y));
            WindowRect.anchoredPosition = new Vector2(L(c_b_x, c_a_x, timer, curve_X), L(c_b_y, c_a_y, timer, curve_Y));

            timer += Time.deltaTime;
            yield return null;
        }

        WindowRect.sizeDelta = rect.size;
        WindowRect.anchoredPosition = rect.center;
    }






    public IEnumerator SetRect(Vector2 center, Vector2 size, float time)
    {
        return SetRect(RectEX.Rect_CS(center, size), time);

    }

}
