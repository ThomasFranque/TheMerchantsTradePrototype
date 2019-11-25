public class DivineBow : WarItem
{
	public override WarGearType GearType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public DivineBow(int basePrice) : base(basePrice)
	{
		GearType = WarGearType.Bow;

		Rarity = TradeHandler.GetRandomRarity(3);

		Description = "A bow strung by a godess of the hunt herself.\n" +
			"Maybe an Archer can find some use for it.";

		CustomName = "Divine Bow";
	}
}
