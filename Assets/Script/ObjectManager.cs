using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public bool isDrag;
    Rigidbody2D rigid;

    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z=0;
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.1f);
        }
    }
    public void Drop()
    {
        isDrag = false;
    }
    public void Drag()
    {
        isDrag = true;
        rigid.simulated = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Doll")
        {
            Destroy(gameObject);
        }
    }
    
    
}
