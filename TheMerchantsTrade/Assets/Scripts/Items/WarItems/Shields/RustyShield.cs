public class RustyShield : WarItem
{
	public override WarGearType GearType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public RustyShield(int basePrice) : base(basePrice)
	{
		GearType = WarGearType.Shield;

		Rarity = TradeHandler.GetRandomRarity(1);

		Description = "A decrepit, old rusty shield.\n" +
			"Maybe a Paladin can find some use for it.";

		CustomName = "Rusty Shield";
	}
}
