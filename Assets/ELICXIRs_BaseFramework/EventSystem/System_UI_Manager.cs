using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_UI_Manager : MonoBehaviour
{
    public System_UI<System_Window> Windows = new System_UI<System_Window>();

}

[System.Serializable]
public class System_UI<T> where T:MonoBehaviour
{
    Dictionary<string, T> UI = new Dictionary<string, T>();

    [SerializeField] T defaultprefab;
    [SerializeField] Transform parent;

    public T Add(string key)
    {
        if (!UI.ContainsKey(key))
        {
            T newT = MonoBehaviour.Instantiate(defaultprefab, parent);
            UI.Add(key, newT);
            return newT;
        }
        return null;       
    }

    public T Get(string key)
    {
        return UI[key];
    }

    public void Remove(string key)
    {
        if (UI.ContainsKey(key))
        {
            T a=UI[key];
            UI.Remove(key);
            MonoBehaviour.Destroy(a.gameObject);
        }
    }


}