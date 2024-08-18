using System;
using System.Collections.Generic;
using Exiled.API;
using Exiled.CustomItems;
using Exiled.API.Features.Spawn;
using Exiled.Loader;
using InventorySystem.Items.Usables;
using Exiled.CustomItems.API.Features;
using Exiled.CustomItems.API.EventArgs;
using Exiled.Events.EventArgs.Player;
using PluginAPI.Events;
using Exiled.API.Features.Attributes;
using PlayerStatsSystem;
using Exiled.API.Enums;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.Events.EventArgs.Map;
using UnityEngine;
using MEC;
using Player = Exiled.Events.Handlers.Player;
using Exiled.API.Interfaces;
using Exiled.API.Structs;
using Exiled.API.Extensions;
using CustomPlayerEffects;
using System.Linq;
using Exiled.API.Features;
using Random = System.Random;


namespace Coin
{
    [CustomItem(ItemType.Coin)]
    public class Coin : CustomItem
    {
        public override uint Id { get; set; } = 50;
        public override string Name { get; set; } = "Weird Quarter";
        public override string Description { get; set; } = "I don't know what it is, but this thing just seems off.";
        public override float Weight { get; set; } = 1.15f;

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new DynamicSpawnPoint()
                {
                    Chance = 10,
                    Location = SpawnLocationType.Inside330Chamber,
                }
            }
        };
        protected override void SubscribeEvents()
        {
            Player.FlippingCoin += OnFlippingCoin;

            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Player.FlippingCoin -= OnFlippingCoin;

            base.UnsubscribeEvents();
        }
        private void OnFlippingCoin(FlippingCoinEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;

            if (ev.IsTails == true)
            {
               Timing.CallDelayed(2f, () => ev.Player.Explode());
            }
            else
            {
                Random random = new Random();
                int maxValue = 3;
                float RandomNumber = (float)random.Next(maxValue);
                switch (RandomNumber)
                {
                    case 0:
                        ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Invigorated, 60f);
                        ev.Player.EnableEffect(Exiled.API.Enums.EffectType.RainbowTaste, 60f);
                        ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Scp1853, 60f);
                        ev.Player.Broadcast(5, "You got the effects: \n -Invigorated \n -Rainbow Taste \n -SCP 1853");
                    break;
                    case 1:
                        ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Scp207, 60f);
                        ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Vitality, 60f);
                        ev.Player.EnableEffect(Exiled.API.Enums.EffectType.SilentWalk, 60f);
                        ev.Player.Broadcast(5, "You got the effects: \n -SCP 207 \n -Vitality \n -Silent Walk");
                    break;
                    case 2:
                        ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Ghostly, 60f);
                        ev.Player.EnableEffect(Exiled.API.Enums.EffectType.DamageReduction, 60f);
                        ev.Player.EnableEffect(Exiled.API.Enums.EffectType.BodyshotReduction, 60f);
                        ev.Player.Broadcast(5, "You got the effects: \n -Ghostly \n -Damage Reduction \n -Bodyshot Reduction");
                    break;
                    case 3:
                        ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Stained, 60f);
                        ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Blinded, 60f);
                        ev.Player.EnableEffect(Exiled.API.Enums.EffectType.Scanned, 60f);
                        ev.Player.Broadcast(5, "You got the effects: \n -Stained \n -Blinded \n -Scanned");
                    break;
                }
            }
        }
    }
}
