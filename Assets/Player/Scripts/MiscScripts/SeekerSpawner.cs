using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SeekerSpawner : MonoBehaviour
{
    [SerializeField]
    public ObjectPool pool;

    public void FireGun(float val)
    {
        GameObject bullet = pool.getObj();
        if (bullet.GetComponent<BulletScript>() != null)
        {
            bullet.GetComponent<BulletScript>().damage = val;
        }

        bullet.transform.rotation = transform.rotation;
        bullet.transform.Rotate(Vector3.forward, Random.Range(-180, 180), Space.Self);
        bullet.transform.position = transform.position + (transform.forward * 2);
        //bullet.GetComponent<bulletScript>(). = transform.tag;
        bullet.SetActive(true);
    }


}
