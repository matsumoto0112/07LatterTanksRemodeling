using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Person
{
    First, Third,
}

public class CameraChangeFirstThird : MonoBehaviour
{

    [SerializeField]
    private Transform firstPersonCameraTransform;
    [SerializeField]
    private Transform thirdPersonCameraTransform;

    public Person mode { private set; get; }
    [SerializeField, Header("ゲーム開始時のモード")]
    private Person firstMode;
    [SerializeField]
    private float cameraMoveTime;
    private Camera mainCamera;

    // Use this for initialization
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        if (firstMode == Person.Third)
        {
            mode = Person.Third;
            ToThirdPersonMode();
        }
        else
        {
            mode = Person.First;
            ToFirstPersonMode();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwapMode();
        }
    }

    public void SwapMode()
    {
        if (mode == Person.First)
        {
            mode = Person.Third;
            ToThirdPersonMode();
        }
        else
        {
            mode = Person.First;
            ToFirstPersonMode();
        }
    }

    private void ToFirstPersonMode()
    {
        StartCoroutine(CameraMoveAndRotation(firstPersonCameraTransform.localPosition, firstPersonCameraTransform.localRotation));
    }

    private void ToThirdPersonMode()
    {
        StartCoroutine(CameraMoveAndRotation(thirdPersonCameraTransform.localPosition, thirdPersonCameraTransform.localRotation));
    }

    /// <summary>
    /// カメラの座標と回転を徐々に移動させる
    /// </summary>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    private IEnumerator CameraMoveAndRotation(Vector3 position, Quaternion rotation)
    {
        float time = 0.0f;
        Vector3 cameraFirstPosition = mainCamera.transform.localPosition;
        Quaternion cameraFirstRotation = mainCamera.transform.localRotation;
        while (time < cameraMoveTime)
        {
            float t = (time / cameraMoveTime);
            mainCamera.transform.localPosition = Vector3.Lerp(cameraFirstPosition, position, t);
            mainCamera.transform.localRotation = Quaternion.Slerp(cameraFirstRotation, rotation, t);
            time += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.localPosition = position;
        mainCamera.transform.localRotation = rotation;
    }
}
