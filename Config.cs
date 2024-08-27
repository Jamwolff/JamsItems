using System.Collections.Generic;
using System.ComponentModel;
using Coin;
using Drugs;
using Exiled.API.Interfaces;
using InventorySystem.Items.Coin;

namespace KYSyringe.Configs
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Debug Printouts")]
        public bool Debug { get; set; } = false;

        [Description("List of LJ-429s.")]
        public List<Syringe> Syringes { get; private set; } = new()
        {
            new Syringe(),
        };

        [Description("List of Drugs.")]
        public List<Pills> Pillss { get; private set; } = new()
        {
            new Pills(),
        };
        [Description("List of Coins.")]
        public List<Coins> Coins { get; private set; } = new()
        {
            new Coins(),
        };


    }
}