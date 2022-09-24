using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField]private float speed;
    [SerializeField]private int ballCount, incomeValue,speedPrize,addBallPrize,IncomePrize;
    public int money;
    [SerializeField] private PathCreator activePathCreator;
    [SerializeField] private TextMeshProUGUI moneyText, ballCountText,speedText,IncomeText,addBallPrizeText,speedPrizeText,IncomePrizeText;
    public GameObject[] balls;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        PlayerPrefsOperation();
    }
    public void BallThrow()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");

        if (balls.Length == 0)
        {
            StartCoroutine(BallCreate());
        }

    }

    public void UpgradeBallCount()
    {
        if(money >= addBallPrize)
        {
            money -= addBallPrize;
            addBallPrize += 5;
            ballCount++;
            PlayerPrefs.SetInt("BallCount", ballCount);
            PlayerPrefs.SetInt("Money", money);
            PlayerPrefs.SetInt("AddBallPrize", addBallPrize);
            SetTextValue();
        }
    }

    public void UpgradeSpeed()
    {
        if (money >= speedPrize)
        {
            money -= speedPrize;
            speedPrize += 5;
            speed += .5f;
            PlayerPrefs.SetFloat("Speed", speed);
            PlayerPrefs.SetInt("Money", money);
            PlayerPrefs.SetInt("SpeedPrize", speedPrize);
            SetTextValue();
        }
    }

    public void Income()
    {
        if(money >= IncomePrize)
        {
            money -= IncomePrize;
            IncomePrize += 5;
            incomeValue += 1;
            PlayerPrefs.SetInt("IncomeValue", incomeValue);
            PlayerPrefs.SetInt("Money", money);
            PlayerPrefs.SetInt("IncomePrize", IncomePrize);
            SetTextValue();
        }
    }

    public void UpgradeMoney()
    {
        money += incomeValue;
        PlayerPrefs.SetInt("Money", money);
        SetTextValue();
    }

    public void SetTextValue()
    {
        moneyText.text = "Money:" + money;
        ballCountText.text = "Top Sayısı:" + ballCount;
        speedText.text = "Speed:" + speed;
        IncomeText.text = "Income:" + incomeValue;
        addBallPrizeText.text = "" + addBallPrize;
        speedPrizeText.text = "" + speedPrize;
        IncomePrizeText.text = "" + IncomePrize;

    }

    public void PlayerPrefsOperation()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
            moneyText.text = "Money:" + money;
        }
        else
        {
            PlayerPrefs.SetInt("Money", 0);
            moneyText.text ="Money:"+PlayerPrefs.GetInt("Money").ToString();
        }

        if (PlayerPrefs.HasKey("Speed"))
        {
            speed = PlayerPrefs.GetFloat("Speed");
            speedText.text = "Speed:" + speed;
        }
        else
        {
            PlayerPrefs.SetFloat("Speed", 5f);
            speed = 5f;
            speedText.text ="Speed:"+PlayerPrefs.GetFloat("Speed").ToString();
        }

        if (PlayerPrefs.HasKey("BallCount"))
        {
            ballCount = PlayerPrefs.GetInt("BallCount");
            ballCountText.text = "Top Sayısı:" + ballCount;
        }
        else
        {
            PlayerPrefs.SetInt("BallCount", 1);
            ballCount = 1;
            ballCountText.text = "Top Sayısı:" + PlayerPrefs.GetInt("BallCount").ToString();
        }
        if (PlayerPrefs.HasKey("IncomeValue"))
        {
            incomeValue = PlayerPrefs.GetInt("IncomeValue");
            IncomeText.text = "Income:" + incomeValue;
        }
        else
        {
            PlayerPrefs.SetInt("IncomeValue", 5);
            incomeValue = 5;
            IncomeText.text = "Income:" + PlayerPrefs.GetInt("IncomeValue").ToString();
        }
        if (PlayerPrefs.HasKey("AddBallPrize"))
        {
            addBallPrize = PlayerPrefs.GetInt("AddBallPrize");
            addBallPrizeText.text = "" + addBallPrize;
        }
        else
        {
            PlayerPrefs.SetInt("AddBallPrize", 5);
            addBallPrize = 5;
            addBallPrizeText.text = "" + PlayerPrefs.GetInt("AddBallPrize").ToString();
        }
        if (PlayerPrefs.HasKey("SpeedPrize"))
        {
            speedPrize = PlayerPrefs.GetInt("SpeedPrize");
            speedPrizeText.text = "" + speedPrize;
        }
        else
        {
            PlayerPrefs.SetInt("SpeedPrize", 5);
            speedPrize = 5;
            speedPrizeText.text = "" + PlayerPrefs.GetInt("SpeedPrize").ToString();
        }
        if (PlayerPrefs.HasKey("IncomePrize"))
        {
            IncomePrize = PlayerPrefs.GetInt("IncomePrize");
            IncomePrizeText.text = "" + IncomePrize;
        }
        else
        {
            PlayerPrefs.SetInt("IncomePrize", 5);
            IncomePrize = 5;
            IncomePrizeText.text = "" + PlayerPrefs.GetInt("IncomePrize").ToString();
        }
    }
    IEnumerator BallCreate()
    {
        for(int i = 0; i < ballCount; i++)
        {
            GameObject ball = Instantiate(ballPrefab);
            PathFollower ballPathFollower = ball.GetComponent<PathFollower>();
            ballPathFollower.pathCreator = activePathCreator;
            ballPathFollower.speed = speed;
            yield return new WaitForSeconds(.75f/speed);
        }
    }
}
