using System;
using System.Text;
using PokemonApp.Models;
using System.Threading.Tasks;
using System.Windows.Media;
using PokemonApp.Models.Enums;

namespace PokemonApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Pokemon _pokemon1;
        private readonly Pokemon _pokemon2;
        private bool _bIsFinished;

        public MainWindow()
        {
            _pokemon1 = new Pokemon(EPokemonType.PokemonType.Fire, "Charizard", 50, 1, 1.0, 5, 3, 2);
            _pokemon2 = new Pokemon(EPokemonType.PokemonType.Water, "Blastoise", 40, 1, 1.0, 5, 20, 5);
            InitializeComponent();
            _ = InitializeUiComponents();
        }

        private Task InitializeUiComponents()
        {
            Pokemon1Name.Text = _pokemon1.name;
            Pokemon1Health.Text = $"Health: {_pokemon1.startHealth}";
            Pokemon1Attack.Text = $"Attack Amount: {_pokemon1.attack}";
            Pokemon1Defense.Text = $"Defense Amount: {_pokemon1.defense.ToString()}";
            Pokemon1Type.Text = $"Pokemon Type: {_pokemon1.eType.ToString()}";
            Pokemon2Name.Text = _pokemon2.name;
            Pokemon2Health.Text = $"Health: {_pokemon2.startHealth}";
            Pokemon2Attack.Text = $"Attack Amount: {_pokemon2.attack}";
            Pokemon2Defense.Text = $"Defense Amount: {_pokemon2.defense.ToString()}";
            Pokemon2Type.Text = $"Pokemon Type: {_pokemon2.eType.ToString()}";
            return Task.CompletedTask;
        }

        private void AttackPokemon()
        {
            var p1Atk = _pokemon1.Attack(_pokemon2);
            var p2Atk = _pokemon2.Attack(_pokemon1);
            Console.WriteLine($"{p1Atk}\r\n{p2Atk}\r\n{_pokemon1.startHealth}\r\n{_pokemon2.startHealth}");
            var blSb = new StringBuilder();
            blSb.Append(BattleLog.Text);
            blSb.AppendLine($"{_pokemon1.name} attacked {_pokemon2.name} and dealt {p1Atk} damage!");
            blSb.AppendLine($"{_pokemon2.name} attacked {_pokemon1.name} and dealt {p2Atk} damage!");
            OnAttackFinished(blSb);
        }

        private void OnAttackFinished(StringBuilder blSb)
        {
            if (_pokemon1.curHealth <= 0)
            {
                AttackButtonBorder.Opacity = 0.7;
                AttackButtonContent.Content = "Battle Finished";
                blSb.AppendLine($"{_pokemon1.name} has fainted!");
                blSb.AppendLine($"{_pokemon2.name} won the battle!");
                _bIsFinished = true;
            }

            if (_pokemon2.curHealth <= 0)
            {
                AttackButtonBorder.Opacity = 0.7;
                AttackButtonContent.Content = "Battle Finished";
                blSb.AppendLine($"{_pokemon2.name} has fainted!");
                blSb.AppendLine($"{_pokemon1.name} won the battle!");
                _bIsFinished = true;
            }

            Pokemon1Health.Text = $"Health: {_pokemon1.curHealth}";
            Pokemon2Health.Text = $"Health: {_pokemon2.curHealth}";
            Pokemon1HealthBar.Value = Math.Round(_pokemon1.curHealth / _pokemon1.startHealth * 100);
            Pokemon2HealthBar.Value = Math.Round(_pokemon2.curHealth / _pokemon2.startHealth * 100);
            BattleLog.Text = blSb.ToString();
            BattleLogScrollViewer.ScrollToEnd();
        }

        private void OnAttackButtonMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_bIsFinished) return;
            AttackButtonBorder.Background = (Brush)new BrushConverter().ConvertFromString("#20212b")!;
        }

        private void OnAttackButtonMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_bIsFinished) return;
            AttackButtonBorder.Background = (Brush)new BrushConverter().ConvertFromString("#14151b")!;
        }

        private void OnAttackButtonMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_bIsFinished) return;
            AttackButtonBorder.Background = (Brush)new BrushConverter().ConvertFromString("#2c2d3b")!;
        }

        private void OnAttackButtonMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_bIsFinished) return;
            AttackPokemon();
            AttackButtonBorder.Background = (Brush)new BrushConverter().ConvertFromString("#20212b")!;
        }
    }
}