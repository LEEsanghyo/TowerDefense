using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public float Monster_StartHP;
    public float Monster_HP;

    public GameObject DamagetText;
    public GameObject TextPosition;
    public GameObject Monster_HPbar;

    public void GetDamage(int damage)
    {
        GameObject damageText = Instantiate(DamagetText, TextPosition.transform.position, Quaternion.identity);
        damageText.GetComponent<Text>().text = damage.ToString();
        Monster_HP -= damage;
        Monster_HPbar.GetComponent<Image>().fillAmount = Monster_HP / Monster_StartHP;

        Destroy(damageText, 0.5f); 
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        Debug.Log(other.GetComponent<Splash>());
        GetDamage(other.GetComponent<Unit>().Damage); 
    }
}
