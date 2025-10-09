## Epic Loot Patches
### >> loottables.json

**Major Changes**

Mob tier system rework. Expanded from 8 tiers to 14 tiers for more granular loot progression. The strongest enemies of the current biome will have a chance to drop the next biome's items, provided you have defeated the current biome's boss. (Note: Requires you to set a main epicloot.cfg file option: 

> Item Drop Limits = BossKillUnlocksNextBiomeItems

Loot weight distribution is custom.
Hammer, Hoe, Cultivator can drop late-game.
Progressive rarity increases across world levels 1-6 for each mob tier.
Drop quantity chances scale with mob level (higher levels = more items)
Treasure chest loot tables unchanged

## AllTameable
### >> AllTameable_TameList_From_Default.cfg

Adds tames for almost every non-boss creature in the game. 

**Features:**
- Increased maximum creature count (20 for all)
- Custom items for taming each creature (with custom healing ammounts per item)
- Custom time for taming each creature
- Custom pregnancy and growth time for each creature
- Custom variance in offspring (i.e. breeding Greydwarf Brute = 94% chance Greydwarf, 5% chance for Brute, 1% chance for Shaman)
- Babies have special names (i.e. piglet, leveret, wolf pup, sapling, bear cub, neck hatchling, seed tick, seeker broodling)
- Breeding restrictions (cannot breed undead creatures, kvastur, stone golem)
- Egg laying with custom egg type/color/size and hatch time (serpents, neck, leech, drake, deathsquito, hen, seekers, gjall, tick, asksvin, volture)
- Swarm breeding (currently not implemented; if it's ever made so creatures can reproduce without mates, I will change this config so that seekers can't breed, except the queen with royal jelly)
- Greyling and seeker brood are only non-boss creatures not included

