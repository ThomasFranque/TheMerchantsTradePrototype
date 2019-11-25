public class Moisterzima : MagicStone
{
	public override StoneType StoneType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public Moisterzima(int basePrice) : base(basePrice)
	{
		StoneType = StoneType.Water;

		Rarity = TradeHandler.GetRandomRarity(1);

		Description = "A magic stone infused with various droplets.\n" +
			"Maybe a Water Wizard can find some use for it.";

		CustomName = "Watercell Stone";
	}
}
