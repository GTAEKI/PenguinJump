using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //텍스트 메쉬 프로
    TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        scoreText.text = GameManager.instance.score.ToString();
    }
}
