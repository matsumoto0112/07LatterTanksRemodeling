using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    [SerializeField, Header("ゲームの制限時間")]
    private float limitTime;

    private void Start()
    {
        StartCoroutine(LimitUpdate(limitTime));
    }

    private IEnumerator LimitUpdate(float limitTime)
    {
        yield return new WaitForSeconds(limitTime);
        SceneChanger.Instance().Change(SceneName.Result);
    }
}
