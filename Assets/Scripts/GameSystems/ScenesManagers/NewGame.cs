using UnityEngine.SceneManagement;
using UnityEngine;

public class NewGame : MonoBehaviour {
    public void StartNewGame() {
        SceneManager.LoadScene("NavalBattle");
    }
}
