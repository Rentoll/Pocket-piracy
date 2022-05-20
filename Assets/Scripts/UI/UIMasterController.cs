using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMasterController : MonoBehaviour {
    [SerializeField]
    GameObject[] UIElementsToHide;
    
    public void HideUI() {
        foreach (GameObject element in UIElementsToHide) {
            element.SetActive(false);
        }
    }

    public void ShowUI() {
        foreach (GameObject element in UIElementsToHide) {
            element.SetActive(true);
        }
    }
    
}
