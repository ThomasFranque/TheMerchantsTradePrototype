public class ShinySword : WarItem
{
	public override WarGearType GearType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public ShinySword(int basePrice) : base(basePrice)
	{
		GearType = WarGearType.Sword;

		Rarity = TradeHandler.GetRandomRarity(2);

		Description = "A shiny, carefully forged sword.\n" +
			"Maybe a Swordsman can find some use for it.";

		CustomName = "Shiny Sword";
	}
}
