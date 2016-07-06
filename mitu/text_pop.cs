using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextPop : MonoBehaviour
{
    private float time_  = 0f;
    public GameObject text_;
    public float sec_life_ = 5f;
    TextMesh tm_;
    public Vector3 v_;

    public void Create(string t, Color c)
    {
        //string f = "Fonts/Limited/s1-mplus-2c-medium";
        string f = "Fonts/MPlusTestflight60/mplus-2p-regular";
        text_ = new GameObject("text1");
        text_.transform.SetParent(this.transform, false);
        tm_ = text_.AddComponent<TextMesh>();
        MeshRenderer mr = text_.GetComponent<MeshRenderer>();
        mr.material = Resources.Load<Material>(f);
        tm_.text = t;
        //tm.fontSize = 6;
        tm_.characterSize = 0.1f;
        tm_.font = Resources.Load<Font>(f);
        tm_.color = new Color(c.r, c.g, c.b, 0f);
        v_ = new Vector3(0, 0.001f, 0);
        
    }

    void Start()
    {
        time_ = Time.time;
    }
    void Update()
    {
        //text_.transform.position = camera_.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
        float t = Time.time;
        float a = Mathf.Sin(Mathf.PI * (t - time_) / sec_life_);
        //float a = 1f-(0.2f + 0.8f * (t - time_) / (sec_life_/2));
        tm_.color = new Color(tm_.color.r, tm_.color.g, tm_.color.b, a);
        if (t- time_ > sec_life_)
        {
            Destroy(this.transform.root.gameObject);
        }
        this.transform.position += v_;
    }
}