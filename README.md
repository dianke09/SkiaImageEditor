# SkiaImageEditor

已将用户请求中的控件改写为 `.NET 10 + WinForms` 示例工程（`src/MyFirstRep.WinForms`）。

## 说明

由于当前环境无法直连 GitHub 仓库 `https://github.com/dianke09/myfirstrep`（网络返回 403），本仓库提供的是通用控件改写模板与演示窗体，包括：

- `RoundedButton`
- `PlaceholderTextBox`
- `ToggleSwitch`

可在连通外网后对照原仓库逐个微调样式和行为。

## 运行

```bash
dotnet build SkiaImageEditor.sln
dotnet run --project src/MyFirstRep.WinForms/MyFirstRep.WinForms.csproj
```
