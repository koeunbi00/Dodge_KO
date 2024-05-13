using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text scoreText; // 추가된 부분
    public Text recordText;

    private float surviveTime;
    private float score; // 추가된 부분
    private bool isGameover;



    void Start()
    {
        surviveTime = 0;
        score = 0; // 추가된 부분
        isGameover = false;
        
    }


    void Update()
    {
        if(!isGameover){
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
            IncreaseScore(Time.deltaTime);
            

        }
        else{
            if(Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    public void EndGame(){
        isGameover = true;
        gameoverText.SetActive(true);
        float bestScore = PlayerPrefs.GetFloat("BestScore");

        if(score > bestScore){
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        recordText.text = "Best Score : " + (int)bestScore;//bestTime이 나오던 코드에서 bestScore가 나오는 코드로 수정

    }
        
    public void IncreaseScore(float amount)
    {
        score += amount;
        scoreText.text = "Score : " + (int)score;//scorebullet 닿았을 경우 추가 가능
    }// 점수를 증가시키는 함수
    
}
