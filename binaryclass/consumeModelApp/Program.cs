using System;
using SampleBinaryClassification.Model.DataModels;
using Microsoft.ML;

namespace consumeModelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumeModel();
        }

        public static void ConsumeModel()
        {
            MLContext mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load("../SampleBinaryClassification/SampleBinaryClassification.Model/MLModel.zip", out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
            var input = new ModelInput();
            Console.WriteLine("Enter your comments");
            //input.SentimentText = "That is rude";
            input.SentimentText = Console.ReadLine();
            ModelOutput result = predEngine.Predict(input);
            Console.WriteLine($"Text: {input.SentimentText} | Prediction: {(result.Prediction ? "Toxic" : "Non-toxic")} sentiment");
        }
    }
}
