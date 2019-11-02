using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int Damage;
    public float Range;
    public GameObject Target;
    public GameObject Splash;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    // Update is called once per frame
    void UpdateTarget()
    {
        if (Target == null)
        {
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
            float shortestDistance = Mathf.Infinity;    // 가장 짧은 거리  
            GameObject nearestMonster = null;       // 가장 가까운 몬스터
            foreach (GameObject Monster in Monsters)
            {
                float DistanceToMonsters = Vector3.Distance(transform.position, Monster.transform.position);

                if (DistanceToMonsters < shortestDistance)
                {
                    shortestDistance = DistanceToMonsters;
                    nearestMonster = Monster;
                }
            }
            if (nearestMonster != null && shortestDistance <= Range)
            {
                Target = nearestMonster;
                Attack();
            }
            else
            {
                IDLE();
                Target = null;
            }
        }
    }

    public void Attack()
    {
        anim.SetInteger("UnitAnimState", 2);
    }

    public void IDLE()
    {
        anim.SetInteger("UnitAnimState", 1);
    }

    public int getDamage()
    {
        return Damage;
    }

    public void SplashDamage()
    {
        GameObject splash = Instantiate(Splash, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
        int  con = getDamage();
        Debug.Log("con = " + con);
        splash.GetComponent<Splash>().Damage = getDamage();
        Destroy(splash, 2f);
    }


}

