namespace Minecraft
{
    public class Blocks
    {
        
        public enum BlockType // all block types we can have
        {
            NONE,
            DIRT,
            COBBLESTONE,
            LOG,
            PLANKS,
            CHEST,
            CRAFTING_TABLE,
            FURNACE,
            SAND,
            //Implementation de crafts pour le bonus
            STONE_BUTTON,
            DOOR,
            WOODEN_STAIR,
            COBBLESTONE_STAIR,
            //IMPLEMENTATION DE DROP POUR LES MOBS
            MEAT,
            GUN_POWDER, 
            ROTTEN_FLESH
        }
        
       

        public BlockType type;  // the type of block
        public int count;       // the number of blocks in the stack
    
        public Blocks(BlockType type, int count)
        {
            this.type = type;
            this.count = count;
        }

    }
}