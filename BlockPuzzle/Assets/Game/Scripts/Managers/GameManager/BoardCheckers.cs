using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCheckers : MonoBehaviour {
    public RaycastHit2D ShootRay() {
        return Physics2D.Raycast(transform.position + transform.forward, transform.forward, 8);
    }
    public bool Check() { 
        if (ShootRay()) {
            if (ShootRay().transform.gameObject.layer == 10)
                return true;
            else return false;
        } else return false;
    }
    public GameObject CheckObject() {
        if (ShootRay()) {
            if (ShootRay().transform.gameObject.layer == 10)
                return ShootRay().transform.gameObject;
            else return null;
        } else return null;
    }
}
