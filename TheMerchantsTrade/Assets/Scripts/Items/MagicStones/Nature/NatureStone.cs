public class NatureStone : MagicStone
{
	public override StoneType StoneType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public NatureStone(int basePrice) : base(basePrice)
	{
		StoneType = StoneType.Nature;

		Rarity = TradeHandler.GetRandomRarity(3);

		Description = "A magic stone infused with Nature's call.\n" +
			"Maybe a Nature Wizard can find some use for it.";

		CustomName = "Nature Stone";
	}
}
