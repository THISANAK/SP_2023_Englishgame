using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Component")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerText2;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Setting")]
    public bool hasLimit;
    public float timerLimit;




    [Header("Formats Setting")]
    public bool hasFormat;
    public Timerformats format;
    private Dictionary<Timerformats, string> timeFormats = new Dictionary<Timerformats, string>();
    void Start()
    {
        timeFormats.Add(Timerformats.whol, "0");
        timeFormats.Add(Timerformats.TenthDecimal, "0.0");
        timeFormats.Add(Timerformats.HundrethsDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            timerText2.color = Color.red;
            enabled = false;
        }

        SetTimerText();
    }
    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
        timerText2.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
    }

}
public enum Timerformats
{
    whol,
    TenthDecimal,
    HundrethsDecimal
}
