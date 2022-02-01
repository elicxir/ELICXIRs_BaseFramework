# ELICXIRs_BaseFramework
An improved version of ELICXIRs_BaseFramework_OneScene to handle multiple scenes.

Copyright (c) 2022 ELICXIR

Released under the MIT license

https://opensource.org/licenses/mit-license.php

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
#### Miscs
役に立つと思われる以下の機能を導入してあります。
- EnumIndex:配列にEnumの名前を付けてわかりやすくする。
    https://goropocha.hatenablog.com/entry/2021/02/11/232617
