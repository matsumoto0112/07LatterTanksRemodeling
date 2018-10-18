using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static Score instance;
    /// <summary>
    /// インスタンスの取得
    /// </summary>
    public static Score Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("Score");
                instance = obj.AddComponent<Score>();
            }
            return instance;
        }
    }
    private int comboBonus;
    private float comboWaitTime;

    /// <summary>
    /// コンボ回数
    /// </summary>
    public int comboNum { private set; get; }

    private Coroutine comboCoroutine; //コンボ間時間計測コルーチン

    /// <summary>
    /// スコア
    /// </summary>
    public int score { private set; get; }

    public Score()
    {
        Init();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Init()
    {
        score = 0;
        comboNum = 0;
        comboWaitTime = 1.0f;
        comboBonus = 1000;
        if (comboCoroutine != null)
        {
            StopCoroutine(comboCoroutine);
        }
        comboCoroutine = null;
    }

    /// <summary>
    /// 加算
    /// </summary>
    /// <param name="score"></param>
    public void Add(int score)
    {
        AddScore(score);
        AddCombo();
        ComboCoroutineStart();
    }

    private void AddScore(int num)
    {
        this.score += num;
    }

    private void AddCombo()
    {
        comboNum++;
        if (!(comboNum % 10 == 0)) return;
        AddBonus(comboBonus);
    }

    private void AddBonus(int bonus)
    {
        this.score += bonus;
    }

    private void ComboCoroutineStart()
    {
        if (comboCoroutine != null)
        {
            StopCoroutine(comboCoroutine);
        }
        comboCoroutine = null;
        comboCoroutine = StartCoroutine(Combo(comboWaitTime));
    }

    /// <summary>
    /// 減算
    /// </summary>
    /// <param name="score"></param>
    public void Subscibe(int score)
    {
        this.score -= score;
    }

    private IEnumerator Combo(float comboWaitTime)
    {
        float time = 0.0f;
        while (time < comboWaitTime)
        {
            time += Time.deltaTime;
            yield return null;
        }
        comboNum = 0;
    }
}
