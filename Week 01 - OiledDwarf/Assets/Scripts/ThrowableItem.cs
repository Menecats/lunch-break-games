﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableItem : MonoBehaviour
{
    public ParticleSystem breakEffectPrefab;
    public float effectRadius = .6f;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, effectRadius);
        foreach (Collider item in hitColliders)
        {
            Entity e = item.gameObject.GetComponent<Entity>();

            if (e != null)
            {
                e.Die();
            }
        }
        ParticleSystem ps = Instantiate(breakEffectPrefab, transform.position, Quaternion.identity);
        Destroy(ps.gameObject, 5f);
        Destroy(gameObject);
    }
}
