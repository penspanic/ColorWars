using UnityEngine;
using System.Collections;

public class bulletweapon : MonoBehaviour {
    public GameObject player;
    public int weaponnum;
    public GameObject bulletluncher1;
    public GameObject bulletluncher2;
    public GameObject bulletluncher3;
    public GameObject bulletluncher4;
    public GameObject bulletluncher5;

    void bulletshot()
    {
        weaponnum = player.GetComponent<Player>().levelnum;
        if (weaponnum == 1)
        {
            bullet1();
        }
        if (weaponnum == 2)
        {
            bullet2();
        }
        if (weaponnum == 3)
        {
            bullet3();
        }
    }

    void bullet1()
    {
        bulletluncher1.SendMessage("shot");
    }
    void bullet2()
    {
        bulletluncher1.SendMessage("shot");
        bulletluncher2.SendMessage("shot");
        bulletluncher3.SendMessage("shot");
    }
    void bullet3()
    {
        bulletluncher1.SendMessage("shot");
        bulletluncher2.SendMessage("shot");
        bulletluncher3.SendMessage("shot");
        bulletluncher4.SendMessage("shot");
        bulletluncher5.SendMessage("shot");
    }
}
