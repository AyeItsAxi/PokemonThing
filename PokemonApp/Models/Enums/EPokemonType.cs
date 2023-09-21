using System.ComponentModel;

namespace PokemonApp.Models.Enums;

public class EPokemonType
{
    public enum PokemonType
    {
        [Description("Normal")]
        Normal,
        [Description("Fire")]
        Fire,
        [Description("Water")]
        Water,
        [Description("Grass")]
        Grass,
        [Description("Electric")]
        Electric,
        [Description("Ice")]
        Ice,
        [Description("Fighting")]
        Fighting,
        [Description("Poison")]
        Poison,
        [Description("Ground")]
        Ground,
        [Description("Flying")]
        Flying,
        [Description("Psychic")]
        Psychic,
        [Description("Bug")]
        Bug,
        [Description("Rock")]
        Rock,
        [Description("Ghost")]
        Ghost,
        [Description("Dragon")]
        Dragon,
        [Description("Dark")]
        Dark,
        [Description("Steel")]
        Steel,
        [Description("Fairy")]
        Fairy
    }
}