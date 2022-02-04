# ELICXIRs_BaseFramework
An improved version of ELICXIRs_BaseFramework_OneScene to handle multiple scenes.

Copyright (c) 2022 ELICXIR

Released under the MIT license

https://opensource.org/licenses/mit-license.php

## 導入方法について
ELICXIRs_BaseFramework(以下「当機能」)を導入する方法は以下の通りです。

### 1.導入したいUnityProjectをgithubで管理する
githubでこれから作成するunityのprojectを管理できるようにしましょう。

- UnityHubでNewProjectで新しいプロジェクトのフォルダを作成する
- 作成したフォルダ全体を管理するgithubのリポジトリを作成する

### 2.当機能の導入
当機能をsubmoduleとして導入します。

https://github.com/elicxir/batchfiles
に従って導入してください。

Asset配下にBaseSystemというフォルダが作成されるため競合しないようにしてください。

Assets/BaseSystem配下のファイルを変更するとupdateが失敗することがあります。その時はAssets/BaseSystemとAssets/BaseSystem_Customizeを削除し、gitmoduleからこのプロジェクトの情報を消した後初めからやり直してください。

Assets/BaseSystem_Customize配下にはGameManager.csとGameEnums.csのファイルが追加されます。この二つのファイルは自分の作るゲームに合わせて書き換えてください。_


## 利用方法について

### 1.GameManagerの作成
Assets/BaseSystem_Customize配下にGameManager.csがあるためこれを使ってください。

### 





### 特殊stateについて

以下のgamestateは事前に用途が割り当てられており、ユーザー側から変更することはできません。

- Undefined
- Scene
- Loading

#### Undefined
初期化処理などに使われる「未定義」の状態です。ゲーム開始後は基本的にこの状態になることはありません。

#### Scene
読み込んだシーンにおいてある"Scene_Executer"を継承したスクリプトを扱うことができます。

これを利用することでシーンごとに異なる処理を行うことができます。例えばアクションゲームでステージごとにシーンを分けてSceneで扱うことによりステージ固有の処理なども含めて統一的に扱うことができるようになるでしょう。(そのうちわかりやすいデモを作ります。)

#### Loading
シーンのローディングが完了していないときにScene状態に移行しようとするとLoadingが呼ばれます。シーンのロードが完了すると自動でそのシーンに移行します。

### Sceneの指定について
列挙型のgamesceneを用いてゲーム中に使用するシーンを1:1対応させています。スクリプト上ではgamesceneを用いてシーンの移行を実装できます。

Build Settings の Scenes In Builds に各gamesceneに対応するシーンを順番通りに登録してください。

GameManagerSceneは変更しないことをお勧めします。

### 初期状態について




---
## その他役に立つ機能の紹介

### バッチファイル
#### add_basesystem.bat
 
このフレームワークをsubmoduleとして導入できます。(Asset配下のBaseSystemフォルダにこのリポジトリのAsset配下が導入されます。)

#### update.bat

submoduleの更新


### Testクラス(Test.cs)
デバッグ用の設定ができます。

#### ShowLog
以下のLogを表示するかのフラグ


#### Log
UnityのDebug.Log()に表示のオンオフ切り替えをつけました

#### 

### Miscs
役に立つと思われる以下の機能を導入してあります。
- EnumIndex:配列にEnumの名前を付けてわかりやすくする。
    https://goropocha.hatenablog.com/entry/2021/02/11/232617
