using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class System_Window : System_UI_element
{
    Image window;

    [SerializeField] AnimationCurve curve_X;
    [SerializeField] AnimationCurve curve_Y;

    protected override void SetReference()
    {
        base.SetReference();
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






    public Vector2 GetMinSize
    {
        get
        {
            return new Vector2(Mathf.RoundToInt(window.sprite.border.x + window.sprite.border.z), Mathf.RoundToInt(window.sprite.border.y + window.sprite.border.w));
        }
    }



    //éûä‘ÇÇ©ÇØÇƒà íuÇ∆ëÂÇ´Ç≥ÇïœçX
    public IEnumerator SetRect(Rect rect, float time, bool reverse = false)
    {
        float c_b_x = UIRect.anchoredPosition.x;
        float c_b_y = UIRect.anchoredPosition.y;

        float c_a_x = rect.center.x;
        float c_a_y = rect.center.y;

        float s_b_x = UIRect.sizeDelta.x;
        float s_b_y = UIRect.sizeDelta.y;

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


            UIRect.sizeDelta = new Vector2(L(s_b_x, s_a_x, timer, curve_X), L(s_b_y, s_a_y, timer, curve_Y));
            UIRect.anchoredPosition = new Vector2(L(c_b_x, c_a_x, timer, curve_X), L(c_b_y, c_a_y, timer, curve_Y));

            timer += Time.deltaTime;
            yield return null;
        }

        UIRect.sizeDelta = rect.size;
        UIRect.anchoredPosition = rect.center;
    }

    public IEnumerator SetRect(Vector2 center, Vector2 size, float time)
    {
        return SetRect(RectEX.Rect_CS(center, size), time);

    }

}
