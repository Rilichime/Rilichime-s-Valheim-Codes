using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace CircletColorPicker
{
    [BepInPlugin("your.name.circletcolorpicker", "Circlet Color Picker", "1.3.0")]
    [BepInDependency("shudnal.CircletExtended", BepInDependency.DependencyFlags.HardDependency)]
    public class CircletColorPicker : BaseUnityPlugin
    {
        private static CircletColorPicker instance;

        // Config
        private static ConfigEntry<string> configHotkeyPrimary;
        private static ConfigEntry<string> configHotkeyNext;
        private static ConfigEntry<string> configHotkeyPrevious;
        private static ConfigEntry<string> configPreset1;
        private static ConfigEntry<string> configPreset2;
        private static ConfigEntry<string> configPreset3;
        private static ConfigEntry<string> configPreset4;
        private static ConfigEntry<string> configPreset5;
        private static ConfigEntry<string> configPreset6;
        private static ConfigEntry<string> configPreset7;
        private static ConfigEntry<string> configPreset8;
        private static ConfigEntry<string> configPreset9;
        private static ConfigEntry<string> configPreset10;
        private static ConfigEntry<string> configPreset11;
        private static ConfigEntry<string> configPreset12;
        private static ConfigEntry<string> configPreset13;
        private static ConfigEntry<string> configPreset14;
        private static ConfigEntry<string> configPreset15;
        private static ConfigEntry<string> configPreset16;
        private static ConfigEntry<string> configPreset17;
        private static ConfigEntry<string> configPreset18;
        private static ConfigEntry<string> configPreset19;
        private static ConfigEntry<string> configPreset20;
        private static ConfigEntry<string> configPreset21;
        private static ConfigEntry<string> configPreset22;
        private static ConfigEntry<string> configPreset23;
        private static ConfigEntry<string> configPreset24;
        private static ConfigEntry<string> configPreset25;
        private static ConfigEntry<string> configPreset26;
        private static ConfigEntry<string> configPreset27;
        private static ConfigEntry<string> configPreset28;
        private static ConfigEntry<string> configPreset29;
        private static ConfigEntry<string> configPreset30;
        private static ConfigEntry<string> configPreset31;
        private static ConfigEntry<string> configPreset32;
        private static ConfigEntry<string> configPreset33;
        private static ConfigEntry<string> configPreset34;
        private static ConfigEntry<string> configPreset35;
        private static ConfigEntry<string> configPreset36;
        private static ConfigEntry<string> configPreset37;
        private static ConfigEntry<string> configPreset38;
        private static ConfigEntry<string> configPreset39;
        private static ConfigEntry<string> configPreset40;
        private static ConfigEntry<string> configPreset41;
        private static ConfigEntry<string> configPreset42;
        private static ConfigEntry<string> configPreset43;
        private static ConfigEntry<string> configPreset44;
        private static ConfigEntry<string> configPreset45;
        private static ConfigEntry<string> configPreset46;
        private static ConfigEntry<string> configPreset47;
        private static ConfigEntry<string> configPreset48;
        private static ConfigEntry<string> configPreset49;
        private static ConfigEntry<string> configPreset50;
        private static ConfigEntry<string> configPreset51;
        private static ConfigEntry<string> configPreset52;
        private static ConfigEntry<string> configPreset53;
        private static ConfigEntry<string> configPreset54;
        private static ConfigEntry<string> configPreset55;

        // Color system
        private static List<ColorPreset> presets = new List<ColorPreset>();
        private static int currentPresetIndex = 0;
        private static KeyCode primaryKey = KeyCode.LeftControl;
        private static KeyCode nextKey = KeyCode.RightArrow;
        private static KeyCode previousKey = KeyCode.LeftArrow;
        private static Dictionary<string, Color> circletColors = new Dictionary<string, Color>();

        // Track active color override
        private Coroutine colorEnforcer = null;

        void Awake()
        {
            instance = this;

            // Setup hotkey config
            configHotkeyPrimary = Config.Bind("Hotkey", "Primary Key", "LeftControl",
                "First key (modifier): LeftControl, LeftShift, LeftAlt, RightControl, etc.");

            configHotkeyNext = Config.Bind("Hotkey", "Next Color Key", "RightArrow",
                "Key to cycle to next color: RightArrow, LeftArrow, C, V, N, etc.");

            configHotkeyPrevious = Config.Bind("Hotkey", "Previous Color Key", "LeftArrow",
                "Key to cycle to previous color: LeftArrow, RightArrow, Z, X, etc.");

            // Setup color presets (Name|#HEXCODE format)
            configPreset1 = Config.Bind("Color Presets", "1", "Barn Red|#7C0902",
                "Format: Name|#HEXCODE (get hex codes from htmlcolorcodes.com)");
            configPreset2 = Config.Bind("Color Presets", "2", "Candy Apple|#FF0800", "");
            configPreset3 = Config.Bind("Color Presets", "3", "Raspberry|#E3256B", "");
            configPreset4 = Config.Bind("Color Presets", "4", "Deep Pink|#FF66CC", "");
            configPreset5 = Config.Bind("Color Presets", "5", "Cinnabar|#E44D2E", "");
            configPreset6 = Config.Bind("Color Presets", "6", "Coral|#F88379", "");
            configPreset7 = Config.Bind("Color Presets", "7", "Alloy|#C46210", "");
            configPreset8 = Config.Bind("Color Presets", "8", "Atomic Tangerine|#FF9966", "");
            configPreset9 = Config.Bind("Color Presets", "9", "Orange|#FF7538", "");
            configPreset10 = Config.Bind("Color Presets", "10", "Gamboge|#EF9B0F", "");
            configPreset11 = Config.Bind("Color Presets", "11", "Amber|#FFBF00", "");
            configPreset12 = Config.Bind("Color Presets", "12", "Canary|#FFEF00", "");
            configPreset13 = Config.Bind("Color Presets", "13", "Flax|#EEDC82", "");
            configPreset14 = Config.Bind("Color Presets", "14", "Grain|#FADA5E", "");
            configPreset15 = Config.Bind("Color Presets", "15", "Straw|#E4D96F", "");
            configPreset16 = Config.Bind("Color Presets", "16", "Pear|#D1E231", "");
            configPreset17 = Config.Bind("Color Presets", "17", "Mindaro|#E3F988", "");
            configPreset18 = Config.Bind("Color Presets", "18", "Green|#03C03C", "");
            configPreset19 = Config.Bind("Color Presets", "19", "Dark Green|#013220", "");
            configPreset20 = Config.Bind("Color Presets", "20", "Emerald|#50C878", "");
            configPreset21 = Config.Bind("Color Presets", "21", "Kelly Green|#4CBB17", "");
            configPreset22 = Config.Bind("Color Presets", "22", "Peppermint|#2E8B57", "");
            configPreset23 = Config.Bind("Color Presets", "23", "Jungle|#29AB87", "");
            configPreset24 = Config.Bind("Color Presets", "24", "Hook Green|#49796B", "");
            configPreset25 = Config.Bind("Color Presets", "25", "Robin Egg|#00CCCC", "");
            configPreset26 = Config.Bind("Color Presets", "26", "Myrtle Green|#317873", "");
            configPreset27 = Config.Bind("Color Presets", "27", "Midnight Green|#004953", "");
            configPreset28 = Config.Bind("Color Presets", "28", "Blue Green|#0D98BA", "");
            configPreset29 = Config.Bind("Color Presets", "29", "Sea Green|#20B2AA", "");
            configPreset30 = Config.Bind("Color Presets", "30", "Teal|#008080", "");
            configPreset31 = Config.Bind("Color Presets", "31", "Tiffany Blue|#81D8D0", "");
            configPreset32 = Config.Bind("Color Presets", "32", "Azure|#007FFF", "");
            configPreset33 = Config.Bind("Color Presets", "33", "Capri Blue|#00BFFF", "");
            configPreset34 = Config.Bind("Color Presets", "34", "Baby Blue|#89CFF0", "");
            configPreset35 = Config.Bind("Color Presets", "35", "Zaffre Blue|#0014A8", "");
            configPreset36 = Config.Bind("Color Presets", "36", "True Blue|#2D68C4", "");
            configPreset37 = Config.Bind("Color Presets", "37", "Honolulu Blue|#0076B6", "");
            configPreset38 = Config.Bind("Color Presets", "38", "Powder Blue|#9EB9D4", "");
            configPreset39 = Config.Bind("Color Presets", "39", "Periwinkle|#CCCCFF", "");
            configPreset40 = Config.Bind("Color Presets", "40", "Maya Blue|#73C2FB", "");
            configPreset41 = Config.Bind("Color Presets", "41", "Deep Blue|#003262", "");
            configPreset42 = Config.Bind("Color Presets", "42", "Pale Purple|#B284BE", "");
            configPreset43 = Config.Bind("Color Presets", "43", "Amethyst|#9966CC", "");
            configPreset44 = Config.Bind("Color Presets", "44", "Byzantium|#702963", "");
            configPreset45 = Config.Bind("Color Presets", "45", "Grape|#6F2DA8", "");
            configPreset46 = Config.Bind("Color Presets", "46", "Lavender|#B57EDC", "");
            configPreset47 = Config.Bind("Color Presets", "47", "Plum|#880085", "");
            configPreset48 = Config.Bind("Color Presets", "48", "Tropical Indigo|#9683EC", "");
            configPreset49 = Config.Bind("Color Presets", "49", "Tekhelet|#512888", "");
            configPreset50 = Config.Bind("Color Presets", "50", "Mauve|#9A4EAE", "");
            configPreset51 = Config.Bind("Color Presets", "51", "Mulberry|#C54B8C", "");
            configPreset52 = Config.Bind("Color Presets", "52", "Seashell|#FFF5EE", "");
            configPreset53 = Config.Bind("Color Presets", "53", "Vanilla|#F3E5AB", "");
            configPreset54 = Config.Bind("Color Presets", "54", "Cream|#FFFDD0", "");
            configPreset55 = Config.Bind("Color Presets", "55", "White|#FFFFFF", "");

            LoadSettings();

            // Apply Harmony patches (only the safe ones)
            Harmony.CreateAndPatchAll(typeof(CircletColorPicker), null);

            Logger.LogInfo($"Circlet Color Picker loaded!");
            Logger.LogInfo($"Next color: {primaryKey}+{nextKey}");
            Logger.LogInfo($"Previous color: {primaryKey}+{previousKey}");
        }

        void LoadSettings()
        {
            primaryKey = ParseKeyCode(configHotkeyPrimary.Value);
            nextKey = ParseKeyCode(configHotkeyNext.Value);
            previousKey = ParseKeyCode(configHotkeyPrevious.Value);

            presets.Clear();
            List<ConfigEntry<string>> allPresets = new List<ConfigEntry<string>>
            {
                configPreset1, configPreset2, configPreset3, configPreset4, configPreset5,
                configPreset6, configPreset7, configPreset8, configPreset9, configPreset10,
                configPreset11, configPreset12, configPreset13, configPreset14, configPreset15,
                configPreset16, configPreset17, configPreset18, configPreset19, configPreset20,
                configPreset21, configPreset22, configPreset23, configPreset24, configPreset25,
                configPreset26, configPreset27, configPreset28, configPreset29, configPreset30,
                configPreset31, configPreset32, configPreset33, configPreset34, configPreset35,
                configPreset36, configPreset37, configPreset38, configPreset39, configPreset40,
                configPreset41, configPreset42, configPreset43, configPreset44, configPreset45,
                configPreset46, configPreset47, configPreset48, configPreset49, configPreset50,
                configPreset51, configPreset52, configPreset53, configPreset54, configPreset55
            };

            foreach (var preset in allPresets)
            {
                if (preset != null)
                {
                    string[] parts = preset.Value.Split('|');
                    if (parts.Length == 2)
                    {
                        ColorPreset colorPreset = new ColorPreset
                        {
                            Name = parts[0],
                            Color = HexToColor(parts[1])
                        };
                        presets.Add(colorPreset);
                    }
                }
            }

            Logger.LogInfo($"Loaded {presets.Count} color presets");
        }

        void Update()
        {
            Player player = Player.m_localPlayer;
            if (player == null) return;

            ItemDrop.ItemData circlet = FindEquippedCirclet(player);

            // Check for next color hotkey
            if (UnityEngine.Input.GetKey(primaryKey) && UnityEngine.Input.GetKeyDown(nextKey))
            {
                if (circlet != null)
                {
                    CycleColor(circlet, 1); // Forward
                    UpdateCircletLight(player, circlet);
                }
                else
                {
                    MessageHud.instance?.ShowMessage(MessageHud.MessageType.Center,
                        "No circlet equipped!");
                }
            }

            // Check for previous color hotkey
            if (UnityEngine.Input.GetKey(primaryKey) && UnityEngine.Input.GetKeyDown(previousKey))
            {
                if (circlet != null)
                {
                    CycleColor(circlet, -1); // Backward
                    UpdateCircletLight(player, circlet);
                }
                else
                {
                    MessageHud.instance?.ShowMessage(MessageHud.MessageType.Center,
                        "No circlet equipped!");
                }
            }
        }

        void CycleColor(ItemDrop.ItemData circlet, int direction)
        {
            if (presets.Count == 0)
            {
                Logger.LogWarning("No color presets available!");
                return;
            }

            // Cycle to next/previous preset
            currentPresetIndex = (currentPresetIndex + direction + presets.Count) % presets.Count;
            ColorPreset preset = presets[currentPresetIndex];

            // Set and save color
            SetCircletColor(circlet, preset.Color);

            // Show message
            MessageHud.instance?.ShowMessage(MessageHud.MessageType.Center,
                $"Circlet Color: {preset.Name}");
        }

        void SetCircletColor(ItemDrop.ItemData circlet, Color color)
        {
            string id = GetCircletID(circlet);
            circletColors[id] = color;

            // Save to item custom data
            if (circlet.m_customData == null)
                circlet.m_customData = new Dictionary<string, string>();

            circlet.m_customData["circlet_color"] = $"{color.r:F4},{color.g:F4},{color.b:F4}";
        }

        Color GetCircletColor(ItemDrop.ItemData circlet)
        {
            // Try to load from item custom data
            if (circlet.m_customData != null && circlet.m_customData.ContainsKey("circlet_color"))
            {
                string[] parts = circlet.m_customData["circlet_color"].Split(',');
                if (parts.Length == 3)
                {
                    float.TryParse(parts[0], out float r);
                    float.TryParse(parts[1], out float g);
                    float.TryParse(parts[2], out float b);
                    return new Color(r, g, b);
                }
            }

            // Try to get from stored colors
            string id = GetCircletID(circlet);
            if (circletColors.ContainsKey(id))
                return circletColors[id];

            // Default color
            return Color.white;
        }

        ItemDrop.ItemData FindEquippedCirclet(Player player)
        {
            if (player?.GetInventory() == null) return null;

            List<ItemDrop.ItemData> equipped = player.GetInventory().GetEquippedItems();
            if (equipped == null) return null;

            return equipped.Find(item => item.m_shared.m_name == "$item_helmet_dverger");
        }

        void UpdateCircletLight(Player player, ItemDrop.ItemData circlet)
        {
            // Stop any previous color enforcer
            if (colorEnforcer != null)
            {
                StopCoroutine(colorEnforcer);
            }

            // Start a new one that will continuously enforce our color
            colorEnforcer = StartCoroutine(EnforceColorContinuously(player, circlet));
        }

        // Continuously enforce the color every frame
        IEnumerator EnforceColorContinuously(Player player, ItemDrop.ItemData circlet)
        {
            Color targetColor = GetCircletColor(circlet);
            string circletId = GetCircletID(circlet);

            // Enforce for 10 seconds, then check every second
            float elapsed = 0f;

            while (elapsed < 10f)
            {
                // Check if player still has this circlet equipped
                ItemDrop.ItemData currentCirclet = FindEquippedCirclet(player);
                if (currentCirclet == null || GetCircletID(currentCirclet) != circletId)
                {
                    yield break; // Stop if circlet is unequipped
                }

                // Force the color on all lights
                Light[] lights = player.GetComponentsInChildren<Light>();
                foreach (Light light in lights)
                {
                    // Only change if it's not already our color (to avoid fighting)
                    if (Vector4.Distance(new Vector4(light.color.r, light.color.g, light.color.b, 1),
                                         new Vector4(targetColor.r, targetColor.g, targetColor.b, 1)) > 0.01f)
                    {
                        light.color = targetColor;
                    }
                }

                elapsed += Time.deltaTime;
                yield return null; // Wait one frame
            }

            // After 10 seconds, check once per second
            while (true)
            {
                yield return new WaitForSeconds(1f);

                ItemDrop.ItemData currentCirclet = FindEquippedCirclet(player);
                if (currentCirclet == null || GetCircletID(currentCirclet) != circletId)
                {
                    yield break;
                }

                Light[] lights = player.GetComponentsInChildren<Light>();
                foreach (Light light in lights)
                {
                    if (Vector4.Distance(new Vector4(light.color.r, light.color.g, light.color.b, 1),
                                         new Vector4(targetColor.r, targetColor.g, targetColor.b, 1)) > 0.01f)
                    {
                        light.color = targetColor;
                    }
                }
            }
        }

        string GetCircletID(ItemDrop.ItemData item)
        {
            if (item.m_crafterID != 0L)
                return $"{item.m_crafterID}_{item.m_crafterName}";
            return $"{item.GetHashCode()}";
        }

        Color HexToColor(string hex)
        {
            hex = hex.Replace("#", "");
            if (hex.Length != 6) return Color.white;

            try
            {
                int r = System.Convert.ToInt32(hex.Substring(0, 2), 16);
                int g = System.Convert.ToInt32(hex.Substring(2, 2), 16);
                int b = System.Convert.ToInt32(hex.Substring(4, 2), 16);
                return new Color(r / 255f, g / 255f, b / 255f);
            }
            catch
            {
                Logger.LogWarning($"Invalid hex color: #{hex}");
                return Color.white;
            }
        }

        KeyCode ParseKeyCode(string keyString)
        {
            try
            {
                return (KeyCode)System.Enum.Parse(typeof(KeyCode), keyString, true);
            }
            catch
            {
                Logger.LogWarning($"Invalid key code: {keyString}, using default");
                return KeyCode.None;
            }
        }

        // Harmony patch to apply color when circlet is equipped
        [HarmonyPatch(typeof(VisEquipment), "SetHelmetEquipped")]
        [HarmonyPostfix]
        static void ApplyColorOnEquip(VisEquipment __instance, int hash)
        {
            if (instance == null) return;

            Player player = __instance.GetComponent<Player>();
            if (player == null) return;

            ItemDrop.ItemData circlet = player.GetInventory()?.GetEquippedItems()?.Find(
                item => item.m_shared.m_name == "$item_helmet_dverger"
            );

            if (circlet != null)
            {
                instance.StartCoroutine(ApplyColorDelayed(player, circlet));
            }
        }

        static IEnumerator ApplyColorDelayed(Player player, ItemDrop.ItemData circlet)
        {
            // Wait for CircletExtended to set up the light
            yield return new WaitForSeconds(0.5f);

            // Get saved color
            Color color = Color.white;
            if (circlet.m_customData != null && circlet.m_customData.ContainsKey("circlet_color"))
            {
                string[] parts = circlet.m_customData["circlet_color"].Split(',');
                if (parts.Length == 3)
                {
                    float.TryParse(parts[0], out float r);
                    float.TryParse(parts[1], out float g);
                    float.TryParse(parts[2], out float b);
                    color = new Color(r, g, b);
                }
            }

            // Apply to all lights and start continuous enforcement
            VisEquipment visEquip = player.GetComponent<VisEquipment>();
            if (visEquip != null)
            {
                Light[] lights = visEquip.GetComponentsInChildren<Light>();
                foreach (Light light in lights)
                {
                    light.color = color;
                }

                // Start the continuous enforcer
                if (instance != null && instance.colorEnforcer != null)
                {
                    instance.StopCoroutine(instance.colorEnforcer);
                }
                instance.colorEnforcer = instance.StartCoroutine(instance.EnforceColorContinuously(player, circlet));
            }
        }

        // Harmony patch to apply color when circlet is placed on item stand
        [HarmonyPatch(typeof(ItemStand), "UpdateAttach")]
        [HarmonyPostfix]
        static void ApplyColorOnItemStand(ItemStand __instance)
        {
            if (instance == null) return;

            // Get the ItemDrop component from the item stand
            ItemDrop itemDrop = __instance.GetComponentInChildren<ItemDrop>();
            if (itemDrop == null || itemDrop.m_itemData == null) return;

            ItemDrop.ItemData attachedItem = itemDrop.m_itemData;

            // Check if it's a circlet
            if (attachedItem.m_shared.m_name == "$item_helmet_dverger")
            {
                instance.StartCoroutine(ApplyColorToItemStandDelayed(__instance, attachedItem));
            }
        }

        static IEnumerator ApplyColorToItemStandDelayed(ItemStand itemStand, ItemDrop.ItemData circlet)
        {
            // Wait for CircletExtended to set up the light
            yield return new WaitForSeconds(0.5f);

            // Get saved color from item custom data
            Color color = Color.white;
            if (circlet.m_customData != null && circlet.m_customData.ContainsKey("circlet_color"))
            {
                string[] parts = circlet.m_customData["circlet_color"].Split(',');
                if (parts.Length == 3)
                {
                    float.TryParse(parts[0], out float r);
                    float.TryParse(parts[1], out float g);
                    float.TryParse(parts[2], out float b);
                    color = new Color(r, g, b);
                }
            }

            // Apply color to all lights in the item stand's attached item
            Light[] lights = itemStand.GetComponentsInChildren<Light>();
            foreach (Light light in lights)
            {
                light.color = color;
            }

            // Continue enforcing the color for item stands
            if (instance != null)
            {
                instance.StartCoroutine(EnforceItemStandColorContinuously(itemStand, circlet, color));
            }
        }

        static IEnumerator EnforceItemStandColorContinuously(ItemStand itemStand, ItemDrop.ItemData circlet, Color targetColor)
        {
            // Continuously check and enforce color every second
            while (itemStand != null)
            {
                yield return new WaitForSeconds(1f);

                // Check if the circlet is still attached
                ItemDrop itemDrop = itemStand.GetComponentInChildren<ItemDrop>();
                if (itemDrop == null || itemDrop.m_itemData == null || itemDrop.m_itemData != circlet)
                {
                    yield break; // Stop if item was removed
                }

                // Re-apply color to all lights
                Light[] lights = itemStand.GetComponentsInChildren<Light>();
                foreach (Light light in lights)
                {
                    if (light != null && Vector4.Distance(
                        new Vector4(light.color.r, light.color.g, light.color.b, 1),
                        new Vector4(targetColor.r, targetColor.g, targetColor.b, 1)) > 0.01f)
                    {
                        light.color = targetColor;
                    }
                }
            }
        }

        class ColorPreset
        {
            public string Name;
            public Color Color;
        }
    }
}