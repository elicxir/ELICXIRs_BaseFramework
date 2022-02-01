using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //GameManagerのシングルトン化
    public static GameManager Game_Manager;

    [HideInInspector] public InputSystemManager Input;



    public bool DebugMode;


    public gamestate GameState => Now_GameState;

    public gamescene GameScene => Now_GameScene;

    gamestate Now_GameState = gamestate.Undefined;
    gamestate Pre_GameState = gamestate.Undefined;
    gamestate Next_GameState = gamestate.Undefined;

    gamescene Now_GameScene = gamescene.Scene1;
    gamescene Next_GameScene = gamescene.GameManager;





    [EnumIndex(typeof(gamestate))] [SerializeField] GameStateExecuter[] Executers;


    //fade用のパネル
    public CanvasGroup transitionpanel;

    public IEnumerator FadeOut(float time, Action action = null)
    {
        if (DebugMode)
        {
            print("fade");
        }
        float mult = 1 / time;
        transitionpanel.alpha = 0;

        while (transitionpanel.alpha < 1)
        {
            transitionpanel.alpha += Time.deltaTime * mult;
            transitionpanel.alpha = Mathf.Min(transitionpanel.alpha, 1);
            if (action != null)
            {
                action();
            }
            yield return null;
        }
        transitionpanel.alpha = 1;

    }
    public IEnumerator FadeIn(float time, Action action = null)
    {
        float mult = 1 / time;

        transitionpanel.alpha = 1;

        while (transitionpanel.alpha > 0)
        {
            transitionpanel.alpha -= Time.deltaTime * mult;
            transitionpanel.alpha = Mathf.Max(transitionpanel.alpha, 0);

            if (action != null)
            {
                action();
            }
            yield return null;
        }
        transitionpanel.alpha = 0;
    }
    public IEnumerator In(float time, Action action = null)
    {
        float timer = 0;

        do
        {
            timer = Mathf.Min(timer + Time.deltaTime, time);
            transitionpanel.alpha = 1 - timer / time;
            if (action != null)
            {
                action();
            }
            yield return null;

        } while (timer < time);
        transitionpanel.alpha = 0;
    }





    [ContextMenu("Set Executers")]
    private void SetExecuters()
    {
        if (Enum.GetNames(typeof(gamestate)).Length < 2)
        {
            Debug.LogError("undefinedに加えて、最低1つのgamestateが必要です");
            return;
        }

        Executers = new GameStateExecuter[Enum.GetNames(typeof(gamestate)).Length];

        GameStateExecuter[] exs = GetComponentsInChildren<GameStateExecuter>();

        foreach (var item in exs)
        {
            for (int i = 0; i < Enum.GetNames(typeof(gamestate)).Length; i++)
            {
                if (item.name == ((gamestate)i).ToString())
                {
                    Executers[i] = item;
                }
            }
        }

        Executers[1] = SMF.Get_Scene_Executer();
    }


    private void OnValidate()
    {
        if (Input == null)
        {
            Input = GetComponentInChildren<InputSystemManager>();
        }

        for (int i = 0; i < Executers.Count(); i++)
        {
            if (Executers[i] == null&&i!=1)
            {
                Debug.LogError("GameStateExecuter is null");
            }
        }

    }

    //以下参照エラー検出用関数群


















    void Awake()
    {
        if (Game_Manager == null)
        {
            Game_Manager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        GAME_AWAKE();
    }

    void GAME_AWAKE()
    {
        Input.Init();

        StateQueue(gamestate.Title);

    }



    public void StateQueue(gamestate state = gamestate.Undefined)
    {
        statequeueflag = true;
        if (state == gamestate.Undefined)
        {
            Next_GameState = Pre_GameState;
        }
        else
        {
            Next_GameState = state;
        }
    }
    bool statequeueflag = false;










    IEnumerator StateChange()
    {
        statequeueflag = false;

        Pre_GameState = Now_GameState;
        Now_GameState = gamestate.Undefined;

        yield return StartCoroutine(Executers[(int)Pre_GameState].Finalizer(Next_GameState));
        yield return StartCoroutine(Executers[(int)Next_GameState].Init(Pre_GameState));

        Now_GameState = Next_GameState;

        if (DebugMode)
        {
            print($"GameState was Changed from {Pre_GameState} to {Now_GameState}");
        }

        yield break;
    }

    private void Update()
    {
        Input.Updater();

        if (statequeueflag)
        {
            StartCoroutine(StateChange());
        }

        StateMachineUpdater();
    }
    private void LateUpdate()
    {
        StateMachineLateUpdater();
    }
    private void FixedUpdate()
    {
        StateMachineFixedUpdater();
    }






    void StateMachineUpdater()
    {
        if (Now_GameState != gamestate.Undefined)
        {
            Executers[(int)Now_GameState].Updater();
        }
    }

    void StateMachineLateUpdater()
    {
        if (Now_GameState != gamestate.Undefined)
        {
            Executers[(int)Now_GameState].LateUpdater();
        }
    }

    void StateMachineFixedUpdater()
    {
        if (Now_GameState != gamestate.Undefined)
        {
            Executers[(int)Now_GameState].FixedUpdater();
        }
    }

    [ContextMenu("c")]
    void CheckScene()
    {
        print(SceneManager.GetSceneByBuildIndex(0).isLoaded);
        print(SceneManager.GetSceneByBuildIndex(1).isLoaded);
        print(SceneManager.GetSceneAt(0).name);
        print(SceneManager.GetSceneAt(1).name);
        print(SceneManager.GetSceneAt(2).name);
        print(SceneManager.GetSceneAt(3).name);


    }


}


public enum gamestate
{
    Undefined,
    Scene,
    Loading,
    MainGame,
    Title,
}

public enum gamescene
{
    GameManager,
    Scene1,
    Scene2,
}

//SceneManagementFunctions
public class SMF
{    

    public static Scene_Executer Get_Scene_Executer()
    {
        GameObject @object = GameObject.FindGameObjectWithTag("SceneExecuter");
        if (@object != null)
        {
            if (@object.scene == SceneManager.GetSceneByBuildIndex((int)GameManager.Game_Manager.GameScene))
            {
                return @object.GetComponent<Scene_Executer>();
            }
        }

        Debug.Log("SeceneExecuterError");
        return null;

    }
}