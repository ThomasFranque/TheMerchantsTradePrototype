public class DepthStone : MagicStone
{
	public override StoneType StoneType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public DepthStone(int basePrice) : base(basePrice)
	{
		StoneType = StoneType.Water;

		Rarity = TradeHandler.GetRandomRarity(3);

		Description = "A magic stone infused with oceanic might.\n" +
			"Maybe a Water Wizard can find some use for it.";

		CustomName = "Depth Stone";
	}
}
