using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameStartAndPause();

public class GameManager : MonoBehaviour
{
    //싱글톤 패턴 Instance
    public static GameManager instance;

    public bool isGameStart = false;
    public GameObject gameOverUI;
    public GameObject gameStartUI;

    //게임 시작 및 정지 이벤트
    public static event GameStartAndPause GameStartEvent;
    public static event GameStartAndPause GameOverEvent;

    // 점수 관련 변수
    public int score = 0;

    public AudioClip gamePlaySound;

    private void Awake()
    {
        //싱글톤 패턴
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {           
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        isGameStart = false;
        gameStartUI.SetActive(true);

        AudioManager.instance.PlayMusicLoop(gamePlaySound);
    }

    private void Update()
    {
        //게임 시작
        GameStart();

        if (!isGameStart) return; //게임이 시작되지 않았다면 나머지 기능 동작 x

        //게임 정지
        GamePause();
    }


    //게임 종료
    public void GameOver()
    {
        isGameStart = false;
        Time.timeScale = 0.0f;
        gameOverUI.SetActive(true);
        GameOverEvent();
    }

    //게임 정지
    private void GamePause()
    {
        if (isGameStart && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("게임 정지");
            Time.timeScale = 0.0f;
            isGameStart = false;
        }
    }

    //게임 시작
    public void GameStart()
    {
        //게임이 시작되지 않았고, 화면을 터치
        if (!isGameStart && Input.GetMouseButtonDown(0))
        {
            
            GameStartEvent();
            isGameStart = true;
            score = 0;
            
            Time.timeScale = 1.0f;
            DestroyClouds();
            gameOverUI.SetActive(false);
            gameStartUI.SetActive(false);
        }
    }

    private void DestroyClouds()
    {
        // BlackCloud 또는 WhiteCloud 스크립트를 가진 모든 오브젝트를 찾습니다.
        BlackCloud[] blackClouds = FindObjectsOfType<BlackCloud>();
        WhiteCloud[] whiteClouds = FindObjectsOfType<WhiteCloud>();

        // 모든 BlackCloud 오브젝트를 삭제합니다.
        foreach (var blackCloud in blackClouds)
        {
            Destroy(blackCloud.gameObject);
        }

        // 모든 WhiteCloud 오브젝트를 삭제합니다.
        foreach (var whiteCloud in whiteClouds)
        {
            Destroy(whiteCloud.gameObject);
        }
    }
}
