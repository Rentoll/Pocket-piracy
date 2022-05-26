using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoading : MonoBehaviour {

    void Update() {
        if (Input.touchCount > 0) {
            SceneManager.LoadScene("NavalBattle");
        }
    }
}
