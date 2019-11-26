public class LifeStone : MagicStone
{
	public override StoneType StoneType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public LifeStone(int basePrice) : base(basePrice)
	{
		StoneType = StoneType.Necromancy;

		Rarity = TradeHandler.GetRandomRarity(3);

		Description = "A magic stone infused by an elder demon's spell.\n" +
			"Maybe a Necromancer can find some use for it.";

		CustomName = "Life Stone";
	}
}
