public abstract class MagicStone : Collectable
{
	public abstract StoneType StoneType { get; }
	public override ItemCategory Category { get; }

	public MagicStone(int basePrice) : base (basePrice)
	{
		Category = ItemCategory.MagicStone;
	}
}
