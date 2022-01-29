using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
    [SerializeField]
    private GameObject[] planks;

    private short currentPlank = 0;
    private bool repaired = false;

    public void holeActivation() {
        currentPlank = 0;
        repaired = false;
        foreach (GameObject plank in planks) {
            plank.SetActive(false);
        }
    }

    private void Update() {
       
    }

    public void addPlank() {
        if (currentPlank < planks.Length) {
            planks[currentPlank++].SetActive(true);
        }
        if(currentPlank == planks.Length) {
            repaired = true;
        }
    }

    public bool checkStatus() {
        if(repaired)
            return true;
        return false;
    }
}
