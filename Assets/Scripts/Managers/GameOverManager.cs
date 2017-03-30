using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    // 배경 음악 끄려고 추가한 것
    // public AudioSource backgroudMusic;
    // 백그라운드 음악을 건드릴 수 있는
    // playerHealth 같은 걸 만들어야하는 것 같다.

    Animator anim;
    float restartTimer;

    void Awake()
    {
        anim = GetComponent<Animator>();

        // 배경 음악 끄려고 추가한 것
        //backgroudMusic = GetComponent<AudioSource>();

    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            // 배경 음악 끄려고 추가한 것
            //backgroudMusic.Stop();


            // 게임 반복 시작을 그만둠
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                //Application.LoadLevel(Application.loadedLevel);
                // 씬 불러오는 코드였다..ㅎ
                SceneManager.LoadScene("Level01");
                //SceneManager.GetActiveScene;
            }
        }
    }
}
