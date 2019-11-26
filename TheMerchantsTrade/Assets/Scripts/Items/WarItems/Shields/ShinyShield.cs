public class ShinyShield : WarItem
{
	public override WarGearType GearType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public ShinyShield(int basePrice) : base(basePrice)
	{
		GearType = WarGearType.Shield;

		Rarity = TradeHandler.GetRandomRarity(2);

		Description = "A well-maintained, shiny shield.\n" +
			"Maybe a Paladin can find some use for it.";

		CustomName = "Shiny Shield";
	}
}
