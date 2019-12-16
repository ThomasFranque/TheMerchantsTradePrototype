public class Burnedzima : MagicStone
{
	public override StoneType StoneType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public Burnedzima(int basePrice) : base(basePrice)
	{
		StoneType = StoneType.Fire;

		Rarity = TradeHandler.GetRandomRarity(2);

		Description = "A magic stone infused with the roar of fire.\n" +
			"Maybe a Fire Wizard can find some use for it.";

		CustomName = "Burnedzima Stone";
	}
}
