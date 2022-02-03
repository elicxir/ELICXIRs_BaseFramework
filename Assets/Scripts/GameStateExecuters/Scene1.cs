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
            GM.SceneQueue(gamestate.Scene, gamescene.Scene2);
        }
    }
}
