using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text uiText;
    public GameObject leftUI;
    public GameObject rightUI;
    public Transform player;
    public Transform targetObjects;

    public Transform secondTargetObjects; // 第二個目的地的位置
    public Transform thirdTargetObjects; // 第三个目的地的位置
    public float targetAngleRange = 20f;
    public float turnAngleThreshold = 30f;

    private bool reachedFirstTarget = false; // 是否已經到達第一個目的地
    private int targetIndex = 0; // 当前目标索引，0代表第一个目标，1代表第二个目标，依此类推

    public GameObject turnTrigger; // 触发转向的空物体
    public GameObject Point2;
    public GameObject Point3;
    public GameObject Point4;

    private void Update()
    {
        // 获取头盔y轴转动的角度
        float helmetYaw = player.rotation.eulerAngles.y;

        // 将视角正前方定义为0度，转向正后方为180度或-180度
        float targetAngle = Mathf.Atan2(targetObjects.position.x - player.position.x, targetObjects.position.z - player.position.z) * Mathf.Rad2Deg;
        targetAngle = Mathf.Repeat(targetAngle + 180f, 360f) - 180f;

        // 计算头盔角度与目标角度的差值
        float angleDiff = Mathf.DeltaAngle(helmetYaw, targetAngle);

        // 更新UI文本显示
        uiText.text = "Angle Diff: " + angleDiff.ToString("F1") + " degrees";

        // 判断是否在目标角度范围内
        bool withinTargetRange = Mathf.Abs(angleDiff) <= targetAngleRange;

        // 根据角度差值显示或隐藏UI界面
        if (withinTargetRange)
        {
            leftUI.SetActive(false);
            rightUI.SetActive(false);
        }
        else if (angleDiff < -turnAngleThreshold && !gameObject == turnTrigger)
        {
            leftUI.SetActive(true);
            rightUI.SetActive(false);
        }
        else if (angleDiff > turnAngleThreshold)
        {
            leftUI.SetActive(false);
            rightUI.SetActive(true);
        }
        else
        {
            
             
                leftUI.SetActive(false);
                rightUI.SetActive(false);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flag") && targetIndex == 0)
        {
            targetIndex++;
            targetObjects = secondTargetObjects; // 切换到第二个目标
        }
        else if (other.CompareTag("Flag") && targetIndex == 1)
        {
            targetIndex++;
            targetObjects = thirdTargetObjects; // 切换到第三个目标
        }



        // 触发转向的空物体碰撞检测
        if (other.gameObject == turnTrigger)
        {
            leftUI.SetActive(false);
            rightUI.SetActive(true);
        }

        // 触发转向的空物体碰撞检测
        if (other.gameObject == Point3)
        {
            leftUI.SetActive(false);
            rightUI.SetActive(false);
        }

    }

    void OnTriggerExit(Collider other)
    {
        // 触发转向的空物体碰撞检测
        if (other.gameObject == Point2)
        {
            leftUI.SetActive(false);
            rightUI.SetActive(false);
        }
    }
}
