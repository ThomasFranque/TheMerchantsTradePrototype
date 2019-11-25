public class Leafcell : MagicStone
{
	public override StoneType StoneType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public BurnedZima(int basePrice) : base(basePrice)
	{
		StoneType = StoneType.Nature;

		Rarity = TradeHandler.GetRandomRarity(1);

		Description = "A magic stone infused with minor natural powers.\n" +
			"Maybe a Nature Wizard can find some use for it.";

		CustomName = "Leafcell Stone";
	}
}
