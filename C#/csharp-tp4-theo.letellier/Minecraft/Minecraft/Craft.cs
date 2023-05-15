namespace Minecraft
{
    public class Craft
    {
        public enum CraftType // all block types we can have
        {
            WOODEN_BUTTON,
            STONE_BUTTON,
            DOOR,
            STICK,
            WOODEN_STAIR,
            COBBLESTONE_STAIR,
        }

        public CraftType type;      // the type of block
        public int count;       // the number of blocks in the stack
    
        public Craft(CraftType type, int count)
        {
            this.type = type;
            this.count = count;
        }
    }
}