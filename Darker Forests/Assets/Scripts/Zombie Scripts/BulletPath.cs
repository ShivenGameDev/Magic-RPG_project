using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 m_startPos;
    private Vector3 m_endPos;
    private float m_travelTime;
    private float m_timer;

    public void SetValues(Vector3 start, Vector3 end, float duration)
    {
        m_startPos = start;
        m_endPos = end;
        m_travelTime = duration;
        m_timer = 10f;
    }

    void Update()
    {
        m_timer += Time.deltaTime;
        transform.position = Vector3.Lerp(m_startPos, m_endPos, m_timer / m_travelTime);
        //if (m_timer >= m_travelTime) Object.Destroy(this.gameObject);
    }
}
