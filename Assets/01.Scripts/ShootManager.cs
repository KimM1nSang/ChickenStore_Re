using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootManager : MonoBehaviour
{
    public int curBullet = 0;//ÃÑ¾Ë °¹¼ö
    public int MaxBullet = 3;//ÃÑ¾Ë ÃÖ´ë
    private const int bulletLimit = 3;//ÃÑ¾Ë°¹¼öÀÇ ÇÑ°è
    public Image[] BulletImage = null;//ÃÑ¾ËÀÇ °¹¼ö¸¦ ¾Ë·ÁÁÙ UI

    private void Start()
    {
        curBullet = MaxBullet;
    }
    public bool Shoot()
    {
        if(curBullet > 0)
        {
            curBullet--;//ÃÑ¾Ë ¼Ò¸ð
            BulletImage[curBullet].color = new Color(0, 0, 0); //ÃÑ¾Ë ¼Ò¸ð ÀÌ¹ÌÁö º¯È¯
            return true;
        }
        return false;
    }
    public void ReLoad()
    {
        curBullet = MaxBullet;
        foreach (var item in BulletImage)
        {
            item.color = Color.white;
        }
    }
}
