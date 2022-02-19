using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class System_Textbox : System_UI_element
{
    [SerializeField] RectTransform TextRect;
    [SerializeField] TextMeshProUGUI TMP;

    [SerializeField] GameObject textObject;

    protected override void SetReference()
    {
        base.SetReference();
        textObject.SetRef(ref TMP);
    }

    public void SetText(string content)
    {
        TMP.text = content;
    }


}
