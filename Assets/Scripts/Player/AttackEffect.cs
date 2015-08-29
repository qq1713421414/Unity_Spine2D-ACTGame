using UnityEngine;
using System.Collections;

public class AttackEffect : MonoBehaviour {

	//扩展技能时需要更新此处
	public string[] attack_effects = {"atk_1", "atk_2"};
	public string[] skill_effects = {"skill_1", "skill_2", "skill_3", "skill_4", "skill_5", "skill_6"};
    /*---------------------------------------------------*/

	public SkeletonAnimation m_SkeletonAnimation;
    private float direction;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (m_SkeletonAnimation.AnimationName != null)
        {
            if (m_SkeletonAnimation.state.GetCurrent(0).time >= m_SkeletonAnimation.state.GetCurrent(0).endTime)
            {
                GetComponent<MeshRenderer>().enabled = false;
                m_SkeletonAnimation.AnimationName = null;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
                if (m_SkeletonAnimation.AnimationName == "skill_6")
                    transform.Translate(Time.deltaTime * GlobalValue.skill_6_moveSpeed * direction * Vector3.right);
            }
        }
    }

    //type为1即普通攻击特效类型，type为2即技能攻击特效类型
    public void setEffect(int index, int type, Vector3 position, float direction) {
        m_SkeletonAnimation.timeScale = 1;
        if (type == 1)
        {
            m_SkeletonAnimation.AnimationName = attack_effects[index];
        }
        else
        {
            m_SkeletonAnimation.AnimationName = skill_effects[index];
            if (index == 5) m_SkeletonAnimation.timeScale = 1.5f;
;        }
        this.direction = direction;
        transform.position = position;
        transform.localScale = new Vector3(direction, 1, 1);
    }

    public bool isPlaying() {
        if (m_SkeletonAnimation.state.GetCurrent(0) == null) return false;
        else if (m_SkeletonAnimation.state.GetCurrent(0).time > m_SkeletonAnimation.state.GetCurrent(0).endTime) return false;
        return true;
    }
}
