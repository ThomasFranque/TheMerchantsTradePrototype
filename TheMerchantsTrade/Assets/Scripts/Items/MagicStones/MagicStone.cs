public abstract class MagicStone : Collectable
{
	public abstract StoneType StoneType { get; }
	public override ItemCategory Category { get; }
	public override int BasePrice { get; }


	public MagicStone(int basePrice)
	{
		Category = ItemCategory.MagicStone;
		BasePrice = basePrice;
	}
}
