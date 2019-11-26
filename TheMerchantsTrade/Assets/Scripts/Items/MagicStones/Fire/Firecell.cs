public class Firecell : MagicStone
{
	public override StoneType StoneType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public Firecell(int basePrice) : base(basePrice)
	{
		StoneType = StoneType.Fire;

		Rarity = TradeHandler.GetRandomRarity(3);

		Description = "A seemingly innactive magical fire stone.\n" +
			"Maybe a Fire Wizard can find some use for it.";

		CustomName = "Firecell Stone";
	}
}
