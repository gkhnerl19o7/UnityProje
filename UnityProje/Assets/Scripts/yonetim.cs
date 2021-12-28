using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class yonetim : MonoBehaviour
{
    public LineRenderer cizgi;
    public Camera kamera;
    public Transform top,sanalayak;
    public Rigidbody vurus;
    public GameObject kaybetmepnl,kazanmapnl,topobje;
    float vurusgucu=0.0f;
    int vurushakki=3;
    public Text kalanhak;
    bool golmu = false;
    Vector3 sanalayakbaslangýc;
    Vector3 topvc;
    
    void Start()
    {
        kaybetmepnl.SetActive(false);
        kazanmapnl.SetActive(false);
        cizgi.transform.position = top.transform.position;
        sanalayakbaslangýc = sanalayak.position;
        topvc = top.position;
        sanalayak.transform.position = new Vector3(GameObject.Find("Top").transform.position.x - 1.2f, GameObject.Find("Top").transform.position.y - 0.5f, GameObject.Find("Top").transform.position.z);
        kalanhak.text = "Kalan hak: " + vurushakki;
        
    }
    void Update()
    {
        cizgiayar();
        fareayar();
        goruntu();
        Golmu();
        oyunbitti();
        
    }
    void cizgiayar() 
    {
        RaycastHit temas;
        Ray isik = kamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(isik,out temas))
        {
            Vector3 topunpoz = top.position;
            Vector3 faretemas = new Vector3(temas.point.x, temas.point.y, temas.point.z);
            cizgi.SetPosition(0, topunpoz);
            cizgi.SetPosition(1, faretemas);
            top.LookAt(faretemas);
        }
    }
    void fareayar() 
    {
        float distance = Vector3.Distance(top.transform.position, sanalayak.transform.position);
        if (Input.GetMouseButton(0)&& cizgi.gameObject.activeSelf)
        {
            if (distance <=2.0f)
            {
                sanalayak.Translate(0, 0, -0.2f * Time.deltaTime);
                vurusgucu += 5.0f * Time.deltaTime;
            }
            
        }
        if (Input.GetMouseButtonUp(0)&& cizgi.gameObject.activeSelf)
        {
            
            sanalayak.localPosition = sanalayakbaslangýc;
            Invoke("vur", 0.1f);
            topobje.GetComponent<AudioSource>().PlayOneShot(topobje.GetComponent<Top>().sesler[0]);
        }
    }
    void vur() 
    {
        vurus.velocity = top.forward * vurusgucu;
        
        cizgi.gameObject.SetActive(false);
        sanalayak.gameObject.SetActive(false);
        
        vurusgucu = 0.0f;
       
    }
    void goruntu() 
    {
        if (vurus.velocity.magnitude<=0.1f && cizgi.gameObject.activeSelf==false)
        { vurushakki--;
        kalanhak.text = "Kalan Hak: " + vurushakki;
            cizgi.gameObject.SetActive(true);
            sanalayak.gameObject.SetActive(true);
            sanalayak.transform.position =new Vector3(GameObject.Find("Top").transform.position.x-1.2f, GameObject.Find("Top").transform.position.y-0.5f, GameObject.Find("Top").transform.position.z);
        }
    }
    void oyunbitti() 
    {
        if (vurushakki==0 && golmu==false )
        {
            kaybetmepnl.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void restart1() 
    {
        SceneManager.LoadScene(1);
        top.position = new Vector3(-20f, 0.5f,0f );
        vurushakki = 3;
        Time.timeScale = 1;
    }
    public void bolum2() 
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("level", 2);
    }
    public void restart2()
    {
        SceneManager.LoadScene(2);
        top.position = new Vector3(-20f, 0.5f, 0f);
        vurushakki = 3;
        Time.timeScale = 1;
    }
    void Golmu() 
    {
        topvc.x=top.position.x;
       if (topvc.x >= 23.5f && golmu==false)
        {
            golmu = true;
            topobje.GetComponent<AudioSource>().PlayOneShot(topobje.GetComponent<Top>().sesler[2]);
            kazanmapnl.SetActive(true);
            Time.timeScale = 0.1f;

        }
    }
}
