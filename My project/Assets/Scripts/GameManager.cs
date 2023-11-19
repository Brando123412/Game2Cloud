using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text textScore;
    [SerializeField] GameObject planerScore;
    float score;
    public void Start(){
        Time.timeScale = 1;
    }
    private void Update() {
        score+= Time.deltaTime;
    }
    public void LoseEvento(){
        planerScore.SetActive(true);
        Time.timeScale = 0;
        float scoreRound=Mathf.Round(score);
        textScore.text ="Score: " +scoreRound.ToString();
    }
}
