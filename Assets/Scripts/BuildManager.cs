using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager external_var;
    public GameObject SelectNode;
    public GameObject Tower;

    public void Start()
    {
        external_var = this;
    }

    public void BuildToTower()
    {
        //unity에서 제공하는 생성함수
        Instantiate(Tower, SelectNode.transform.position, Quaternion.identity); // (Tower Object, Create Location, Create Rotation)
    }
}
