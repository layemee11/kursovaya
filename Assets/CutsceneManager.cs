using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector cutsceneDirector;

    public void PlayCutscene()
    {
        // Воспроизведение катсцены
        cutsceneDirector.Play();

        // Остановка игрового времени (если нужно)
        Time.timeScale = 0f;

        // Подписываемся на событие окончания катсцены
        cutsceneDirector.stopped += OnCutsceneStopped;
    }

    private void OnCutsceneStopped(PlayableDirector director)
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Level1End");
    }
}
