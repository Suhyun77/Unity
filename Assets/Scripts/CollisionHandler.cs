using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // PARAMETER
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    // CASH
    AudioSource audioSource;

    //STATE
    bool isTransitioning = false; // 부딪힌 경우에만 true가 된다.

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


        void OnCollisionEnter(Collision other) // 부딪힌 다른 것이 무엇인지 물어보는 것
    {
        if (isTransitioning)  {return;} //(isTransitioning == true)
        
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence(); // 부딪힌 뒤 1초 delay
                break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop(); // success 오디오 시작 전 다른 오디오 끄기
        audioSource.PlayOneShot(success);
        //todo add particle effect upon success 
        GetComponent<Movement>().enabled = false; //rocket의 movement 컴포넌트 제어권 off | Stop player controls during the delay
        Invoke("LoadNextLevel", levelLoadDelay); // Parameterise delay setting (we can tune in the inspector)
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop(); // crash 오디오 시작 전 다른 오디오 끄기
        audioSource.PlayOneShot(crash);
        //todo add particle effect upon crash
        GetComponent<Movement>().enabled = false; //rocket의 movement 컴포넌트 제어권 off | Stop player controls during the delay
        Invoke("ReloadLevel", levelLoadDelay); // Parameterise delay setting (we can tune in the inspector)
    }

    void LoadNextLevel()
    {   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex <= 1)   // to ensure we don't try to load level 2
        { 
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) // "다음 씬 인덱스 = 우리가 가진 씬들의 총 개수"일 경우
            {
                nextSceneIndex = 0; // 씬 인덱스 초기화
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
    
    }

    void ReloadLevel()
    {   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // buildIndex : 현재 활동하고 있는, 빌드 설정에 있는 씬의 인덱스 반환
        SceneManager.LoadScene(currentSceneIndex); // SceneManager.LoadScene(0) : 씬의 인덱스를 통해 현재 씬 불러오기
    }

    
}
