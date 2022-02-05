using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サウンド管理用クラス 事前に登録したAudioClipをPlaySEとPlayBGMで再生可能　
/// 効果音は同時に16音まで出せるように設定済み。(SE_Sourceを増やせば最大数は上がる)
/// </summary>
public class SoundManager : MonoBehaviour
{
    AudioSource audioSource_BGM;
    AudioSource[] audioSource_SE;


    private void OnValidate()
    {
        SetSource();

    }

    void SetSource()
    {
        print("SetAudioSource");
        List<AudioSource> sources = new List<AudioSource>(GetComponentsInChildren<AudioSource>());

        for (int i = sources.Count - 1; i >= 0; i--)
        {
            print(sources[i].name);

            if (sources[i].gameObject == this.gameObject)
            {
                audioSource_BGM = sources[i];
                sources.RemoveAt(i);
            }
        }

        audioSource_SE = sources.ToArray();
    }







    [SerializeField] SoundDatas SoundDatas;

    public float BGM_Volume
    {
        get
        {
            return BGM_Volume_var;
        }
        set
        {
            BGM_Volume_var=Mathf.Clamp01(value);
            audioSource_BGM.volume=BGM_Volume_var;
        }
    }
    float BGM_Volume_var=1;
    public float SE_Volume
    {
        get
        {
            return SE_Volume_var;
        }
        set
        {
            SE_Volume_var = Mathf.Clamp01(value);
            foreach (var item in audioSource_SE)
            {
                item.volume = SE_Volume_var;
            }
        }
    }
    float SE_Volume_var = 1;

    public int SE_Range
    {
        get
        {
            return SE_Range_var;
        }
        set
        {
            SE_Range_var = value;
            foreach (var item in audioSource_SE)
            {
                item.maxDistance = SE_Range_var;
            }
        }
    }
    int SE_Range_var = 500;

    //SEの再生 positionを指定するとその位置から再生する
    public void PlaySE(SE se,Vector3? position=null)
    {
        int index = GetSESourceIndex();

        if (position == null)
        {
            audioSource_SE[index].spatialBlend = 0;
        }
        else
        {
            audioSource_SE[index].spatialBlend = 1;
            audioSource_SE[index].gameObject.transform.position = (Vector3)position;

        }

        audioSource_SE[index].clip = SoundDatas.soundEffects[(int)se];

        audioSource_SE[index].Play();
    }

    int GetSESourceIndex()
    {
        for (int i = 0; i < audioSource_SE.Length; i++)
        {
            searchStart++;

            if (!audioSource_SE[(i+ searchStart)% audioSource_SE.Length].isPlaying)
            {
                print((i + searchStart) % audioSource_SE.Length);
                return (i + searchStart) % audioSource_SE.Length;
            }

            
        }

        searchStart++;

        print(searchStart % audioSource_SE.Length);

        return searchStart % audioSource_SE.Length;
    }
    int searchStart = 0;


    public void PlayBGM(BGM bgm)
    {

        audioSource_BGM.clip = SoundDatas.musics[(int)bgm];

        audioSource_BGM.Play();
    }


}
