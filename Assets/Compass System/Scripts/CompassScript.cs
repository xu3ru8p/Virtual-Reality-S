using UnityEngine;

public class CompassScript : MonoBehaviour
{
    //public Transform playerTransform;   // 玩家的位置變換
    public Transform northTransform;    // 指北針指向的方向

    //public Transform needle; // 指针的Transform组件
    public Transform needleTip;         // 指针的尖端位置，即指针中心点所在的子对象

    void Start()
    {
        // 在開始時將指北針的位置設定為相對於玩家的位置
        //transform.position = playerTransform.position + new Vector3(0, 0, 2); // 將指北針的位置設定為玩家位置上方2個單位
    }
    void Update()
    {
        // 更新指北針的位置，以使其始終保持相對於玩家的位置
        //transform.position = playerTransform.position + new Vector3(0, 0, 2); // 將指北針的位置設定為玩家位置上方2個單位

        // 將指北針的y軸設置為玩家的y軸，使其始終朝向玩家的方向
        //Vector3 northPos = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
        //transform.LookAt(northPos);

        // 將指北針的x軸旋轉到世界的北方
        northTransform.rotation = Quaternion.Euler(0, 0,0 );

        // 使指针的尖端位置保持不变
        northTransform.position = needleTip.position;


        // 移動指北針的Z軸位置，保持Y軸不變
        northTransform.position = new Vector3(northTransform.position.x, northTransform.position.y, transform.position.z);

    }
}
