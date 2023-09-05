using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MortgageCalculator : Page
	{
		// Initialise variables
		private double principalBorrow;
		private double years;
		private double months;
		private double yearlyInterestRate;
		private double monthlyInterestRate;

		// Stefan Exclusive
		private double periods;

		private double monthlyRepayment;
		

		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			principalBorrow = double.Parse(principalBorrowTextBox.Text);
			years = double.Parse(yearsTextBox.Text);
			months = double.Parse(monthsTextBox.Text);
			yearlyInterestRate = double.Parse(yearlyInterestRateTextBox.Text) / 100d;
			monthlyInterestRate = yearlyInterestRate / 12d;

			periods = years * 12 + months;

			monthlyRepayment = principalBorrow * (monthlyInterestRate * (Math.Pow((1+monthlyInterestRate), periods)) / ((Math.Pow((1+monthlyInterestRate), periods)) - 1));

			// Increase Monthly Rate ready for display
			monthlyInterestRate = monthlyInterestRate * 100d;

			monthlyInterestRateTextBox.Text = monthlyInterestRate.ToString("N4");
			monthlyRepaymentTextBox.Text = monthlyRepayment.ToString("N2");
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Menu));
		}
	}
}
