using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelectButton : MonoBehaviour
{
    [SerializeField] private GameObject x;
    public bool isInteratable = true;

    public void SetInteractable(bool isInteratable)
    {
        this.isInteratable = isInteratable;
        x.SetActive(!isInteratable);
    }
}
