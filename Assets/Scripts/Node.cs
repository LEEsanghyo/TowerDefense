using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color StartColor;
    public Color SelectColor;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
    }

    // Update is called once per frame
   private  void OnMouseUp()
    {
        rend.material.color = SelectColor;
        BuildManager.external_var.SelectNode = this.gameObject;
    }
}
