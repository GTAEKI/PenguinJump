using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameOverUIScore : MonoBehaviour
{
    
    public GameObject currentScoreText;
    public GameObject bestScoreText;
    private int bestScore = 0;


    private void OnEnable()
    {
        currentScoreText.GetComponent<TextMeshProUGUI>().text = "Scroe : " + GameManager.instance.score.ToString();
        if(GameManager.instance.score > bestScore)
        {
            bestScore = GameManager.instance.score;
        }
        bestScoreText.GetComponent<TextMeshProUGUI>().text = "BestScore : " + bestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
