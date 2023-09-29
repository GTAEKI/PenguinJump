using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameStartAndPause();

public class GameManager : MonoBehaviour
{
    //싱글톤 패턴 Instance
    private static GameManager instance;

    public bool isGameStart = false;

    //게임 시작 및 정지 이벤트
    public static event GameStartAndPause GameStartEvent;
    public static event GameStartAndPause GamePauseEvent;

    // TIME 관련 변수
    private const int BASIC_SET_TIME = 15; // 초기 게임 설정시간
    private float remainTime;
    public int countWhiteCloud; // 흰구름 3번 밟을경우 1초 추가

    // 거리 관련 변수
    private float myDistance;

    // 점수 관련 변수
    public int Score = 0;


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
    }

    private void Update()
    {
        //게임 시작
        GameStart();

        if (!isGameStart) return; //게임이 시작되지 않았다면 나머지 기능 동작 x

        //게임 정지
        GamePause();

        //거리 증가
        IncreaseDistance();

        //게임 종료
        GameOver();
    }


    //게임 종료
    private void GameOver()
    {
        if(remainTime <= 0)
        {
            // TODO 게임 종료
        }
    }

    //거리 증가
    private void IncreaseDistance()
    {
        myDistance += Time.deltaTime;
    }

    //게임 정지
    private void GamePause()
    {
        if (isGameStart && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("게임 정지");

            GamePauseEvent();

            //GameObject SpawnClouds = GameObject.Find("CloudSpawners");
            //SpawnClouds.GetComponent<SpawnCloud>().PauseSpawnCloud();
            

            //TODO 게임정지
            //1) Pause 이미지
            //2) 구름 생성 정지
            //3) 시간 흐름 정지
        }
    }

    //게임 시작
    private void GameStart()
    {
        //게임이 시작되지 않았고, 화면을 터치
        if (!isGameStart && Input.GetMouseButtonDown(0))
        {
            //TODO 게임시작
            //1) Touch for start 이미지 setActive(false);
            //2) 구름 생성
            //3) 변수 초기화

            GameStartEvent();

            //GameObject SpawnClouds = GameObject.Find("CloudSpawners");
            //SpawnClouds.GetComponent<SpawnCloud>().StartSpawnCloud();

            remainTime = BASIC_SET_TIME; // 초기 시작시간으로 초기화
            isGameStart = true;
        }
    }

    //TODO 점수 계산
    //1) 흰 구름 5개 밟으면 1초 추가
    //2) 검정 구름 1개 부딪힐 경우 3초 감소
}
