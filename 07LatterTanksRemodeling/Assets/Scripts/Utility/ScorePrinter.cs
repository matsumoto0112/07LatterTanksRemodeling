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
        if (scoreText != null)
        {
            scoreText.text = "Score:" + score.score;
        }
        if (comboText != null)
        {
            comboText.text = score.comboNum + "Combo";
        }
    }
}
