# MAUI-Blazor-Hybrid-Windows-Sample.1

Windows向け MAUI + Blazor Hybrid アプリケーションのサンプル実装です。オフライン（サーバー無し）で動作し、SQLiteを使用したローカルデータ管理を実現します。

## 主な機能

- **SQLiteデータベース**: 初回起動時に自動作成される組み込みデータベース
- **カテゴリ管理**: カテゴリの追加・編集・削除機能
- **アイテム管理**: アイテムの追加・編集・削除機能（カテゴリとの関連付け）
- **Excel定義ファイル**: DataModel.xlsxからのデータベーススキーマ定義の読み込み
- **エクスポート/インポート**: データベースのZIP形式でのバックアップと復元
- **レポート機能**: IReportServiceインターフェースによる拡張可能なレポート機能（ダミー実装付き）

## 必要な環境

### 開発環境
- **Windows 10/11** (version 1809以降)
- **.NET 8.0 SDK** または **.NET 9.0 SDK**
- **Visual Studio 2022** (version 17.8以降) または **Visual Studio Code**
  - ワークロード: .NET Multi-platform App UI development
- **Windows SDK** (10.0.17763.0以降)

### 必要なパッケージ
プロジェクトには以下のNuGetパッケージが含まれています：
- Microsoft.Maui.Controls (8.0.90)
- Microsoft.AspNetCore.Components.WebView.Maui (8.0.90)
- Microsoft.EntityFrameworkCore.Sqlite (8.0.10)
- EPPlus (7.5.1) - Excel操作用

## セットアップ手順

### 1. リポジトリのクローン
```bash
git clone https://github.com/Iriya-Takekawa/MAUI-Blazor-Hybrid-Windows-Sample.1.git
cd MAUI-Blazor-Hybrid-Windows-Sample.1
```

### 2. ソリューションを開く
```bash
cd MauiBlazorApp
# Visual Studioで開く場合
start MauiBlazorApp.sln
```

または、Visual Studio Codeで開く場合：
```bash
code .
```

### 3. ビルドと実行

#### Visual Studio 2022の場合
1. ソリューションを開く
2. ビルド構成を「Debug」または「Release」に設定
3. ターゲットプラットフォームを「Windows Machine」に設定
4. F5キーまたは「デバッグの開始」をクリック

#### コマンドラインの場合
```bash
# Windows向けにビルド
dotnet build -f net8.0-windows10.0.19041.0

# Windows向けに実行
dotnet run -f net8.0.windows10.0.19041.0
```

## プロジェクト構成

```
MauiBlazorApp/
├── Components/              # Blazorコンポーネント
│   ├── Layout/             # レイアウトコンポーネント
│   │   ├── MainLayout.razor
│   │   └── NavMenu.razor
│   ├── Pages/              # ページコンポーネント
│   │   ├── Home.razor
│   │   ├── Categories.razor
│   │   ├── Items.razor
│   │   ├── ExportImport.razor
│   │   ├── Report.razor
│   │   └── Definition.razor
│   └── Routes.razor        # ルーティング定義
├── Data/                   # データアクセス層
│   └── AppDbContext.cs     # Entity Framework DbContext
├── Models/                 # データモデル
│   ├── Category.cs
│   └── Item.cs
├── Services/               # サービス層
│   ├── IReportService.cs
│   ├── DummyReportService.cs
│   ├── IExcelDefinitionService.cs
│   ├── ExcelDefinitionService.cs
│   ├── IDataExportImportService.cs
│   └── DataExportImportService.cs
├── Resources/              # リソースファイル
│   ├── Raw/
│   │   ├── DataModel.xlsx      # データベース定義ファイル
│   │   └── ReportTemplate.xlsx # レポートテンプレート
│   ├── Styles/
│   └── Fonts/
├── wwwroot/                # 静的ファイル
│   ├── css/
│   └── index.html
├── MauiProgram.cs          # アプリケーション起動設定
├── App.xaml / App.xaml.cs  # MAUIアプリケーション定義
└── MainPage.xaml           # メインページ（BlazorWebView）
```

## データ格納場所

### SQLiteデータベース
- **パス**: `FileSystem.AppDataDirectory/app.db`
- **Windows実際のパス例**: 
  ```
  C:\Users\[ユーザー名]\AppData\Local\Packages\[AppId]\LocalState\app.db
  ```

### エクスポートファイルの既定の場所
- **パス**: `Documents\MauiBlazorApp_Exports\`
- **Windows実際のパス例**: 
  ```
  C:\Users\[ユーザー名]\Documents\MauiBlazorApp_Exports\
  ```

## データベース設計

### Categoriesテーブル
| カラム名 | 型 | 説明 |
|---------|-----|------|
| Id | INTEGER (PK, AUTOINCREMENT) | 内部ID |
| Code | TEXT(50) | ビジネスキー（一意） |
| Name | TEXT(200) | カテゴリ名 |

### Itemsテーブル
| カラム名 | 型 | 説明 |
|---------|-----|------|
| Id | INTEGER (PK, AUTOINCREMENT) | 内部ID |
| Code | TEXT(50) | ビジネスキー（一意） |
| Name | TEXT(200) | アイテム名 |
| CategoryId | INTEGER (FK) | カテゴリID |
| Amount | DECIMAL(18,2) | 金額 |
| Note | TEXT(500) | 備考 |

## 使用方法

### 1. アイテムの追加
1. 左メニューから「Items」を選択
2. 「Add New Item」ボタンをクリック
3. フォームに情報を入力（カテゴリはドロップダウンから選択）
4. 「Save」ボタンをクリック

### 2. カテゴリの管理
1. 左メニューから「Categories」を選択
2. 「Add New Category」ボタンで新規追加
3. 各カテゴリの「Edit」「Delete」ボタンで編集・削除

### 3. データのエクスポート
1. 左メニューから「Export/Import」を選択
2. 「Export Now」ボタンをクリック
3. エクスポート先のパスにZIPファイルが作成される

### 4. データのインポート
1. 左メニューから「Export/Import」を選択
2. インポートするZIPファイルのフルパスを入力
3. 「Import Now」ボタンをクリック
4. アプリケーションを再起動して変更を反映

### 5. Excel定義の確認
1. 左メニューから「Excel Definition」を選択
2. DataModel.xlsxの内容が表示される

### 6. レポートテンプレートの確認
1. 左メニューから「Report」を選択
2. ReportTemplate.xlsxのパスと存在確認結果が表示される

## 拡張ポイント

### レポート機能の実装
`IReportService`インターフェースを実装することで、AS-ReportやSpreadsheetGearなどの実際のレポートエンジンに差し替えることができます。

```csharp
public interface IReportService
{
    string GetReportTemplatePath();
    bool ValidateReportTemplate();
}
```

`MauiProgram.cs`でサービス登録を変更：
```csharp
// 現在のダミー実装
builder.Services.AddSingleton<IReportService, DummyReportService>();

// 実装に差し替え
builder.Services.AddSingleton<IReportService, ActualReportService>();
```

### グリッドコンポーネントの差し替え
現在は標準の`<table>`要素を使用していますが、高機能なグリッドコンポーネント（例：Telerik UI for MAUI、Syncfusion、DevExpress）に差し替えることができます。

### Web版への展開
Entity Framework Coreを使用しているため、比較的容易にBlazor Server/WebAssemblyアプリケーションに移行できます。

## トラブルシューティング

### ビルドエラー: "Windows SDK not found"
- Visual Studio Installerから「Windows SDK」をインストールしてください

### データベースが作成されない
- アプリケーションを管理者権限で実行してみてください
- `FileSystem.AppDataDirectory`へのアクセス権限を確認してください

### Excelファイルが読み込めない
- `Resources/Raw/DataModel.xlsx`が正しく配置されているか確認
- ビルド時に`PreserveNewest`で出力されるように設定されているか確認

### インポートが失敗する
- ZIPファイルに`app.db`が含まれているか確認
- ファイルパスにスペースや特殊文字が含まれていないか確認

## ライセンス

このプロジェクトはサンプルコードとして提供されています。商用利用する場合は、使用しているライブラリ（特にEPPlus）のライセンスを確認してください。

## 貢献

プルリクエストを歓迎します。大きな変更の場合は、まずissueを開いて変更内容を議論してください。

## 関連リンク

- [.NET MAUI Documentation](https://docs.microsoft.com/dotnet/maui/)
- [Blazor Documentation](https://docs.microsoft.com/aspnet/core/blazor/)
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core/)
- [EPPlus Documentation](https://github.com/EPPlusSoftware/EPPlus)