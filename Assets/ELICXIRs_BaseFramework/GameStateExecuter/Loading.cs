using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : GameStateExecuter_Panel
{
    public override IEnumerator Init(gamestate before)
    {
        CanvasGroup.alpha = 1;
        yield return null;
    }



    public override IEnumerator Finalizer(gamestate after)
    {
        yield return null;
        CanvasGroup.alpha = 0;
    }

    public override void Updater()
    {
    }
}
