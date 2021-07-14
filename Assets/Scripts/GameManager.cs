using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficRacer
{
    /// <summary>
    /// Script which keep track of game status and selected car 
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        UIManager uIManager;
        public static GameManager singeton;
        // [HideInInspector] public GameStatus gameStatus = GameStatus.NONE;
        [HideInInspector] public int currentCarIndex = 0;

        private void Start()
        {

        }
        private void Awake()
        {
            if (singeton == null)
            {
                singeton = this;
                DontDestroyOnLoad(gameObject);
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
                // if (!PlayerPrefs.HasKey("ball2"))
                // {
                //     PlayerPrefs.SetInt("ball2", 2);
                // }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}