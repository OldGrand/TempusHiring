using System.ComponentModel.DataAnnotations;

namespace TempusHiring.DataAccess.EntityEnums
{
    public enum PaymentMethod
    {
        [Display(Name="Cash")]
        Cash,
        [Display(Name = "Check")]
        Checks,
        [Display(Name = "Debit cards")]
        DebitCards,
        [Display(Name = "Credit cards")]
        CreditCards,
        [Display(Name = "Mobile payment")]
        MobilePayments,
        [Display(Name = "Bank transfer")]
        ElectronicBankTransfers
    }
}
