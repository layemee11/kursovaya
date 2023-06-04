using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector cutsceneDirector;

    public void PlayCutscene()
    {
        // ��������������� ��������
        cutsceneDirector.Play();

        // ��������� �������� ������� (���� �����)
        Time.timeScale = 0f;

        // ������������� �� ������� ��������� ��������
        cutsceneDirector.stopped += OnCutsceneStopped;
    }

    private void OnCutsceneStopped(PlayableDirector director)
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Level1End");
    }
}
