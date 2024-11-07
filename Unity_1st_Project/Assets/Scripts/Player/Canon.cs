using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Canon : MonoBehaviour
{
    public float _canonCooltime =30;
    private float canonCooltime;
    public float NoCoolDuration = 5f;
    public Button skill;
    public GameObject aimingArea;
    private bool isActive=false;
    public GameObject canonBall;
    public Transform canon;
    public Transform muzzle;
    public Image canonCooltimePanel;
    private float startCooltime;

    private void Awake()
    {
        canonCooltime = _canonCooltime;
        startCooltime=-canonCooltime;
    }

    private void Start()
    {
        GameManager.Instance.Canon = this;
        skill.onClick.AddListener(SkillOn);
    }

    private void Update()
    {
        Aiming();
        canonCooltimePanel.fillAmount = (canonCooltime-(Time.time- startCooltime))/canonCooltime;
    }

    private void SkillOn()
    {
        if (Time.time >= startCooltime + canonCooltime)
        {
            isActive = !isActive;
            aimingArea.SetActive(isActive);
            startCooltime = Time.time;
        }
    }

    private void Aiming()
    {
        if (aimingArea.activeSelf==true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            aimingArea.transform.position =new Vector3(mousePos.x, aimingArea.transform.position.y, aimingArea.transform.position.z);
            if (aimingArea.transform.position.x<-3.61)
            {
                aimingArea.transform.position = new Vector3(-3.61f, aimingArea.transform.position.y);
            }
            else if (aimingArea.transform.position.x>8)
            {
                aimingArea.transform.position = new Vector3(8f, aimingArea.transform.position.y);
            }
            Vector2 fireDirection = aimingArea.transform.position-canon.position;
            canon.up = fireDirection;
            GameManager.Instance.aimArea = aimingArea.transform;
            if (Input.GetMouseButton(0))
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        Instantiate(canonBall,muzzle.position,muzzle.rotation);
        aimingArea.SetActive(false);
        isActive = false;
    }

    Coroutine coroutine=null;

    public void accessNoCool()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
        coroutine = StartCoroutine(NoCool());
    }
    public IEnumerator NoCool()
    {
        print("»£√‚");
        canonCooltime=0;
        yield return new WaitForSeconds(NoCoolDuration);
        canonCooltime =_canonCooltime;
    }
}
