public class DivineSword : WarItem
{
	public override WarGearType GearType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public DivineSword(int basePrice) : base(basePrice)
	{
		GearType = WarGearType.Sword;

		Rarity = TradeHandler.GetRandomRarity(3);

		Description = "A sword blessed by an unknown deity.\n" +
			"Maybe a Swordsman can find some use for it.";

		CustomName = "Divine Sword";
	}
}
