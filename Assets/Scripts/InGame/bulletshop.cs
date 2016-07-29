using UnityEngine;
using System.Collections;

public class bulletshop : MonoBehaviour {
    public GameObject bullet;

    void shot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        Debug.Log("dadf");
    }
}
