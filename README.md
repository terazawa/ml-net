# ML.NET

* https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet
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


## ML.NET Get Started in 10 minutes

* Automated MLを使ってみるというチュートリアル
  * https://docs.microsoft.com/en-us/dotnet/machine-learning/automl-overview
  * 二値分類、多値分類、回帰
  * 将来的にはクラスタリング、リコメンド、ランキングなどにも対応予定

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

