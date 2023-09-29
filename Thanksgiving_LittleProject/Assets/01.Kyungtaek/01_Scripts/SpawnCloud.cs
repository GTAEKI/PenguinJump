using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : MonoBehaviour
{
    // 구름 스폰 포인트
    public GameObject[] spawnPoint;

    // 구름 4개당 1개는 검정구름이 나오도록 구름 갯수체크
    private int cloudCount;

    // 검정구름 흰구름 프리펩
    public GameObject whiteCloud;
    public GameObject blackCloud;

    // 코루팀 참조를 위한 변수
    private Coroutine cloudSpawnCoroutine;

    private void Start()
    {
        GameManager.GameStartEvent += StartSpawnCloud;
        GameManager.GamePauseEvent += PauseSpawnCloud;
    }

    // 구름생성 시작 함수
    public void StartSpawnCloud()
    {
        Debug.Log("구름 스포너 함수");
        cloudSpawnCoroutine = StartCoroutine(CreateClouds());
    }

    IEnumerator CreateClouds()
    {
        while (true)
        {
            int randomPoint = Random.Range(0, 3);

            if(cloudCount == 4)
            {
                cloudCount = 0;
                Instantiate(blackCloud, spawnPoint[randomPoint].transform.position, Quaternion.identity);
                Debug.Log("검정 구름 생성");
            }
            else
            {
                cloudCount += 1;
                Instantiate(whiteCloud, spawnPoint[randomPoint].transform.position, Quaternion.identity);
                Debug.Log("흰 구름 생성");
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    // 구름생성 정지 함수
    public void PauseSpawnCloud()
    {
        StopCoroutine(cloudSpawnCoroutine);
    }
}
