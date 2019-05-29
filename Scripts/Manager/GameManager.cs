using UnityEngine;

public class GameManager : MonoBehaviour
{ 
	public static GameManager	singleton	{ private set; get; }

	public EventsManager		m_events	{ private set; get; }
	public BattleManager		m_battle	{ private set; get; }
	public StoryManager			m_story		{ private set; get; }
	public ItemManager			m_item		{ private set; get; }
	public SpriteManager		m_sprite	{ private set; get; }

	#region MONO CALLS
	private void Awake ()
	{
		if (singleton != null)
		{ 
			Destroy (this.gameObject);
			return;
		}

		singleton = this;
		CreateManagers ();
	}
	#endregion

	#region FUNCTIONS
	public void CreateManagers ()
	{ 
		m_events	= new EventsManager ();
		m_battle	= new BattleManager ();
		m_story		= new StoryManager  ();
		m_item		= new ItemManager   ();
		m_sprite	= new SpriteManager ();
	}
	#endregion
}