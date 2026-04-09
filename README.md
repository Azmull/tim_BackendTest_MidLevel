## 技術環境
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / LocalDB
- Swagger / Swashbuckle
- Visual Studio 2022

## 專案架構
```text
tim_BackendTest_MidLevel
├─ Controllers
│  └─ MyOfficeAcpdController.cs
├─ Dtos
│  ├─ MyOfficeAcpdCreateRequestDto.cs
│  ├─ MyOfficeAcpdUpdateRequestDto.cs
│  └─ MyOfficeAcpdResponseDto.cs
├─ Models
│  ├─ MyOfficeAcpd.cs
│  └─ Myoffice_ACPDContext.cs
├─ Program.cs
├─ appsettings.json
└─ README.md
```

### 架構說明
- `Controllers/`：API 端點與 CRUD 邏輯
- `Dtos/`：API 請求與回應模型
- `Models/`：資料表 Entity 與 `DbContext`
- `Program.cs`：服務註冊、資料庫連線、Swagger 設定
- `appsettings.json`：資料庫連線字串設定

## 執行步驟

### 1. 開啟專案
使用 `Visual Studio 2022` 開啟專案。

### 2. 準備資料庫
請先在 SQL Server / LocalDB 建立或還原資料庫：
- 資料庫名稱：`Myoffice_ACPD`

並確認包含資料表：
- `MyOffice_ACPD`

### 3. 設定連線字串
修改 `tim_BackendTest_MidLevel/appsettings.json`：

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\ProjectModels;Database=Myoffice_ACPD;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> 若使用其他 SQL Server instance，請自行修改 `Server`。

### 4. 執行專案
按 `F5` 啟動專案。

### 5. 開啟 Swagger
啟動後可由首頁自動導向 Swagger

## 資料庫設定
- 資料庫名稱：`Myoffice_ACPD`
- 資料表名稱：`MyOffice_ACPD`
- 主鍵：`ACPD_SID`
- 主鍵產生方式：由程式於新增資料時自動產生唯一 `ACPD_SID`

## API 清單
- `GET /api/myofficeacpd`
- `GET /api/myofficeacpd/{id}`
- `POST /api/myofficeacpd`
- `PUT /api/myofficeacpd/{id}`
- `DELETE /api/myofficeacpd/{id}`

## Swagger 測試 JSON

### `POST /api/myofficeacpd`
```json
{
  "acpdCname": "王小明",
  "acpdEname": "Wang",
  "acpdSname": "Tim",
  "acpdEmail": "tim@example.com",
  "acpdStatus": 1,
  "acpdStop": false,
  "acpdStopMemo": "",
  "acpdLoginId": "tim001",
  "acpdLoginPwd": "P@ssw0rd",
  "acpdMemo": "swagger create test",
  "acpdNowId": "SYSTEM"
}
```

### `PUT /api/myofficeacpd/{id}`
```json
{
  "acpdCname": "王小明-更新",
  "acpdEname": "Wang Updated",
  "acpdSname": "Tim",
  "acpdEmail": "tim.updated@example.com",
  "acpdStatus": 1,
  "acpdStop": false,
  "acpdStopMemo": "",
  "acpdLoginId": "tim001",
  "acpdLoginPwd": "P@ssw0rd123",
  "acpdMemo": "swagger update test",
  "acpdUpdid": "SYSTEM"
}
```

> `GET` 與 `DELETE` 為 RESTful API，無 request body，請直接使用路由參數測試。

## HTTP Status Code 設計
- `200 OK`：查詢或更新成功
- `201 Created`：新增成功
- `204 No Content`：刪除成功
- `400 Bad Request`：輸入資料錯誤
- `404 Not Found`：查無資料
- `500 Internal Server Error`：系統錯誤

## Repository URL
- `https://github.com/Azmull/tim_BackendTest_MidLevel`
