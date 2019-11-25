public abstract class WarItem : Collectable
{
	public abstract WarGearType GearType { get; }
	public override ItemCategory Category { get; }


	public WarItem(int basePrice) : base(basePrice)
	{
		Category = ItemCategory.WarGear;
	}
}
