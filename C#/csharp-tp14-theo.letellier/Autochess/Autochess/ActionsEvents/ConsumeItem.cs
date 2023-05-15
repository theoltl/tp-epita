namespace Autochess
{
    public partial class ActionEvent
    {
        public partial class ConsumeItem
        {
            private Item Item;

            public override void InitId()
            {
                Item = Program.ItemBank.GetItem(ItemName);
            }
        }
    }
}
