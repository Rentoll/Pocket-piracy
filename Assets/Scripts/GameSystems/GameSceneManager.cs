using UnityEngine.SceneManagement;
using UnityEngine;

public class GameSceneManger : MonoBehaviour {
    //NavalBattle BoardingBattle LoadingScreen

    [SerializeField]
    private GameObject[] Scenes;

    public void StartNewGame() {
        LoadScene("NavalBattle");
    }

    private void Start() {
        Scenes[0].SetActive(true);
    }

    private void LoadScene(string sceneName) {
        switch(sceneName) {
            case "NavalBattle":
                break;
            default:
                break;
        }
        //SceneManager.LoadScene(sceneName);
    }
}
