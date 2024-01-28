using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;

public class UIManage : MonoBehaviour
{
    public Text salary_text;
    public Text day_text;
    public Text time_text;
    public Text award_text;
    public Text goal_text;
    public GameObject gameobject;
    public Transform heartTransfom;
    public float hearmul = 1.0f;
    public float scale = 1.0f;
    public Transform transform;
    public Material mat;
    public float time = 0.5f;

    
    // #region Single_Instance
    //
    // private static UIManage _instance;
    //
    // public static UIManage Instance
    // {
    //     get
    //     {
    //         if (_instance == null)
    //             _instance = GameObject.Find("Manage").GetComponent<UIManage>();
    //         return _instance;
    //     }
    // }
    //
    // #endregion

    private float value;
    private float lerp;

    // Start is called before the first frame update
    void Start()
    {
        Find();
    }

    // Update is called once per frame
    void Update()
    {
        time_text.text = "" + ((int)Manage.Instance.left_Time);
        day_text.text = "" + Manage.Instance.Day;
        goal_text.text = "" + Player.Instance.salaryMax;
        award_text.text = Player.Instance.award.ToString();

        if (transform==null||heartTransfom==null)
            Find();
        value = (float)Player.Instance.energy / (float)Player.Instance.energyMax;
        time -= Time.deltaTime;
        mat.SetFloat("_Value", value);

        // mat.shader..value = (float)_player.energy / (float)_player.energyMax;
        if (value > 0.5)
        {
            lerp = Mathf.Lerp(-90, 90, Mathf.Abs(Mathf.Sin(Time.time)));
            transform.localEulerAngles = new Vector3(0, 0, lerp);
            heartTransfom.localScale = new Vector3(scale + Mathf.Abs(Mathf.Sin(Time.time)) * hearmul,
                scale + Mathf.Abs(Mathf.Sin(Time.time)) * hearmul,
                scale + Mathf.Abs(Mathf.Sin(Time.time)) * hearmul);
        }
        else
        {
            lerp = Mathf.Lerp(-60, 60, Mathf.Abs(Mathf.Sin(Time.time)));
            transform.localEulerAngles = new Vector3(0, 0, lerp);
            heartTransfom.localScale = new Vector3(scale + Mathf.Abs(Mathf.Sin(Time.time)) * hearmul,
                scale + Mathf.Abs(Mathf.Sin(Time.time)) * hearmul, 
                scale + Mathf.Abs(Mathf.Sin(Time.time)) * hearmul);
        }


        if (time <= 0)
        {
            time = Manage.Instance.TimeThread;
        }
    }


    public void ChangeSalaryShow(int startvalue, int offset)
    {
        DOTween.To(value => { salary_text.text = Mathf.Floor(value).ToString(); }, startvalue,
            startvalue + offset, 0.2f);
        GameObject temp = Instantiate(gameobject, GameObject.Find("Canvas").transform);
        StartCoroutine(temp.GetComponent<ChangeText>().Show(offset));
    }

    public void Find()
    {
        transform = GameObject.Find("PointerGame").transform;
        heartTransfom = GameObject.Find("HeartPanel").transform;
    }
}