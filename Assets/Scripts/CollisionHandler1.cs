using UnityEngine;

public class CollisionHandler1 : MonoBehaviour
{
    public GameObject c; // 参考要切换材质的对象C
    public Material aMaterial; // 材质A
    public Material bMaterial; // 材质B

    public AudioClip mission_finish1;
    AudioSource audio_finish;
    public GameObject expmap;
   // public GameObject LeftUI;
   // public GameObject RightUI;
    public UIController1 UIC1;

    public void OnTriggerEnter(Collider Flag)
    {
        GameObject target = Flag.gameObject;
        if (Flag.gameObject.tag == "Player")
        {
            UIC1.NumberCollisions += 1;
            Renderer cRenderer = c.GetComponent<Renderer>();
            if (cRenderer != null)
            {
                cRenderer.material = bMaterial; // 将对象C的材质切换为B材质
            }
            this.audio_finish = GetComponent<AudioSource>();

            this.audio_finish.PlayOneShot(this.mission_finish1);
            Instantiate(expmap, transform.position, transform.rotation);
           // RightUI.SetActive(false);
           // LeftUI.SetActive(false);
        }
    }
}
