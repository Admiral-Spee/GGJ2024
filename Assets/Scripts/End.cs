using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip WIN, LOSE;
    #region Single_Instance

    private static End _instance;

    public static End Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("Manage").GetComponent<End>();
            return _instance;
        }
    }

    #endregion
    

    public enum EndType
    {
        WORKLESS,
        DIE,
        INVOLUTION,
        DISMISS,
        NORMAL
    }


    private Image EndImage;
    private Image Charac_Image;
    private Button Exit_Button;
    private Button Next_Button;
    private Button Retry_Button;

    public void LoadEnd(EndType endType)
    {
        StartCoroutine(Load(endType ));
    }

    IEnumerator Load(EndType endType)
    {
        Player.Instance.status = Player.PlayerStatus.PAUSE;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Scenes/EndScene", LoadSceneMode.Additive);
        yield return operation;
        Scene endscence = SceneManager.GetSceneByBuildIndex(1);

        GameObject rootGameObject = endscence.GetRootGameObjects().FirstOrDefault(x => x.name == "Canvas");

        EndImage = rootGameObject.transform.Find("EndImage").GetComponent<Image>();
        Charac_Image = rootGameObject.transform.Find("CharacterImage").GetComponent<Image>();
        Exit_Button = rootGameObject.transform.Find("Exit").GetComponent<Button>();
        Next_Button = rootGameObject.transform.Find("Next").GetComponent<Button>();
        Retry_Button = rootGameObject.transform.Find("Retry").GetComponent<Button>();

        switch (endType)
        {
            case EndType.WORKLESS:
                EndImage.sprite = Resources.Load<Sprite>("Photo/End/End-Fish");
                Charac_Image.sprite = Resources.Load<Sprite>("Photo/End/Stuff_Laugh");
                Retry_Button.gameObject.SetActive(false);
                Debug.Log("ww");
                audioSource.PlayOneShot(WIN);
                break;
            case EndType.DIE:
                EndImage.sprite = Resources.Load<Sprite>("Photo/End/End-Die");
                Charac_Image.gameObject.SetActive(false);
                Next_Button.gameObject.SetActive(false);
                audioSource.PlayOneShot(LOSE);
                break;
            case EndType.INVOLUTION:
                EndImage.sprite = Resources.Load<Sprite>("Photo/End/End-Inv");
                Charac_Image.sprite = Resources.Load<Sprite>("Photo/End/Boss_Laugh");
                Retry_Button.gameObject.SetActive(false);
                audioSource.PlayOneShot(WIN);
                break;
            case EndType.DISMISS:
                EndImage.sprite = Resources.Load<Sprite>("Photo/End/End-Dismiss");
                Charac_Image.gameObject.SetActive(false);
                Next_Button.gameObject.SetActive(false);
                audioSource.PlayOneShot(LOSE);
                break;
            case EndType.NORMAL:
                EndImage.sprite = Resources.Load<Sprite>("Photo/End/End-Normal");
                Charac_Image.gameObject.SetActive(false);
                Retry_Button.gameObject.SetActive(false);
                audioSource.PlayOneShot(WIN);
                break;
        }
    }
    
}