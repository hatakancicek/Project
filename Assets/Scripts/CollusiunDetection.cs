using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollusiunDetection : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D col) {
        GameObject g = col.gameObject;
        print(g.name);
    }
}
