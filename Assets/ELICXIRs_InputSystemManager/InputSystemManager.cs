using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputSystemManager : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    class InputButton
    {
        public string id;

        InputAction inputAction;

        //n flame前の入力情報
        public bool[] buffer = new bool[240];

        public bool Buttondown;//押された瞬間かどうか
        public bool Button;//押されているか
        public bool Buttonup;//離された瞬間かどうか

        public void Init(PlayerInput input)
        {
            inputAction = input.actions[id];

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = false;
            }
        }

        public void Update()
        {
            {
                Button = inputAction.ReadValue<float>() > 0;

                for (int i = 0; i < buffer.Length - 1; i++)
                {
                    buffer[buffer.Length - i - 1] = buffer[buffer.Length - i - 2];
                }
                buffer[0] = Button;
            }

            if (buffer[0] && !buffer[1])
            {
                Buttondown = true;

            }
            else
            {
                Buttondown = false;
            }

            if (!buffer[0] && buffer[1])
            {
                Buttonup = true;
            }
            else
            {
                Buttonup = false;
            }



        }

    }

    List<InputButton> inputButtons = new List<InputButton>();

    public void Init()
    {
        for (int q = 0; q < Enum.GetNames(typeof(Control)).Length; q++)
        {
            InputButton data = new InputButton { id = ((Control)q).ToString() };
            inputButtons.Add(data);
        }

        foreach (InputButton data in inputButtons)
        {
            data.Init(playerInput);
        }
    }

    string log_buffer;

    public void Updater()
    {
        string log = "input: ";
        bool logflag = false;

        foreach (InputButton data in inputButtons)
        {
            data.Update();
            if (data.Button)
            {
                log += data.id;
                log += " ";
                logflag = true;
            }
        }
        if (!logflag)
        {
            log += "none";

        }
        
        if(log != log_buffer)
        {
            Test.InputLog(log);
        }
        log_buffer = log;


    }

    int GetIndex(string id)
    {
        for (int q = 0; q < inputButtons.Count; q++)
        {
            if (inputButtons[q].id == id)
            {
                return q;
            }
        }
        return 0;
    }


    public bool Button(Control control)
    {
        return inputButtons[(int)control].Button;
    }
    public bool ButtonUp(Control control)
    {
        return inputButtons[(int)control].Buttonup;
    }
    public bool ButtonDown(Control control)
    {
        return inputButtons[(int)control].Buttondown;
    }

    public Vector2 InputArrow()
    {
        Vector2 result = Vector2.zero;

        if (Button(Control.Up))
        {
            result += Vector2.up;
        }
        if (Button(Control.Left))
        {
            result += Vector2.left;
        }
        if (Button(Control.Right))
        {
            result += Vector2.right;
        }
        if (Button(Control.Down))
        {
            result += Vector2.down;
        }
        return result;
    }

}

public enum Control
{
    Button1,
    Button2,
    Button3,
    Button4,

    Up,
    Down,
    Right,
    Left,

}