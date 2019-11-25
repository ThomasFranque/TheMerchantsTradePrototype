public class WellCraftedBow : WarItem
{
	public override WarGearType GearType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public WellCraftedBow(int basePrice) : base(basePrice)
	{
		GearType = WarGearType.Bow;

		Rarity = TradeHandler.GetRandomRarity(2);

		Description = "A bow crafted with materials of good quality.\n" +
			"Maybe an Archer can find some use for it.";

		CustomName = "Well Crafted Bow";
	}
}
