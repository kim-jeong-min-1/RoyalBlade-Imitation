using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextPool : Singleton<DamageTextPool>
{
    [SerializeField] private Queue<DamageText> objects = new Queue<DamageText>();
    [SerializeField] private DamageText poolObject;

    public void GetText(Vector3 pos, float damage)
    {
        DamageText t;

        if (objects.Count != 0) t = objects.Dequeue();
        else t = Instantiate(poolObject, transform);

        t.transform.position = pos;
        t.gameObject.SetActive(true);
        t.StartCoroutine(t.DamageText_Update(damage, ReturnText));
    }

    public void ReturnText(DamageText t)
    {
        t.gameObject.SetActive(false);
        objects.Enqueue(t);
    }
}
