using System;
using Exiled.API.Features;
using KYSyringe;
using MEC;
using Server = Exiled.Events.Handlers.Server;
using Exiled.CustomItems.API.Features;
using InventorySystem.Items.Firearms.Attachments;
using PluginAPI.Events;
using YamlDotNet.Core;
using Version = System.Version;
using Exiled.CustomItems;

namespace KYSyringe

{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override string Name { get; } = "Jam's Custom Items";
        public override string Author { get; } = "Jamwolff, with a lot of help and 'borrowed' code from Snivy (Thanks Again Again BTW)";
        public override string Prefix { get; } = "JI";
        public override Version Version { get; } = new Version(1, 1, 1);
        public override Version RequiredExiledVersion { get; } = new Version(8, 11, 0);

        public override void OnEnabled()
        {
            Instance = this;
            CustomItem.RegisterItems(overrideClass: Config);
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            CustomItem.UnregisterItems();
            Instance = null;
            base.OnDisabled();
        }
    }
}