﻿namespace Memoria.Data
{
    public enum BattleCommandId : int
    {
        None = 0,
        Attack = 1,
        Steal = 2,
        Jump = 3,               // When jumping in the air (normal)
        Defend = 4,
        Escape = 5,             // Unused (see "SysEscape" for the fleeing command)
        FinishBlow = 6,         // Unused
        Change = 7,
        Eat = 8,
        Cook = 9,
        Spear = 10,             // When attacking after the jump (normal)
        SpearInTrance = 11,     // When attacking after the jump (trance)
        JumpInTrance = 12,      // When jumping in the air (trance)
        Accumulate = 13,        // Focus - Vivi's command
        Item = 14,
        Throw = 15,
        SummonGarnet = 16,
        WhiteMagicGarnet = 17,
        Phantom = 18,           // Eidolon - Garnet's summon in trance
        WhiteMagicEiko = 19,
        SummonEiko = 20,
        DoubleWhiteMagic = 21,
        BlackMagic = 22,
        DoubleBlackMagic = 23,
        BlueMagic = 24,
        SecretTrick = 25,       // Skill - Zidane's command (normal)
        InsideTrick = 26,       // Dyne - Zidane's command (trance)
        DragonAct = 27,         // Dragon - Freya's command
        MasterTrick = 28,       // Flair - Amarant's command (normal)
        SuperTrick = 29,        // Elan - Amarant's command (trance)
        SwordAct = 30,          // Sword Art
        MagicSword = 31,        // Sword Magic
        HolySword1 = 32,        // Seiken - Beatrix's command (1st part in Alexandria Castle)
        HolySword2 = 33,        // Seiken - Beatrix's command (2nd part in Alexandria streets)
        HolyWhiteMagic = 34,    // White Magic - Beatrix's command
        RedMagic1 = 35,         // Unused
        RedMagic2 = 36,         // Unused
        YellowMagic1 = 37,      // Unused
        YellowMagic2 = 38,      // Unused
        WhiteMagicCinna1 = 39,  // Unused
        WhiteMagicCinna2 = 40,  // Unused
        StageMagicZidane = 41,  // SFX containing Medeo
        StageMagicBlank = 42,   // SFX containing Pyro
        StageMagicMarcus = 43,  // SFX containing Poly
        StageMagicCinna = 44,   // SFX containing Pyro
        AccessMenu = 45,        // Unused - Related to the .ini option [Battle] AccessMenus
        Reserve4 = 46,          // Unused
        EnemyAtk = 47,          // Normal enemy attacks (function ATB)
        BoundaryCheck = 48,     // Used as a delimiter for commands that can be defined in "Commands.csv" (the following ones cannot)
        Counter = 49,           // Party member counter-attacks
        MagicCounter = 50,      // Party member return magic
        AutoPotion = 51,        // Party member auto-potions
        RushAttack = 52,        // Attack triggered by Steiner's Charge!
        EnemyCounter = 53,      // Enemy counters (function Counter)
        EnemyDying = 54,        // Enemy dying moves (function Death)
        EnemyReaction = 55,     // Other enemy counter (function CounterEx)
        SysEscape = 56,         // When fleeing, either manually or triggered after Zidane's Flee
        SysPhantom = 57,        // The replicates of Garnet's trance Eidolon
        SysLastPhoenix = 58,    // Eiko's Phoenix that randomly triggers before Game Over
        SysTrans = 59,          // Turning into trance or back to normal
        SysDead = 60,           // Dummied - used to be when a player character died
        SysReraise = 61,        // Dummied - used to be when a player character used Auto-Life
        SysStone = 62,          // Turning into stone with the status Petrify
        ScriptCounter1 = 63,    // Enemy additional moves (function Loop)
        ScriptCounter2 = 64,    // Enemy additional moves when ScriptCounter1 is already used (function Loop)
        ScriptCounter3 = 65,    // Enemy additional moves when the others two are already used (function Loop)
        BoundaryUpperCheck = 99 // Used as a delimiter for commands that can be defined in "Commands.csv" (the previous ones cannot)
    }
}
