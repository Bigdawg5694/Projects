namespace GradedExercise5
{
    /// <summary>
    /// An employer-sponsored account
    /// </summary>
    public class EmployerSponsoredAccount : MutualFund
    {
		#region Contructor

		public EmployerSponsoredAccount(float deposit)
			   : base(deposit)
		{
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Provides balance with account type caption
		/// </summary>
		/// <returns>balance with caption</returns>
		public override string ToString()
        {
            return "Employer-Sponsored Account Balance: " + balance;
        }

		/// <summary>
		/// Doubles money being added before adjusting balance
		/// </summary>
		public override void AddMoney(float amount)
		{
			amount *= 2;
			amount -= amount * ServiceChargePercent;
			balance += amount;
		}
		#endregion
	}
}
