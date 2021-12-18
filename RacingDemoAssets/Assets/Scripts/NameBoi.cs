using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NameBoi : MonoBehaviour
{
    public GameObject nameAnchor;
    void Start()
    {
        GetComponent<TextMeshPro>().text = nameAnchor.name;
    }

}
