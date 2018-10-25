using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSceneChanger : MonoBehaviour
{
    [SerializeField]
    private List<KeyCode> sceneChangerKeys;
    [SerializeField]
    private SceneName next;

    // Update is called once per frame
    void Update()
    {
        foreach (var key in sceneChangerKeys)
        {
            if (Input.GetKeyDown(key))
            {
                SceneChanger.Instance().Change(next);
            }
        }
    }
}
