using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    [SerializeField]private int accessoryNum = 8;
    [SerializeField] private GameObject accessory = null;
    [SerializeField] private GameObject accSpwan;
    [SerializeField] private float radius = 1.5f;

    private List<ObjectManager> accList = new List<ObjectManager>();    

    void Start()
    {
        for(int i= 0; i<accessoryNum; i++)
        {
            GameObject accGameObj = Instantiate(accessory);
            accGameObj.transform.SetParent(accSpwan.transform);

            float angle = i * Mathf.PI * 2 / accessoryNum;
            Vector3 position = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            accGameObj.transform.localPosition = position;

            ObjectManager acc = accGameObj.GetComponent<ObjectManager>();

            accList.Add(acc);
        }
        
    }

    void Update()
    {
        
    }
}
