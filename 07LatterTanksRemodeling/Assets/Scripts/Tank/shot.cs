using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shot : MonoBehaviour {

    public int m_PlayerNumber = 1;              // さまざまなプレーヤーを識別するために使用されます。
    public int firecount = 5;                   // 弾数５
    public Rigidbody m_Shell;                   // シェルのプレハブ
    public Transform m_FireTransform;           // シェルが産卵されたタンクの子供。
    public Slider m_AimSlider;                  // 現在の発射勢力を表示するタンクの子供。
    public AudioSource m_ShootingAudio;         // 撮影用オーディオの再生に使用されたオーディオソースへの参照。 注：動きのあるオーディオソースとは異なります。
    public AudioClip m_ChargingClip;            // 各ショットが充電されると再生されるオーディオ。
    public AudioClip m_FireClip;                // 各ショットが放火されたときに再生されるオーディオ。
  //  public float m_MinLaunchForce = 15f;        // 火災ボタンが押されていない場合にシェルに与えられる力。
 //   public float m_MaxLaunchForce = 30f;        // 最大充電時間の間、火災ボタンが押された場合にシェルに与えられる力。
  //  public float m_MaxChargeTime = 0.75f;       // シェルが最大の力で発射されるまでにどれくらいの時間充電できますか？

    private bool cameraFlag;                    // カメラが三人称か一人称か
    private bool fireFlag = false;              // 撃ったかどうか
    private float m_fWaitTime = 3.0f;           // 3秒待つ
    private float m_fTime;                      
    private string m_FireButton;   // シェルを起動するために使用される入力軸。
    [SerializeField]
    private float m_CurrentLaunchForce = 1;         // fireボタンが放されたときにシェルに与えられる力。
   // private float m_ChargeSpeed;                // 最大充電時間に基づいて発射力がどのくらい速くなるか。
    private bool m_Fired;                       // このボタンを押してシェルを起動したかどうか。
    [SerializeField]
    private GameObject sprite;
    [SerializeField]
    private CameraChangeFirstThird cft;

    private void OnEnable()
    {
        // タンクがオンになったら、打ち上げ力とUIをリセットします
///m_CurrentLaunchForce = m_MinLaunchForce;
    //    m_AimSlider.value = m_MinLaunchForce;
    }
    void Start () {
        //三人称
        cameraFlag = false;
        // 射撃軸は、プレイヤー番号に基づいています。
        m_FireButton = "Fire" + m_PlayerNumber;
        //初期弾数
        firecount = 5;
        // 発射力が充電される速度は、最大充電時間による可能な力の範囲である
     //   m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(cft.mode== Person.Third)
        { return; }
        if (fireFlag == true)
        {
            m_fTime += Time.deltaTime;
        }
        if (m_fTime >= m_fWaitTime)
        {
            m_fTime =0;
            fireFlag = false;
        }

        if (firecount != 0 && fireFlag == false)
        {
            // スライダは、最小打ち上げ力のデフォルト値を持つ必要があります。
          //  m_AimSlider.value = m_MinLaunchForce;

            // 最大の力が超過し、シェルがまだ起動されていない場合...
            //if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
            //{
            //    // ...最大の力を使ってシェルを起動します。
            //    m_CurrentLaunchForce = m_MaxLaunchForce;
              
            //}
            // それ以外の場合、起動ボタンが押され始めたばかりの場合...
            if (Input.GetButtonDown(m_FireButton))
            {
                Fire();
                // ...発射された旗をリセットし、発射勢力をリセットする。
                m_Fired = false;
                //m_CurrentLaunchForce = m_MinLaunchForce;

               // // クリップを充電クリップに変更し、再生を開始します。
               //; m_ShootingAudio.clip = m_ChargingClip;
               // m_ShootingAudio.Play()
            }
            //// それ以外の場合、起動ボタンが押されていて、シェルがまだ起動していない場合は...
            //else if (Input.GetButton(m_FireButton) && !m_Fired)
            //{
            //    // 起動力を増加させ、スライダを更新します。
            //  //  m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

            //    m_AimSlider.value = m_CurrentLaunchForce;
            //}
            //// それ以外の場合、起動ボタンが放され、シェルがまだ起動されていない場合...
            //else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
            //{
            //    // ...シェルを起動
            //    Fire();
            //}
        }

    }
    private void Fire()
    {
        // firedフラグは1回だけ呼び出されるように設定します。
        m_Fired = true;
        fireFlag = true;
    
        //弾数消費
        //firecount = firecount - 1;
        // シェルのインスタンスを作成し、その剛体の参照を格納します。
        Rigidbody shellInstance =
            Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        Vector3 Direction = (sprite.transform.position - m_FireTransform.position).normalized;

        // シェルの速度を発射位置の順方向の発射力に設定します。
        shellInstance.velocity = m_CurrentLaunchForce * Direction;
        
        // クリップをファイティングクリップに変更して再生します。
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();

        // 打ち上げの力をリセットします。 これはボタンイベントがない場合の予防措置です。
       // m_CurrentLaunchForce = m_MinLaunchForce;
    }

}
