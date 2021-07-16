using System.Collections.Generic;
using System.Collections;
using UnityEngine;
public class GameManager : MonoBehaviour

{
    public static GameManager Instance
    {
        get
        {
            if(instance==null)
            instance=new GameObject("GameManager").AddComponent<GameManager>();
            return instance;
        }
    }

private static GameManager instance=null;
    void Awake()
    {
       if(instance)
       {
           DestroyImmediate(gameObject);
       }
       else
       {
           instance=this;
           DontDestroyOnLoad(gameObject);

           //use your playerprefs and code
                if (!PlayerPrefs.HasKey("CurrentLevel"))
                {
                    PlayerPrefs.SetInt("CurrentLevel", 0);
                }
                if (!PlayerPrefs.HasKey("TotalScore"))
                {
                    PlayerPrefs.SetInt("TotalScore", 0);
                }
                if (!PlayerPrefs.HasKey("ball"))
                {
                    PlayerPrefs.SetInt("ball", 1);
                }
                if (!PlayerPrefs.HasKey("Score"))
                {
                    PlayerPrefs.SetInt("Score", 500);
                }
                if (!PlayerPrefs.HasKey("P2"))
                {
                    PlayerPrefs.SetInt("P2", 0);
                }
                if (!PlayerPrefs.HasKey("P3"))
                {
                    PlayerPrefs.SetInt("P3", 0);
                }
                if (!PlayerPrefs.HasKey("P4"))
                {
                    PlayerPrefs.SetInt("P4", 0);
                }
                if(!PlayerPrefs.HasKey("LevelName"))
                {
                    PlayerPrefs.SetInt("LevelName",1);
                }
                Debug.Log("game manager ok he");
           }
       }

    }