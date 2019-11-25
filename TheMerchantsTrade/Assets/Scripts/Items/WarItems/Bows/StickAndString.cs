public class StickAndString : WarItem
{
	public override WarGearType GearType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public StickAndString(int basePrice) : base(basePrice)
	{
		GearType = WarGearType.Bow;

		Rarity = TradeHandler.GetRandomRarity(1);

		Description = "A poorly-made, rudimentary 'bow'.\n" +
			"Maybe an Archer can find some use for it.";

		CustomName = "Stick and String";
	}
}
