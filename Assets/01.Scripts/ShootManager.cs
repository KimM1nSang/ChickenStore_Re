using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootManager : MonoBehaviour
{
    public int curBullet = 0;//�Ѿ� ����
    public int MaxBullet = 3;//�Ѿ� �ִ�
    private const int bulletLimit = 3;//�Ѿ˰����� �Ѱ�
    public Image[] BulletImage = null;//�Ѿ��� ������ �˷��� UI

    private void Start()
    {
        curBullet = MaxBullet;
    }
    public bool Shoot()
    {
        if(curBullet > 0)
        {
            curBullet--;//�Ѿ� �Ҹ�
            BulletImage[curBullet].color = new Color(0, 0, 0); //�Ѿ� �Ҹ� �̹��� ��ȯ
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
