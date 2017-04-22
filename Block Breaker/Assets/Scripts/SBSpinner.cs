using UnityEngine;
using System.Collections;

public class SBSpinner : MonoBehaviour {

	private int m_spriteNum;
	//private string m_spriteNames = "SBAnimation";
	private SpriteRenderer m_spriteRenderer;
	//private Sprite[] m_sprites;
	
	public Sprite[] SBAnimation;
	
	public bool isVisible = false;

	// Use this for initialization
	void Start () {
		m_spriteRenderer = this.GetComponent<SpriteRenderer>();
		//m_sprites = Resources.LoadAll<Sprite>(m_spriteNames);
	}
	
	// Update is called once per frame
	void Update () {
		
	
		if (m_spriteNum > SBAnimation.Length - 1 )
			m_spriteNum = 0;
		
		m_spriteRenderer.sprite = isVisible ? SBAnimation[m_spriteNum] : null;
		
		m_spriteNum++;
		
//		if (m_spriteRenderer.sprite == null)
//		{
//			m_spriteRenderer.sprite = m_sprite;
//		}
//		 else
//		 {
//			m_sprite = m_spriteRenderer.sprite;
//			m_spriteRenderer.sprite = null;
//		 }
		
	}
}
