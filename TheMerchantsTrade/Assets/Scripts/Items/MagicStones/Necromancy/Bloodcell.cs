public class Bloodcell : MagicStone
{
	public override StoneType StoneType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public Bloodcell(int basePrice) : base(basePrice)
	{
		StoneType = StoneType.Necromancy;

		Rarity = TradeHandler.GetRandomRarity(1);

		Description = "A magic stone infused with a minor imp's blood.\n" +
			"Maybe a Necromancer can find some use for it.";

		CustomName = "Bloodcell Stone";
	}
}
