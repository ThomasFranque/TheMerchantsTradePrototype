public class Necrozima : MagicStone
{
	public override StoneType StoneType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public Necrozima(int basePrice) : base(basePrice)
	{
		StoneType = StoneType.Necromancy;

		Rarity = TradeHandler.GetRandomRarity(2);

		Description = "A magic stone infused with a demon's essence.\n" +
			"Maybe a Necromancer can find some use for it.";

		CustomName = "Necrozima Stone";
	}
}
