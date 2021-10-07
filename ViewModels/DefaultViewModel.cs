using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;

namespace TextClassification.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
		public string InputText { get; set; }
		public string Result { get; set; } = null;
		public decimal? Score { get; set; } = null;

		public void Predict()
		{
			var sampleData = new MLModel.ModelInput()
			{
				Col0 = InputText,
			};

			//Load model and predict output
			var output = MLModel.Predict(sampleData);

			if ((int)output.Prediction == 0)
			{
				Result = "Negative.";
			}
			else
			{
				Result = "Positive.";
			}

			Score = decimal.Round((decimal)(output.Score[(int)output.Prediction] * 100), 2);
		}
	}
}
