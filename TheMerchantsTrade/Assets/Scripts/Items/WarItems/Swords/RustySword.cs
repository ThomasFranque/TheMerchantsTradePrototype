public class RustySword : WarItem
{
	public override WarGearType GearType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public RustySword(int basePrice) : base(basePrice)
	{
		GearType = WarGearType.Sword;

		Rarity = TradeHandler.GetRandomRarity(1);

		Description = "A plain old rusty sword.\n" +
			"Maybe a Swordsman can find some use for it.";

		CustomName = "Rusty Sword";
	}
}
