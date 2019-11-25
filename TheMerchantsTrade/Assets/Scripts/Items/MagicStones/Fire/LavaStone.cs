public class LavaStone : MagicStone
{
	public override StoneType StoneType { get; }
	public override Rarity Rarity { get; }
	public override string Description { get; }
	public override string CustomName { get; }

	public LavaStone(int basePrice) : base(basePrice)
	{
		StoneType = StoneType.Fire;

		Rarity = TradeHandler.GetRandomRarity(3);

		Description = "A magic stone infused with volcanic torment.\n" +
			"Maybe a Fire Wizard can find some use for it.";

		CustomName = "Lava Stone";
	}
}
