using System;
using PokemonApp.Models.Enums;

namespace PokemonApp.Models;

public class Pokemon
{
    public PokemonType type;
    public string name;
    public double startHealth;
    public double curHealth;
    public double speed;
    public int level;
    public readonly int attack;
    public readonly int defense;
    private int power;
    public EPokemonType.PokemonType eType;

    public Pokemon(EPokemonType.PokemonType type, string name, double startHealth, int level, double speed, int attack, int defense, int power)
    {
        this.type = new PokemonType(type);
        this.name = name;
        this.startHealth = startHealth;
        this.curHealth = startHealth;
        this.speed = speed;
        this.attack = attack;
        this.defense = defense;
        this.level = 1;
        this.power = power;
        this.eType = type;
    }

    public double Attack(Pokemon target)
    {
        var damageModifier = target.eType switch
        {
            EPokemonType.PokemonType.Normal => type.normalEffectiveness,
            EPokemonType.PokemonType.Fire => type.fireEffectiveness,
            EPokemonType.PokemonType.Water => type.waterEffectiveness,
            EPokemonType.PokemonType.Grass => type.grassEffectiveness,
            EPokemonType.PokemonType.Electric => type.electricEffectiveness,
            EPokemonType.PokemonType.Ice => type.iceEffectiveness,
            EPokemonType.PokemonType.Fighting => type.fightingEffectiveness,
            EPokemonType.PokemonType.Poison => type.poisonEffectiveness,
            EPokemonType.PokemonType.Ground => type.groundEffectiveness,
            EPokemonType.PokemonType.Flying => type.flyingEffectiveness,
            EPokemonType.PokemonType.Psychic => type.psychicEffectiveness,
            EPokemonType.PokemonType.Bug => type.bugEffectiveness,
            EPokemonType.PokemonType.Rock => type.rockEffectiveness,
            EPokemonType.PokemonType.Ghost => type.ghostEffectiveness,
            EPokemonType.PokemonType.Dragon => type.dragonEffectiveness,
            EPokemonType.PokemonType.Dark => type.darkEffectiveness,
            EPokemonType.PokemonType.Steel => type.steelEffectiveness,
            EPokemonType.PokemonType.Fairy => type.fairyEffectiveness,
            _ => throw new ArgumentOutOfRangeException()
        };
        var damageToDeal = attack * damageModifier;
        if (damageToDeal > 0)
        {
            target.curHealth -= damageToDeal;
        }

        return damageToDeal;
    }
}