using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DB/SoundDatas")]
public class SoundDatas : ScriptableObject
{
    [EnumIndex(typeof(BGM))] public AudioClip[] musics;

    [EnumIndex(typeof(SE))] public AudioClip[] soundEffects;
}
