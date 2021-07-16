using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    BallMovement ballMovement;
    public Text score, finishingScore, totalScore, levelCount;
    public string selectballname;

    public GameObject[] pButton;

    // public GameObject ball1,ball2;
    public GameObject[] levels;
    public GameObject[] pos;
    public GameObject finishingPanal, gameplayPanal, gameOverPanal, mainMenuPanal, ballHolder, shopPanal, settingPanal, ball1, ball2,ball3,ball4;
    private void Awake()
    {
        if(PlayerPrefs.GetInt("CurrentLevel")==20)
        {
            PlayerPrefs.SetInt("CurrentLevel",Random.RandomRange(0,19));
        }
    }
    void Start()
    {
        for (int i = 2; i < 5; i++)
        {
            OpenedBallsCheck(PlayerPrefs.GetInt("P"+i),i);
        }

        if (PlayerPrefs.GetInt("Ball") == 2)
        {
            ball1.SetActive(false);
            ball2.SetActive(true);
            ball3.SetActive(false);
            ball4.SetActive(false);
        }
        else
        {
            ball1.SetActive(true);
            ball2.SetActive(false);
            ball3.SetActive(false);
            ball4.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Ball") == 3)
        {
            ball1.SetActive(false);
            ball2.SetActive(false);
            ball3.SetActive(true);
            ball4.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Ball") == 4)
        {
            ball1.SetActive(false);
            ball2.SetActive(false);
            ball3.SetActive(false);
            ball4.SetActive(true);
        }
        ballMovement = (BallMovement)FindObjectOfType(typeof(BallMovement));
        levels[PlayerPrefs.GetInt("CurrentLevel")].SetActive(true);
        levelCount.text = PlayerPrefs.GetInt("LevelName").ToString();
        Debug.Log("level name "+ PlayerPrefs.GetInt("LevelName"));
        if (PlayerPrefs.GetInt("CurrentLevel") == 0)
        {
            ballHolder.transform.position = pos[0].transform.position;
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 1)
        {
            ballHolder.transform.position = pos[1].transform.position;
            //levelCount.text = 2.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 2)
        {
            ballHolder.transform.position = pos[2].transform.position;
            //levelCount.text = 3.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 3)
        {
            ballHolder.transform.position = pos[3].transform.position;
            //levelCount.text = 4.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 4)
        {
            ballHolder.transform.position = pos[4].transform.position;
            //levelCount.text = 5.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 5)
        {
            ballHolder.transform.position = pos[5].transform.position;
            //levelCount.text = 6.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 6)
        {
            ballHolder.transform.position = pos[6].transform.position;
            //levelCount.text = 7.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 7)
        {
            ballHolder.transform.position = pos[7].transform.position;
            //levelCount.text = 8.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 8)
        {
            ballHolder.transform.position = pos[8].transform.position;
            //levelCount.text = 9.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 9)
        {
            ballHolder.transform.position = pos[9].transform.position;
            //levelCount.text = 10.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 10)
        {
            ballHolder.transform.position = pos[10].transform.position;
            //levelCount.text = 11.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 11)
        {
            ballHolder.transform.position = pos[11].transform.position;
            //levelCount.text = 12.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 12)
        {
            ballHolder.transform.position = pos[12].transform.position;
            //levelCount.text = 13.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 13)
        {
            ballHolder.transform.position = pos[13].transform.position;
            //levelCount.text = 14.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 14)
        {
            ballHolder.transform.position = pos[14].transform.position;
            //levelCount.text = 15.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 15)
        {
            ballHolder.transform.position = pos[15].transform.position;
            //levelCount.text = 16.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 16)
        {
            ballHolder.transform.position = pos[16].transform.position;
            //levelCount.text = 17.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 17)
        {
            ballHolder.transform.position = pos[17].transform.position;
            //levelCount.text = 18.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 18)
        {
            ballHolder.transform.position = pos[18].transform.position;
            //levelCount.text = 19.ToString();
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 19)
        {
            ballHolder.transform.position = pos[19].transform.position;
            //levelCount.text = 20.ToString();
        }
        // if(selectballname == "ball1")
        // {
        //     ball1.SetActive(true);
        // }
        // if(selectballname == "ball2")
        // {
        //     ball1.SetActive(true);
        // }
    }
    void OpenedBallsCheck(int playerprefno,int buttonno)
    {
      if(playerprefno==1)
      {
      pButton[buttonno-2].SetActive(false);
      }
    }
    public void Restart()
    {
        SoundManager.instance.Click();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void PlayButton()
    {
        // SoundManager.instance.bgsource.mute = true;
        SoundManager.instance.Click();
        mainMenuPanal.SetActive(false);
        gameplayPanal.SetActive(true);
        Time.timeScale = 1;
    }
    public void Nextlevel()
    {
        PlayerPrefs.SetInt("LevelName",PlayerPrefs.GetInt("LevelName")+1);
        // SoundManager.instance.bgsource.mute = false;
        SoundManager.instance.Click();
        PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
        Time.timeScale = 1;
        SceneManager.LoadScene("Main 2");
    }

    public void purchase1()
    { 
        if(PlayerPrefs.GetInt("Score") >= 10000)
        {
            AdsScript.instance.ShowRewardedad();
            PlayerPrefs.SetInt("P2",1);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - 10000);
            totalScore.text = PlayerPrefs.GetInt("Score").ToString();
            pButton[0].gameObject.SetActive(false);
        }
    }
    public void purchase2()
    {
        if(PlayerPrefs.GetInt("Score") >= 20000)
        {
            AdsScript.instance.ShowRewardedad();
            PlayerPrefs.SetInt("P3",1);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - 20000);
            totalScore.text = PlayerPrefs.GetInt("Score").ToString();
            pButton[1].gameObject.SetActive(false);
        }
    }
    public void purchase3()
    {
        if(PlayerPrefs.GetInt("Score") >= 30000)
        {
            AdsScript.instance.ShowRewardedad();
            PlayerPrefs.SetInt("P4",1);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - 30000);
            totalScore.text = PlayerPrefs.GetInt("Score").ToString();
            pButton[2].gameObject.SetActive(false);
        }
    }
    public void selectball1()
    {
        SoundManager.instance.Click();
        ball1.SetActive(true);
        ball2.SetActive(false);
        ball3.SetActive(false);
        ball4.SetActive(false);
    }
    public void selectball2()
    {
        SoundManager.instance.Click();
        ball1.SetActive(false);
        ball2.SetActive(true);
        ball3.SetActive(false);
        ball4.SetActive(false);
    }
    public void selectball3()
    {
        SoundManager.instance.Click();
        ball1.SetActive(false);
        ball2.SetActive(false);
        ball3.SetActive(true);
        ball4.SetActive(false);
    }
    public void selectball4()
    {
        SoundManager.instance.Click();
        ball1.SetActive(false);
        ball2.SetActive(false);
        ball3.SetActive(false);
        ball4.SetActive(true);
    }
    public void OpenShopPanal()
    {
        SoundManager.instance.Click();
        mainMenuPanal.SetActive(false);
        shopPanal.SetActive(true);
    }
    public void OpenSettingPanal()
    {
        SoundManager.instance.Click();
        mainMenuPanal.SetActive(false);
        settingPanal.SetActive(true);
    }
    public void ExitPanal()
    {
        SoundManager.instance.Click();
        settingPanal.SetActive(false);
        mainMenuPanal.SetActive(true);
    }
    public void Exit()
    {
        SoundManager.instance.Click();
        Application.Quit();
    }
    public void shop()
    {
        if (ball1.activeInHierarchy)
        {
            SoundManager.instance.Click();
            PlayerPrefs.SetInt("Ball", 1);
            selectballname = "ball1";
            shopPanal.SetActive(false);
            gameplayPanal.SetActive(true);
            Time.timeScale = 1;
        }
        if (ball2.activeInHierarchy)
        {
            SoundManager.instance.Click();
            PlayerPrefs.SetInt("Ball", 2);
            selectballname = "ball2";
            shopPanal.SetActive(false);
            gameplayPanal.SetActive(true);
            Time.timeScale = 1;
        }
        if (ball3.activeInHierarchy)
        {
            SoundManager.instance.Click();
            PlayerPrefs.SetInt("Ball", 3);
            selectballname = "ball2";
            shopPanal.SetActive(false);
            gameplayPanal.SetActive(true);
            Time.timeScale = 1;
        }
        if (ball4.activeInHierarchy)
        {
            SoundManager.instance.Click();
            PlayerPrefs.SetInt("Ball", 4);
            selectballname = "ball2";
            shopPanal.SetActive(false);
            gameplayPanal.SetActive(true);
            Time.timeScale = 1;
        }
    }
    public void AudioOn()
    {
        SoundManager.instance.bgsource.mute = false;
    }
    public void AudioOff()
    {
        SoundManager.instance.bgsource.mute = true;
    }
}
