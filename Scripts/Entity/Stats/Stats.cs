[System.Serializable]
public class Stats
{
    public Level        level;
	public LevelCap		levelCap;
    public Experience   experience;

    public Movement     movement;
    public SkillPoints  skillPoints;

    public Vitality     vitality;
    public Dexterity    dexterity;
    public Spirit       spirit;

    public HP           hp;
    public HPRegen      hpRegen;
  
    public MP           mp;
    public MPRegen      mpRegen;
    
    public Damage       damage;
    public Defense      defense;
    
    public CritDamage   critDamage;
    public CritRate     critRate;
    
    public MagicDamage  magicDamage;
    public MagicDefense magicDefense;
    
    public Accuracy     accuracy;
    public Evasion      evasion;

	#region CONSTRUCTOS
	public Stats () 
	{ 
		this.level          = new Level ();
		this.levelCap		= new LevelCap ();
        this.experience     = new Experience ();

        this.skillPoints    = new SkillPoints ();
        this.movement       = new Movement ();

        this.vitality       = new Vitality ();
        this.dexterity      = new Dexterity ();
        this.spirit         = new Spirit ();
        
        this.hp             = new HP ();
        this.hpRegen        = new HPRegen ();
        
        this.mp             = new MP ();
        this.mpRegen        = new MPRegen ();
        
        this.damage         = new Damage ();
        this.defense        = new Defense ();
        
        this.critDamage     = new CritDamage ();
        this.critRate       = new CritRate ();
        
        this.magicDamage    = new MagicDamage ();
        this.magicDefense   = new MagicDefense ();

        this.accuracy       = new Accuracy ();
        this.evasion        = new Evasion ();
	}

    public Stats (Stats stats)
    {
        this.level          = stats.level;
		this.levelCap		= stats.levelCap;
        this.experience     = stats.experience;

        this.skillPoints    = stats.skillPoints;
        this.movement       = stats.movement;

        this.vitality       = stats.vitality;
        this.dexterity      = stats.dexterity;
        this.spirit         = stats.spirit;
        
        this.hp             = stats.hp;
        this.hpRegen        = stats.hpRegen;
        
        this.mp             = stats.mp;
        this.mpRegen        = stats.mpRegen;
        
        this.damage         = stats.damage;
        this.defense        = stats.defense;
        
        this.critDamage     = stats.critDamage;
        this.critRate       = stats.critRate;
        
        this.magicDamage    = stats.magicDamage;
        this.magicDefense   = stats.magicDefense;

        this.accuracy       = stats.accuracy;
        this.evasion        = stats.evasion;
    }
	#endregion

	#region CALCULATION
	// # Rule in calculating stats
	// - each level, units will gain 6 stat points
	// - for playable characters, 3 points will be automatically allocated
	//   while the remaining point will be allocated by the player manually
	// - for non-playable characters; all of the stats will be allocated immediately
	//
	// - the movement stat/trait is independent from all of the other stats
	// - movement default value is 4 for level 1; each level there will be an automatic allocation
	public static Stats CalculateStats (Stats baseStats, Stats statsPadding = null) 
    {
        Stats newStats = new Stats (baseStats);

        // Add Primary Stats Padding
        if (statsPadding != null) 
        {
            newStats.vitality .Add (statsPadding.vitality);
            newStats.dexterity.Add (statsPadding.dexterity);
            newStats.spirit   .Add (statsPadding.spirit);
        }

        // # Vitality Affects Physical Stats
        BaseStats statModifier  = newStats.vitality;
        // HP               |   1 sp = 3 hp
        newStats.hp             .ModifyStat (statModifier, 3);
        // HP Regen         |   1 sp = .25 hpregen
        newStats.hpRegen        .ModifyStat (statModifier, .25f);
        // PhysDamage       |   1 sp = 2.5 dmg
        newStats.damage         .ModifyStat (statModifier, 2.5f);
        // PhysDefense      |   1 sp = .5 def
        newStats.defense        .ModifyStat (statModifier, .50f);
        
        // # Dexterity Affects Physical Off and Evasion
        statModifier            = newStats.dexterity;
        // Accuracy         |   1 sp = .30%
        newStats.accuracy       .ModifyStat (statModifier, .30f);
        // Crit Damage      |   1 sp = .15%
        newStats.critDamage     .ModifyStat (statModifier, .15f);
        // Crit Rate        |   1 sp = .10%
        newStats.critRate       .ModifyStat (statModifier, .10f);
        // Evasion          |   1 sp = .20%
        newStats.evasion        .ModifyStat (statModifier, .20f);

        // # Spirit Affects Magical Stats
        statModifier            = newStats.spirit;
        // MP               |   1 sp = 3 mp
        newStats.mp             .ModifyStat (statModifier, 3);
        // MP Regen         |   1 sp = .25 mpregen
        newStats.mpRegen        .ModifyStat (statModifier, .25f);
        // Magic Damage     |   1 sp = 2.5 mDmg
        newStats.magicDamage    .ModifyStat (statModifier, 2.5f);
        // Magic Defense    |   1 sp = .5 mDef
        newStats.magicDefense   .ModifyStat (statModifier, .50f);

        // # Level Affects Movement Stats
        statModifier            = newStats.level;
        newStats.movement       .ModifyStat (statModifier, 4);

        // Add Secondary Stats Padding
        if (statsPadding != null) 
        {
            newStats.level          .Add (statsPadding.level);
            newStats.experience     .Add (statsPadding.experience);
            newStats.skillPoints    .Add (statsPadding.skillPoints);
            newStats.movement       .Add (statsPadding.movement);

            newStats.hp             .Add (statsPadding.hp);
            newStats.hpRegen        .Add (statsPadding.hpRegen);
            
            newStats.mp             .Add (statsPadding.mp);
            newStats.mpRegen        .Add (statsPadding.mpRegen);
            
            newStats.damage         .Add (statsPadding.damage);
            newStats.defense        .Add (statsPadding.defense);
            
            newStats.critDamage     .Add (statsPadding.critDamage);
            newStats.critRate       .Add (statsPadding.critRate);
            
            newStats.magicDamage    .Add (statsPadding.magicDamage);
            newStats.magicDefense   .Add (statsPadding.magicDefense);

            newStats.accuracy       .Add (statsPadding.accuracy);
            newStats.evasion        .Add (statsPadding.evasion);
        }

        return newStats;
    }

    public static Stats CalculateStatsPadding (params StatPadding[] statPaddings)
    {
        Stats newStats = new Stats ();
        return newStats;
    }
	#endregion
}