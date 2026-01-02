using UnityEngine;
using UnityEngine.UI;

public class UIController2 : MonoBehaviour
{
    public Text uiText;
    public GameObject leftUI;
    public GameObject rightUI;
    public Transform player;
    public Transform targetObjects;//1個目的地的位置
    public GameObject Area;

    public float targetAngleRange = 20f;
    public float turnAngleThreshold = 30f;
    public Quaternion initialRotation; // 初始旋轉值

                                       // private bool reachedFirstTarget = false; // 是否已經到達第一個目的地
                                       //private int targetIndex = 0; // 当前目标索引，0代表第一个目标，1代表第二个目标，依此类推
    private bool stopUpdate = false; // 是否停止Update的标志

    void Start()
    {
        // 取得初始旋轉值
        initialRotation = transform.rotation;


    }
    private void Update()
    {
        

        // 計算與初始旋轉值的差值
        Quaternion deltaRotation = Quaternion.Inverse(initialRotation) * transform.rotation;

        // 取得 y 軸角度
        float angleY = deltaRotation.eulerAngles.y;

        // 將負的角度值轉換為正的角度值
        //angleY = (angleY + 360f) % 360f;
        angleY = Mathf.Repeat(angleY, 360f);
        // 檢查是否超過180度，若是則減去360度
        //if (angleY > 180f)
        //{
        //    angleY -= 360f;
        //}

        // 四捨五入為整數
        angleY = Mathf.Round(angleY);






        // 计算头盔角度与目标角度的差值
        float angleDiff = Mathf.DeltaAngle(angleY, targetObjects.eulerAngles.y);

        // 更新UI文本显示
        uiText.text = "Ang:"+ angleY;
        //uiText.text = "Ang" + helmetYaw + "Angle Diff: " + angleDiff.ToString("F1") + " degrees";

        // 判断是否在目标角度范围内
        bool withinTargetRange = Mathf.Abs(angleDiff) <= targetObjects.eulerAngles.y;

        // 根据角度差值显示或隐藏UI界面
        if (targetObjects== player)
        {
            leftUI.SetActive(false);
            rightUI.SetActive(false);
        }
        else if (angleDiff < -turnAngleThreshold)
        {
            leftUI.SetActive(true);
            rightUI.SetActive(false);
        }
        else if (angleDiff > turnAngleThreshold)
        {
            leftUI.SetActive(false);
            rightUI.SetActive(true);
        }
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Area)
        {
            stopUpdate = true;
            leftUI.SetActive(false);
            rightUI.SetActive(false);

            if (stopUpdate)
                return;
        }
    }
}
