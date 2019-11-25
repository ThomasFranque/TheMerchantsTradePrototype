public abstract class WarItem : Collectable
{
	public abstract WarGearType GearType { get; }
	public override ItemCategory Category { get; }
	public override int BasePrice { get; }


	public WarItem(int basePrice)
	{
		Category = ItemCategory.WarGear;
		BasePrice = basePrice;
	}
}
