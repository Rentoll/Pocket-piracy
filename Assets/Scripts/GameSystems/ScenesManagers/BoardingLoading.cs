using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardingLoading : MonoBehaviour {

    void Update() {
        if(Input.touchCount > 0) {
            SceneManager.LoadScene("BoardingBattle");
        }
    }
}
