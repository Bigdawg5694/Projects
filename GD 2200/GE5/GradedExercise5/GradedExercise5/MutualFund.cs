namespace GradedExercise5
{
    /// <summary>
    /// A mutual fund
    /// </summary>
    public class MutualFund : InvestmentAccount
    {
        protected float ServiceChargePercent = 0.01f;

        #region Contructor

        public MutualFund(float deposit)
               : base(deposit)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Updates the balance by adding 6%
        /// </summary>
        public override void UpdateBalance()
        {
            balance += balance * 0.06f;
		}

        /// <summary>
        /// Provides balance with account type caption
        /// </summary>
        /// <returns>balance with caption</returns>
        public override string ToString()
        {
            return "Mutual Fund Balance: " + balance;
        }

		/// <summary>
		/// Adds money from mutual fund into account
		/// </summary>
		/// <param name="amount" > amount to add</param>
		public override void AddMoney(float amount)
		{
            amount -= amount * ServiceChargePercent;
            balance += amount;
		}

		#endregion
	}
}
