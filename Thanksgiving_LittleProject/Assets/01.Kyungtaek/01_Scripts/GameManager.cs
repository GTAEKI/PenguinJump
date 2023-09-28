using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤 패턴 Instance
    private static GameManager instance;

    private void Awake()
    {
        //싱글톤 패턴
        if(instance != null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {           
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }
}
