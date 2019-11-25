public class Naturezima : MagicStone
{
	public override StoneType StoneType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public Naturezima(int basePrice) : base(basePrice)
	{
		StoneType = StoneType.Nature;

		Rarity = TradeHandler.GetRandomRarity(2);

		Description = "A magic stone infused with a forest spirit.\n" +
			"Maybe a Nature Wizard can find some use for it.";

		CustomName = "Naturezima Stone";
	}
}
