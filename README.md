﻿# ELICXIRs_BaseFramework
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

特にTemplate配下のprefabを更新してしまうなどの場合が起こり得るため注意してください。(後述する手順に従うとよいでしょう)

Assets/BaseSystem_Customize配下にはGameManager.csとGameEnums.csなどのファイルが追加されます。これらのファイルは自分のゲームに合わせてカスタマイズしてください。




## 利用方法について
以下の作業はすべてAssets/BaseSystem配下以外の場所で行ってください。

### 1.GameManagerSceneの作成
GameManagerSceneはゲーム全体のマネージメントを行うシーンのことです。常に読み込まれており、ステート遷移やサウンド管理を行っています。

シーンを作成します。(ここではGameManagerSceneとします)

Assets/BaseSystem/Assets/TemplateのGameManager.prefabを作成したシーン上に配置。

buildsettingsでシーンを登録してください。その際、indexは0になるようにしてください。

### 2.Sceneの作成

シーンを追加する際の手順は以下の通りです。

シーンを作成します。(ここではTestSceneとします)

GameEnums.csのgamesceneに対応する値を追加してください(TestSceneとします)

buildsettingsでシーンを登録してください。その際、gamesceneの順番にシーンのindexをそろえてください。

Scene_Executer.csを継承した管理クラスを作成してください。

シーン上にgameObjectを作成し、そこに管理クラスをアタッチすれば準備完了です(Objectの名前が変わります。)

### 3.Stateの追加

シーン依存ではないGameStateを追加する際には以下の手順に従ってください。

GameStateExecuter.csを継承した管理クラスを作る。管理クラスの名前は追加したGameState名と一致させてください。

gameObjectを作成し(名前は追加したGameState名と一致させてください)、管理クラスをアタッチしてGameManagerSceneに置いたGameManager.prefabのGameStateExecuters配下に配置する。










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

### ピクセルフォント「マルモニカ」Font Asset

※TextMeshProを導入してください。

患者長ひっく様が配布しているピクセルフォント「マルモニカ」を TextMeshProで



ピクセルフォント「マルモニカ」は加工・改変・再配布が可能ですが、加工・改変・再配布後であっても著作権は患者長ひっく様が保有しています。使用の際には利用規約に目を通してください。


http://www17.plala.or.jp/xxxxxxx/00ff/

フォント制作・著作
© 2018-2021 hicc 患者長ひっく



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
