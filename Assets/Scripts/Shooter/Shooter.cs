using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private List<BulletData> bulletDatas;
    [SerializeField] private Transform shootPoint;
    private static Vector3 bulletPoolPos = new Vector3(1000, -1000, 1000);
    private void Start()
    {
        GameObject parent = new GameObject(transform.name + "Bullet Pool");
        parent = Instantiate(parent);
        foreach (var data in bulletDatas) {
            data.CreatePool();
            for (int i = 0; i < data.bulletPoolSize; i++)
            {
                GameObject bullet = Instantiate(Resources.Load(data.bulletObject.bulletPath) as GameObject, parent.transform);
                BulletController controller = bullet.GetComponent<BulletController>();
                controller.OnInst(ref data.notActiveBullets, bulletPoolPos, shootPoint);
            }
        }

    }

    public virtual void Shoot(int id) {
        BulletData data = bulletDatas[id];
        if (data.notActiveBullets.Count > 0) {
            data.notActiveBullets[0].Shoot();
        }
    }


    [Serializable]
    public class BulletData{
        public BulletSerializeObject bulletObject;
        public int bulletPoolSize;
        public List<BulletController> notActiveBullets;
        public void CreatePool() {
            notActiveBullets = new List<BulletController>();
        }
    }
}
