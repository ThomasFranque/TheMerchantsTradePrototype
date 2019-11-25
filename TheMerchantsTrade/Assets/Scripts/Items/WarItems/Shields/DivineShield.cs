public class DivineShield : WarItem
{
	public override WarGearType GearType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public DivineShield(int basePrice) : base(basePrice)
	{
		GearType = WarGearType.Shield;

		Rarity = TradeHandler.GetRandomRarity(3);

		Description = "A glowing shield, blessed by an elder god.\n" +
			"Maybe a Paladin can find some use for it.";

		CustomName = "Divine Shield";
	}
}
