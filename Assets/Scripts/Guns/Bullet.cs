﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float _speed;
    GameObject _sender;

    public void SetUp(GameObject sender)
    {
        _sender = sender;
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _sender)
            return;
        if (other.gameObject.CompareTag("Bullet"))
            return;

        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
            damageable.TakeDamage();

        Destroy(gameObject);
    }
}
