using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    UIManager uIManager;
    public Rigidbody rb;
    public float xforce = 2f;
    public float yforce = 2f;
    private int scoreText = 0;
    bool isJump = true;
    private void Awake()
    {
        uIManager = (UIManager)FindObjectOfType(typeof(UIManager));
    }
    void Start()
    {
        AdsScript.instance.ShowBottomCentertBanner();
        uIManager.totalScore.text = PlayerPrefs.GetInt("Score").ToString();
        // if (PlayerPrefs.GetString("ball")== "ball1")
        // {
        //     uIManager.ball1.SetActive(true);
        // }
        // if (PlayerPrefs.GetString("ball")== "ball2")
        // {
        //     uIManager.ball2.SetActive(true);
        // }
        // if (uIManager.selectballname == "ball1")
        // {
        //     uIManager.ball1.SetActive(true);
        // }
        // if (uIManager.selectballname == "ball2")
        // {
        //     uIManager.ball2.SetActive(true);            
        // }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (uIManager.gameplayPanal.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0) && rb.velocity.magnitude <= 2)
            {
                SoundManager.instance.Press();
                Movement();
            }
        }
    }
    private void Update()
    {
        // if (Time.deltaTime==0&&Input.GetMouseButtonDown(0))
        // {
        //     Time.timeScale=1;
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
        // }
    }
    void Movement()
    {
        rb.AddForce(xforce, yforce, 0, ForceMode.Impulse);
        rb.AddTorque(0f, 0f, -0.2f);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Sliceable" && other.gameObject.tag == "Coin")
        {
            rb.velocity = Vector3.zero;
        }
        if (other.collider.tag == "Faild")
        {
            AdsScript.instance.ShowInterstitial();
            SoundManager.instance.Failed();
            uIManager.gameOverPanal.SetActive(true);
            uIManager.gameplayPanal.SetActive(false);   
            Time.timeScale = 0;
        }
        if (other.gameObject.tag == "Red")
        {
            rb.AddForce(5f, 6f, 0f, ForceMode.Impulse);
            rb.AddTorque(0f, 0f, -5f);
        }
        if (other.gameObject.tag == "Sliceable")
        {
            SoundManager.instance.Failed();
            scoreText++;
            uIManager.score.text = scoreText.ToString();
        }
        if (other.gameObject.tag == "Coin")
        {
            SoundManager.instance.Failed();
            scoreText++;
            uIManager.score.text = scoreText.ToString();
        }
        if (other.gameObject.tag == "50x")
        {
            AdsScript.instance.ShowRewardedad();
            SoundManager.instance.Reward();
            scoreText *= 50;
            uIManager.finishingScore.text = scoreText.ToString();
            // uIManager.totalScore.text = scoreText.ToString() + uIManager.finishingScore.text;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scoreText);
            uIManager.totalScore.text = PlayerPrefs.GetInt("Score").ToString();
            uIManager.finishingPanal.SetActive(true);
            uIManager.gameplayPanal.SetActive(false);
            Time.timeScale = 0;
        }
        if (other.gameObject.tag == "10x")
        {
            AdsScript.instance.ShowInterstitial();
            SoundManager.instance.Reward();
            scoreText *= 10;
            uIManager.finishingScore.text = scoreText.ToString();
            // uIManager.totalScore.text = scoreText.ToString() + uIManager.finishingScore.text;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scoreText);
            uIManager.totalScore.text = PlayerPrefs.GetInt("Score").ToString();
            uIManager.finishingPanal.SetActive(true);
            uIManager.gameplayPanal.SetActive(false);
            Time.timeScale = 0;
        }
        if (other.gameObject.tag == "8x")
        {
            SoundManager.instance.Reward();
            scoreText *= 8;
            uIManager.finishingScore.text = scoreText.ToString();
            // uIManager.totalScore.text = scoreText.ToString() + uIManager.finishingScore.text;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scoreText);
            uIManager.totalScore.text = PlayerPrefs.GetInt("Score").ToString();
            uIManager.finishingPanal.SetActive(true);
            uIManager.gameplayPanal.SetActive(false);
            Time.timeScale = 0;
        }
        if (other.gameObject.tag == "6x")
        {
            SoundManager.instance.Reward();
            scoreText *= 6;
            uIManager.finishingScore.text = scoreText.ToString();
            // uIManager.totalScore.text = scoreText.ToString() + uIManager.finishingScore.text;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scoreText);
            uIManager.totalScore.text = PlayerPrefs.GetInt("Score").ToString();
            uIManager.finishingPanal.SetActive(true);
            uIManager.gameplayPanal.SetActive(false);
            Time.timeScale = 0;
        }
        if (other.gameObject.tag == "5x")
        {
            SoundManager.instance.Reward();
            scoreText *= 5;
            uIManager.finishingScore.text = scoreText.ToString();
            // uIManager.totalScore.text = scoreText.ToString() + uIManager.finishingScore.text;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scoreText);
            uIManager.totalScore.text = PlayerPrefs.GetInt("Score").ToString();
            uIManager.finishingPanal.SetActive(true);
            uIManager.gameplayPanal.SetActive(false);
            Time.timeScale = 0;
        }
        if (other.gameObject.tag == "4x")
        {
            SoundManager.instance.Reward();
            scoreText *= 4;
            uIManager.finishingScore.text = scoreText.ToString();
            // uIManager.totalScore.text = scoreText.ToString() + uIManager.finishingScore.text;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scoreText);
            uIManager.totalScore.text = PlayerPrefs.GetInt("Score").ToString();
            uIManager.finishingPanal.SetActive(true);
            uIManager.gameplayPanal.SetActive(false);
            Time.timeScale = 0;
        }
        if (other.gameObject.tag == "3x")
        {
            SoundManager.instance.Reward();
            scoreText *= 3;
            uIManager.finishingScore.text = scoreText.ToString();
            // uIManager.totalScore.text = scoreText.ToString() + uIManager.finishingScore.text;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scoreText);
            uIManager.totalScore.text = PlayerPrefs.GetInt("Score").ToString();
            uIManager.finishingPanal.SetActive(true);
            uIManager.gameplayPanal.SetActive(false);
            Time.timeScale = 0;
        }
        if (other.gameObject.tag == "2x")
        {
            SoundManager.instance.Reward();
            scoreText *= 2;
            uIManager.finishingScore.text = scoreText.ToString();
            // uIManager.totalScore.text = scoreText.ToString() + uIManager.finishingScore.text;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scoreText);
            uIManager.totalScore.text = PlayerPrefs.GetInt("Score").ToString();
            uIManager.finishingPanal.SetActive(true);
            uIManager.gameplayPanal.SetActive(false);
            Time.timeScale = 0;
        }
        if (other.gameObject.tag == "1x")
        {
            SoundManager.instance.Reward();
            uIManager.finishingScore.text = scoreText.ToString();
            // uIManager.totalScore.text = scoreText.ToString() + uIManager.finishingScore.text;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scoreText);
            uIManager.totalScore.text = PlayerPrefs.GetInt("Score").ToString();
            uIManager.finishingPanal.SetActive(true);
            uIManager.gameplayPanal.SetActive(false);
            Time.timeScale = 0;
        }
        // PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+scoreText);
        // uIManager.totalScore.text=PlayerPrefs.GetInt("Score").ToString();
    }
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.1f);
        isJump = true;
    }
}
