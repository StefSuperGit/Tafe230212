using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class CurrencyConversionCalculator : Page
    {
        public CurrencyConversionCalculator()
        {
            this.InitializeComponent();
        }

		/** creates an 2 dimension array with conversion rate where indexes represent currency as follows:
		USD 0
		EUR 1
		P	2
		R	3
		**/
		static double[,] conversionTable()
		{
			double[,] array =
			{
				{1, 0.85189982, 0.72872436, 74.257327},
				{1.1739732, 1, 0.8556672,87.00755 },
				{1.371907, 1.1686692, 1, 101.68635 },
				{0.011492628, 0.013492774, 0.0098339397, 1}
			};
			return array;
		}

		/** Creates a 2 dimension array with the currency symbol on the first row and currency name on the second row
		 */
		static string[,] conversionName()
		{
			string[,] nameCurrency =
			{
				{ "$", "€", "£", "₹" },
				{ "US Dollars", "Euros", "British Pounds", "Indian Rupees" }
			};
			return nameCurrency;
		}


		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			double fromAmount;
			double toAmount;
			string stringBuilder;


			// Loads array of currency
			double[,] currencyArray = conversionTable();

			string[,] nameCurrency = conversionName();

			// Saves the amount entered into local variable
			try
			{
				fromAmount = double.Parse(amountTextBox.Text);
			}
			catch
			{
				
				var dialogMessage = new MessageDialog("Error! Please enter a valid amount with no letters or symbols! ");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				return;
			}

			// Multiples amount by selected currency rate
			toAmount = fromAmount * currencyArray[fromCurrencyBox.SelectedIndex, toCurrencyBox.SelectedIndex];


			stringBuilder = fromAmount.ToString() + " " + nameCurrency[1, fromCurrencyBox.SelectedIndex].ToString() + "=";
			selectedCurrencyTextBlock.Text = stringBuilder;

			stringBuilder = nameCurrency[0, toCurrencyBox.SelectedIndex].ToString() + toAmount.ToString() + " " + nameCurrency[1, toCurrencyBox.SelectedIndex].ToString();
			destinationCurrencyTextBlock.Text = stringBuilder;

			stringBuilder = nameCurrency[0, fromCurrencyBox.SelectedIndex].ToString() + "1" + " = " + currencyArray[fromCurrencyBox.SelectedIndex, toCurrencyBox.SelectedIndex] + " " + nameCurrency[1, toCurrencyBox.SelectedIndex].ToString();
			comparrsionTextBlock.Text = stringBuilder;

			stringBuilder = nameCurrency[0, toCurrencyBox.SelectedIndex].ToString() + "1" + " = " + currencyArray[toCurrencyBox.SelectedIndex, fromCurrencyBox.SelectedIndex] + " " + nameCurrency[1, fromCurrencyBox.SelectedIndex].ToString();
			comparrisonReversedTextBlock.Text = stringBuilder;

		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Menu));
		}
	}
}
