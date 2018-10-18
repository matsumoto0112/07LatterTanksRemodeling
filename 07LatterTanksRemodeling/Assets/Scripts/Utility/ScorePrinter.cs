using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrinter : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text comboText;

    private Score score;

    private void Start()
    {
        score = Score.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "スコア:" + score.score;
        comboText.text = "コンボ:" + score.comboNum;
    }
}
