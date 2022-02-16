using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : Scene_Executer
{
    public override IEnumerator Init(gamestate before)
    {

        yield return StartCoroutine(GM.FadeIn(0.3f));
    }



    public override IEnumerator Finalizer(gamestate after)
    {
        yield return StartCoroutine(GM.FadeOut(0.3f));
    }

    public override void Updater()
    {
        if (GM.Input.ButtonDown(Control.Button1))
        {
            GM.StateQueue(gamestate.Scene, gamescene.Scene2);
        }

        if (GM.Input.ButtonDown(Control.Button2))
        {
            //StartCoroutine(change());
        }
        if (GM.Input.ButtonDown(Control.Button3))
        {
            StartCoroutine(close());
        }
        if (GM.Input.ButtonDown(Control.Button4))
        {
            StartCoroutine(open());
        }
    }

    System_UI<System_Window> Windows
    {
        get
        {
            return GM.UI.Windows;
        }
    }

    IEnumerator close()
    {

        yield return Windows.Get("1").SetRect(RectEX.Rect_CS(Windows.Get("1").GetPos, Windows.Get("1").GetMinSize), 0.2f, true);
        Windows.Remove("1");

        yield return Windows.Get("2").SetRect(RectEX.Rect_CS(Windows.Get("2").GetPos, Windows.Get("2").GetMinSize), 0.2f, true);
        Windows.Remove("2");
    }


    IEnumerator open()
    {
        Windows.Add("1");
        Windows.Get("1").SetRectInstantly(RectEX.Rect_CS(new Vector2(200, 150), Windows.Get("1").GetMinSize));
        yield return Windows.Get("1").SetRect(RectEX.Rect_CS(Windows.Get("1").GetPos, new Vector2(200, 150)), 0.2f);

        Windows.Add("2");
        Windows.Get("2").SetRectInstantly(RectEX.Rect_CS(new Vector2(-200, -150), Windows.Get("2").GetMinSize));
        yield return Windows.Get("2").SetRect(RectEX.Rect_CS(Windows.Get("2").GetPos, new Vector2(400, 320)), 0.2f);
    }
}
