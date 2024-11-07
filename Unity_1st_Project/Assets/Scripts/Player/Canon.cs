using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Canon : MonoBehaviour
{
    public float _canonCooltime =30;
    private float canonCooltime;
    public float NoCoolDuration = 5f;
    public GameObject canonAimingArea;
    private bool isActive=false;
    public CanonBall canonBall;
    public Transform canonPosition;
    public Transform muzzlePosition;
    private float startCooltime;

    private void Awake()
    {
        canonCooltime = _canonCooltime;
        startCooltime=-canonCooltime;
    }

    private void Start()
    {
        GameManager.Instance.Canon = this;
        UIManager.Instance.shootCanonButton.onClick.AddListener(SkillOn);
    }

    private void Update()
    {
        Aiming();
        UIManager.Instance.canonCooltimePanel.fillAmount = (canonCooltime-(Time.time- startCooltime))/canonCooltime;
    }

    private void SkillOn()
    {
        if (Time.time >= startCooltime + canonCooltime)
        {
            isActive = !isActive;
            canonAimingArea.SetActive(isActive);
            startCooltime = Time.time;
        }
    }

    private void Aiming()
    {
        if (canonAimingArea.activeSelf==true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            canonAimingArea.transform.position =new Vector3(mousePos.x, canonAimingArea.transform.position.y, canonAimingArea.transform.position.z);
            if (canonAimingArea.transform.position.x<-3.61)
            {
                canonAimingArea.transform.position = new Vector3(-3.61f, canonAimingArea.transform.position.y);
            }
            else if (canonAimingArea.transform.position.x>8)
            {
                canonAimingArea.transform.position = new Vector3(8f, canonAimingArea.transform.position.y);
            }
            Vector2 fireDirection = canonAimingArea.transform.position-canonPosition.position;
            canonPosition.up = fireDirection;
            GameManager.Instance.aimArea = canonAimingArea.transform;
            if (Input.GetMouseButton(0))
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        Instantiate(canonBall,muzzlePosition.position,muzzlePosition.rotation);
        canonAimingArea.SetActive(false);
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
        canonCooltime=0;
        yield return new WaitForSeconds(NoCoolDuration);
        canonCooltime =_canonCooltime;
    }
}
