namespace VendingMachineApp.src
{
    /// <summary>
    ///     Enum representation of all possible states of the Vending Machine
    /// </summary>
    public enum VENDING_MACHINE_STATE
    {
        INSERT_COINS,
        EXACT_CHANGE_ONLY,
        DISPLAY_TOTAL,
        PURCHASE_COMPLETED,
        PRICE_CHECK,
        SOLD_OUT
    }
}
