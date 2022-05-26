using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseLoading : MonoBehaviour {

    void Update() {
        if (Input.touchCount > 0) {
            SceneManager.LoadScene("LoadingScreen");
        }
    }
}
