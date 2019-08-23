# [ML.NET](https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet)

* Get Started in 10 minutes
  * https://dotnet.microsoft.com/learn/ml-dotnet/get-started-tutorial/intro
  * https://docs.microsoft.com/en-us/dotnet/api/microsoft.ml.automl.binaryclassificationtrainer?view=automl-dotnet

## .NET Framework / .NET Core

* .NET Framework
* .NET Core
* .NET 5
  * https://devblogs.microsoft.com/dotnet/introducing-net-5/
  * ![](https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2019/05/dotnet5_platform.png)
  * ![](https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2019/05/dotnet_schedule.png)


## Get Started in 10 minutes

* Automated MLを使ってみるというチュートリアル
  * https://docs.microsoft.com/en-us/dotnet/machine-learning/automl-overview
  * 二値分類、多値分類、回帰
  * 将来的にはクラスタリング、リコメンド、ランキングなどにも対応予定

```tsv
Sentiment	SentimentText
1	  ==RUDE== Dude, you are rude upload that carl picture back, or else.
1	  == OK! ==  IM GOING TO VANDALIZE WILD ONES WIKI THEN!!!   
1	   Stop trolling, zapatancas, calling me a liar merely demonstartes that you arer Zapatancas. You may choose to chase every legitimate editor from this site and ignore me but I am an editor with a record that isnt 99% trolling and therefore my wishes are not to be completely ignored by a sockpuppet like yourself. The consensus is overwhelmingly against you and your trollin g lover Zapatancas,  
1	  ==You're cool==  You seem like a really cool guy... *bursts out laughing at sarcasm*.
1	 ::::: Why are you threatening me? I'm not being disruptive, its you who is being disruptive.   
1	  == hey waz up? ==  hey ummm... the fif four fifty one song... was the info inacurate?  did i spell something wrong? hmm... cause i don't think you have a right to delete ANYTHING that is accurate and that peple may want to read about fool. i don't like being pushed around especially by some little boy. got it?
0	 ::::::::::I'm not sure either. I think it has something to do with merely ahistorical vs being derived from pagan myths. Price does believe the latter, I'm not sure about other CMT proponents.   
0	" *::Your POV and propaganda pushing is dully noted. However listing interesting facts in a netral and unacusitory tone is not POV. You seem to be confusing Censorship with POV monitoring. I see nothing POV expressed in the listing of intersting facts. If you want to contribute more facts or edit wording of the cited fact to make them sound more netral then go ahead. No need to CENSOR interesting factual information. "
0	  == File:Hildebrandt-Greg and Tim.jpg listed for deletion == An image or media file that you uploaded or altered, File:Hildebrandt-Greg and Tim.jpg, has been listed at Wikipedia:Files for deletion. Please see the discussion to see why this is (you may have to search for the title of the image to find its entry), if you are interested in it not being deleted.     
0	  ::::::::This is a gross exaggeration. Nobody is setting a kangaroo court. There was a simple addition concerning the airline. It is the only one disputed here.   
```

```console
$ mlnet auto-train --task binary-classification --dataset "wikipedia-detox-250-line-data.tsv" --label-column-name "Sentiment" --max-exploration-time 10
```

* https://docs.microsoft.com/en-us/dotnet/machine-learning/reference/ml-net-cli-reference
* データセットの指定
  * データセットだけ指定するとCross Validation等勝手にやる
  * 自分でテストセットを分けることも可能
* ターゲットカラムの設定
  * カラム名またはインデックス番号で指定
* 使わないカラムの指定
* ![](https://docs.microsoft.com/en-us/dotnet/machine-learning/media/automate-training-with-cli/cli-high-level-process.png)

```csharp
// Data process configuration with pipeline data transformations 
var dataProcessPipeline = mlContext.Transforms.Text.FeaturizeText("SentimentText_tf", "SentimentText")
                          .Append(mlContext.Transforms.CopyColumns("Features", "SentimentText_tf"))
                          .Append(mlContext.Transforms.NormalizeMinMax("Features", "Features"))
                          .AppendCacheCheckpoint(mlContext);
// Set the training algorithm 
var trainer = mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression(new LbfgsLogisticRegressionBinaryTrainer.Options() { L2Regularization = 0.9264836f, L1Regularization = 0.1886002f, OptimizationTolerance = 1E-07f, HistorySize = 20, MaximumNumberOfIterations = 1149916419, InitialWeightsDiameter = 0.6599894f, DenseOptimizer = true, LabelColumnName = "Sentiment", FeatureColumnName = "Features" });
```
